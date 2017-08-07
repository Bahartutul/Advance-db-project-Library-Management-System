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
    public partial class employee_info : Form
    {
        public employee_info()
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                if (comboBox1.Text == "Recent Employee")
                {
                    OracleCommand cmd = new OracleCommand("select * from empinfo  order by employee_id asc", con);


                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                    label6.Text = dataTable.Rows.Count.ToString();
                }
                else if(comboBox1.Text== "Deleted Employee")
                {
                    OracleCommand cmd = new OracleCommand("select * from pre_emp_del_info  order by employee_id asc", con);


                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                    label6.Text = dataTable.Rows.Count.ToString();

                }
                else if(comboBox1.Text=="Updated Employee")
                {
                    OracleCommand cmd = new OracleCommand("select * from pre_emp_up_info  order by employee_id asc", con);


                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                    label6.Text = dataTable.Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show("Please select a field in combobox for which one you want to search...!!!"); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            adminhome a = new adminhome();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                if (comboBox1.Text == "Recent Employee")
                {
                    OracleCommand cmd = new OracleCommand("emp_search.search1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("INPUT", OracleDbType.Varchar2).Value = textBox1.Text;
                    cmd.Parameters["INPUT"].Size = 20;
                    cmd.Parameters.Add("empinfo", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    //  cmd.Parameters.Add("book_amount", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    con.Open();
                    if (textBox1.Text != "")
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(reader);

                        dataGridView1.DataSource = table;
                        label6.Text = dataGridView1.Rows.Count.ToString();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please insert value in searching field...!!!");
                    }
                }
                else if(comboBox1.Text=="Deleted Employee")
                {
                    OracleCommand cmd = new OracleCommand("emp_search.search_del", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("INPUT", OracleDbType.Varchar2).Value = textBox1.Text;
                    cmd.Parameters["INPUT"].Size = 20;
                    cmd.Parameters.Add("pre_emp_del_info", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    //  cmd.Parameters.Add("book_amount", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    con.Open();
                    if (textBox1.Text != "")
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(reader);

                        dataGridView1.DataSource = table;
                        label6.Text = dataGridView1.Rows.Count.ToString();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please insert value in searching field...!!!");
                    }
                }
                else if(comboBox1.Text=="Updated Employee")
                {
                    OracleCommand cmd = new OracleCommand("emp_search.search_up", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("INPUT", OracleDbType.Varchar2).Value = textBox1.Text;
                    cmd.Parameters["INPUT"].Size = 20;
                    cmd.Parameters.Add("pre_emp_up_info", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    //  cmd.Parameters.Add("book_amount", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    con.Open();
                    if (textBox1.Text != "")
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(reader);

                        dataGridView1.DataSource = table;
                        label6.Text = dataGridView1.Rows.Count.ToString();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please insert value in searching field...!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a field in combobox for which one you want to search...!!!"); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
