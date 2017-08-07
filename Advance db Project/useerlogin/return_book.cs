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
using Oracle.ManagedDataAccess.Types;

namespace useerlogin
{
    public partial class return_book : Form
    {
        public return_book()
        {
            InitializeComponent();
        }
        string constr = "Data Source=(DESCRIPTION =" +
"(ADDRESS = (PROTOCOL = TCP)(HOST = Server)(PORT = 1522))" +
"(CONNECT_DATA =" +
  "(SERVER = DEDICATED)" +
  "(SERVICE_NAME = XE)" +
")" +
"); User Id=system; Password=tiger";
        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            adminhome a = new adminhome();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd=new OracleCommand("book_return.get_details",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("u_id", OracleDbType.Int32).Value = user_id.Text;
                cmd.Parameters.Add("b_id", OracleDbType.Varchar2).Value = book_id.Text;
                cmd.Parameters["b_id"].Size = 20;
                
                cmd.Parameters.Add("b_d", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["b_d"].Size = 50;
                cmd.Parameters.Add("r_d", OracleDbType.Varchar2).Direction= ParameterDirection.Output;
                cmd.Parameters["r_d"].Size = 50;
               con.Open();
                cmd.ExecuteNonQuery();
                Borrow_date.Text = cmd.Parameters["b_d"].Value.ToString();
                return_date.Text = cmd.Parameters["r_d"].Value.ToString();
                con.Close();

               string s = Convert.ToDateTime(CDate.Text).ToShortDateString();
                string s1 = Convert.ToDateTime(return_date.Text).ToShortDateString();
                DateTime dt = Convert.ToDateTime(s).Date;
                DateTime dt1 = Convert.ToDateTime(s1).Date;
                if (dt > dt1)
                {
                    string diff = dt.Subtract(dt1).ToString("dd");
                    string a="5";
                    int i = Int32.Parse(diff);
                    int j = Int32.Parse(a);
                    int k = i * j;
                
                     string l = Convert.ToString(k);
                    fine.Text = l;
                }
                else
                {
                    fine.Text = "No fine";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void return_book_Load(object sender, EventArgs e)
        {
            DateTime idate = DateTime.Now;
            CDate.Text = idate.ToString();//("dd/MM/yyyy");
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            OracleConnection con = new OracleConnection(constr);
          
                if (comboBox2.Text == "Borrow")
                {
                    OracleCommand cmd = new OracleCommand("book_return.borrower_search", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("u_id", OracleDbType.Int32).Value = user_id_src.Text;
                    // cmd.Parameters["u_id"].Size = 20;
                    cmd.Parameters.Add("boorow_book", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    con.Open();
                    if (user_id_src.Text != "")
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(reader);

                        dataGridView1.DataSource = table;
                        count.Text = dataGridView1.Rows.Count.ToString();
                        con.Close();
                    }
                    else
                    {

                        MessageBox.Show("Please insert User_id in searching field...!!!");


                    }
                }
                else if (comboBox2.Text == "Return")
                {
                    OracleCommand cmd = new OracleCommand("book_return.returner_search", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("u_id", OracleDbType.Int32).Value = user_id_src.Text;
                    // cmd.Parameters["u_id"].Size = 20;
                    cmd.Parameters.Add("return_book", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    con.Open();
                    if (user_id_src.Text != "")
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(reader);

                        dataGridView1.DataSource = table;
                        count.Text = dataGridView1.Rows.Count.ToString();
                        con.Close();
                    }
                    else
                    {

                        MessageBox.Show("Please insert User_id in searching field...!!!");


                    }
                }
            
            else
            {

                MessageBox.Show("Please select your choice from combobox...!!!");

            }
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(constr);
            try
            {
                if (comboBox1.Text == "Borrow")
                {
                    string q1 = "select * from borrow_book";
                    OracleCommand cmd = new OracleCommand(q1, con);
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                    count.Text = dataTable.Rows.Count.ToString();
                }
                if (comboBox1.Text == "Return")
                {
                    string q1 = "select * from return_book";
                    OracleCommand cmd = new OracleCommand(q1, con);
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                    count.Text = dataTable.Rows.Count.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void retrn_Click(object sender, EventArgs e)
        {
            try
            {
            OracleConnection con = new OracleConnection(constr);
            OracleCommand cmd = new OracleCommand("book_return.return_b", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("u_id", OracleDbType.Int32).Value = user_id.Text;
            cmd.Parameters.Add("b_id", OracleDbType.Varchar2).Value = book_id.Text;

                
           //cmd.Parameters["b_id"].Size = 20;
            cmd.Parameters.Add("b_d", OracleDbType.Varchar2).Value = Borrow_date.Text;
            //cmd.Parameters["b_d"].Size = 20;
            cmd.Parameters.Add("r_d", OracleDbType.Varchar2).Value = return_date.Text;
           // cmd.Parameters["r_d"].Size = 20;*/
            cmd.Parameters.Add("f", OracleDbType.Varchar2).Value = fine.Text;
            //cmd.Parameters["f"].Size = 20;
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book return successfully done...!!!");
            con.Close();
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }
    }

