namespace useerlogin
{
    partial class borrow
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
            this.components = new System.ComponentModel.Container();
            this.Clear = new System.Windows.Forms.Button();
            this.Set = new System.Windows.Forms.Button();
            this.num_of_day = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.borrowhistory = new System.Windows.Forms.Button();
            this.Borrorbook = new System.Windows.Forms.Button();
            this.Cdate = new System.Windows.Forms.Label();
            this.return_date = new System.Windows.Forms.TextBox();
            this.Return = new System.Windows.Forms.Label();
            this.Borrow_date = new System.Windows.Forms.TextBox();
            this.Bdate = new System.Windows.Forms.Label();
            this.book_id = new System.Windows.Forms.TextBox();
            this.bookid = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.White;
            this.Clear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.Location = new System.Drawing.Point(525, 218);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 35);
            this.Clear.TabIndex = 38;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Set
            // 
            this.Set.BackColor = System.Drawing.Color.White;
            this.Set.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Set.Location = new System.Drawing.Point(523, 82);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(75, 35);
            this.Set.TabIndex = 37;
            this.Set.Text = "Set";
            this.Set.UseVisualStyleBackColor = false;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // num_of_day
            // 
            this.num_of_day.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_of_day.Location = new System.Drawing.Point(172, 230);
            this.num_of_day.Multiline = true;
            this.num_of_day.Name = "num_of_day";
            this.num_of_day.Size = new System.Drawing.Size(143, 27);
            this.num_of_day.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "Num_Of_Day";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(231, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 37);
            this.label2.TabIndex = 34;
            this.label2.Text = "##Borrow Book##";
            // 
            // borrowhistory
            // 
            this.borrowhistory.BackColor = System.Drawing.Color.White;
            this.borrowhistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrowhistory.Location = new System.Drawing.Point(494, 176);
            this.borrowhistory.Name = "borrowhistory";
            this.borrowhistory.Size = new System.Drawing.Size(141, 35);
            this.borrowhistory.TabIndex = 33;
            this.borrowhistory.Text = "Borrow_History";
            this.borrowhistory.UseVisualStyleBackColor = false;
            this.borrowhistory.Click += new System.EventHandler(this.borrowhistory_Click);
            // 
            // Borrorbook
            // 
            this.Borrorbook.BackColor = System.Drawing.Color.White;
            this.Borrorbook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Borrorbook.Location = new System.Drawing.Point(524, 129);
            this.Borrorbook.Name = "Borrorbook";
            this.Borrorbook.Size = new System.Drawing.Size(75, 35);
            this.Borrorbook.TabIndex = 32;
            this.Borrorbook.Text = "Borrow";
            this.Borrorbook.UseVisualStyleBackColor = false;
            this.Borrorbook.Click += new System.EventHandler(this.Borrorbook_Click);
            // 
            // Cdate
            // 
            this.Cdate.AutoSize = true;
            this.Cdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cdate.Location = new System.Drawing.Point(594, 9);
            this.Cdate.Name = "Cdate";
            this.Cdate.Size = new System.Drawing.Size(110, 21);
            this.Cdate.TabIndex = 31;
            this.Cdate.Text = "Current_Date";
            // 
            // return_date
            // 
            this.return_date.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.return_date.Location = new System.Drawing.Point(173, 192);
            this.return_date.Multiline = true;
            this.return_date.Name = "return_date";
            this.return_date.ReadOnly = true;
            this.return_date.Size = new System.Drawing.Size(142, 27);
            this.return_date.TabIndex = 30;
            // 
            // Return
            // 
            this.Return.AutoSize = true;
            this.Return.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return.Location = new System.Drawing.Point(66, 196);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(104, 21);
            this.Return.TabIndex = 29;
            this.Return.Text = "Return_Date";
            // 
            // Borrow_date
            // 
            this.Borrow_date.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Borrow_date.Location = new System.Drawing.Point(172, 154);
            this.Borrow_date.Multiline = true;
            this.Borrow_date.Name = "Borrow_date";
            this.Borrow_date.ReadOnly = true;
            this.Borrow_date.Size = new System.Drawing.Size(143, 27);
            this.Borrow_date.TabIndex = 28;
            this.Borrow_date.TextChanged += new System.EventHandler(this.Borrow_date_TextChanged);
            // 
            // Bdate
            // 
            this.Bdate.AutoSize = true;
            this.Bdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bdate.Location = new System.Drawing.Point(61, 157);
            this.Bdate.Name = "Bdate";
            this.Bdate.Size = new System.Drawing.Size(108, 21);
            this.Bdate.TabIndex = 27;
            this.Bdate.Text = "Borrow_Date";
            // 
            // book_id
            // 
            this.book_id.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.book_id.Location = new System.Drawing.Point(172, 113);
            this.book_id.Multiline = true;
            this.book_id.Name = "book_id";
            this.book_id.Size = new System.Drawing.Size(143, 27);
            this.book_id.TabIndex = 26;
            // 
            // bookid
            // 
            this.bookid.AutoSize = true;
            this.bookid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookid.Location = new System.Drawing.Point(98, 118);
            this.bookid.Name = "bookid";
            this.bookid.Size = new System.Drawing.Size(71, 21);
            this.bookid.TabIndex = 25;
            this.bookid.Text = "Book_Id";
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.White;
            this.back.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(576, 486);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(111, 39);
            this.back.TabIndex = 46;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(172, 69);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(143, 27);
            this.textBox1.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 47;
            this.label1.Text = "User_Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 486);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 21);
            this.label6.TabIndex = 50;
            this.label6.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 486);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 21);
            this.label7.TabIndex = 49;
            this.label7.Text = "Result_found:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(95, 275);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(543, 194);
            this.dataGridView1.TabIndex = 39;
            // 
            // borrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(733, 545);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Set);
            this.Controls.Add(this.num_of_day);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.borrowhistory);
            this.Controls.Add(this.Borrorbook);
            this.Controls.Add(this.Cdate);
            this.Controls.Add(this.return_date);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.Borrow_date);
            this.Controls.Add(this.Bdate);
            this.Controls.Add(this.book_id);
            this.Controls.Add(this.bookid);
            this.Name = "borrow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "borrow";
            this.Load += new System.EventHandler(this.borrow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Set;
        private System.Windows.Forms.TextBox num_of_day;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button borrowhistory;
        private System.Windows.Forms.Button Borrorbook;
        private System.Windows.Forms.Label Cdate;
        private System.Windows.Forms.TextBox return_date;
        private System.Windows.Forms.Label Return;
        private System.Windows.Forms.TextBox Borrow_date;
        private System.Windows.Forms.Label Bdate;
        private System.Windows.Forms.TextBox book_id;
        private System.Windows.Forms.Label bookid;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}