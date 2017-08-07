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

namespace useerlogin
{
    public partial class add_delete_update : Form
    {
        public add_delete_update()
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
        private void Show_Click(object sender, EventArgs e)
        {

            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("select bd.book_id,bd.book_name,bd.edition,bd.writer_name,bd.shelf_no,bd.total_amount,ba.available from book_details bd,book_amount ba where bd.book_id = ba.book_id order by book_id asc", con);

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
        private void add_delete_update_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            adminhome a = new adminhome();
            a.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {

            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("book_add_del_up.insert_data", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = book_id.Text;
                cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = book_name.Text;
                cmd.Parameters.Add("edi", OracleDbType.Varchar2).Value = edition.Text;
                cmd.Parameters.Add("w_n", OracleDbType.Varchar2).Value = writer_name.Text;
                cmd.Parameters.Add("s_n", OracleDbType.Int32).Value = shelf_no.Text;
                cmd.Parameters.Add("amnt", OracleDbType.Int32).Value = amount.Text;
                con.Open();
                 if (book_id.Text != "" && book_name.Text != "" && edition.Text != "" && writer_name.Text != "" && shelf_no.Text != "" && amount.Text !="")
                 {
                     cmd.ExecuteNonQuery();
                     con.Close();
                     MessageBox.Show("1 Row is added correctly");
                 }
                 else
                 {
                     MessageBox.Show("Insert all field Properly");
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          /*  try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd=new OracleCommand("insert into book_details (book_id,book_name,edition,writer_name,shelf_no) values('"+book_id.Text+"','"+book_name.Text+"','"+edition.Text+"','"+writer_name.Text+"','"+shelf_no.Text+"')",con);
                OracleCommand cmd1 = new OracleCommand("insert into book_amount (book_id,amount) values ('" + book_id.Text + "','" + amount.Text + "')",con);
                con.Open();
              //  DataTable dt = new DataTable();
                if (book_id.Text != "" && book_name.Text != "" && edition.Text != "" && writer_name.Text != "" && shelf_no.Text != "" && amount.Text !="")
                {
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("1 Row is added correctly");
                }
                else
                {
                    MessageBox.Show("Insert all field Properly");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con =new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("book_add_del_up.delete_data",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = book_id.Text; 

                con.Open();
                if (book_id.Text != "")
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
           /* try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("delete from book_amount where book_id='" + book_id.Text + "'",con);
                OracleCommand cmd1 = new OracleCommand("delete from book_details where book_id='" + book_id.Text + "'", con);
                con.Open();
                if (book_id.Text != "")
                {
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
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
            * 
                MessageBox.Show(ex.Message);
            }*/
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
          /*  OracleConnection con = new OracleConnection(constr);
            OracleCommand cmd=new OracleCommand("update book_details set Book_Name='" + book_name.Text + "',Edition='" + edition.Text + "',Writer_Name='" + writer_name.Text + "',Shelf_No='" + shelf_no.Text + "' where Book_Id='" + book_id.Text + "'",con);
            OracleCommand cmd1=new OracleCommand("update book_amount set amount='"+amount.Text+"' where book_id='"+book_id.Text+"'",con);
           
            con.Open();
            if (book_id.Text != "" && book_name.Text != "" && edition.Text != "" && writer_name.Text != "" && shelf_no.Text != "" && amount.Text != "" && amount.Text != "")
            {
                int value;
                if (Int32.TryParse(amount.Text, out value))
                {
                    if (value >= 0)
                    {
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Update succesfull for selected item");
                    }

                    else
                    {
                        MessageBox.Show(" Negative value insertion not possiable");
                    }
                }
            }
            else
            {
                MessageBox.Show("Insert all field properly.....");
            }*/
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("book_add_del_up.UPDATE_DATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = book_id.Text;
                cmd.Parameters["id"].Size = 20;
                cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = book_name.Text;
                cmd.Parameters["name"].Size = 20;
                cmd.Parameters.Add("edi", OracleDbType.Varchar2).Value = edition.Text;
                cmd.Parameters["edi"].Size = 20;
                cmd.Parameters.Add("w_n", OracleDbType.Varchar2).Value = writer_name.Text;
                cmd.Parameters["w_n"].Size = 20;
                cmd.Parameters.Add("s_n", OracleDbType.Int32).Value = shelf_no.Text;
                cmd.Parameters["s_n"].Size = 20;
                cmd.Parameters.Add("amnt", OracleDbType.Varchar2).Value = amount.Text;
                cmd.Parameters["amnt"].Size = 20;
                
                con.Open();
                if (book_id.Text != "" && book_name.Text != "" && edition.Text != "" && writer_name.Text != "" && shelf_no.Text != "" && amount.Text != "")
                {
                    cmd.ExecuteNonQuery();
                    
                    con.Close();
                    MessageBox.Show("Update succesfull for selected item");

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

        private void Get_details_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(constr);
                OracleCommand cmd = new OracleCommand("book_add_del_up.get_book_details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = book_id.Text;
                cmd.Parameters["id"].Size = 20;
                // cmd.Parameters.Add("w_name", OracleDbType.Varchar2).Value = textBox1.Text;
                // cmd.Parameters["w_name"].Size = 20;
                cmd.Parameters.Add("name", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["name"].Size = 20;
                cmd.Parameters.Add("edi", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["edi"].Size = 20;
                cmd.Parameters.Add("writer", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["writer"].Size = 20;
                cmd.Parameters.Add("shelf", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["shelf"].Size = 20;
                cmd.Parameters.Add("amnt", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                cmd.Parameters["amnt"].Size = 20;
                con.Open();
                cmd.ExecuteNonQuery();
                book_name.Text = cmd.Parameters["name"].Value.ToString();
                edition.Text = cmd.Parameters["edi"].Value.ToString();
                writer_name.Text = cmd.Parameters["writer"].Value.ToString();
                shelf_no.Text = cmd.Parameters["shelf"].Value.ToString();
                amount.Text = cmd.Parameters["amnt"].Value.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

                /* OracleConnection con = new OracleConnection(constr);
            OracleCommand cmd = new OracleCommand("Select * from book_details where book_id='"+book_id.Text+"'",con);
            OracleDataReader myReader;
            try
            {
                con.Open();
                myReader=cmd.ExecuteReader();
                while(myReader.Read())
                {
                    string sBook_Id = myReader.GetString("book_name");
                 
                }
            }*/

           /* string query = "select * from book_details where Book_Id='" + book_id.Text + "'";
            MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=Lms");
            //  MySqlDataAdapter msd = new MySqlDataAdapter("select * from book_details", mcon);
            MySqlCommand cmd = new MySqlCommand(query, mcon);
            MySqlDataReader myReader;
            try
            {
                mcon.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    string sBook_Id = myReader.GetString("Book_Id");
                    string sBook_Name = myReader.GetString("Book_Name");
                    string sEdition = myReader.GetString("Edition");
                    string sWriter_Name = myReader.GetString("Writer_Name");
                    string sShelf_No = myReader.GetString("Shelf_No");
                    book_id.Text = sBook_Id;
                    book_name.Text = sBook_Name;
                    edition.Text = sEdition;
                    writer_name.Text = sWriter_Name;
                    shelf_no.Text = sShelf_No;
                }
            }
            catch (Exception ex)
            {

            }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            book_id.Clear();
            book_name.Clear();
            edition.Clear();
            writer_name.Clear();
            shelf_no.Clear();
            amount.Clear();
        }
    }
}
