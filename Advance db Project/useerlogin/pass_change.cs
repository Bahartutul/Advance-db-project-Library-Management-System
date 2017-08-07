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
    public partial class pass_change : Form
    {
        private string un;
        public string passname
        {
            get { return un; }
            set { un = value; }
        }
        public pass_change()
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
        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("pass_recovery.pass_change", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.Text;
                cmd.Parameters.Add("opass", OracleDbType.Varchar2).Value = Opass.Text;
                cmd.Parameters.Add("npass", OracleDbType.Varchar2).Value = Npass.Text;
                con.Open();
                if(id.Text !="" && Opass.Text !="" && Npass.Text !="" && Cpass.Text !="")
                {
                    if (Npass.Text == Cpass.Text)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password change correctly done...!!!");
                    }
                    else
                    {
                        MessageBox.Show("New password and Confirm password field does not match...!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Please fillup all the given field...!!!");
                }
                

           
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            
            userhome1 u = new userhome1();
            u.passname = id.Text;
            this.Close();
            u.Show();
        }

        private void pass_change_Load(object sender, EventArgs e)
        {
            id.Text = un;
        }
    }
}
