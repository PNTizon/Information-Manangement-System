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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");


            con.Open();

            SqlCommand cnn = new SqlCommand("Insert into booktable values(@id,@book,@number,@author,@publisher)", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
            cnn.Parameters.AddWithValue("@Book", txtBookName.Text);
            cnn.Parameters.AddWithValue("@Number", int.Parse(txtNum.Text));
            cnn.Parameters.AddWithValue("@Author", txtAuthor.Text);
            cnn.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
            

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Saved");
        }
              
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");


            con.Open();

            SqlCommand cnn = new SqlCommand("Update booktable set book=@book,number=@number,author=@author,publisher=@publisher where id=@id", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
            cnn.Parameters.AddWithValue("@Book", txtBookName.Text);
            cnn.Parameters.AddWithValue("@Number", int.Parse(txtNum.Text));
            cnn.Parameters.AddWithValue("@Author", txtAuthor.Text);
            cnn.Parameters.AddWithValue("@Publisher", txtPublisher.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Delete from booktable where id=@id", con);

            cnn.Parameters.AddWithValue("@id", int.Parse(txtID.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");
            SqlCommand cnn = new SqlCommand("Select * from booktable", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from booktable", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}
