using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace assignment1_2
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        List<DTO> masterRows = null;
        private int nextId = 0;
        private int configurationNumber = 0;
        Relationship relationship = new Relationship();
        RichTextBox[] richTextBoxes = new RichTextBox[100];

        public Form1()
        {
            InitializeComponent();
            loadConfigurationFromXml();

            this.richTextBoxes[0] = this.richTextBox1;
            this.richTextBoxes[1] = this.richTextBox2;
            this.richTextBoxes[2] = this.richTextBox3;
            this.richTextBoxes[3] = this.richTextBox4;
            this.richTextBoxes[4] = this.richTextBox5;
            this.richTextBoxes[5] = this.richTextBox6;
            this.richTextBoxes[6] = this.richTextBox7;
            this.richTextBoxes[7] = this.richTextBox8;

            for (int i = 0; i < 8; i++)
            {
                richTextBoxes[i].Hide();
            }

            this.sqlConnection = new SqlConnection(relationship.connectionString);
            SqlDataAdapter sqlData = new SqlDataAdapter(relationship.selectMaster, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            this.Master.DataSource = dataTable;
            this.masterRows = dataTable.AsEnumerable()
               .Select(property => new DTO(property[0].ToString(), property[1].ToString())).ToList();
            sqlConnection.Open();
            SqlCommand comm = new SqlCommand(relationship.selectMaxId, sqlConnection);
            Int32 count = (Int32)comm.ExecuteScalar();
            this.nextId = count + 1;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.Out.WriteLine("starting app..");
            
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private void loadConfigurationFromXml()
        {
            XmlDocument configuration = new XmlDocument();
            configuration.Load("configuration.xml");
            var configurationNumberString = configuration.SelectSingleNode("root/relationship_number").InnerText;
            var configurationNumber = int.Parse(configurationNumberString);
            var relationshipNode = configuration.SelectNodes("root/relationship").Item(configurationNumber);

            //for the given relationship, we create a new Relationship object which we use
            //to store the queries from the xml
            relationship.connectionString = relationshipNode.SelectSingleNode("connection").InnerText;
            relationship.name = relationshipNode.SelectSingleNode("name").InnerText;
            
            
            //master zone of the relationship
            relationship.masterName = relationshipNode.SelectSingleNode("master/name").InnerText;
            relationship.selectMaster = relationshipNode.SelectSingleNode("master/select/query").InnerText;

            //slave zone on the relationship
            relationship.slaveName = relationshipNode.SelectSingleNode("slave/name").InnerText;

            relationship.selectMaxId = relationshipNode.SelectSingleNode("slave/maxId/query").InnerText;

            relationship.attributes = Int32.Parse(relationshipNode.SelectSingleNode("slave/attributes").InnerText);

            relationship.selectSlave = relationshipNode.SelectSingleNode("slave/select/query").InnerText;

            relationship.insertSlave = relationshipNode.SelectSingleNode("slave/insert/query").InnerText;
            relationship.insertSlaveParams = Int32.Parse(relationshipNode.SelectSingleNode("slave/insert/numberOfParams").InnerText);

            relationship.updateSlave = relationshipNode.SelectSingleNode("slave/update/query").InnerText;
            relationship.updateSlaveParams = Int32.Parse(relationshipNode.SelectSingleNode("slave/update/numberOfParams").InnerText);

            relationship.deleteSlave = relationshipNode.SelectSingleNode("slave/delete/query").InnerText;
            relationship.deleteSlaveParams = Int32.Parse(relationshipNode.SelectSingleNode("slave/delete/numberOfParams").InnerText);
        }

        private void Subreddit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fill_posts_table();
            for (int i = 0; i < 8; i++)
            {
                if (i < relationship.attributes)
                {
                    richTextBoxes[i].Show();
                }
                else
                {
                    richTextBoxes[i].Hide();
                }
            }
        }

        private void fill_posts_table()
        {
            String id = this.Master.SelectedRows[0].Cells[0].Value.ToString();
            SqlDataAdapter sqlData =
                new SqlDataAdapter(String.Format(relationship.selectSlave, id), sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            this.Slave.DataSource = dataTable;
        }

        private void Posts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < relationship.attributes; i++)
            {
                this.richTextBoxes[i].Text = this.Slave.SelectedRows[0].Cells[i].Value.ToString();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string string_command = relationship.insertSlave;

            String[] attributes_from_gui = new string[10];
            for(int i=0; i<relationship.attributes; i++)
            {
                attributes_from_gui[i] = this.richTextBoxes[i].Text;
            }
            
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(relationship.selectSlave, this.sqlConnection);
            sqlDataAdapter.InsertCommand = new SqlCommand(
                string.Format(string_command, attributes_from_gui), 
            this.sqlConnection);
            sqlDataAdapter.InsertCommand.Connection = this.sqlConnection;
            sqlDataAdapter.InsertCommand.ExecuteNonQuery();
            SqlCommand comm = new SqlCommand(string_command, sqlConnection);
            fill_posts_table();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string string_command = relationship.deleteSlave;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(relationship.selectSlave, this.sqlConnection);
            sqlDataAdapter.DeleteCommand = new SqlCommand(

                string.Format(string_command,
                    this.richTextBox1.Text
                )
            );
            //this.sqlConnection.Open();
            sqlDataAdapter.DeleteCommand.Connection = this.sqlConnection;
            sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
            SqlCommand comm = new SqlCommand(string_command, sqlConnection);
            fill_posts_table();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string string_command = relationship.updateSlave;
            String[] attributes_from_gui = new string[10];
            for (int i = 0; i < relationship.attributes; i++)
            {
                attributes_from_gui[i] = this.richTextBoxes[i].Text;
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(relationship.selectSlave, this.sqlConnection);
            sqlDataAdapter.UpdateCommand = new SqlCommand(
                string.Format(string_command, attributes_from_gui)
            ); ;
            //this.sqlConnection.Open();
            sqlDataAdapter.UpdateCommand.Connection = this.sqlConnection;
            sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
            SqlCommand comm = new SqlCommand(string_command, sqlConnection);
            fill_posts_table();
        }
    }
}
