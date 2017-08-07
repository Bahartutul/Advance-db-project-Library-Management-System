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

    public partial class adminhome : Form
    {
        public adminhome()
        {
            InitializeComponent();
        }

        private void Add_Book_Click(object sender, EventArgs e)
        {
            this.Close();
            add_delete_update adu=new add_delete_update();
            adu.Show();
        }

        private void Show_Book_Details_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Book_Click(object sender, EventArgs e)
        {
            this.Close();
            add_delete_update adu = new add_delete_update();
            adu.Show();
        }

        private void Update_Book_Click(object sender, EventArgs e)
        {
            this.Close();
            add_delete_update adu = new add_delete_update();
            adu.Show();
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void previousbookdetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deletehistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void updatehistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            book_history u = new book_history();
            u.Show();
        }

        private void addDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            add_del_up_emp adue = new add_del_up_emp();
            adue.Show();
        }

        private void currentEmployeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            employee_info c = new employee_info();
            c.Show();
        }

        private void deleteinfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void updateinfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void borrowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            return_book r = new return_book();
            r.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            book_history b = new book_history();
            b.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
            login l = new login();
            l.Show();
        }

        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            user_info ui = new user_info();
            ui.Show();
        }

        private void supplierDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            add_del_up_sup a = new add_del_up_sup();
            a.Show();

        }
    }
}
