using InfoRegSystem.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class UserTransactionFunction
    {
        private static string Book { get; set; }
        public static void RetunTransaction(DataGridView transactiongrid, Action displayBorrow)
        {
            try
            {
                if (transactiongrid.CurrentRow == null)
                {
                    MessageBox.Show("Please select a record to update the return date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // kani siya kay ginakuha niya ang expected return date
                DateTime expectedReturnDate = DateTime.MinValue;
                if (transactiongrid.CurrentRow.Cells["ExpectedReturnDate"].Value != DBNull.Value)
                {
                    expectedReturnDate = Convert.ToDateTime(transactiongrid.CurrentRow.Cells["ExpectedReturnDate"].Value);
                }

                if (transactiongrid.CurrentRow.Cells["Book"].Value != DBNull.Value)
                {
                    Book = transactiongrid.CurrentRow.Cells["Book"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Book information is missing. Please select a valid record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string approvalStatus = transactiongrid.CurrentRow.Cells["Status"].Value.ToString();
                if (approvalStatus != "Approved")
                {
                    string message = approvalStatus == "Declined"
                        ? "The return cannot be processed because the request was rejected by the admin."
                        : "The return cannot be processed because the request has not been approved by the admin.";
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime returnDateValue = DateTime.Now;
                int penaltyAmount = 0;
                string paymentStatus = "Paid";

                if (returnDateValue > expectedReturnDate)
                {
                    TimeSpan lateDuration = returnDateValue - expectedReturnDate;
                    penaltyAmount = (int)(lateDuration.TotalHours * 10);
                    paymentStatus = "Unpaid";
                }
                var result = MessageBox.Show("Are you sure you want to return this record?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                int recordId = Convert.ToInt32(transactiongrid.CurrentRow.Cells["Id"].Value);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(Connection.Database))
                    {
                        sqlConnection.Open();

                        // Update Borrow Record
                        using (SqlCommand cmd = new SqlCommand("UpdateBorrowRecord", sqlConnection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", GlobalUserInfo.FirstName);
                            cmd.Parameters.AddWithValue("@Penalty", penaltyAmount);
                            cmd.Parameters.AddWithValue("@Book", Book);
                            cmd.Parameters.AddWithValue("@ReturnDate", returnDateValue);
                            cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                using (SqlCommand updateCopiesCmd = new SqlCommand("UpdateBookCopiesForBorrow", sqlConnection))
                                {
                                    updateCopiesCmd.CommandType = CommandType.StoredProcedure;
                                    updateCopiesCmd.Parameters.AddWithValue("@BookTitle", Book);
                                    updateCopiesCmd.Parameters.AddWithValue("@ActionType", "RETURN");
                                    updateCopiesCmd.ExecuteNonQuery();
                                }
                                using (SqlCommand status = new SqlCommand("UpdateStatus", sqlConnection))
                                {
                                    status.CommandType = CommandType.StoredProcedure;
                                    status.Parameters.AddWithValue("@BorrowId", recordId);

                                    status.ExecuteNonQuery();
                                }
                            }
                            displayBorrow();
                            Display.DisplayUserTransaction(transactiongrid);
                        }
                        MessageBox.Show("The admin is verifying the return of the book.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Error: No record found for the specified ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void BorrowTransaction(Panel panel)
        {
            UserBorrowTransactions transactions = new UserBorrowTransactions();
            UserFormManager.openUserDashboard(transactions, panel);
        }
    }
}