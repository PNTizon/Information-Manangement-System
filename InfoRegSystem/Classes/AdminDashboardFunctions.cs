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

        public void HandleSearch(DataGridView dataGridViewBookInfo, string searchbox)
        {
            using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
            {
                sqlConnection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("SearchBooks", sqlConnection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@searchInput", searchbox);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewBookInfo.DataSource = table;
                }
            }
        }
    }
}
