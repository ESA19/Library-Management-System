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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=ESA\\SQLEXPRESS; database=master; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bName from New_Book2", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    comboBookN.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
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

                cmd.CommandText = "select * from NewStudent where sEnrol='" + en + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count!=0)
                {
                    
                    txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtEnroll.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtDep.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSem.Text=ds.Tables[0].Rows[0][4].ToString();
                    txtCont.Text=ds.Tables[0].Rows[0][5].ToString();

                }
                else
                {
                    MessageBox.Show("Please Check Student Enrollment No Or Student isn't Registered!","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEnrol.Text = ""; 
                }

            }
            else
            {
                MessageBox.Show("Please Enter A Student Enrollment No", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            String sName=txtName.Text;
            String sEnrol=txtEnroll.Text;
            String sDep=txtDep.Text;
            String sSem =txtSem.Text;
            String sCont = txtCont.Text;
            String bookN=comboBookN.Text;
            String bookIda=dateBookIssue.Text;


            if (comboBookN.Text!=""&&txtName.Text!="")
            {
                if (dateBookIssue.Text==DateTime.Today.ToString("D"))
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "insert into NewIssue_Book (IbSen,IbSn,IbSd,IbSs,IbSc,IbBn,Ibida) values ('" + sEnrol + "','" + sName + "','" + sDep + "','" + sSem + "','" + sCont + "','" + bookN + "','" + bookIda + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Book Issued succesfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtEnroll.Clear();
                    txtName.Clear();
                    txtDep.Clear();
                    txtSem.Clear();
                    txtCont.Clear();
                    comboBookN.Text = "";
                    dateBookIssue.Value = DateTime.Today;
                }
                else
                {
                    MessageBox.Show("Please select a Today Date!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
               

            }
            else
            {
                MessageBox.Show("Please fill required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         



        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEnrol.Clear();
            txtName.Clear();
            txtDep.Clear();
            txtSem.Clear();
            txtCont.Clear();
            comboBookN.Text = "";
            dateBookIssue.Value = DateTime.Today;
           
        }

        private void txtEnrol_TextChanged(object sender, EventArgs e)
        {
            if (txtEnrol.Text=="")
            {
                txtEnrol.Clear();
                txtName.Clear();
                txtDep.Clear();
                txtSem.Clear();
                txtCont.Clear();
                comboBookN.Text = "";
                dateBookIssue.Value = DateTime.Today;

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
