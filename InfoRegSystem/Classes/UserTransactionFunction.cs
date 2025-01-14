using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Guna.UI2.Native.WinApi;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class UserTransactionFunction
    {
        private Display display;


        private string book { get; set; }

        public UserTransactionFunction()
        {
            display = new Display();


        }
        public void RetunTransaction(DataGridView transactiongrid,Action displayBorrow)
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
                    displayBorrow();
                    display.DisplayUserTransaction(transactiongrid);
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
        public void BorrowTransaction()
        {



        }
    }
}
