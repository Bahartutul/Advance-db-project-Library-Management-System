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
    public partial class forget_pass : Form
    {
        public forget_pass()
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
        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                if(comboBox1.Text=="User")
                {
                    if(newpassword.Text==con_pass.Text)
                    {
                    OracleCommand cmd = new OracleCommand("pass_recovery.user_pass", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("id", OracleDbType.Int32).Value = userid.Text;
                    cmd.Parameters.Add("pin", OracleDbType.Varchar2).Value = pinbox.Text;
                    cmd.Parameters.Add("npass", OracleDbType.Varchar2).Value = newpassword.Text;
                    con.Open();
                    if(userid.Text !="" && pinbox.Text != "" && newpassword.Text !="" && con_pass.Text !="" )
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Done");
                    }
                        else
                    {
                        MessageBox.Show("Please filup all field...!!!");
                    }
                    }
                    else
                    {
                        MessageBox.Show("Newpassword and Confirm password does not match...!!!");
                    }
                }
                else if (comboBox1.Text == "Admin")
                {
                    if (newpassword.Text == con_pass.Text)
                    {
                        OracleCommand cmd = new OracleCommand("pass_recovery.admin_pass", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("id", OracleDbType.Int32).Value = userid.Text;
                        cmd.Parameters.Add("pin", OracleDbType.Varchar2).Value = pinbox.Text;
                        cmd.Parameters.Add("npass", OracleDbType.Varchar2).Value = newpassword.Text;
                        con.Open();
                        if (userid.Text != "" && pinbox.Text != "" && newpassword.Text != "" && con_pass.Text != "")
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Done");
                        }
                        else
                        {
                            MessageBox.Show("Please filup all field...!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Newpassword and Confirm password does not match...!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Please select your identity from combobox...!!!");
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            login l = new login();
            l.Show();
        }
    }
}
