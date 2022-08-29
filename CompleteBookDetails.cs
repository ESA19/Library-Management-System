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
    public partial class CompleteBookDetails : Form
    {
        public CompleteBookDetails()
        {
            InitializeComponent();
        }

        private void CompleteBookDetails_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            label3.Visible =false;
            dataGridView2.Visible = true;
            label4.Visible =false;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from NewIssue_Book where Ibrda is null";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds=new DataSet();
            adapter.Fill(ds);
            
            if (ds.Tables[0].Rows.Count!=0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                dataGridView1.Visible = false;
                label3.Visible = true;
            }
            cmd.CommandText = "select* from NewIssue_Book where Ibrda is not null";
            SqlDataAdapter adapter1=new SqlDataAdapter(cmd);
            DataSet ds1=new DataSet();
            adapter1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count!=0)
            {
                dataGridView2.DataSource = ds1.Tables[0];
            }
            else
            {
                dataGridView2.Visible=false;
                label4.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
