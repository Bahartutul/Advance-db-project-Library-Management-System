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
    public partial class userhome1 : Form
    {
        private string un;
       
        public string passname
        {
            get { return un; }
            set { un = value; }
        }
        public userhome1()
        {
            InitializeComponent();
          
        }

        private void userhome1_Load(object sender, EventArgs e)
        {
          //  searchdata(""); 
           
           
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
          
     
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("book_search.search1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("INPUT", OracleDbType.Varchar2).Value = textBox1.Text;
                cmd.Parameters["INPUT"].Size = 20;
                cmd.Parameters.Add("book_details", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                //  cmd.Parameters.Add("book_amount", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);

                dataGridView1.DataSource = table;
                label6.Text = dataGridView1.Rows.Count.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }

        private void borrow_Click(object sender, EventArgs e)
        {
            this.Close();
            borrow b = new borrow();
            b.passname = un;
            b.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
            login l = new login();
            l.Show();
        }

        private void change_pass_Click(object sender, EventArgs e)
        {
            this.Close();
            pass_change pc = new pass_change();
            pc.passname = un;
            pc.Show();
        }
            
        }

    }

