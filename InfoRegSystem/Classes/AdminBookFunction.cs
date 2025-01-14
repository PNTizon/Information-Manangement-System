using System;
using System.Collections.Generic;
using Guna.UI2.WinForms;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfoRegSystem.Forms;

namespace InfoRegSystem.Classes
{
    public  class AdminBookFunction
    {
        private Display display;
        private AdminDashboard _dashboard;
        public AdminBookFunction()
        {
            display = new Display();
            _dashboard = new AdminDashboard();
        }

        public void SearchBooks(Guna2TextBox searchbox,ComboBox genrebox,DataGridView bookgrid)
        {
            string searchInput = searchbox.Text.Trim();
            string selectedGenre = genrebox.SelectedItem?.ToString();

            // Check if both fields are empty
            if (string.IsNullOrWhiteSpace(searchInput) && string.IsNullOrWhiteSpace(selectedGenre))
            {
                MessageBox.Show("Please enter a search term or select a genre.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("SearchBooks", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@SearchInput", string.IsNullOrWhiteSpace(searchInput) ? (object)DBNull.Value : searchInput);
                        cmd.Parameters.AddWithValue("@Genre", string.IsNullOrWhiteSpace(selectedGenre) ? (object)DBNull.Value : selectedGenre);

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
        public void Cleaner(TextBox title,TextBox author,TextBox copies)
        {
            title.Clear();
            author.Clear();
            copies.Clear();
        }
        public void AddBook(TextBox titles,TextBox authors,TextBox copy,ComboBox genrebox,DataGridView bookgrid)
        {
            string title = titles.Text.Trim();
            string author = authors.Text.Trim();
            string genre = genrebox.SelectedItem?.ToString();
            int copies;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(genre))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(copy.Text.Trim(), out copies) || copies < 0)
            {
                MessageBox.Show("Please enter a valid number of copies.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("AddBook", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@Genres", genre);
                    cmd.Parameters.AddWithValue("@Copies", copies);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Book record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        display.DisplayBooks(bookgrid);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the book record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                sqlConnection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cleaner(titles,authors,copy);
        }
        public void UpdateBook(TextBox titles, TextBox authors, TextBox copy,ComboBox genrebox,DataGridView bookgrid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(titles.Text) || genrebox.SelectedItem == null)
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

                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("UpdateBook", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", titles.Text);
                cmd.Parameters.AddWithValue("@Author", authors.Text);
                cmd.Parameters.AddWithValue("@Copies", int.Parse(copy.Text));
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

                sqlConnection.Close();
                display.DisplayBooks(bookgrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cleaner(titles, authors, copy);
            _dashboard.loadbookslist();
        }
        public void DeleteBook(TextBox title, TextBox author, TextBox copies,DataGridView bookgrid)
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
                    SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand("DeleteBook", sqlConnection);

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

                    display.DisplayBooks(bookgrid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cleaner(title, author, copies);
            _dashboard.loadbookslist();
        }
    }
}
