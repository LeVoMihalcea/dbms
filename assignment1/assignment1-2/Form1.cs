using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment1_2
{
    public partial class Form1 : Form
    {
        private static string connectionString =
                   @"Data Source=LAPTOP-LEO\SQLEXPRESS;Initial Catalog=Reddit2;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        List<DTO> subreddits = null;
        private int nextId = 0;

        public Form1()
        {
            InitializeComponent();
            SqlDataAdapter sqlData = new SqlDataAdapter("Select * from Subreddits", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            this.Subreddit.DataSource = dataTable;
            this.subreddits = dataTable.AsEnumerable()
               .Select(property => new DTO(property[0].ToString(), property[1].ToString())).ToList();
            sqlConnection.Open();
            SqlCommand comm = new SqlCommand("select max(PostId) from Posts", sqlConnection);
            Int32 count = (Int32)comm.ExecuteScalar();
            this.nextId = count + 1;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Subreddit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Subreddit.ReadOnly = true;
            this.Posts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Posts.ReadOnly = true;
            this.richTextBox1.Text = "PostId";
            this.richTextBox2.Text = "UserId";
            this.richTextBox3.Text = "PictureId";
            this.richTextBox4.Text = "SubredditId";
            this.richTextBox5.Text = "Title";
            this.richTextBox6.Text = "PostText";
            this.richTextBox7.Text = "Upvotes";
            this.richTextBox8.Text = "Downvotes";
            this.richTextBox1.GotFocus += (useless1, useless2) =>
            {
                if (this.richTextBox1.Text == "PostId")
                {
                    this.richTextBox1.Text = "";
                }
            };
            this.richTextBox2.GotFocus += (useless1, useless2) =>
            {
                if (this.richTextBox2.Text == "UserId")
                {
                    this.richTextBox2.Text = "";
                }
            };
            this.richTextBox3.GotFocus += (useless1, useless2) =>
            {
                if (this.richTextBox3.Text == "PictureId")
                {
                    this.richTextBox3.Text = "";
                }
            };
            this.richTextBox4.GotFocus += (useless1, useless2) =>
            {
                if (this.richTextBox4.Text == "SubredditId")
                {
                    this.richTextBox4.Text = "";
                }
            };
            this.richTextBox5.GotFocus += (useless1, useless2) =>
            {
                if (this.richTextBox5.Text == "Title")
                {
                    this.richTextBox5.Text = "";
                }
            };
            this.richTextBox6.GotFocus += (useless1, useless2) =>
            {
                if (this.richTextBox6.Text == "PostText")
                {
                    this.richTextBox6.Text = "";
                }
            };
            this.richTextBox7.GotFocus += (useless1, useless2) =>
            {
                if (this.richTextBox7.Text == "Upvotes")
                {
                    this.richTextBox7.Text = "";
                }
            };
            this.richTextBox8.GotFocus += (useless1, useless2) =>
            {
                if (this.richTextBox8.Text == "Downvotes")
                {
                    this.richTextBox8.Text = "";
                }
            };
        }

        private void Subreddit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fill_posts_table();
            this.richTextBox4.Text = this.Subreddit.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void fill_posts_table()
        {
            String id = this.Subreddit.SelectedRows[0].Cells[0].Value.ToString();
            SqlDataAdapter sqlData =
                new SqlDataAdapter("Select * from Posts where SubredditId = " + id, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            this.Posts.DataSource = dataTable;
        }

        private void Posts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String id = this.Posts.SelectedRows[0].Cells[0].Value.ToString();
            String userId = this.Posts.SelectedRows[0].Cells[1].Value.ToString();
            String pictureId = this.Posts.SelectedRows[0].Cells[2].Value.ToString();
            String subredditId = this.Posts.SelectedRows[0].Cells[3].Value.ToString();
            String title = this.Posts.SelectedRows[0].Cells[4].Value.ToString();
            String postText = this.Posts.SelectedRows[0].Cells[5].Value.ToString();
            String upvotes = this.Posts.SelectedRows[0].Cells[6].Value.ToString();
            String downvotes = this.Posts.SelectedRows[0].Cells[7].Value.ToString();

            this.richTextBox1.Text = id;
            this.richTextBox2.Text = userId;
            this.richTextBox3.Text = pictureId;
            this.richTextBox4.Text = subredditId;
            this.richTextBox5.Text = title;
            this.richTextBox6.Text = postText;
            this.richTextBox7.Text = upvotes;
            this.richTextBox8.Text = downvotes;
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string string_command = "insert Posts values ({0}, {1}, {2}, {3}, '{4}', '{5}', {6}, {7})";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Posts", this.sqlConnection);
            sqlDataAdapter.InsertCommand = new SqlCommand(

                string.Format(string_command, 
                    this.richTextBox1.Text, 
                    this.richTextBox2.Text, 
                    this.richTextBox3.Text, 
                    this.richTextBox4.Text, 
                    this.richTextBox5.Text, 
                    this.richTextBox6.Text, 
                    this.richTextBox7.Text,
                    this.richTextBox8.Text
                ), this.sqlConnection);
            sqlDataAdapter.InsertCommand.Connection = this.sqlConnection;
            //this.sqlConnection.Open();
            sqlDataAdapter.InsertCommand.ExecuteNonQuery();
            SqlCommand comm = new SqlCommand(string_command, sqlConnection);
            fill_posts_table();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string string_command = "delete from Posts where PostId = {0}";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Posts", this.sqlConnection);
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
            string string_command = "update Posts " +
                "set " +
                "UserId = {1}," +
                "PictureId = {2}," +
                "SubredditId = {3}," +
                "Title = '{4}'," +
                "PostText = '{5}'," +
                "Upvotes = {6}," +
                "Downvotes = {7}" +
                "where " +
                "PostId = {0} ";
            System.Console.WriteLine(string.Format(string_command,
                    this.richTextBox1.Text,
                    this.richTextBox2.Text,
                    this.richTextBox3.Text,
                    this.richTextBox4.Text,
                    this.richTextBox5.Text,
                    this.richTextBox6.Text,
                    this.richTextBox7.Text,
                    this.richTextBox8.Text
                ));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Posts", this.sqlConnection);
            sqlDataAdapter.UpdateCommand = new SqlCommand(

                string.Format(string_command,
                    this.richTextBox1.Text,
                    this.richTextBox2.Text,
                    this.richTextBox3.Text,
                    this.richTextBox4.Text,
                    this.richTextBox5.Text,
                    this.richTextBox6.Text,
                    this.richTextBox7.Text,
                    this.richTextBox8.Text
                )
           
            );
            //this.sqlConnection.Open();
            sqlDataAdapter.UpdateCommand.Connection = this.sqlConnection;
            sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
            SqlCommand comm = new SqlCommand(string_command, sqlConnection);
            fill_posts_table();
        }
    }
}
