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
    public partial class add_del_up_sup : Form
    {
        public add_del_up_sup()
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
            OracleConnection con = new OracleConnection(constr);
            OracleCommand cmd = new OracleCommand("sup_add", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = sup_id.Text;
            cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = name.Text;
            cmd.Parameters.Add("add", OracleDbType.Varchar2).Value = Position.Text;
            cmd.Parameters.Add("tp", OracleDbType.Int32).Value = price.Text;
            cmd.Parameters.Add("p", OracleDbType.Varchar2).Value = phone.Text;
            con.Open();
            if(sup_id.Text!="" && name.Text!="" && Position.Text!="" && price.Text!="" && phone.Text!="")
            {
            cmd.ExecuteNonQuery();
                MessageBox.Show("Done supplier adding");
            }
            else
            {
                MessageBox.Show("Please insert all field correctly");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("sup_amount_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Int32).Value = sup_id.Text;
                cmd.Parameters.Add("t1", OracleDbType.Varchar2).Value = textBox1.Text;
                cmd.Parameters.Add("t2", OracleDbType.Varchar2).Value = textBox2.Text;
                cmd.Parameters.Add("t3", OracleDbType.Varchar2).Value = textBox3.Text;
                cmd.Parameters.Add("t4", OracleDbType.Varchar2).Value = textBox4.Text;
                cmd.Parameters.Add("t5", OracleDbType.Varchar2).Value = textBox5.Text;
                cmd.Parameters.Add("t6", OracleDbType.Varchar2).Value = textBox6.Text;
                cmd.Parameters.Add("t7", OracleDbType.Varchar2).Value = textBox7.Text;
                cmd.Parameters.Add("t8", OracleDbType.Varchar2).Value = textBox8.Text;
                cmd.Parameters.Add("t9", OracleDbType.Varchar2).Value = textBox9.Text;
                cmd.Parameters.Add("t10", OracleDbType.Varchar2).Value = textBox10.Text;

                cmd.Parameters.Add("t11", OracleDbType.Int32).Value = textBox11.Text;
                cmd.Parameters.Add("t12", OracleDbType.Int32).Value = textBox12.Text;
                cmd.Parameters.Add("t13", OracleDbType.Int32).Value = textBox13.Text;
                cmd.Parameters.Add("t14", OracleDbType.Int32).Value = textBox14.Text;
                cmd.Parameters.Add("t15", OracleDbType.Int32).Value = textBox15.Text;
                cmd.Parameters.Add("t16", OracleDbType.Int32).Value = textBox16.Text;
                cmd.Parameters.Add("t17", OracleDbType.Int32).Value = textBox17.Text;
                cmd.Parameters.Add("t18", OracleDbType.Int32).Value = textBox18.Text;
                cmd.Parameters.Add("t19", OracleDbType.Int32).Value = textBox19.Text;
                cmd.Parameters.Add("t20", OracleDbType.Int32).Value = textBox20.Text;

                con.Open();

                cmd.ExecuteNonQuery();
                MessageBox.Show("Done suppling ammount adding");

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            adminhome a = new adminhome();
            a.Show();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("select * from sup_info order by sup_id asc", con);

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

        private void Get_details_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("get_details_sup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Int32).Value = sup_id.Text;
               
                // cmd.Parameters.Add("w_name", OracleDbType.Varchar2).Value = textBox1.Text;
                // cmd.Parameters["w_name"].Size = 20;
                cmd.Parameters.Add("name", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                
                cmd.Parameters.Add("add", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                
                cmd.Parameters.Add("tp", OracleDbType.Int32).Direction = ParameterDirection.Output;
                
                cmd.Parameters.Add("p", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                
                
                con.Open();
                cmd.ExecuteNonQuery();
                name.Text= cmd.Parameters["name"].Value.ToString();
                Position.Text = cmd.Parameters["add"].Value.ToString();
                price.Text = cmd.Parameters["tp"].Value.ToString();
                phone.Text= cmd.Parameters["p"].Value.ToString();
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
