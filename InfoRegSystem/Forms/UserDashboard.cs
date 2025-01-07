using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InfoRegSystem.Forms
{
    public partial class UserDashboard : UserControl
    {
        private frmRegistration frmRegistration;
        private UserMainForm frmMain;

        int userId = GlobalUserInfo.UserId;
        string username = GlobalUserInfo.Username;

        public UserDashboard()
        {
            InitializeComponent();
            DisplayBorrow();

            greetingslbl.Text = $"Welcome, {GlobalUserInfo.FirstName}!";
        }
        public UserDashboard(string username, int userId) : this()
        {
            this.username = username;
            this.userId = userId;
        }

        public UserDashboard(frmRegistration frmRegistration) : this()
        {
            this.frmRegistration = frmRegistration;
        }
             
        public void DisplayBorrow()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    string query = @"
                            SELECT 
                                (SELECT COUNT(b.Id) 
                                 FROM borrowtable b 
                                 INNER JOIN studentable s ON b.Id = s.Id 
                                 WHERE b.BorrowedDate IS NOT NULL 
                                   AND b.ReturnDate IS NULL 
                                   AND s.Id = @UserId) AS BorrowedCount,
                                (SELECT COUNT(b.Id) 
                                 FROM borrowtable b 
                                 INNER JOIN studentable s ON b.Id = s.Id 
                                 WHERE b.ReturnDate IS NOT NULL 
                                   AND s.Id = @UserId) AS ReturnedCount,
                                (SELECT COUNT(b.Id) 
                                 FROM borrowtable b 
                                 INNER JOIN studentable s ON b.Id = s.Id 
                                 WHERE b.ReturnDate IS NULL 
                                   AND b.ExpectedReturnDate < @CurrentDate 
                                   AND s.Id = @UserId) AS OverdueCount";

                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int borrowedCount = Convert.ToInt32(reader["BorrowedCount"]);
                                int returnedCount = Convert.ToInt32(reader["ReturnedCount"]);
                                int overdueCount = Convert.ToInt32(reader["OverdueCount"]);

                                UpdateDashboardLabels(borrowedCount, returnedCount, overdueCount);
                            }
                            else
                            {
                                MessageBox.Show("No data found for the current user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    sqlConnection.Close();
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
        private void UpdateDashboardLabels(int borrowedCount, int returnedCount, int overdueCount)
        {
            lblborrowed.Text = borrowedCount.ToString();

            lblreturned.Text = returnedCount.ToString();

            lbldueboo.Text = overdueCount.ToString();
        }
    }
}
