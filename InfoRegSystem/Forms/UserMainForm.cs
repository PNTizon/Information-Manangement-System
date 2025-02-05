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
        private frmRegistration frmRegistration;
        private UserDashboardFunctions functions;
        private FormManager formManager;
        private ButtonShadow shadow;
        public UserMainForm()
        {
            InitializeComponent();
            formManager = new FormManager();
            functions = new UserDashboardFunctions();
            //NormalButton();
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
        //private void NormalButton()
        //{
        //    List<Button> buttons = new List<Button>
        //    {
        //        btnDasboard,
        //        bookinfobtn,
        //        returnbtn,
        //        logoutbtn
        //    };
        //    shadow = new ButtonShadow(buttons);
        //    shadow.NormalButton();
        //}

        private void UserMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
