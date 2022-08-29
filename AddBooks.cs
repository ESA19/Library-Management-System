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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthorName.Text != "" && txtPublisher.Text != "" && numericQuantity.Text != "")
            {


                String bname = txtBookName.Text;
                String bauthor = txtAuthorName.Text;
                String publisher = txtPublisher.Text;
                String date = dateTimeReleaseDate.Text;
                Int64 quantity = Int64.Parse(numericQuantity.Text);
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = ESA\\SQLEXPRESS; database=master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into New_Book2 (bName,bAuthor,bPubl,bRDate,bQuan) values('" + bname + "','" + bauthor + "','" + publisher + "','" + date + "'," + quantity + ")";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Book Added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthorName.Clear();
                txtPublisher.Clear();
            }
            else
            {
                MessageBox.Show("All field must be FILLED", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will DELETE your unsaved data.", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
            else
            {

            }
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
