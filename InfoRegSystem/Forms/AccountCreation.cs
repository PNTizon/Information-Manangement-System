using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace InfoRegSystem.Forms
{
    public partial class AccountCreation : Form
    {
        public AccountCreation()
        {
            InitializeComponent();
        }

        private void AccCreation_Load(object sender, EventArgs e)
        {
            #region Error Box ReadOnly
            errorbox1.ReadOnly = true;
            errorbox2.ReadOnly = true;
            errorbox3.ReadOnly = true;
            errorbox4.ReadOnly = true;
            errorbox5.ReadOnly = true;
            errorbox6.ReadOnly = true;
            errorbox7.ReadOnly = true;
            errorbox8.ReadOnly = true;
            #endregion
            LoadGender();
        }

        #region Validations
        private bool isValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }
        private bool isValidAge(string age)
        {
            return int.TryParse(age, out int num)
                && num > 13 && num <= 50;
        }
        private bool isValidGender(string gender)
        { return gender == "Male" || gender == "Female" || gender == "Other"; }
        private bool isValidStreet(string street)
        {
            return !string.IsNullOrEmpty(street);
        }
        private bool isValidEmail(string email)
        {
            return email.EndsWith("@gmail.com") && email.Contains("@");
        }
        private bool isValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]{5,15}$");
        }
        private bool isValidPassword(string password)
        {
            return password.Length >= 8;
        }

        private void registration_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
        #region Helpers
        private void hidepass_Click(object sender, EventArgs e)
        {
            showpass.Show();
            hidepass.Hide();

            registration_pass.PasswordChar = '\0';
        }
        private void showpass_Click(object sender, EventArgs e)
        {
            showpass.Hide();
            hidepass.Show();

            registration_pass.PasswordChar = '●';
        }
        #endregion
        private void LoadGender()
        {
            List<string> gender = new List<string> { "Male", "Female", "Others" };
            cmbGender.DataSource = gender;
            cmbGender.SelectedIndex = -1;
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            bool hasErrors = false; 

            #region ErrorMessages
            if (!isValidName(registration_firstname.Text) || !isValidName(registration_lastname.Text))
            {
                errorbox1.Text = "First name and last name are required and must contain only letters.";
                hasErrors = true;
            }
            else
            {
                errorbox1.Text = "";
            }
            if (!int.TryParse(registration_ages.Text.Trim(), out int age))
            {
                errorbox2.Text = "Age must be a valid number between 13 and 50.";
                hasErrors = true;
            }
            else if (age < 13 || age > 50)
            {
                errorbox2.Text = "Age must be between 13 and 50.";
                hasErrors = true;
            }
            else
            {
                errorbox2.Text = "";
            }
            if (!isValidGender(cmbGender.Text))
            {
                errorbox3.Text = "Gender must be 'Male', 'Female', or 'Other'.";
                hasErrors = true;
            }
            else
            {
                errorbox3.Text = "";
            }
            if (!isValidStreet(registration_house.Text))
            {
                errorbox5.Text = "Address is required.";
                hasErrors = true;
            }
            else
            {
                errorbox5.Text = "";
            }
            if (!isValidEmail(registration_emails.Text))
            {
                errorbox6.Text = "Email must contain @gmail.com.";
                hasErrors = true;
            }
            else
            {
                errorbox6.Text = "";
            }
            if (!isValidUsername(registration_username.Text))
            {
                errorbox7.Text = "Username must contain letters (a-z) and numbers.";
                hasErrors = true;
            }
            else
            {
                errorbox7.Text = "";
            }
            if (!isValidPassword(registration_pass.Text))
            {
                errorbox8.Text = "Password must be at least 8 characters long.";
                hasErrors = true;
            }
            else
            {
                errorbox8.Text = "";
            }
            #endregion

            if (hasErrors)
            {
                return;
            }

            SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);
            sqlConnection.Open();

            // Check if username already exists
            using (SqlCommand checkUsernameCmd = new SqlCommand( "CheckUsernameExists", sqlConnection))
            {
                checkUsernameCmd.Parameters.AddWithValue("@username", registration_username.Text.Trim());
                int userCount = (int)checkUsernameCmd.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Username already taken. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlConnection.Close();
                    return;
                }
            }
            //TO GET THE DATE TODAY
            DateTime day = DateTime.Today;

            using (SqlCommand cnn = new SqlCommand ( "InsertStudent",  sqlConnection))
            {
                cnn.CommandType = CommandType.StoredProcedure;
                cnn.Parameters.AddWithValue("@name", registration_firstname.Text.Trim());
                cnn.Parameters.AddWithValue("@lastname", registration_lastname.Text.Trim());
                cnn.Parameters.AddWithValue("@age", age);
                cnn.Parameters.AddWithValue("@gender", cmbGender.Text.Trim());
                cnn.Parameters.AddWithValue("@countrycode", cmbCountryCode.Text.Trim());
                cnn.Parameters.AddWithValue("@phonenum", registration_number.Text.Trim());
                cnn.Parameters.AddWithValue("@address", registration_house.Text.Trim());
                cnn.Parameters.AddWithValue("@email", registration_emails.Text.Trim());
                cnn.Parameters.AddWithValue("@username", registration_username.Text.Trim());
                cnn.Parameters.AddWithValue("@password", registration_pass.Text.Trim());
                cnn.Parameters.AddWithValue("@dateregister", day);

                cnn.ExecuteNonQuery();
            }

            sqlConnection.Close();

            MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmRegistration reg = new frmRegistration();
            reg.Show();
            this.Hide();
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            frmRegistration reg = new frmRegistration();
            reg.Show();
            this.Hide();
        }
    }
}
