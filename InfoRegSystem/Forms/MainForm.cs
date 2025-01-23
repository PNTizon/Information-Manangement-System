using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem
{
    public partial class MainForm : Form
    {
        private frmRegistration frmRegistration;
        private MainformFunctions mainfuntion;
        private ButtonShadow shadow;

        public MainForm()
        {
            InitializeComponent();
            mainfuntion = new MainformFunctions();
            SystemButton();
        }
        public MainForm(frmRegistration frmRegistration) : this() 
        {
            this.frmRegistration = frmRegistration;
        }
        private void btnBookInfo_Click(object sender, EventArgs e)
        {
            mainfuntion.HandleBookInfoForm(btnBookInfo, panel2);
        }
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            mainfuntion.HandleBorrowRecords(btnReturnBook, panel2);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            mainfuntion.HandleLogout(btnLogout, this);
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            mainfuntion.HandleMembers(btnRegister,  panel2);
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            mainfuntion.HandleDashboard(btnDashboard,  panel2);
        }
        public void SystemButton()
        {
            List<Button> buttons = new List<Button>
            {
                btnBookInfo,
                btnDashboard,
                btnLogout,
                btnRegister,
                btnReturnBook
            };
            shadow = new ButtonShadow(buttons);
            shadow.NormalButton();
        }
        private void adminDashboard1_Load(object sender, EventArgs e)
        {

        }
    }
}
