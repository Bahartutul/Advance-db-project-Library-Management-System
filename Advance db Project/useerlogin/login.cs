using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace useerlogin
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

          
          

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        string constr = "Data Source=(DESCRIPTION =" +
"(ADDRESS = (PROTOCOL = TCP)(HOST = Server)(PORT = 1522))" +
"(CONNECT_DATA =" +
  "(SERVER = DEDICATED)" +
  "(SERVICE_NAME = XE)" +
")" +
"); User Id=system; Password=tiger";
        private void button1_Click(object sender, EventArgs e)
        {
          
            OracleConnection con = new OracleConnection(constr);
            try
            {
                if (comboBox1.Text == "User")
                {
                    string sql = "select count(*) from userinfo where user_id='" + textBox1.Text + "'and password='" + textBox2.Text + "'";

                    OracleDataAdapter adapter = new OracleDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    if (textBox1.Text != "" && textBox2.Text != "")
                    {

                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            this.Hide();

                            userhome1 u = new userhome1();
                            u.passname = textBox1.Text;
                            u.Show();

                        }




                        else
                        {
                            MessageBox.Show("Incorrect user_Id and password");
                        }
                    }


                    else
                    {
                        if (textBox1.Text == "" && textBox2.Text == "")
                        {
                            MessageBox.Show("User_Id & password both required");
                        }
                        if (textBox1.Text == "" && textBox2.Text != "")
                        {
                            MessageBox.Show("User_Id required");
                        }
                        if (textBox1.Text != "" && textBox2.Text == "")
                        {
                            MessageBox.Show("Password is required");
                        }


                    }
                }




                else if (comboBox1.Text == "Admin")
                {

                    string sql = "select count(*) from admininfo where id='" + textBox1.Text + "'and password='" + textBox2.Text + "'";

                    OracleDataAdapter adapter = new OracleDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    if (textBox1.Text != "" && textBox2.Text != "")
                    {

                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            this.Hide();

                            adminhome a = new adminhome();

                            a.Show();

                        }




                        else
                        {
                            MessageBox.Show("Incorrect Id and password");
                        }
                    }


                    else
                    {
                        if (textBox1.Text == "" && textBox2.Text == "")
                        {
                            MessageBox.Show("Id & password both required");
                        }
                        if (textBox1.Text == "" && textBox2.Text != "")
                        {
                            MessageBox.Show("Id required");
                        }
                        if (textBox1.Text != "" && textBox2.Text == "")
                        {
                            MessageBox.Show("Password is required");
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Select Login as from combobox...!!!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void admin_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminhome a = new adminhome();
            a.Show();
        }

        private void Sing_up_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            sign_up s = new sign_up();
            s.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            forget_pass f = new forget_pass();
            f.Show();
        }
    }
}
