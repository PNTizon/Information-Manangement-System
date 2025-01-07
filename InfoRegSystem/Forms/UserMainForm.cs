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
        private ButtonHandler handler;
        private FormManager formManager;
        public UserMainForm()
        {
            InitializeComponent();
            formManager = new FormManager();
            handler = new ButtonHandler();
        }
        public UserMainForm(frmRegistration frmRegistration) : this()
        {
            this.frmRegistration = frmRegistration;
        }
        private void bookinfobtn_Click(object sender, EventArgs e)
        {
            handler.UserBookInfo(bookinfobtn, this, userpnlDash);
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            handler.UserTransaction(returnbtn, this, userpnlDash);
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            handler.UserLogout(logoutbtn, this);
        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            handler.UserDashboard(btnDasboard, userpnlDash,this);
        }
    }
}
