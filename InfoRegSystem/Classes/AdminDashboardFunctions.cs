using InfoRegSystem.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class AdminDashboardFunctions
    {
        private AdminDashboard dashboard;

        public void HandleSearch(DataGridView dataGridViewBookInfo, Guna.UI2.WinForms.Guna2TextBox searchbox)
        {
            using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
            {
                sqlConnection.Open();

                string searchInput = searchbox.Text;

                using (SqlDataAdapter adapter = new SqlDataAdapter("SearchBooks", sqlConnection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@searchInput", $"%{searchInput}%");
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewBookInfo.DataSource = table;
                }
            }
        }
    }
}
