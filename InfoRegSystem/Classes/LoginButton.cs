using InfoRegSystem.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class LoginButton
    {
        private frmRegistration registration;
        private MainForm mainform;
        private FormManager formManager;
       

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
    }
}
