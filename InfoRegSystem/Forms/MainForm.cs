using InfoRegSystem.Classes;
using System;
using System.Windows.Forms;

namespace InfoRegSystem
{
    public partial class MainForm : Form
    {
        //private readonly ButtonShadow shadow;

        public MainForm()
        {
            InitializeComponent();
        }
        private void btnBookInfo_Click(object sender, EventArgs e)
        {
            MainformFunctions.HandleBookInfoForm(btnBookInfo, panel2);
        }
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            MainformFunctions.HandleBorrowRecords(btnReturnBook, panel2);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            MainformFunctions.HandleLogout(btnLogout, this);
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            MainformFunctions.HandleMembers(btnRegister, panel2);
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MainformFunctions.HandleDashboard(btnDashboard, panel2);
        }
        private void btnTransactions_Click_1(object sender, EventArgs e)
        {
            MainformFunctions.HandleTransactions(btnTransactions, panel2);
        }
    }
}
