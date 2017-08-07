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
    public partial class sign_up : Form
    {
        public sign_up()
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
            OracleConnection con = new OracleConnection(constr);

            OracleCommand cmd = new OracleCommand("user_acc", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = uname.Text;
            cmd.Parameters.Add("pass", OracleDbType.Varchar2).Value = password.Text;
            cmd.Parameters.Add("add", OracleDbType.Varchar2).Value = address.Text;
            cmd.Parameters.Add("age", OracleDbType.Varchar2).Value = age.Text;
            cmd.Parameters.Add("gen", OracleDbType.Varchar2).Value = comboBox1.Text;
            cmd.Parameters.Add("phn", OracleDbType.Varchar2).Value = mnum.Text;
            cmd.Parameters.Add("sq", OracleDbType.Varchar2).Value = sp.Text;
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = ParameterDirection.Output;

            con.Open();
            if(uname.Text !="" && password.Text !="" && cpass.Text !="" && address.Text !="" && age.Text !="" && comboBox1.Text !=null && mnum.Text !="" && sp.Text !="")
            {
                if (mnum.Text.Length == 11)
                {
                    if (password.Text == cpass.Text)
                    {
                        if (sp.Text.Length < 6)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Sign up successfully done...!!!");
                            label10.Text = "Your Id is '" + cmd.Parameters["id"].Value.ToString() + "' , Pls remember it for Login...!!!";
                        }
                        else
                        {
                            MessageBox.Show("Sequrity pin maximum length 5 character/digit...!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password and confirm_password field does not match...!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Phone number must be contain 11 digit...!!!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all required field correctly...!!!");
            }

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            login l = new login();
            l.Show();
        }
    }
}
