using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace InfoRegSystem.Forms
{
    public partial class AccountCreation : Form
    {
        private ButtonShadow shadow;
        private AccountRegistrationFunctions function = new AccountRegistrationFunctions();
        private Helpers helper = new Helpers();

        public AccountCreation()
        {
            InitializeComponent();
            GunaButton();
        }

        private void AccCreation_Load(object sender, EventArgs e)
        {
            helper.SetReadOnly(errorbox1, errorbox3, errorbox4, errorbox5, errorbox6, errorbox7, errorbox8, countryNumbers);
            helper.HelperGender(cmbGender);
            PhoneNumberList.ListPhneNumber(CmbCountryCode_SelectedIndexChanged, cmbCountryCode);
            ActiveControl = registration_firstname;
        }
        private void hidepass_Click(object sender, EventArgs e)
        {
            helper.HidePassword(showpass, hidepass, registration_pass);
        }
        private void Showpass_Click(object sender, EventArgs e)
        {
            helper.ShowPassord(showpass, hidepass, registration_pass);
        }
        private void createbtn_Click(object sender, EventArgs e)
        {
            function.Register(registration_firstname.Text, registration_lastname.Text, registration_house.Text, registration_emails.Text, registration_number,
                countryNumbers, registration_username.Text, registration_pass.Text, cmbGender, errorbox1, errorbox3, errorbox4, errorbox5,  errorbox6, errorbox7, errorbox8, this);
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            function.Login(this);
        }
        private void CmbCountryCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhoneNumberList.ComboBox_autoModifier(CmbCountryCode_SelectedIndexChanged, cmbCountryCode, countryNumbers);
        }
        #region Events
        private void registration_number_TextChanged(object sender, EventArgs e)
        {
            helper.HelperNumberRestriction(registration_number);
        }
        private void Registration_pass_TextChanged(object sender, EventArgs e)
        {
            helper.PasswordHelper(registration_pass);
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
            helper.UpperCase(registration_firstname);
        }
        private void Registration_lastname_Leave(object sender, EventArgs e)
        {
            helper.UpperCase(registration_lastname);
        }
        private void Registration_username_Leave(object sender, EventArgs e)
        {
            helper.UpperCase(registration_username);
        }
        #endregion
        private void CmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
