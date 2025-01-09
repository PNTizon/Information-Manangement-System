using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminBookInfo : UserControl
    {
        private AdminDashboard _dashboard;
        private Helpers helper;
        public AdminBookInfo(AdminDashboard dashboard)
        {
            InitializeComponent();
            _dashboard = dashboard;
        }
        public AdminBookInfo()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("GetBooks", sqlConnection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                bookgridView.DataSource = dataTable;

                if (bookgridView.Columns.Contains("BookID"))
                {
                    bookgridView.Columns["BookID"].Visible = false;
                }
                sqlConnection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadGenres()
        {
            helper.GenresHelper(cmbGenres);
        }
        private void LoadGenresForSearch()
        {
            helper.GenresHelper(cmbGenre);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchInput = searchbox.Text.Trim();
            string selectedGenre = cmbGenre.SelectedItem?.ToString();

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
                            bookgridView.DataSource = table;
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
        private void BookInfo_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadGenres();
            LoadGenresForSearch();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string genre = cmbGenres.SelectedItem?.ToString();
            int copies;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(genre))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCopies.Text.Trim(), out copies) || copies < 0)
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

                        LoadData();
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
            Clear();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text) || cmbGenres.SelectedItem == null)
                {
                    MessageBox.Show("Please ensure all fields are filled, including the genre.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (bookgridView.CurrentRow == null)
                {
                    MessageBox.Show("No record selected. Please select a record to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedID = Convert.ToInt32(bookgridView.CurrentRow.Cells["BookID"].Value);

                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("UpdateBook", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@Copies", int.Parse(txtCopies.Text));
                cmd.Parameters.AddWithValue("@Genres", cmbGenres.SelectedItem.ToString());
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
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Clear();
            _dashboard.loadbookslist();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (bookgridView.CurrentRow == null)
                {
                    MessageBox.Show("Please select a valid record to delete.");
                    return;
                }

                int selectedID = Convert.ToInt32(bookgridView.CurrentRow.Cells["BookID"].Value);

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

                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Clear();
            _dashboard.loadbookslist();
        }

        #region Helpers
        private void txtCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtBookID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void bookgridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = bookgridView.Rows[e.RowIndex];

                    int selectedID = Convert.ToInt32(bookgridView.CurrentRow.Cells["BookID"].Value);

                    bookgridView.Columns["BookID"].Visible = false;
                    txtTitle.Text = row.Cells["title"].Value.ToString();
                    txtAuthor.Text = row.Cells["author"].Value.ToString();
                    txtCopies.Text = row.Cells["copies"].Value.ToString();

                    string genre = row.Cells["Genres"].Value.ToString();
                    cmbGenres.SelectedItem = genre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source);
            }
        }
        private void Clear()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtCopies.Clear();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
