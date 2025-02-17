using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{

    public class AccountRegistrationFunctions
    {
        private static FrmRegistration login;
        
        public static void Register(string firstname, string lastname, string address, string email, Guna2TextBox phoneNums, TextBox countryNums, string username,
          string password, ComboBox genderbox, TextBox error1, TextBox error3, TextBox error4, TextBox error5, TextBox error6, TextBox error7, TextBox error8, Form currentForm)
        {
            bool hasErrors = false;

            #region ErrorMessages
            if (!Helpers.isValidName(firstname) || !Helpers.isValidName(lastname))
            {
                error1.Text = "First name and last name are required and must contain only letters.";
                hasErrors = true;
            }
            else
            {
                error1.Text = "";
            }
            if (!Helpers.isValidGender(genderbox.Text))
            {
                error3.Text = "Gender must be 'Male', 'Female', or 'Other'.";
                hasErrors = true;
            }
            else
            {
                error3.Text = "";
            }
            if (!Helpers.isValidAddress(address))
            {
                error5.Text = "Address is required.";
                hasErrors = true;
            }
            else
            {
                error5.Text = "";
            }
            if (!Helpers.isValidEmail(email))
            {
                error6.Text = "Email must contain @gmail.com.";
                hasErrors = true;
            }
            else
            {
                error6.Text = "";
            }
            if (!Helpers.isValidUsername(username))
            {
                error7.Text = "Username must contain letters (a-z) and numbers.";
                hasErrors = true;
            }
            else
            {
                error7.Text = "";
            }
            if (!Helpers.isValidPassword(password))
            {
                error8.Text = "Password must be at least 8 characters long.";
                hasErrors = true;
            }
            else
            {
                error8.Text = "";
            }
            if (!Helpers.isValidPhoneNumber(countryNums, phoneNums))
            {
                error4.Text = "Contains 10-digit number with a valid country code.";
                hasErrors = true;
            }
            else
            {
                error4.Text = "";
            }
            #endregion

            if (hasErrors)
            {
                return;
            }

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Database))
            {
                sqlConnection.Open();

                using (SqlCommand checkUsernameCmd = new SqlCommand("CheckUsernameExists", sqlConnection))
                {
                    checkUsernameCmd.CommandType = CommandType.StoredProcedure;
                    checkUsernameCmd.Parameters.AddWithValue("@Username", username.Trim());
                    int userCount = (int)checkUsernameCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Username already taken. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sqlConnection.Close();
                        return;
                    }
                }
                DateTime day = DateTime.Today;

                using (SqlCommand cnn = new SqlCommand("InsertStudent", sqlConnection))
                {
                    cnn.CommandType = CommandType.StoredProcedure;
                    cnn.Parameters.AddWithValue("@name", firstname.Trim());
                    cnn.Parameters.AddWithValue("@lastname", lastname.Trim());
                    cnn.Parameters.AddWithValue("@gender", genderbox.Text);
                    cnn.Parameters.AddWithValue("@countrycode", countryNums.Text);
                    cnn.Parameters.AddWithValue("@phonenumber", phoneNums.Text);
                    cnn.Parameters.AddWithValue("@address", address.Trim());
                    cnn.Parameters.AddWithValue("@email", email.Trim());
                    cnn.Parameters.AddWithValue("@username", username.Trim());
                    cnn.Parameters.AddWithValue("@password", password.Trim());
                    cnn.Parameters.AddWithValue("@dateregister", day);

                    cnn.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            login = new FrmRegistration();
            login.Show();
            currentForm.Hide();
        }
    }
}
