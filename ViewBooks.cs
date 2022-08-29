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
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
           dataGridView1.Visible = false;
           panel2.Visible = false;

        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from New_Book2 where bid=" + bid + "";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);


                    rowid=Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                    panel2.Visible = true;
                    txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtPubl.Text = ds.Tables[0].Rows[0][3].ToString();
                    dateTimePicker1.Text = ds.Tables[0].Rows[0][4].ToString();
                    numericUpDown1.Value = Convert.ToDecimal(ds.Tables[0].Rows[0][5].ToString());
                    ViewBooks vb = new ViewBooks();
                    vb.AutoScroll = true;
                }

                else
                {
                    panel2.Visible = false;
                }





            }
            catch 
            {

                
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text!="")
            {
                label7.Visible = false;
                dataGridView1.Visible = true;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from New_Book2 where bName  LIKE '"+txtSearch.Text+ "%' OR bAuthor LIKE '" + txtSearch.Text + "%' OR bPubl LIKE '" + txtSearch.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count==0)
                {
                    dataGridView1.Visible=false;
                    label7.Visible = true;
                    
                }

            }
            else
            {
                dataGridView1.Visible = false;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            panel2.Visible=false;
            dataGridView1.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be UPDATED. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String bname = txtName.Text;
                String bauthor = txtAuthor.Text;
                String publisher = txtPubl.Text;
                String date = dateTimePicker1.Text;
                Int64 quantity = Int64.Parse(numericUpDown1.Text);


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update New_Book2 set bName='" + bname + "',bAuthor='" + bauthor + "',bPubl='" + publisher + "',bRDate='" + date + "',bQuan=" + quantity + "where bid=" + rowid + "";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                txtPubl.Clear();
                txtName.Clear();
                txtAuthor.Clear();
                dateTimePicker1.Value = DateTime.Now;
                numericUpDown1.Value = 0;


                cmd.CommandText = "select * from New_Book2 where bName  LIKE '" + txtSearch.Text + "%' OR bAuthor LIKE '" + txtSearch.Text + "%' OR bPubl LIKE '" + txtSearch.Text + "%'";
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
               






            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data Will DELETED. Confirm?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from New_Book2 where bid=" + rowid + ""; 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                panel2.Visible = false;
                cmd.CommandText = "select * from New_Book2 where bName  LIKE '" + txtSearch.Text + "%' OR bAuthor LIKE '" + txtSearch.Text + "%' OR bPubl LIKE '" + txtSearch.Text + "%'";
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count == 0)
                {
                    dataGridView1.Visible = false;
                    label7.Visible = true;

                }
                else
                {
                     dataGridView1.Visible=true;
                }


              







            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
