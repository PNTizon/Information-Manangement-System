using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace InfoRegSystem.Forms
{
    public partial class AccountCreation : Form
    {
        private ButtonShadow shadow;

        public AccountCreation()
        {
            InitializeComponent();
            GunaButton();
        }

        private void AccCreation_Load(object sender, EventArgs e)
        {
            #region ReadOnly
            errorbox1.ReadOnly = true;  errorbox3.ReadOnly = true; errorbox4.ReadOnly = true;errorbox5.ReadOnly = true;
            errorbox6.ReadOnly = true;  errorbox7.ReadOnly = true; errorbox8.ReadOnly = true;countryNumbers.ReadOnly = true;
            #endregion
            Helpers.HelperGender(cmbGender);

            PhoneNumberList.ListPhneNumber(cmbCountryCode_SelectedIndexChanged, cmbCountryCode);

            ActiveControl = registration_firstname;
        }
        private void hidepass_Click(object sender, EventArgs e)
        {
            Helpers.HidePassword(showpass, hidepass, registration_pass);
        }
        private void showpass_Click(object sender, EventArgs e)
        {
            Helpers.ShowPassord(showpass, hidepass, registration_pass);
        }
        private void createbtn_Click(object sender, EventArgs e)
        {
            AccountRegistrationFunctions.Register(registration_firstname.Text, registration_lastname.Text, registration_house.Text, registration_emails.Text,
                registration_number,  countryNumbers, registration_username.Text, registration_pass.Text, cmbGender, errorbox1, errorbox3,
                errorbox4, errorbox5, errorbox6, errorbox7, errorbox8, this);
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
            Helpers.HelperNumberRestriction(registration_number);
        }
        private void registration_pass_TextChanged(object sender, EventArgs e)
        {
            Helpers.PasswordHelper(registration_pass);
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
        private void registration_firstname_Leave_1(object sender, EventArgs e)
        {
            Helpers.UpperCase(registration_firstname);
        }
        private void registration_lastname_Leave(object sender, EventArgs e)
        {
            Helpers.UpperCase(registration_lastname);
        }
        private void registration_username_Leave(object sender, EventArgs e)
        {
            Helpers.UpperCase(registration_username);
        }
        #endregion
    }
}
