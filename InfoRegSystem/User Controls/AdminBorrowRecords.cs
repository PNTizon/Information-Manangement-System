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

namespace InfoRegSystem.Forms
{
    public partial class AdminBorrowRecords : UserControl
    {
        private AdminDashboard dashboard;
        private UserMainForm userDashboard;
        public AdminBorrowRecords()
        {
            InitializeComponent();
        }

        public AdminBorrowRecords(AdminDashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }
        private void LoadData()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("GetBorrowData", sqlConnection);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewBorrow.DataSource = dataTable;

                // Hide the ID column if it exists
                if (dataGridViewBorrow.Columns.Contains("Id"))
                {
                    dataGridViewBorrow.Columns["Id"].Visible = false;
                }

                sqlConnection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtLastname.Text) || string.IsNullOrWhiteSpace(txtBook.Text))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                // Check if the student exists
                SqlCommand checkStudentCmd = new SqlCommand("CheckStudentExist", sqlConnection);
                checkStudentCmd.CommandType = CommandType.StoredProcedure;
                checkStudentCmd.Parameters.AddWithValue("@Name", txtName.Text);
                checkStudentCmd.Parameters.AddWithValue("@Lastname", txtLastname.Text);

                object studentIdResult = checkStudentCmd.ExecuteScalar();
                if (studentIdResult == null)
                {
                    MessageBox.Show("The entered student is not registered in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int studentId = Convert.ToInt32(studentIdResult);

                // Check if the book exists and has available copies
                SqlCommand checkBookCmd = new SqlCommand("CheckBookExistsAvailability", sqlConnection);
                checkBookCmd.CommandType = CommandType.StoredProcedure;
                checkBookCmd.Parameters.AddWithValue("@Book", txtBook.Text);
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

                // Prevent duplicate borrow entries for the same student and book
                SqlCommand checkDuplicateCmd = new SqlCommand("CheckDuplication", sqlConnection);
                checkDuplicateCmd.CommandType = CommandType.StoredProcedure;
                checkDuplicateCmd.Parameters.AddWithValue("@Name", txtName.Text);
                checkDuplicateCmd.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                checkDuplicateCmd.Parameters.AddWithValue("@Book", txtBook.Text);
                int duplicateCount = (int)checkDuplicateCmd.ExecuteScalar();

                if (duplicateCount > 0)
                {
                    MessageBox.Show("This book is already borrowed by the student and not yet returned.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Current date and time for BorrowedDate
                DateTime borrowedDate = DateTime.Now;

                // Set the expected return date (e.g., 7 days from the borrowed date)
                DateTime expectedReturnDate = borrowedDate.AddDays(7);

                // Insert into the borrowtable
                SqlCommand insertCmd = new SqlCommand("AddBorrowRecord", sqlConnection);
                checkDuplicateCmd.CommandType = CommandType.StoredProcedure;
                insertCmd.Parameters.AddWithValue("@Name", txtName.Text);
                insertCmd.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                insertCmd.Parameters.AddWithValue("@Book", txtBook.Text);
                insertCmd.Parameters.AddWithValue("@BorrowedDate", borrowedDate); // Use DateTime.Now
                insertCmd.Parameters.AddWithValue("@ExpectedReturnDate", expectedReturnDate); // Add 7 days

                insertCmd.ExecuteNonQuery();

                // Decrement the book copies in the Books table
                SqlCommand updateCopiesCmd = new SqlCommand("DecrementBookCopies", sqlConnection);
                updateCopiesCmd.CommandType = CommandType.StoredProcedure;
                updateCopiesCmd.Parameters.AddWithValue("@Book", txtBook.Text);
                updateCopiesCmd.ExecuteNonQuery();

                MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh dashboard and data
                dashboard?.displayBorrow();
                dashboard?.loadbookslist();
                LoadData();

                sqlConnection.Close();
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewBorrow.CurrentRow == null)
                {
                    MessageBox.Show("Please select a record to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the record ID
                object idValue = dataGridViewBorrow.CurrentRow.Cells["Id"].Value;
                if (idValue == DBNull.Value || idValue == null)
                {
                    MessageBox.Show("Invalid record selected. No ID found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Get the original book title before updating
                string originalBookTitle = dataGridViewBorrow.CurrentRow.Cells["Book"].Value.ToString();
                // Get the updated book title from the user input
                string updatedBookTitle = txtBook.Text.Trim();


                int recordId = Convert.ToInt32(idValue);

                // Retrieve the values for update
                string updatedName = txtName.Text.Trim();
                string updatedLastName = txtLastname.Text.Trim();
                string updatedBook = txtBook.Text.Trim();
                DateTime updatedBorrowedDate = borrowDate.Value;

                // Validate fields
                if (string.IsNullOrEmpty(updatedName) || string.IsNullOrEmpty(updatedLastName) || string.IsNullOrEmpty(updatedBook))
                {
                    MessageBox.Show("Please ensure all fields are filled in.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                // Update query for borrowtable excluding ReturnDate and Penalty

                SqlCommand cmd = new SqlCommand(" UpdateBorrowTable", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", updatedName);
                cmd.Parameters.AddWithValue("@LastName", updatedLastName);
                cmd.Parameters.AddWithValue("@Book", updatedBook);
                cmd.Parameters.AddWithValue("@BorrowedDate", updatedBorrowedDate);
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
                    LoadData();
                    dashboard?.displayBorrow();
                    dashboard?.loadbookslist();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewBorrow.CurrentRow == null)
                {
                    MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int recordId = Convert.ToInt32(dataGridViewBorrow.CurrentRow.Cells["Id"].Value);
                string bookTitle = Convert.ToString(dataGridViewBorrow.CurrentRow.Cells["Book"].Value);

                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                // Delete the borrow record from the borrowtable
                SqlCommand cmd = new SqlCommand("DeleteBorrowMemder", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", recordId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Increase book copies in Books table
                    SqlCommand updateCopiesCmd = new SqlCommand("UpdateBookCopiesForBorrow", sqlConnection);
                    updateCopiesCmd.Parameters.AddWithValue("@OriginalBook", bookTitle);
                    updateCopiesCmd.ExecuteNonQuery();

                    MessageBox.Show("Record deleted successfully.");
                    LoadData();
                    dashboard?.displayBorrow();
                    dashboard?.loadbookslist();
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            UpdateReturnDate();
            dashboard?.displayBorrow();
            LoadData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void UpdateReturnDate()
        {
            try
            {
                if (dataGridViewBorrow.CurrentRow == null)
                {
                    MessageBox.Show("Please select a record to update the return date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int recordId = Convert.ToInt32(dataGridViewBorrow.CurrentRow.Cells["Id"].Value);

                // Check if the ExpectedReturnDate is DBNull before casting

                DateTime expectedReturnDate = DateTime.MinValue; // Default value
                if (dataGridViewBorrow.CurrentRow.Cells["ExpectedReturnDate"].Value != DBNull.Value)
                {
                    expectedReturnDate = Convert.ToDateTime(dataGridViewBorrow.CurrentRow.Cells["ExpectedReturnDate"].Value);
                }

                DateTime returnDateValue = returnDate.Checked ? returnDate.Value : DateTime.Now;

                decimal penaltyAmount = 0;
                if (returnDateValue > expectedReturnDate) // If the return is late
                {
                    TimeSpan lateDuration = returnDateValue - expectedReturnDate;
                    penaltyAmount = (decimal)(lateDuration.TotalHours * 10);
                }

                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("UpdateReturnDetails", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = recordId;
                cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = returnDateValue;
                cmd.Parameters.Add("@Penalty", SqlDbType.Decimal).Value = penaltyAmount;
                cmd.ExecuteNonQuery();


                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Decrement the book copies in the Books table
                    SqlCommand updateCopiesCmd = new SqlCommand("UpdateBookCopiesForBorrow", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    updateCopiesCmd.Parameters.AddWithValue("@OrginalBook", txtBook.Text);
                    updateCopiesCmd.ExecuteNonQuery();

                    LoadData();
                    dashboard?.displayBorrow();
                    dashboard?.loadbookslist();
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
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewBorrow.Rows[e.RowIndex];

                    txtName.Text = row.Cells["name"].Value.ToString();
                    txtBook.Text = row.Cells["book"].Value.ToString();
                    txtLastname.Text = row.Cells["lastname"].Value.ToString();

                    if (row.Cells["borroweddate"].Value != DBNull.Value)
                    {
                        borrowDate.Value = Convert.ToDateTime(row.Cells["borroweddate"].Value);
                    }
                    else
                    {
                        borrowDate.Value = DateTime.Now;
                    }

                    if (row.Cells["returndate"].Value != DBNull.Value)
                    {
                        returnDate.Value = Convert.ToDateTime(row.Cells["returndate"].Value);
                    }
                    else
                    {
                        returnDate.Value = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occurred: " + ex.Message + " - " + ex.Source);
            }
        }

        private void BorrowForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnSearch_Click(object sender, EventArgs e)
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
                        dataGridViewBorrow.DataSource = table;
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
    }
}
