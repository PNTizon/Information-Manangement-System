using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Guna.UI2.WinForms;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfoRegSystem.Forms;

namespace InfoRegSystem.Classes
{
    public class UserBookFunction
    {
        private UserFormManager formMange;

        public UserBookFunction()
        {
            formMange = new UserFormManager();
        }

        public void UserBookSearch(Guna2TextBox searchbox,ComboBox genrebox,DataGridView bookgrid)
        {
            string searchInput = searchbox.Text.Trim();
            string selectedGenre = genrebox.SelectedItem?.ToString();

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
        public void BorrowTransaction(Guna2Button transaction, Panel panel)
        {
            UserBorrowTransactions transactions = new UserBorrowTransactions();
            formMange.openUserDashboard(transactions, panel);
        }
    }
}
