using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace InfoRegSystem.Classes
{
    public class AdminBorrowFunctions
    {
        private Display display;
        string firstName, lastName;

        public AdminBorrowFunctions()
        {
            display = new Display();
        }
        public void BorrowHandler(string name, string lastname, string book, ComboBox duration,
            Action displayBorrow, Action displayBookList, DataGridView borrowRecords)
        {
            if (GlobalUserInfo.FirstName == null || GlobalUserInfo.Lastname == null)
            {
                firstName = name;
                lastName = lastname;
            }
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastname) || string.IsNullOrWhiteSpace(book))
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

                    int studentId = GlobalUserInfo.UserId;
                    using (SqlCommand checkStudentCmd = new SqlCommand("CheckStudentExist", sqlConnection))
                    {
                        checkStudentCmd.CommandType = CommandType.StoredProcedure;
                        checkStudentCmd.Parameters.AddWithValue("@Name", firstName);
                        checkStudentCmd.Parameters.AddWithValue("@Lastname", lastName);

                        var result = checkStudentCmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("The entered student is not registered in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        studentId = Convert.ToInt32(result);
                    }

                    using (SqlCommand checkBookCmd = new SqlCommand("CheckBookExistsAvailability", sqlConnection))
                    {
                        checkBookCmd.CommandType = CommandType.StoredProcedure;
                        checkBookCmd.Parameters.AddWithValue("@Book", book);
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
                    using (SqlCommand checkDuplicateCmd = new SqlCommand("CheckDuplication", sqlConnection))
                    {
                        checkDuplicateCmd.CommandType = CommandType.StoredProcedure;
                        checkDuplicateCmd.Parameters.AddWithValue("@StudentId", studentId);
                        checkDuplicateCmd.Parameters.AddWithValue("@Book", book);

                        int duplicateCount = (int)checkDuplicateCmd.ExecuteScalar();
                        if (duplicateCount > 0)
                        {
                            MessageBox.Show("This book is already borrowed by the student and not yet returned.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    DateTime borrowedDate = DateTime.Now;
                    if (!int.TryParse(duration.SelectedItem.ToString(), out int borrowDurationDays))
                    {
                        MessageBox.Show("Please select a valid borrowing duration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DateTime expectedReturnDate = borrowedDate.AddDays(borrowDurationDays);
                    string status = "Pending"; 
                    using (SqlCommand insertBorrowCmd = new SqlCommand("AddBorrowRecord", sqlConnection))
                    {
                        insertBorrowCmd.CommandType = CommandType.StoredProcedure; 
                        insertBorrowCmd.Parameters.AddWithValue("@StudentId", studentId);
                        insertBorrowCmd.Parameters.AddWithValue("@Name", firstName.Trim()); 
                        insertBorrowCmd.Parameters.AddWithValue("@Lastname", lastName.Trim());
                        insertBorrowCmd.Parameters.AddWithValue("@Book", book.Trim());
                        insertBorrowCmd.Parameters.AddWithValue("@BorrowedDate", borrowedDate);
                        insertBorrowCmd.Parameters.AddWithValue("@ExpectedReturnDate", expectedReturnDate);
                        insertBorrowCmd.Parameters.AddWithValue("@Duration", borrowDurationDays);
                        insertBorrowCmd.Parameters.AddWithValue("@Status", status);

                        insertBorrowCmd.ExecuteNonQuery();
                    }

                    using (SqlCommand decrementCopiesCmd = new SqlCommand("DecrementBookCopies", sqlConnection))
                    {
                        decrementCopiesCmd.CommandType = CommandType.StoredProcedure;
                        decrementCopiesCmd.Parameters.AddWithValue("@BorrowBook", book);
                        decrementCopiesCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                displayBorrow();
                displayBookList();
                display.DisplayBorrowRecords(borrowRecords);
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

        public void UpdateHandler( TextBox name, TextBox lastname,TextBox book, ComboBox duration,
            Action displayBorrow,Action displayBookList, DataGridView borrowRecords)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(lastname.Text) || string.IsNullOrWhiteSpace(book.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (duration.SelectedItem == null)
            {
                MessageBox.Show("Please select the borrowing duration.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    if (borrowRecords.CurrentRow == null)
                    {
                        MessageBox.Show("Please select a record to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Retrieve record ID
                    object idValue = borrowRecords.CurrentRow.Cells["Id"].Value;
                    if (idValue == DBNull.Value || idValue == null)
                    {
                        MessageBox.Show("Invalid record selected. No ID found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int recordId = Convert.ToInt32(idValue);

                    // Get original book title to manage stock
                    string originalBookTitle = borrowRecords.CurrentRow.Cells["Book"].Value.ToString();
                    string updatedBookTitle = book.Text.Trim();

                    // Parse duration and calculate new Expected Return Date
                    DateTime updatedBorrowedDate = DateTime.Now;
                    if (!int.TryParse(duration.SelectedItem.ToString(), out int borrowDurationDays))
                    {
                        MessageBox.Show("Please select a valid borrowing duration.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DateTime updatedExpectedReturnDate = updatedBorrowedDate.AddDays(borrowDurationDays);

                    // Update the borrowtable record
                    using (SqlCommand updateBorrowCmd = new SqlCommand("UpdateAdminBorrowRecords", sqlConnection))
                    {
                        updateBorrowCmd.CommandType = CommandType.StoredProcedure;
                        updateBorrowCmd.Parameters.AddWithValue("@Id", recordId);
                        updateBorrowCmd.Parameters.AddWithValue("@Name", name.Text.Trim());
                        updateBorrowCmd.Parameters.AddWithValue("@Lastname", lastname.Text.Trim());
                        updateBorrowCmd.Parameters.AddWithValue("@Book", updatedBookTitle);
                        updateBorrowCmd.Parameters.AddWithValue("@BorrowedDate", updatedBorrowedDate);
                        updateBorrowCmd.Parameters.AddWithValue("@ExpectedReturnDate", updatedExpectedReturnDate);

                        int rowsAffected = updateBorrowCmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No record found for the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Update book copies if the book title has changed
                    if (!string.Equals(originalBookTitle, updatedBookTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        using (SqlCommand updateCopiesCmd = new SqlCommand("UpdateBookCopiesForBorrow", sqlConnection))
                        {
                            updateCopiesCmd.CommandType = CommandType.StoredProcedure;
                            updateCopiesCmd.Parameters.AddWithValue("@OriginalBook", originalBookTitle);
                            updateCopiesCmd.Parameters.AddWithValue("@UpdatedBook", updatedBookTitle);
                            updateCopiesCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            displayBorrow();
            displayBookList();
            display.DisplayBorrowRecords(borrowRecords);
        }
        public void DeleteHandler(DataGridView records, Action displayBorrow, Action displayBookList)
        {
            try
            {
                if (records.CurrentRow == null)
                {
                    MessageBox.Show("Please select a valid record to delete.");
                    return;
                }

                int recordId = Convert.ToInt32(records.CurrentRow.Cells["Id"].Value);
                string bookTitle = Convert.ToString(records.CurrentRow.Cells["Book"].Value);

                var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                    {
                        sqlConnection.Open();

                        // Delete the borrow record from the borrowtable
                        using (SqlCommand cmd = new SqlCommand("DeleteBorrowMember", sqlConnection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", recordId);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // Increase book copies in Books table
                                SqlCommand updateCopiesCmd = new SqlCommand("IncrementBookCopies", sqlConnection);

                                updateCopiesCmd.CommandType = CommandType.StoredProcedure;
                                updateCopiesCmd.Parameters.AddWithValue("@OriginalBook", bookTitle);
                                updateCopiesCmd.ExecuteNonQuery();

                                MessageBox.Show("Record deleted successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Error: No record found for the specified ID.");
                            }
                            sqlConnection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            displayBorrow();
            displayBookList();
            display.DisplayBorrowRecords(records);
        }

        public void HandleReturn(DataGridView dataGridViewBorrow, DateTimePicker returnDatePicker,
            string bookTitle, Action refreshDashboard, Action refreshBookList)
        {
            try
            {
                if (dataGridViewBorrow.CurrentRow == null)
                {
                    MessageBox.Show("Please select a record to update the return date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int recordId = Convert.ToInt32(dataGridViewBorrow.CurrentRow.Cells["Id"].Value);
                string approvalStatus = dataGridViewBorrow.CurrentRow.Cells["Status"].Value.ToString();

                // Restrict return if the admin hasn't approved or the status is "Rejected"
                if (approvalStatus != "Approved")
                {
                    string message = approvalStatus == "Rejected"
                        ? "The return cannot be processed because the request was rejected by the admin."
                        : "The return cannot be processed because the request has not been approved by the admin.";
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime borrowedDate = Convert.ToDateTime(dataGridViewBorrow.CurrentRow.Cells["BorrowedDate"].Value);

                // Check if the ExpectedReturnDate is DBNull before casting
                DateTime expectedReturnDate = DateTime.MinValue; // Default value para dili mag error ug DBNull or walay minVal
                if (dataGridViewBorrow.CurrentRow.Cells["ExpectedReturnDate"].Value != DBNull.Value)//check if ang value sa expectDate kay DBNull
                {
                    expectedReturnDate = Convert.ToDateTime(dataGridViewBorrow.CurrentRow.Cells["ExpectedReturnDate"].Value);
                }

                DateTime returnDateValue = returnDatePicker.Checked ? returnDatePicker.Value : DateTime.Now;

                decimal penaltyAmount = 0;
                string paymentStatus = "Paid";
                if (returnDateValue > expectedReturnDate) // If the return is late
                {
                    TimeSpan lateDuration = returnDateValue - expectedReturnDate;
                    penaltyAmount = (decimal)(lateDuration.TotalHours * 10); // Assuming 10 pesos per hour as the penalty
                    paymentStatus = "Unpaid";
                }

                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    // Update the return details
                    using (SqlCommand cmd = new SqlCommand("UpdateReturnDetails", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = recordId;
                        cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = returnDateValue;
                        cmd.Parameters.Add("@Penalty", SqlDbType.Decimal).Value = penaltyAmount;
                        cmd. Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = paymentStatus;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update book copies in the Books table (assuming decrementing for return)
                            using (SqlCommand updateCopiesCmd = new SqlCommand("DecrementBookCopies", sqlConnection))
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
      
        public void SearchHandler(Guna2TextBox searchbox, DataGridView recordsgrid)
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
        public void ApproveRequest(string Book,int borrowId,DataGridView recordsgrid)
        {
            string book = Book;
            using (SqlConnection con = new SqlConnection(sqlconnection.Database))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("ApproveRequest", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BorrowId", borrowId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Borrow request approved.");
                }
                using (SqlCommand decrementCopiesCmd = new SqlCommand("DecrementBookCopies", con))
                {
                    decrementCopiesCmd.CommandType = CommandType.StoredProcedure;
                    decrementCopiesCmd.Parameters.AddWithValue("@BorrowBook", book);

                    decrementCopiesCmd.ExecuteNonQuery();
                }
                display.DisplayBorrowRecords(recordsgrid);
            }
        }
        public void RejectRequest(int borrowId,string bookTitle,DataGridView recordsgrid)
        {
            using (SqlConnection con = new SqlConnection(sqlconnection.Database))
            {
                using (SqlCommand cmd = new SqlCommand("RejectRequest", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BorrowId", borrowId);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Borrow request rejected.");
                }
                display.DisplayBorrowRecords(recordsgrid);
            }
        }
    }
}
