﻿using Guna.UI2.WinForms;
using InfoRegSystem.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class UserTransactionFunction
    {
        private Display display;
        private UserFormManager formMange;

        private string book { get; set; }

        public UserTransactionFunction()
        {
            display = new Display();
            formMange = new UserFormManager();
        }
        public void RetunTransaction(DataGridView transactiongrid, Action displayBorrow)
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

                // Get the book value from the selected row
                if (transactiongrid.CurrentRow.Cells["Book"].Value != DBNull.Value)
                {
                    book = transactiongrid.CurrentRow.Cells["Book"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Book information is missing. Please select a valid record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string approvalStatus = transactiongrid.CurrentRow.Cells["Status"].Value.ToString();

                if (approvalStatus != "Approved")
                {
                    string message = approvalStatus == "Rejected"
                        ? "The return cannot be processed because the request was rejected by the admin."
                        : "The return cannot be processed because the request has not been approved by the admin.";
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime returnDateValue = DateTime.Now;
                decimal penaltyAmount = 0;
                string paymentStatus = "Paid";

                if (returnDateValue > expectedReturnDate)
                {
                    TimeSpan lateDuration = returnDateValue - expectedReturnDate;
                    penaltyAmount = (decimal)(lateDuration.TotalHours * 10);
                    paymentStatus = "Unpaid";
                }

                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    // Update Borrow Record
                    SqlCommand cmd = new SqlCommand("UpdateBorrowRecord", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", GlobalUserInfo.FirstName);
                    cmd.Parameters.AddWithValue("@Penalty", penaltyAmount);
                    cmd.Parameters.AddWithValue("@Book", book);
                    cmd.Parameters.AddWithValue("@ReturnDate", returnDateValue);
                     cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Increment the book copies in the Books table
                        SqlCommand updateCopiesCmd = new SqlCommand("IncrementBookCopies", sqlConnection);
                        updateCopiesCmd.CommandType = CommandType.StoredProcedure;
                        updateCopiesCmd.Parameters.AddWithValue("@OriginalBook", book); // Ensure @Book is passed correctly
                        updateCopiesCmd.ExecuteNonQuery();

                        // Refresh the user record display and dashboard
                        displayBorrow();
                        display.DisplayUserTransaction(transactiongrid);
                    }
                    else
                    {
                        MessageBox.Show("Error: No record found for the specified ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void BorrowTransaction(Guna2Button transaction, Panel panel)
        {
            UserBorrowTransactions transactions = new UserBorrowTransactions();
            formMange.openUserDashboard(transactions, panel);
        }
    }
}

