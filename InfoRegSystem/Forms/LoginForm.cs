using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace InfoRegSystem
{
    public partial class FrmRegistration : Form
    {
        private ButtonShadow shadow;

        public FrmRegistration()
        {
            InitializeComponent();
            SystemButton();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginButtonFunctions.HandleLogin(login_username, login_password, txtError, this);
        }
        private void registerbtn_Click(object sender, EventArgs e)
        {
            LoginButtonFunctions.HandleRegister( this);
        }
        private void picShow_Click(object sender, EventArgs e)
        {
            Helpers.ShowPassord(picShow, picPass, login_password);
        }
        private void picPass_Click(object sender, EventArgs e)
        {
            Helpers.HidePassword(picShow, picPass, login_password);
        }
        private void SystemButton()
        {
            List<Button> buttons = new List<Button>
            {
                registerbtn
            };
            shadow = new ButtonShadow(buttons);
            shadow.NormalButton();
        }
        private void frmRegistration_Load(object sender, EventArgs e)
        {
            txtError.ReadOnly = true;
            ActiveControl = login_username;
        }
        private void login_username_Leave_1(object sender, EventArgs e)
        {
            Helpers.UpperCase(login_username);
        }
    }
}
