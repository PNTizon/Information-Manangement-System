using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminDashboard : UserControl
    {
        private ButtonHandler handler;
        private FormManager formManager;
        public AdminDashboard()
        {
            InitializeComponent();
            displayBorrow();
            displayMem();
            formManager = new FormManager();
            handler = new ButtonHandler();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadbookslist();
        }
        public void displayMem()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("GetStudentCount", sqlConnection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int count = Convert.ToInt32(reader[0]);
                        lblTotalMem.Text = count.ToString();
                    }
                    reader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void displayBorrow()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("BorrowState", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int borrowedCount = Convert.ToInt32(reader["BorrowedCount"]);
                            int returnedCount = Convert.ToInt32(reader["ReturnedCount"]);
                            int overdueCount = Convert.ToInt32(reader["OverdueCount"]);

                            if (lblBorrowBoo != null)
                                lblBorrowBoo.Text = borrowedCount.ToString();

                            if (lblReturnBoo != null)
                                lblReturnBoo.Text = returnedCount.ToString();

                            if (lbldueboo != null)
                                lbldueboo.Text = overdueCount.ToString();
                        }
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadbookslist()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

            sqlConnection.Open();

            SqlDataAdapter da = new SqlDataAdapter("GetBooks", sqlConnection);
            DataTable table = new DataTable();
            da.Fill(table);

            if (dataGridViewBookInfo.Columns.Contains("BookID"))
            {
                dataGridViewBookInfo.Columns["BookID"].Visible = false;
            }
            dataGridViewBookInfo.DataSource = table;

            sqlConnection.Close();
        }
        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            handler.HandleSearch(dataGridViewBookInfo, searchbox);
        }
    }
}
