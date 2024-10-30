using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace InfoRegSystem
{
    public partial class RegistarionFormcs : Form
    {
     
        public RegistarionFormcs()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Delete studentable where id=@id", con);

            cnn.Parameters.AddWithValue("@id", int.Parse(txtID.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");


            con.Open();

            SqlCommand cnn = new SqlCommand("Insert into studentable values(@id,@name,@age,@phone,@barangay,@email)", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
            cnn.Parameters.AddWithValue("@Name" , txtName.Text);
            cnn.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
            cnn.Parameters.AddWithValue("@Phone", txtPhoneNum.Text);
            cnn.Parameters.AddWithValue("@Barangay",txtBarangay.Text);
            cnn.Parameters.AddWithValue("@Email",  txtEmail.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Saved");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");


            con.Open();

            SqlCommand cnn = new SqlCommand("Update studentable set name=@name,age=@age,phone=@phone,email=@email,barangay=@barangay where id=@id", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
            cnn.Parameters.AddWithValue("@Name", txtName.Text);
            cnn.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
            cnn.Parameters.AddWithValue("@Phone", txtPhoneNum.Text);
            cnn.Parameters.AddWithValue("@Barangay", txtBarangay.Text);
            cnn.Parameters.AddWithValue("@Email", txtEmail.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");
            SqlCommand cnn = new SqlCommand("Select * from studentable", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NF4HS4J;Initial Catalog=librarydb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from studentable", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;

        }
    }
}
