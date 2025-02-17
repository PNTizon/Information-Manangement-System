using Guna.UI2.WinForms;
using InfoRegSystem.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class LoginButtonFunctions
    {
        public static void HandleLogin(Guna2TextBox usernameTextBox, Guna2TextBox passwordTextBox, TextBox errorLabel, Form currentForm)
        {
            const string adminUsername = "Admin";
            const string adminPassword = "admin123";

            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                errorLabel.Text = "Please fill all the blank fields.";
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
                    using (SqlConnection sqlConnection = new SqlConnection(Connection.Database))
                    {
                        sqlConnection.Open();

                        using (SqlCommand cmd = new SqlCommand("GetUserDetails", sqlConnection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", usernameTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", passwordTextBox.Text.Trim());

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
        public static void HandleRegister(Form currentForm)
        {
            AccountCreation regis = new AccountCreation();
            regis.Show();
            currentForm.Hide();
        }
    }
}
