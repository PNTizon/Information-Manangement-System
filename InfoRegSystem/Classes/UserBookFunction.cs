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
        ////private UserFormManager formMange;

        //public UserBookFunction()
        //{
        //    //formMange = new UserFormManager();
        //}

        public static void UserBookSearch(string searchbox,ComboBox genrebox,DataGridView bookgrid)
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

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@SearchInput", searchInput?.Trim() ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Genre", (selectedGenre) ?? (object)DBNull.Value);

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
        public static void BorrowTransaction(Guna2Button transaction, Panel panel)
        {
            UserBorrowTransactions transactions = new UserBorrowTransactions();
            UserFormManager.openUserDashboard(transactions, panel);
        }
    }
}
