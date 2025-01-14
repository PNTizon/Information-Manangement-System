using InfoRegSystem.Classes;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace InfoRegSystem.Forms
{
    public partial class UserMainForm : Form
    {
        private frmRegistration frmRegistration;
        private UserDashboardFunctions functions;
        private FormManager formManager;
        public UserMainForm()
        {
            InitializeComponent();
            formManager = new FormManager();
            functions = new UserDashboardFunctions();
        }
        public UserMainForm(frmRegistration frmRegistration) : this()
        {
            this.frmRegistration = frmRegistration;
        }
        private void bookinfobtn_Click(object sender, EventArgs e)
        {
            functions.UserBookInfo(bookinfobtn, this, userpnlDash);
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            functions.UserTransaction(returnbtn, this, userpnlDash);
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            functions.UserLogout(logoutbtn, this);
        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            functions.UserDashboard(btnDasboard, userpnlDash,this);
        }
    }
}
