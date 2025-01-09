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
    public partial class UserBook : UserControl
    {
        public UserBook()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void UserBookInfo_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadGenresForSearch();
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
        private void LoadGenresForSearch()
        {
            List<string> genres = new List<string> { "Fiction", "Non-Fiction", "Mystery", "Fantasy", "Sci-Fi", "Biography", "History", "Romance" };
            cmbGenre.DataSource = genres;
            cmbGenre.SelectedIndex = -1;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchInput = searchbox.Text.Trim();
            string selectedGenre = cmbGenre.SelectedItem?.ToString();

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

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
