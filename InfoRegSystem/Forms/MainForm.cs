using InfoRegSystem.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem
{
    public partial class MainForm : Form
    {
        private frmRegistration frmRegistration;
        private ButtonHandler handler;
        private FormManager formManager;

        public MainForm()
        {
            InitializeComponent();
            formManager = new FormManager();
            handler = new ButtonHandler();
        }
        public MainForm(frmRegistration frmRegistration) : this()
        {
            this.frmRegistration = frmRegistration;
        }
        private void btnBookInfo_Click(object sender, EventArgs e)
        {
            handler.HandleBookInfoForm(btnBookInfo, this, panel2);
        }
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            handler.HandleReturnBook(btnReturnBook, panel2);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            handler.HandleLogout(btnLogout, this);
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            handler.HandleMembership(btnRegister, panel2, this);
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            handler.HandleDashboard(btnDashboard, panel2, this);
        }
    }
}
