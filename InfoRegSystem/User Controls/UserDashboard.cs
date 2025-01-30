using InfoRegSystem.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class UserDashboard : UserControl
    {
        private frmRegistration frmRegistration;

        int userId = GlobalUserInfo.UserId;
        string username = GlobalUserInfo.Username;

        public UserDashboard()
        {
            InitializeComponent();
            DisplayBorrow();

            //greetingslbl.Text = $"Welcome, {GlobalUserInfo.FirstName}!";
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

                    using (SqlCommand cmd = new SqlCommand("GetUserBorrowRecords", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);

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
                                MessageBox.Show("No data found for the current user.", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void UpdateDashboardLabels(int borrowedCount, int returnedCount, int overdueCount)
        {
            lblborrowed.Text = borrowedCount.ToString();

            lblreturned.Text = returnedCount.ToString();

            lbldueboo.Text = overdueCount.ToString();
        }

        private void greetingslbl_Click(object sender, EventArgs e)
        {

        }
    }
}
