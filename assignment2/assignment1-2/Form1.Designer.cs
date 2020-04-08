namespace assignment1_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Subreddit = new System.Windows.Forms.DataGridView();
            this.Posts = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.richTextBox7 = new System.Windows.Forms.RichTextBox();
            this.richTextBox8 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize) (this.Subreddit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.Posts)).BeginInit();
            this.SuspendLayout();
            // 
            // Subreddit
            // 
            this.Subreddit.AccessibleName = "Subreddits";
            this.Subreddit.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Subreddit.Location = new System.Drawing.Point(12, 15);
            this.Subreddit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Subreddit.Name = "Subreddit";
            this.Subreddit.RowHeadersWidth = 51;
            this.Subreddit.RowTemplate.Height = 24;
            this.Subreddit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Subreddit.Size = new System.Drawing.Size(841, 494);
            this.Subreddit.TabIndex = 0;
            this.Subreddit.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.Subreddit_CellContentClick);
            // 
            // Posts
            // 
            this.Posts.AccessibleName = "Posts";
            this.Posts.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Posts.Location = new System.Drawing.Point(12, 516);
            this.Posts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Posts.Name = "Posts";
            this.Posts.RowHeadersWidth = 51;
            this.Posts.RowTemplate.Height = 24;
            this.Posts.Size = new System.Drawing.Size(841, 321);
            this.Posts.TabIndex = 1;
            this.Posts.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.Posts_CellContentClick);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(859, 675);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(135, 162);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "ADD";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(1000, 675);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(142, 162);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "DELETE";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(1148, 675);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(133, 162);
            this.UpdateButton.TabIndex = 4;
            this.UpdateButton.Text = "UPDATE";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(859, 15);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(422, 74);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(859, 98);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(422, 74);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(859, 180);
            this.richTextBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(422, 74);
            this.richTextBox3.TabIndex = 8;
            this.richTextBox3.Text = "";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(859, 262);
            this.richTextBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(422, 74);
            this.richTextBox4.TabIndex = 9;
            this.richTextBox4.Text = "";
            // 
            // richTextBox5
            // 
            this.richTextBox5.Location = new System.Drawing.Point(859, 345);
            this.richTextBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(422, 74);
            this.richTextBox5.TabIndex = 10;
            this.richTextBox5.Text = "";
            // 
            // richTextBox6
            // 
            this.richTextBox6.Location = new System.Drawing.Point(859, 428);
            this.richTextBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.Size = new System.Drawing.Size(422, 74);
            this.richTextBox6.TabIndex = 11;
            this.richTextBox6.Text = "";
            // 
            // richTextBox7
            // 
            this.richTextBox7.Location = new System.Drawing.Point(859, 510);
            this.richTextBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox7.Name = "richTextBox7";
            this.richTextBox7.Size = new System.Drawing.Size(422, 74);
            this.richTextBox7.TabIndex = 12;
            this.richTextBox7.Text = "";
            // 
            // richTextBox8
            // 
            this.richTextBox8.Location = new System.Drawing.Point(859, 592);
            this.richTextBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox8.Name = "richTextBox8";
            this.richTextBox8.Size = new System.Drawing.Size(422, 74);
            this.richTextBox8.TabIndex = 13;
            this.richTextBox8.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 846);
            this.Controls.Add(this.richTextBox8);
            this.Controls.Add(this.richTextBox7);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.Posts);
            this.Controls.Add(this.Subreddit);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize) (this.Subreddit)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.Posts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView Subreddit;
        private System.Windows.Forms.DataGridView Posts;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.RichTextBox richTextBox7;
        private System.Windows.Forms.RichTextBox richTextBox8;
    }
}

