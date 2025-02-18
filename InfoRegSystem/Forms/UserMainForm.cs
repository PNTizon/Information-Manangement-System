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
        public UserMainForm()
        {
            InitializeComponent();
        }
        private void bookinfobtn_Click(object sender, EventArgs e)
        {
            UserDashboardFunctions.UserBookInfo( this, userpnlDash);
        }
        private void Returnbtn_Click(object sender, EventArgs e)
        {
            UserDashboardFunctions.UserBorrowing( this, userpnlDash);
        }
        private void logoutbtn_Click(object sender, EventArgs e)
        {
            UserDashboardFunctions.UserLogout( this);
        }
        private void btnDasboard_Click(object sender, EventArgs e)
        {
            UserDashboardFunctions.UserDashboard( userpnlDash,this);
        }
        private void UserMainForm_Load(object sender, EventArgs e)
        {

        }
       
        private void BtnTransaction_Click(object sender, EventArgs e)
        {
            UserDashboardFunctions.UserTransaction(this, userpnlDash);
        }
    }
}
