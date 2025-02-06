using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace InfoRegSystem.Forms
{
    public partial class AccountCreation : Form
    {
        private Helpers helpers;
        private ButtonShadow shadow;
        private frmRegistration login;

        public AccountCreation()
        {
            InitializeComponent();
            helpers = new Helpers();
            GunaButton();
        }

        private void AccCreation_Load(object sender, EventArgs e)
        {
            #region ReadOnly
            errorbox1.ReadOnly = true;
            //errorbox2.ReadOnly = true;
            errorbox3.ReadOnly = true;
            errorbox4.ReadOnly = true;
            errorbox5.ReadOnly = true;
            errorbox6.ReadOnly = true;
            errorbox7.ReadOnly = true;
            errorbox8.ReadOnly = true;
            countryNumbers.ReadOnly = true;
            #endregion
            helpers.HelperGender(cmbGender);

            PhoneNumberList.ListPhneNumber(cmbCountryCode_SelectedIndexChanged, cmbCountryCode);
        }


        #region Helpers
        private void hidepass_Click(object sender, EventArgs e)
        {
            helpers.HidePassword(showpass, hidepass, registration_pass);
        }
        private void showpass_Click(object sender, EventArgs e)
        {
            helpers.ShowPassord(showpass, hidepass, registration_pass);
        }
        #endregion

        private void createbtn_Click(object sender, EventArgs e)
        {
            bool hasErrors = false;

            #region ErrorMessages
            if (!helpers.isValidName(registration_firstname.Text) || !helpers.isValidName(registration_lastname.Text))
            {
                errorbox1.Text = "First name and last name are required and must contain only letters.";
                hasErrors = true;
            }
            else
            {
                errorbox1.Text = "";
            }
            if (!helpers.isValidGender(cmbGender.Text))
            {
                errorbox3.Text = "Gender must be 'Male', 'Female', or 'Other'.";
                hasErrors = true;
            }
            else
            {
                errorbox3.Text = "";
            }
            if (!helpers.isValidAddress(registration_house.Text))
            {
                errorbox5.Text = "Address is required.";
                hasErrors = true;
            }
            else
            {
                errorbox5.Text = "";
            }
            if (!helpers.isValidEmail(registration_emails.Text))
            {
                errorbox6.Text = "Email must contain @gmail.com.";
                hasErrors = true;
            }
            else
            {
                errorbox6.Text = "";
            }
            if (!helpers.isValidUsername(registration_username.Text))
            {
                errorbox7.Text = "Must contain one uppercase letter and numbers.";
                hasErrors = true;
            }
            else
            {
                errorbox7.Text = "";
            }
            if (!helpers.isValidPassword(registration_pass.Text))
            {
                errorbox8.Text = "Password must be at least 8 characters long.";
                hasErrors = true;
            }
            else
            {
                errorbox8.Text = "";
            }
            if (!helpers.isValidPhoneNumber(countryNumbers, registration_number))
            {
                errorbox4.Text = "Contains 10-digit number with a valid country code.";
                hasErrors = true;
            }
            else
            {
                errorbox4.Text = "";
            }
            #endregion

            if (hasErrors)
            {
                return;
            }

            using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
            {
                sqlConnection.Open();

                using (SqlCommand checkUsernameCmd = new SqlCommand("CheckUsernameExists", sqlConnection))
                {
                    checkUsernameCmd.CommandType = CommandType.StoredProcedure;
                    checkUsernameCmd.Parameters.AddWithValue("@Username", registration_username.Text.Trim());
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
                    cnn.Parameters.AddWithValue("@name", registration_firstname.Text.Trim());
                    cnn.Parameters.AddWithValue("@lastname", registration_lastname.Text.Trim());
                    cnn.Parameters.AddWithValue("@gender", cmbGender.Text.Trim());
                    cnn.Parameters.AddWithValue("@countrycode", countryNumbers.Text.Trim());
                    cnn.Parameters.AddWithValue("@phonenumber", registration_number.Text.Trim());
                    cnn.Parameters.AddWithValue("@address", registration_house.Text.Trim());
                    cnn.Parameters.AddWithValue("@email", registration_emails.Text.Trim());
                    cnn.Parameters.AddWithValue("@username", registration_username.Text.Trim());
                    cnn.Parameters.AddWithValue("@password", registration_pass.Text.Trim());
                    cnn.Parameters.AddWithValue("@dateregister", day);

                    cnn.ExecuteNonQuery();

                    sqlConnection.Close();
                }

                MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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
        private void cmbCountryCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhoneNumberList.comboBox_autoModifier(cmbCountryCode_SelectedIndexChanged, cmbCountryCode, countryNumbers);
        }
        #region Events
        private void registration_number_TextChanged(object sender, EventArgs e)
        {
            helpers.HelperNumberRestriction(registration_number);
        }
        private void registration_pass_TextChanged(object sender, EventArgs e)
        {
            helpers.PasswordHelper(registration_pass);
        }
        private void GunaButton()
        {
            List<Button> buttons = new List<Button>
            {
               button1
            };
            shadow = new ButtonShadow(buttons);
            shadow.NormalButton();
        }
        private void registration_firstname_Leave(object sender, EventArgs e)
        {
            helpers.UpperCase(registration_firstname);
        }
       
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void registration_lastname_TextChanged(object sender, EventArgs e)
        {
            helpers.UpperCase(registration_lastname);
        }

        private void registration_username_TextChanged_1(object sender, EventArgs e)
        {
            helpers.UpperCase(registration_username);
        }

        private void registration_pass_Leave_1(object sender, EventArgs e)
        {
            helpers.UpperCase(registration_pass);
        }
        #endregion
    }
}
