using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace InfoRegSystem
{
    public partial class BorrowForm : Form
    {
        public BorrowForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");


            con.Open();

            SqlCommand cnn = new SqlCommand("Insert into borrowtable values(@id,@name,@book,@borroweddate,@returndate)", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
            cnn.Parameters.AddWithValue("@Name", txtName.Text);
            cnn.Parameters.AddWithValue("@Book", txtBook.Text);
            cnn.Parameters.AddWithValue("@BorrowedDate", txtBorrowdate.Text);
            cnn.Parameters.AddWithValue("@ReturnDate", txtReturndate.Text);


            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Saved");
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");


            con.Open();

            SqlCommand cnn = new SqlCommand("Update borrowtable set book=@book,name=@name,returndate=@returndate,borroweddate=@borroweddate where id=@id", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
            cnn.Parameters.AddWithValue("@Name", txtName.Text);
            cnn.Parameters.AddWithValue("@Book", txtBook.Text);
            cnn.Parameters.AddWithValue("@BorrowedDate", txtBorrowdate.Text);
            cnn.Parameters.AddWithValue("@ReturnDate", txtReturndate.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Delete from borrowtable where id=@id", con);

            cnn.Parameters.AddWithValue("@id", int.Parse(txtID.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");
            SqlCommand cnn = new SqlCommand("Select * from borrowtable", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from borrowtable", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}
