using System;
using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace InfoRegSystem.Classes
{
    public class AdminBorrowFunctions
    {
        private Display display;
        public AdminBorrowFunctions()
        {
            display = new Display();
        }
        //ON PROCESS
        public void BorrowHandler(TextBox name, TextBox lastname, TextBox book, ComboBox duration, Action displayBorrow, Action displayBookList, DataGridView borrowRecords)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(lastname.Text) || string.IsNullOrWhiteSpace(book.Text))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (duration.SelectedItem == null)
            {
                MessageBox.Show("Please select the borrowing duration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    // Check if the student exists
                    using (SqlCommand checkStudentCmd = new SqlCommand("CheckStudentExist", sqlConnection))
                    {
                        checkStudentCmd.CommandType = CommandType.StoredProcedure;
                        checkStudentCmd.Parameters.AddWithValue("@Name", name.Text);
                        checkStudentCmd.Parameters.AddWithValue("@Lastname", lastname.Text);

                        object studentIdResult = checkStudentCmd.ExecuteScalar();
                        if (studentIdResult == null)
                        {
                            MessageBox.Show("The entered student is not registered in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int studentId = Convert.ToInt32(studentIdResult);
                    }

                    // Check if the book exists and has available copies
                    using (SqlCommand checkBookCmd = new SqlCommand("CheckBookExistsAvailability", sqlConnection))
                    {
                        checkBookCmd.CommandType = CommandType.StoredProcedure;
                        checkBookCmd.Parameters.AddWithValue("@Book", book.Text);
                        object bookCopiesResult = checkBookCmd.ExecuteScalar();

                        if (bookCopiesResult == null)
                        {
                            MessageBox.Show("The entered book is not registered in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int availableCopies = Convert.ToInt32(bookCopiesResult);
                        if (availableCopies <= 0)
                        {
                            MessageBox.Show("The book is currently out of stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Prevent duplicate borrow entries for the same student and book
                    using (SqlCommand checkDuplicateCmd = new SqlCommand("CheckDuplication", sqlConnection))
                    {
                        checkDuplicateCmd.CommandType = CommandType.StoredProcedure;
                        checkDuplicateCmd.Parameters.AddWithValue("@Name", name.Text);
                        checkDuplicateCmd.Parameters.AddWithValue("@Lastname", lastname.Text);
                        checkDuplicateCmd.Parameters.AddWithValue("@Book", book.Text);
                        int duplicateCount = (int)checkDuplicateCmd.ExecuteScalar();

                        if (duplicateCount > 0)
                        {
                            MessageBox.Show("This book is already borrowed by the student and not yet returned.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Current date and time for BorrowedDate
                    DateTime borrowedDate = DateTime.Now;

                    // Get the borrowing duration from the ComboBox
                    if (!int.TryParse(duration.SelectedItem?.ToString(), out int borrowDurationDays))
                    {
                        MessageBox.Show("Please select a valid borrowing duration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DateTime expectedReturnDate = borrowedDate.AddDays(borrowDurationDays);

                    // Insert into the borrowtable
                    using (SqlCommand insertCmd = new SqlCommand("AddBorrowRecord", sqlConnection))
                    {
                        insertCmd.CommandType = CommandType.StoredProcedure;
                        insertCmd.Parameters.AddWithValue("@Name", name.Text);
                        insertCmd.Parameters.AddWithValue("@Lastname", lastname.Text);
                        insertCmd.Parameters.AddWithValue("@Book", book.Text);

                        insertCmd.Parameters.AddWithValue("@BorrowedDate", borrowedDate); // Use DateTime.Now
                        insertCmd.Parameters.AddWithValue("@ExpectedReturnDate", expectedReturnDate); // Use selected duration

                        insertCmd.ExecuteNonQuery();
                    }

                    // Decrement the book copies in the Books table
                    using (SqlCommand updateCopiesCmd = new SqlCommand("DecrementBookCopies", sqlConnection))
                    {
                        updateCopiesCmd.CommandType = CommandType.StoredProcedure;
                        updateCopiesCmd.Parameters.AddWithValue("@Book", book.Text);
                        updateCopiesCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh dashboard and data
                    displayBorrow();
                    displayBookList();
                    display.DisplayBorrowRecords(borrowRecords);

                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //ON PROCESS
        public void UpdateHandler(TextBox name, TextBox lastname, TextBox book, DateTime datenow, ComboBox duration, DataGridView viewBorrow, Action displayBorrow, Action displayBookList)
        {
            try
            {
                if (viewBorrow.CurrentRow == null)
                {
                    MessageBox.Show("Please select a record to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the record ID
                object idValue = viewBorrow.CurrentRow.Cells["Id"].Value;
                if (idValue == DBNull.Value || idValue == null)
                {
                    MessageBox.Show("Invalid record selected. No ID found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Get the original book title before updating
                string originalBookTitle = viewBorrow.CurrentRow.Cells["Book"].Value.ToString();
                // Get the updated book title from the user input
                string updatedBookTitle = book.Text.Trim();


                int recordId = Convert.ToInt32(idValue);

                // Retrieve the values for update
                string updatedName = name.Text.Trim();
                string updatedLastName = lastname.Text.Trim();
                string updatedBook = book.Text.Trim();
                DateTime updatedBorrowedDate = datenow;

                // Validate fields
                if (string.IsNullOrEmpty(updatedName) || string.IsNullOrEmpty(updatedLastName) || string.IsNullOrEmpty(updatedBook))
                {
                    MessageBox.Show("Please ensure all fields are filled in.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (duration.SelectedItem == null)
                {
                    MessageBox.Show("Please select a duration.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedDuration = int.Parse(duration.SelectedItem.ToString());
                DateTime updatedExpectedReturnDate = updatedBorrowedDate.AddDays(selectedDuration);

                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);


                sqlConnection.Open();

                // Update query for borrowtable excluding ReturnDate and Penalty

                SqlCommand cmd = new SqlCommand("UpdateBorrowTable", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", updatedName);
                cmd.Parameters.AddWithValue("@LastName", updatedLastName);
                cmd.Parameters.AddWithValue("@Book", updatedBook);
                cmd.Parameters.AddWithValue("@BorrowedDate", updatedBorrowedDate);
                cmd.Parameters.AddWithValue("@ExpectedReturnDate", updatedExpectedReturnDate);
                cmd.Parameters.AddWithValue("@Id", recordId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    using (SqlCommand sqlcom = new SqlCommand("UpdateBookCopiesForBorrow", sqlConnection))
                    {
                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.Parameters.AddWithValue("@OriginalBook", originalBookTitle);
                        sqlcom.Parameters.AddWithValue("@UpdatedBook", updatedBookTitle);
                        sqlcom.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record updated successfully.");
                    display.DisplayBorrowRecords(viewBorrow);
                    displayBorrow();
                    displayBookList();
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
        //ON PROCESS
        public void DeleteHandler(DataGridView records, Action displayBorrow, Action displayBookList)
        {
            try
            {
                if (records.CurrentRow == null)
                {
                    MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int recordId = Convert.ToInt32(records.CurrentRow.Cells["Id"].Value);
                string bookTitle = Convert.ToString(records.CurrentRow.Cells["Book"].Value);

                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                // Delete the borrow record from the borrowtable
                SqlCommand cmd = new SqlCommand("DeleteBorrowMember", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", recordId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Increase book copies in Books table
                    SqlCommand updateCopiesCmd = new SqlCommand("", sqlConnection);
                    updateCopiesCmd.Parameters.AddWithValue("@OriginalBook", bookTitle);
                    updateCopiesCmd.ExecuteNonQuery();

                    MessageBox.Show("Record deleted successfully.");
                    display.DisplayBorrowRecords(records);
                    displayBorrow();
                    displayBookList();
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
        //ON PROCESS
        public void HandleReturn(DataGridView dataGridViewBorrow, DateTimePicker returnDatePicker, string bookTitle, Action refreshDashboard, Action refreshBookList)
        {
            try
            {
                if (dataGridViewBorrow.CurrentRow == null)
                {
                    MessageBox.Show("Please select a record to update the return date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int recordId = Convert.ToInt32(dataGridViewBorrow.CurrentRow.Cells["Id"].Value);
                DateTime borrowedDate = Convert.ToDateTime(dataGridViewBorrow.CurrentRow.Cells["BorrowedDate"].Value);

                // Check if the ExpectedReturnDate is DBNull before casting
                DateTime expectedReturnDate = DateTime.MinValue; // Default value
                if (dataGridViewBorrow.CurrentRow.Cells["ExpectedReturnDate"].Value != DBNull.Value)
                {
                    expectedReturnDate = Convert.ToDateTime(dataGridViewBorrow.CurrentRow.Cells["ExpectedReturnDate"].Value);
                }

                DateTime returnDateValue = returnDatePicker.Checked ? returnDatePicker.Value : DateTime.Now;

                decimal penaltyAmount = 0;
                if (returnDateValue > expectedReturnDate) // If the return is late
                {
                    TimeSpan lateDuration = returnDateValue - expectedReturnDate;
                    penaltyAmount = (decimal)(lateDuration.TotalHours * 10); // Assuming 10 pesos per hour as the penalty
                }

                using (SqlConnection sqlConnection = new SqlConnection("YourConnectionStringHere"))
                {
                    sqlConnection.Open();

                    // Update the return details
                    using (SqlCommand cmd = new SqlCommand("UpdateReturnDetails", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = recordId;
                        cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = returnDateValue;
                        cmd.Parameters.Add("@Penalty", SqlDbType.Decimal).Value = penaltyAmount;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update book copies in the Books table (assuming decrementing for return)
                            using (SqlCommand updateCopiesCmd = new SqlCommand("UpdateBookCopiesForBorrow", sqlConnection))
                            {
                                updateCopiesCmd.CommandType = CommandType.StoredProcedure;
                                updateCopiesCmd.Parameters.AddWithValue("@OriginalBook", bookTitle); // Assuming decrementing copies for return
                                updateCopiesCmd.ExecuteNonQuery();
                            }

                            // Update the DataGridView with the exact time details
                            dataGridViewBorrow.CurrentRow.Cells["ReturnDate"].Value = returnDateValue;
                            dataGridViewBorrow.CurrentRow.Cells["Penalty"].Value = penaltyAmount;

                            // Refresh data in UI
                            refreshDashboard?.Invoke();
                            refreshBookList?.Invoke();

                            MessageBox.Show("Return details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error: No record found for the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchHandler(Guna2TextBox searchbox,DataGridView recordsgrid)
        {
            string searchInput = searchbox.Text;

            if (string.IsNullOrWhiteSpace(searchInput))
            {
                MessageBox.Show("Search input cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("SearchBorrowRecords", sqlConnection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchInput", searchInput);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        recordsgrid.DataSource = table;
                    }
                    else
                    {
                        MessageBox.Show("No records found matching your search.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                sqlConnection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ApproveRequest(int borrowId)
        {
            string query = "UPDATE borrowtable SET Status = 'Approved' WHERE Id = @BorrowId";

            using (SqlConnection con = new SqlConnection(sqlconnection.Database))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@BorrowId", borrowId);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Borrow request approved.");
            }
        }
        public void RejectRequest(int borrowId)
        {
            string query = "UPDATE borrowtable SET Status = 'Rejected' WHERE Id = @BorrowId";

            using (SqlConnection con = new SqlConnection(sqlconnection.Database))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@BorrowId", borrowId);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Borrow request rejected.");
            }
        }
    }
}
