using System;
using System.Windows.Forms;


namespace InfoRegSystem
{
    public partial class frmRegistration : Form
    {
        Dashboard dashboard;
        public frmRegistration(Dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }
        public frmRegistration()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "1234")
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Location = this.Location;
                dashboard.Show();
                Clear();
                this.Hide();
            }
            else
            {
                txtError.Text = "Invalid username or password!";
            }
        }
        private void Clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
