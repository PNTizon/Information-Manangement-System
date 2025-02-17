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
    public class UserDashboardFunctions
    {
        public static void UserLogout(Form currentForm)
        {
            Application.Restart();
        }
        public static void UserBookInfo( Form currentForm, Panel pnlDash)
        {
            UserBook bookInfo = new UserBook();
            FormManager.openDashboard(bookInfo, pnlDash);
            bookInfo.Location = currentForm.Location;
        }
        public static void UserTransaction( Form currentForm, Panel pnlDash, UserMainForm Panel = null)
        {
            UserTransaction transac = new UserTransaction(Panel);
            FormManager.openDashboard(transac, pnlDash);
            transac.Location = currentForm.Location;
        }
        public static void UserDashboard(Panel pnlDash, Form currentForm)
        {
            UserDashboard userDashboard = new UserDashboard();
            FormManager.openDashboard(userDashboard, pnlDash);
            userDashboard.Location = currentForm.Location;
        }
        public static void DisplayRecords(Label borrowed,Label returned,Label dues)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Connection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("GetUserBorrowRecords", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", GlobalUserInfo.UserId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int borrowedCount = Convert.ToInt32(reader["BorrowedCount"]);
                                int returnedCount = Convert.ToInt32(reader["ReturnedCount"]);
                                int overdueCount = Convert.ToInt32(reader["OverdueCount"]);

                                if (borrowed != null)
                                    borrowed.Text = borrowedCount.ToString();

                                if (returned != null)
                                    returned.Text = returnedCount.ToString();

                                if (dues != null)
                                    dues.Text = overdueCount.ToString();
                            }
                            else
                            {
                                MessageBox.Show("No data found for the current user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database Error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
