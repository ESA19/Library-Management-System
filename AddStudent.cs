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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text!=""&&txtEnroll.Text!=""&&txtContact.Text!=""&&comboDepartment.Text!=""&&comboSemester.Text!="")
            {
                String sName=txtName.Text;
                String sEnroll=txtEnroll.Text;
                String sContact=txtContact.Text;
                String sSemester = comboSemester.Text;
                String sDepartment=comboDepartment.Text;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source =ESA\\SQLEXPRESS; database=master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into NewStudent (sName,sEnrol,sDepartment,sSemester,sContact) values('" + sName + "','" + sEnroll + "','" + sDepartment + "','" + sSemester + "','" + sContact + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Student Added succesfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Clear();
                txtEnroll.Clear();
                txtContact.Clear();
                comboDepartment.Text = "";
                comboSemester.Text = "";

            }
            else
            {
                MessageBox.Show("Please Fill Required Fields", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnroll.Clear();
            txtContact.Clear();
            comboDepartment.Text = "";
            comboSemester.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
