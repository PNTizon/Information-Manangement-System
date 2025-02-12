using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace InfoRegSystem.Forms
{
    public partial class UserMainForm : Form
    {
        public Panel dashboardPanel { get { return userpnlDash; } }
        //private frmRegistration frmRegistration;
        private ButtonShadow shadow;
        public UserMainForm()
        {
            InitializeComponent();
        }
        private void bookinfobtn_Click(object sender, EventArgs e)
        {
            UserDashboardFunctions.UserBookInfo(bookinfobtn, this, userpnlDash);
        }
        private void returnbtn_Click(object sender, EventArgs e)
        {
            UserDashboardFunctions.UserTransaction(returnbtn, this, userpnlDash);
        }
        private void logoutbtn_Click(object sender, EventArgs e)
        {
            UserDashboardFunctions.UserLogout(logoutbtn, this);
        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            UserDashboardFunctions.UserDashboard(btnDasboard, userpnlDash,this);
        }
        private void UserMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
