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
    public partial class ViewStudentsInfo : Form
    {
        public ViewStudentsInfo()
        {
            InitializeComponent();
        }

        private void ViewStudentsInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel2.Visible = false;
            label8.Visible = false;
        }
       
      
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                label8.Visible = false;
                dataGridView1.Visible = true;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from NewStudent where sName  LIKE '" + txtSearch.Text + "%' OR sEnrol LIKE '" + txtSearch.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count == 0)
                {
                    dataGridView1.Visible = false;
                    label8.Visible = true;

                }

            }
            else
            {
                dataGridView1.Visible = false;
                label8.Visible = false;
                panel2.Visible = false;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            txtSearch.Clear();
            panel2.Visible = false;
            dataGridView1.Visible = false;
        }
        int sid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    sid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from NewStudent where sid=" + sid + "";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);


                    rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                    panel2.Visible = true;
                    txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtEnroll.Text = ds.Tables[0].Rows[0][2].ToString();
                    comboDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                    comboSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtCon.Text =ds.Tables[0].Rows[0][5].ToString();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be UPDATED. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String sName = txtName.Text;
                String sEnroll = txtEnroll.Text;
                String sContact = txtCon.Text;
                String sSemester = comboSemester.Text;
                String sDepartment = comboDepartment.Text;


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update NewStudent set sName='"+sName+"',sEnrol='"+sEnroll+"',sDepartment='"+sDepartment+"',sSemester='"+sSemester+"',sContact='"+sContact+"' where sid="+rowid+"";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                txtEnroll.Clear();
                txtName.Clear();
                txtCon.Clear();
                comboSemester.Text = "";
                comboDepartment.Text = "";
                panel2.Visible = false;


                cmd.CommandText = "select * from NewStudent where sName  LIKE '" + txtSearch.Text + "%' OR sEnrol LIKE '" + txtSearch.Text + "%'";
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];







            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Student Will DELETED. Confirm?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from NewStudent where sid=" + rowid + "";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                panel2.Visible = false;
                cmd.CommandText = "select * from NewStudent where sName  LIKE '" + txtSearch.Text + "%' OR sEnrol LIKE '" + txtSearch.Text + "%' OR sContact LIKE '" + txtSearch.Text + "%'";
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count == 0)
                {
                    dataGridView1.Visible = false;
                    label8.Visible = true;

                }
                else
                {
                    dataGridView1.Visible = true;
                }
            }
        }
            
    }
}
