using InfoRegSystem.Classes;
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
using static Guna.UI2.Native.WinApi;

namespace InfoRegSystem.Forms
{
    public partial class UserTransaction : UserControl
    {
        private UserDashboard formdash;
        private string book { get; set; }

        public UserTransaction()
        {
            InitializeComponent();
        }
        public UserTransaction( UserDashboard formdash)
        {
            this.formdash = formdash;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (transactiongrid.CurrentRow == null)
                {
                    MessageBox.Show("Please select a record to update the return date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the expected return date
                DateTime expectedReturnDate = DateTime.MinValue;

                if (transactiongrid.CurrentRow.Cells["ExpectedReturnDate"].Value != DBNull.Value)
                {
                    expectedReturnDate = Convert.ToDateTime(transactiongrid.CurrentRow.Cells["ExpectedReturnDate"].Value);
                }

                DateTime returnDateValue = DateTime.Now;
                decimal penaltyAmount = 0;

                if (returnDateValue > expectedReturnDate) // If the return is late
                {
                    TimeSpan lateDuration = returnDateValue - expectedReturnDate;
                    penaltyAmount = (decimal)(lateDuration.TotalHours * 10);
                }

                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("UpdateBorrowRecord", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", GlobalUserInfo.FirstName);
                cmd.Parameters.AddWithValue("@Penalty", penaltyAmount);
                cmd.Parameters.AddWithValue("@book", book);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Increment the book copies in the Books table
                    SqlCommand updateCopiesCmd = new SqlCommand("IncrementBookCopies", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    updateCopiesCmd.Parameters.AddWithValue("@Book", book);
                    updateCopiesCmd.ExecuteNonQuery();

                    // Refresh the user record display and dashboard
                    formdash?.DisplayBorrow();
                    DisplayUserRecords();
                }
                else
                {
                    MessageBox.Show("Error: No record found for the specified ID.");
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayUserRecords()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("DisplayUserRecords", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", GlobalUserInfo.FirstName);
                        cmd.Parameters.AddWithValue("@lastname", GlobalUserInfo.Lastname);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            transactiongrid.DataSource = dataTable;
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database Error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void transactiongrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = transactiongrid.Rows[e.RowIndex];

                    book = row.Cells["book"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occurred: " + ex.Message + " - " + ex.Source);
            }
        }

        private void UserTransac_Load(object sender, EventArgs e)
        {
            DisplayUserRecords();
        }
    }
}
