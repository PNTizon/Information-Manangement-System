using InfoRegSystem.Classes;
using InfoRegSystem.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace InfoRegSystem
{
    public partial class frmRegistration : Form
    {
        private ButtonHandler buttonHandler;
        public frmRegistration()
        {
            InitializeComponent();
            buttonHandler = new ButtonHandler();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            buttonHandler.HandleLogin(login_username, login_password, txtError, this);
        }
        private void registerbtn_Click(object sender, EventArgs e)
        {
            buttonHandler.HandleRegister(registerbtn, this);
        }

        private void Clear()
        {
            login_username.Clear();
            login_password.Clear();
        }
        private void picShow_Click(object sender, EventArgs e)
        {
            picShow.Hide();
            picPass.Show();

            login_password.PasswordChar = '●';
        }
        private void picPass_Click(object sender, EventArgs e)
        {
            picPass.Hide();
            picShow.Show();
             
            login_password.PasswordChar = '\0';
        }
    }
}
