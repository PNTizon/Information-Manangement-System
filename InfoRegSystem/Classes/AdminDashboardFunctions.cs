using InfoRegSystem.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace InfoRegSystem.Classes
{
    public class AdminDashboardFunctions
    {
        public static void HandleSearch(DataGridView dataGridViewBookInfo, string searchbox)
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
        public static void DisplayMembers(Label totalMem)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("GetStudentCount", sqlConnection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int count = Convert.ToInt32(reader[0]);
                        totalMem.Text = count.ToString();
                    }
                    reader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void DisplayRecords(Label borrows,Label returns,Label dues)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("BorrowState", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int borrowedCount = Convert.ToInt32(reader["BorrowedCount"]);
                                int returnedCount = Convert.ToInt32(reader["ReturnedCount"]);
                                int overdueCount = Convert.ToInt32(reader["OverdueCount"]);

                                if (borrows != null)
                                    borrows.Text = borrowedCount.ToString();

                                if (returns != null)
                                    returns.Text = returnedCount.ToString();

                                if (dues != null)
                                    dues.Text = overdueCount.ToString();
                            }
                        }
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
