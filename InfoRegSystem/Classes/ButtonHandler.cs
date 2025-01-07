using InfoRegSystem.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class ButtonHandler
    {
        private frmRegistration registration;
        private MainForm mainform;
        private FormManager formManager;
        private AdminMemdersInfo adminMemdersInfo;
        private TextBox searchbox;
        private DataGridView dataGridViewBookInfo;
        private AdminBorrowRecords borrowrecs;

        public ButtonHandler()
        {
            formManager = new FormManager();
            adminMemdersInfo = new AdminMemdersInfo();
        }
        #region MainForm Buttons
        public void HandleLogin(TextBox usernameTextBox, TextBox passwordTextBox, TextBox errorLabel, Form currentForm)
        {
            const string adminUsername = "admin";
            const string adminPassword = "admin123";

            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Please fill all the blank fields.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (usernameTextBox.Text.Trim() == adminUsername && passwordTextBox.Text.Trim() == adminPassword)
                {
                    MainForm adminDashboard = new MainForm();
                    adminDashboard.Show();
                    currentForm.Hide();
                }
                else
                {
                    using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                    {
                        using (SqlCommand cmd = new SqlCommand("GetUserDetails", sqlConnection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", usernameTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", passwordTextBox.Text.Trim());

                            sqlConnection.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    GlobalUserInfo.UserId = reader.GetInt32(0);
                                    GlobalUserInfo.Username = reader.GetString(1);
                                    GlobalUserInfo.FirstName = reader.GetString(2);
                                    GlobalUserInfo.Lastname = reader.GetString(3);

                                    UserMainForm dashboard = new UserMainForm();
                                    dashboard.Show();
                                    currentForm.Hide();
                                    sqlConnection.Close();
                                }
                                else
                                {
                                    errorLabel.Text = "Invalid username or password!";
                                }
                            }
                        }

                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void HandleRegister(Button registerButton, Form currentForm)
        {
            AccountCreation regis = new AccountCreation();
            regis.Show();
            currentForm.Hide();
        }
        public void HandleBookInfoForm(Button bookbtn, Form currentForm, Panel pnlDash)
        {
            AdminBookInfo bookInfoForm = new AdminBookInfo();
            formManager.openDashboard(bookInfoForm, pnlDash);
            bookInfoForm.Location = currentForm.Location;
        }
        public void HandleReturnBook(Button returnbtn, Panel pnlDash)
        {
            AdminBorrowRecords borrowform = new AdminBorrowRecords();
            formManager.openDashboard(borrowform, pnlDash);
        }
        public void HandleLogout(Button logoutbtn, Form currentForm)
        {
            frmRegistration registrationForm = new frmRegistration();
            registrationForm.Show();
            currentForm.Close();
        }
        public void HandleMembership(Button registerbtn, Panel pnlDash, Form currentForm)
        {
            AdminMemdersInfo registarionform = new AdminMemdersInfo();
            formManager.openDashboard(registarionform, pnlDash);
            registarionform.Location = currentForm.Location;
        }
        public void HandleDashboard(Button button, Panel pnlDash, Form currentForm)
        {
            AdminDashboard dashbord = new AdminDashboard();
            formManager.openDashboard(dashbord, pnlDash);
            dashbord.Location = currentForm.Location;
        }
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
        #endregion
        #region Members Info Buttons
        //ON PROCESS
        public void SaveMemberInfo(string name, string lastname, int age, string gender, string countryCode, string phoneNumber, 
            string address, string email, Action displayMethod, Action clearMethod, Action displayMemMethod = null)
        {
            try
            {
                if (!IsValidGmailAddress(email))
                {
                    MessageBox.Show("Invalid Gmail address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    DateTime day = DateTime.Today;
                    using (SqlCommand cnn = new SqlCommand("AddMember", sqlConnection))
                    {
                        cnn.CommandType = CommandType.StoredProcedure;
                        cnn.Parameters.AddWithValue("@name", name.Trim());
                        cnn.Parameters.AddWithValue("@lastname", lastname.Trim());
                        cnn.Parameters.AddWithValue("@age", age);
                        cnn.Parameters.AddWithValue("@gender", gender.Trim());
                        cnn.Parameters.AddWithValue("@countrycode", countryCode.Trim());
                        cnn.Parameters.AddWithValue("@phonenum", phoneNumber.Trim());
                        cnn.Parameters.AddWithValue("@address", address.Trim());
                        cnn.Parameters.AddWithValue("@email", email.Trim());
                        cnn.Parameters.AddWithValue("@dateRegister", day);

                        cnn.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    displayMemMethod?.Invoke();
                }
                displayMemMethod();
                clearMethod();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidGmailAddress(string email)
        {
            return email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
        }
        
        public void DeleteMemberInfo(DataGridView membergrid, Action displayMethod, Action clearMethod, Action displayMemMethod = null)
        {
            try
            {
                if (membergrid.CurrentRow == null)
                {
                    MessageBox.Show("Please select a valid record to delete.");
                    return;
                }

                int selectedID = Convert.ToInt32(membergrid.CurrentRow.Cells["ID"].Value);

                var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {

                    SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);
                    sqlConnection.Open();

                    using (SqlCommand cnn = new SqlCommand("DeleteMember", sqlConnection))
                    {
                        cnn.CommandType = CommandType.StoredProcedure;
                        cnn.Parameters.AddWithValue("@ID", selectedID);

                        int rowsAffected = cnn.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayMemMethod?.Invoke();
                        }
                        else
                        {
                            MessageBox.Show("Record not found.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clearMethod();
            displayMethod();
        }
        public void UpdateMemberInfo(string name, string lastname, string ageText, string gender, string countryCode, string phoneNumber, string address, string email, DataGridView membergrid, Action displayMethod, Action clearMethod, Action displayMemMethod = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || gender == null)
                {
                    MessageBox.Show("Please ensure all fields are filled, including the gender.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidGmailAddress(email))
                {
                    MessageBox.Show("Invalid Gmail address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (membergrid.CurrentRow == null)
                {
                    MessageBox.Show("No record selected. Please select a record to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedID = Convert.ToInt32(membergrid.CurrentRow.Cells["ID"].Value);

                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cnn = new SqlCommand("UpdateMember", sqlConnection))
                    {

                        if (!int.TryParse(ageText, out int parsedAge) || parsedAge < 10 || parsedAge > 120)
                        {
                            MessageBox.Show("Please enter a valid age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        cnn.CommandType = CommandType.StoredProcedure;
                        cnn.Parameters.AddWithValue("@name", name.Trim());
                        cnn.Parameters.AddWithValue("@lastname", lastname.Trim());
                        cnn.Parameters.AddWithValue("@age", parsedAge);
                        cnn.Parameters.AddWithValue("@gender", gender.Trim());
                        cnn.Parameters.AddWithValue("@countrycode", countryCode.Trim());
                        cnn.Parameters.AddWithValue("@phonenum", phoneNumber.Trim());
                        cnn.Parameters.AddWithValue("@address", address.Trim());
                        cnn.Parameters.AddWithValue("@email", email.Trim());
                        cnn.Parameters.AddWithValue("@ID", selectedID);

                        int rowsAffected = cnn.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            displayMemMethod?.Invoke();
                        }
                        else
                        {
                            MessageBox.Show("Record not found.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                displayMethod();
                clearMethod();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MemberSearch(DataGridView membergrid, Guna.UI2.WinForms.Guna2TextBox searchbox)
        {
            string searchInput = searchbox.Text;

            if (string.IsNullOrWhiteSpace(searchInput))
            {
                MessageBox.Show("Search input cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("SearchMembers", sqlConnection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@searchInput", $"%{searchInput}%");
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        membergrid.DataSource = table;
                    }
                    else
                    {
                        MessageBox.Show("No records found matching your search.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                sqlConnection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


















        #region User Dashboard Buttons
        public void UserLogout(Button logoutbtn, Form currentForm)
        {
            frmRegistration registrationForm = new frmRegistration();
            registrationForm.Show();
            currentForm.Close();
        }
        public void UserBookInfo(Button bookbtn, Form currentForm, Panel pnlDash)
        {
            UserBook bookInfo = new UserBook();
            formManager.openDashboard(bookInfo, pnlDash);
            bookInfo.Location = currentForm.Location;
        }
        public void UserTransaction(Button transacbtn, Form currentForm, Panel pnlDash)
        {
            UserTransaction transac = new UserTransaction();
            formManager.openDashboard(transac, pnlDash);
            transac.Location = currentForm.Location;
        }
        public void UserDashboard(Button button, Panel pnlDash, Form currentForm)
        {
            UserDashboard userDashboard = new UserDashboard();
            formManager.openDashboard(userDashboard, pnlDash);
            userDashboard.Location = currentForm.Location;
        }

        #endregion
    }
}
