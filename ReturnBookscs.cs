using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagmentSystem
{
    public partial class ReturnBookscs : Form
    {
        public ReturnBookscs()
        {
            InitializeComponent();
        }

        private void ReturnBookscs_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtEnrol.Text != "")
            {
                String en = txtEnrol.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=ESA\\SQLEXPRESS; database=master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from NewIssue_Book where IbSen='" + en + "'and Ibrda IS NULL";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                

                if (ds.Tables[0].Rows.Count == 0)
                {
                    dataGridView1.Visible = false;
                    MessageBox.Show("Please Check Student Enrollment No Or Student isn't Registered!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEnrol.Text = "";

                }
                else
                {
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Visible=true;
                }
               
                
            }
            else
            {
                MessageBox.Show("Please Enter A Student Enrollment No", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int ibsid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ibsid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                    SqlCommand cmd = new SqlCommand();  
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from NewIssue_Book where Ibid=" + ibsid + "";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);


                    rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                    txtBookN.Text = ds.Tables[0].Rows[0][6].ToString();
                    dateIssue.Text = ds.Tables[0].Rows[0][7].ToString();
                  
                }






            }
            catch
            {


            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEnrol.Text = "";
            txtEnrol.Clear();
            txtBookN.Clear();
            dateReturn.Value = DateTime.Today;
            dateIssue.Value = DateTime.Today;
            dataGridView1.Visible = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            String bookN = txtBookN.Text;
            String bookIda = dateIssue.Text;
            String bookRda = dateReturn.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from NewIssue_Book where Ibid=" + ibsid + "";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (txtBookN.Text!="")
            {
                if (dateReturn.Text==DateTime.Today.ToString("D"))
                {

                        conn.Open();
                        cmd.CommandText = "update  NewIssue_Book set Ibrda='" + bookRda + "' where  Ibid="+rowid+"";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Book Returned succesfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEnrol.Clear();
                        txtBookN.Clear();
                        dateReturn.Value = DateTime.Today;
                        dateIssue.Value = DateTime.Today;
                        dataGridView1.Visible = false;
                    
                       
                }
                else
                {
                    MessageBox.Show("Please select a Today Date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please Select a Book !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEnrol.Clear();
            txtBookN.Clear();
            dateReturn.Value = DateTime.Today;
            dateIssue.Value = DateTime.Today;
            dataGridView1.Visible = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
