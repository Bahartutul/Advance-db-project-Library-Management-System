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
    public partial class add_del_up_emp : Form
    {
        public add_del_up_emp()
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
        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("emp_add_del_up.add_emp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = emp_name.Text;
                cmd.Parameters.Add("pstn", OracleDbType.Varchar2).Value = Position.Text;
                cmd.Parameters.Add("sal", OracleDbType.Int32).Value = salary.Text;
                cmd.Parameters.Add("gen", OracleDbType.Varchar2).Value = Gender.Text;
                cmd.Parameters.Add("age", OracleDbType.Int32).Value = age.Text;
                cmd.Parameters.Add("add", OracleDbType.Varchar2).Value = address.Text;
                cmd.Parameters.Add("phn", OracleDbType.Varchar2).Value = phone.Text;

                con.Open();


                if (emp_name.Text != "" && Position.Text != "" && salary.Text != "" && Gender.Text != "" && age.Text != "" && address.Text != "" && phone.Text != "")
                {
                    if (phone.Text.Length == 11)
                    {
                        int value;
                        if (Int32.TryParse(age.Text, out value))
                        {
                            if (value > 17)
                            {
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("1Row added successfuly...!!!");
                                con.Close();
                            }
                            else
                            {
                                MessageBox.Show("Age must be greater then 17...!!!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phone number must be contain 11 digit...!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Show_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("select * from empinfo order by employee_id asc", con);

                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
                label6.Text = dataTable.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("emp_add_del_up.del_emp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Int32).Value = emp_id.Text;

                con.Open();
                if (emp_id.Text != "")
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("1 Row delete successfully");
                }

                else
                {
                    MessageBox.Show("Please insert book_id for delete");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Get_details_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("emp_add_del_up.get_emp_details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Int32).Value = emp_id.Text;
                cmd.Parameters["id"].Size = 20;
                // cmd.Parameters.Add("w_name", OracleDbType.Varchar2).Value = textBox1.Text;
                // cmd.Parameters["w_name"].Size = 20;
                cmd.Parameters.Add("name", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["name"].Size = 20;
                cmd.Parameters.Add("pstn", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["pstn"].Size = 20;
                cmd.Parameters.Add("sal", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["sal"].Size = 20;
                cmd.Parameters.Add("gen", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["gen"].Size = 20;
                cmd.Parameters.Add("age", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["age"].Size = 20;
                cmd.Parameters.Add("add", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["add"].Size = 20;
                cmd.Parameters.Add("phn", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["phn"].Size = 20;
                con.Open();
                cmd.ExecuteNonQuery();
                emp_name.Text = cmd.Parameters["name"].Value.ToString();
                Position.Text = cmd.Parameters["pstn"].Value.ToString();
                salary.Text = cmd.Parameters["sal"].Value.ToString();
                Gender.Text = cmd.Parameters["gen"].Value.ToString();
                age.Text = cmd.Parameters["age"].Value.ToString();
                address.Text = cmd.Parameters["add"].Value.ToString();
                phone.Text= cmd.Parameters["phn"].Value.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("emp_add_del_up.up_emp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Int32).Value = emp_id.Text;
                cmd.Parameters["id"].Size = 20;
                cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = emp_name.Text;
                cmd.Parameters["name"].Size = 20;
                cmd.Parameters.Add("pstn", OracleDbType.Varchar2).Value = Position.Text;
                cmd.Parameters["pstn"].Size = 20;
                cmd.Parameters.Add("sal", OracleDbType.Int32).Value = salary.Text;
                cmd.Parameters["sal"].Size = 20;
                cmd.Parameters.Add("gen", OracleDbType.Varchar2).Value = Gender.Text;
                cmd.Parameters["gen"].Size = 20;
                cmd.Parameters.Add("a", OracleDbType.Int32).Value = age.Text;
                cmd.Parameters["a"].Size = 20;
                cmd.Parameters.Add("add", OracleDbType.Varchar2).Value = address.Text;
                cmd.Parameters["add"].Size = 20;
                cmd.Parameters.Add("phn", OracleDbType.Varchar2).Value = phone.Text;
                cmd.Parameters["phn"].Size = 20;

                con.Open();

                if (emp_name.Text != "" && Position.Text != "" && salary.Text != "" && Gender.Text != "" && age.Text != "" && address.Text != "" && phone.Text != "")
                {
                    if (phone.Text.Length == 11)
                    {
                        int value;
                        if (Int32.TryParse(age.Text, out value))
                        {
                            if (value > 17)
                            {
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("1Row update done successfully...!!!");
                                con.Close();
                            }
                            else
                            {
                                MessageBox.Show("Age must be greater then 17...!!!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phone number must be 11 character...!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Insert all field properly.....");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            emp_id.Clear();
            emp_name.Clear();
            Position.Clear();
            salary.Clear();
            Gender.Clear();
            age.Clear();
            address.Clear();
            phone.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            adminhome a = new adminhome();
            a.Show();
        }

        private void add_del_up_emp_Load(object sender, EventArgs e)
        {

        }
    }
}
