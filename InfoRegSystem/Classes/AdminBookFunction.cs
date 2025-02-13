using Guna.UI2.WinForms;
using InfoRegSystem.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class AdminBookFunction
    {
        private static AdminDashboard _dashboard =  new AdminDashboard();
        
        public static void SearchBooks(string searchbox, ComboBox genrebox, DataGridView bookgrid)
        {
            string searchInput = searchbox.Trim();
            string selectedGenre = genrebox.SelectedItem?.ToString();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("SearchBooks", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SearchInput", searchInput?.Trim() ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Genre", (selectedGenre)?? (object)DBNull.Value);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            bookgrid.DataSource = table;
                        }
                        else
                        {
                            MessageBox.Show("No records found matching your search.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Cleaner(TextBox title, TextBox author, TextBox copies,ComboBox genre)
        {
            title.Clear();
            author.Clear();
            copies.Clear();
            genre.SelectedIndex = -1;
        }
        public static void AddBook(string title, string author, string copy, string genre, DataGridView bookgrid)
        {
            int copies;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(genre))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(copy.Trim(), out copies) || copies < 0)
            {
                MessageBox.Show("Please enter a valid number of copies.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("AddBook", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Title", title.Trim());
                        cmd.Parameters.AddWithValue("@Author", author.Trim());
                        cmd.Parameters.AddWithValue("@Genres", genre);
                        cmd.Parameters.AddWithValue("@Copies", copies);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Book record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Display.DisplayBooks(bookgrid);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the book record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Display.DisplayBooks(bookgrid);
        }
        public static void UpdateBook(string titles, string authors, string copy, ComboBox genrebox, DataGridView bookgrid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(titles) || genrebox.SelectedItem == null)
                {
                    MessageBox.Show("Please ensure all fields are filled, including the genre.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (bookgrid.CurrentRow == null)
                {
                    MessageBox.Show("No record selected. Please select a record to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedID = Convert.ToInt32(bookgrid.CurrentRow.Cells["BookID"].Value);

                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("UpdateBook", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Title", titles.Trim());
                        cmd.Parameters.AddWithValue("@Author", authors.Trim());
                        cmd.Parameters.AddWithValue("@Copies", int.Parse(copy.Trim()));
                        cmd.Parameters.AddWithValue("@Genres", genrebox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@BookID", selectedID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Record not found.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                Display.DisplayBooks(bookgrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _dashboard.loadbookslist();
        }
        public static void DeleteBook(string title, string author, string copies, DataGridView bookgrid)
        {
            try
            {
                if (bookgrid.CurrentRow == null)
                {
                    MessageBox.Show("Please select a valid record to delete.");
                    return;
                }

                int selectedID = Convert.ToInt32(bookgrid.CurrentRow.Cells["BookID"].Value);

                var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                    {
                        sqlConnection.Open();

                        using (SqlCommand cmd = new SqlCommand("DeleteBook", sqlConnection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@BookID", selectedID);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not found.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            sqlConnection.Close();
                        }
                    }
                }
                Display.DisplayBooks(bookgrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _dashboard.loadbookslist();
        }
    }
}
