using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace InfoRegSystem
{
    public partial class frmRegistration : Form
    {
        private LoginButton login;
        private ButtonShadow shadow;
        private Helpers helpers = new Helpers();

        public frmRegistration()
        {
            InitializeComponent();
            login = new LoginButton();
            SystemButton();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login.HandleLogin(login_username, login_password, txtError, this);
        }
        private void registerbtn_Click(object sender, EventArgs e)
        {
            login.HandleRegister(registerbtn, this);
        }
        private void picShow_Click(object sender, EventArgs e)
        {
            helpers.ShowPassord(picShow, picPass, login_password);
        }
        private void picPass_Click(object sender, EventArgs e)
        {
            helpers.HidePassword(picShow, picPass, login_password);
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
        }
        private void login_username_TextChanged(object sender, EventArgs e)
        {
            helpers.UpperCase(login_username);
        }
    }
}
