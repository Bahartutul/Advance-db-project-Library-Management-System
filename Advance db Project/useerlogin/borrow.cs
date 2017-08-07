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
    public partial class borrow : Form
    {
        private string un;
        public string passname
        {
            get { return un; }
            set { un = value; }
        }
        
        short BookLoan;
        public borrow()
        {
            InitializeComponent();
        
            
            
        }

        private void back_Click(object sender, EventArgs e)
        {
            
            userhome1 u = new userhome1();
            u.passname = textBox1.Text;
            this.Close();
            u.Show();
            
        }

        private void borrow_Load(object sender, EventArgs e)
        {
            textBox1.Text = un;
            DateTime idate = DateTime.Now;
            Borrow_date.Text = idate.ToString("MM/dd/yyyy");//.ToString("MM/dd/yyyy");
            timer1.Start();
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime idate = DateTime.Now;
            Cdate.Text = idate.ToString("MM/dd/yyyy");//("/MM/yyyy");
            timer1.Start();
        }

        private void Set_Click(object sender, EventArgs e)
        {
            DateTime BookDueDate;
            DateTime idate = DateTime.Now;

            switch (num_of_day.Text)
            {
                case "0":
                    BookLoan = 0;
                    System.DateTime today = System.DateTime.Now;
                    System.TimeSpan duration = new System.TimeSpan(BookLoan, 0, 0, 0);
                    System.DateTime answear = today.Add(duration);
                    // return_back.Text = answear.ToShortDateString();
                    return_date.Text = answear.ToString("MM/dd/yyyy");//("dd/MM/yyyy");
                    // timer1.Start();

                    break;

                case "1":
                    BookLoan = 1;
                    System.DateTime today1 = System.DateTime.Now;
                    System.TimeSpan duration1 = new System.TimeSpan(BookLoan, 0, 0, 0);
                    System.DateTime answear1 = today1.Add(duration1);
                    //  return_back.Text = answear1.ToShortDateString();
                    return_date.Text = answear1.ToString("MM/dd/yyyy");//("dd/MM/yyyy");
                    break;

                case "2":
                    BookLoan = 2;
                    System.DateTime today2 = System.DateTime.Now;
                    System.TimeSpan duration2 = new System.TimeSpan(BookLoan, 0, 0, 0);
                    System.DateTime answear2 = today2.Add(duration2);
                    // return_back.Text = answear2.ToShortDateString();
                    return_date.Text = answear2.ToString("MM/dd/yyyy");//("dd/MM/yyyy");
                    break;

                case "3":
                    BookLoan = 3;
                    System.DateTime today3 = System.DateTime.Now;
                    System.TimeSpan duration3 = new System.TimeSpan(BookLoan, 0, 0, 0);
                    System.DateTime answear3 = today3.Add(duration3);
                    // return_back.Text = answear3.ToShortDateString();
                    return_date.Text = answear3.ToString("MM/dd/yyyy");//("dd/MM/yyyy");
                    break;

                case "4":
                    BookLoan = 4;
                    System.DateTime today4 = System.DateTime.Now;
                    System.TimeSpan duration4 = new System.TimeSpan(BookLoan, 0, 0, 0);
                    System.DateTime answear4 = today4.Add(duration4);
                    //return_back.Text = answear4.ToShortDateString();
                    return_date.Text = answear4.ToString("MM/dd/yyyy");//("dd/MM/yyyy");
                    break;

                case "5":
                    BookLoan = 5;
                    System.DateTime today5 = System.DateTime.Now;
                    System.TimeSpan duration5 = new System.TimeSpan(BookLoan, 0, 0, 0);
                    System.DateTime answear5 = today5.Add(duration5);
                    //return_back.Text = answear5.ToShortDateString();
                    return_date.Text = answear5.ToString("MM/dd/yyyy");//("dd/MM/yyyy");
                    break;

                case "6":
                    BookLoan = 6;
                    System.DateTime today6 = System.DateTime.Now;
                    System.TimeSpan duration6 = new System.TimeSpan(BookLoan, 0, 0, 0);
                    System.DateTime answear6 = today6.Add(duration6);
                    //return_back.Text = answear6.ToShortDateString();
                    return_date.Text = answear6.ToString("MM/dd/yyyy");//("dd/MM/yyyy");
                    break;

                case "7":
                    BookLoan = 7;
                    System.DateTime today7 = System.DateTime.Now;
                    System.TimeSpan duration7 = new System.TimeSpan(BookLoan, 0, 0, 0);
                    System.DateTime answear7 = today7.Add(duration7);
                    //return_back.Text = answear7.ToShortDateString();
                    return_date.Text = answear7.ToString("MM/dd/yyyy");//("dd/MM/yyyy");
                    break;
                default :
                    MessageBox.Show("You can not borrow more then 7 days or less then 1 day..!!!");
                    break;


            }
        }
        string constr = "Data Source=(DESCRIPTION =" +
"(ADDRESS = (PROTOCOL = TCP)(HOST = Server)(PORT = 1522))" +
"(CONNECT_DATA =" +
"(SERVER = DEDICATED)" +
"(SERVICE_NAME = XE)" +
")" +
"); User Id=system; Password=tiger";
        private void Borrorbook_Click(object sender, EventArgs e)
        {
            try
            {
            OracleConnection con = new OracleConnection(constr);
            OracleCommand cmd = new OracleCommand("borrow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = textBox1.Text;
            cmd.Parameters.Add("b_i", OracleDbType.Varchar2).Value = book_id.Text;
            cmd.Parameters.Add("b_d", OracleDbType.Varchar2).Value = Borrow_date.Text;
            cmd.Parameters.Add("r_d", OracleDbType.Varchar2).Value = return_date.Text;
            cmd.Parameters.Add("b_du", OracleDbType.Int32).Value = num_of_day.Text;
            con.Open();
            if(textBox1.Text !="" && book_id.Text !="" && Borrow_date.Text !="" && return_date.Text !="" && num_of_day.Text !="")
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book borrow successfuly done...!!!");
                    con.Close();
                }
            else
                {
                      MessageBox.Show("Please fillup all field properly...!!!");
                }
            }
              catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void borrowhistory_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
               
                OracleCommand cmd = new OracleCommand("select * from borrow_book  where user_id='"+textBox1.Text+"'", con);

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

        private void Borrow_date_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
           
            book_id.Clear();
            return_date.Clear();
            num_of_day.Clear();
        }
    }
}
