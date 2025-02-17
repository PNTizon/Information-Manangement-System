using InfoRegSystem.Classes;
using System;
using System.Windows.Forms;

namespace InfoRegSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void BookInfobtn_Click(object sender, EventArgs e)
        {
            MainformFunctions.HandleBookInfoForm(panel2);
        }
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            MainformFunctions.HandleBorrowRecords( panel2);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            MainformFunctions.HandleLogout( this);
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            MainformFunctions.HandleMembers( panel2);
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MainformFunctions.HandleDashboard( panel2);
        }
        private void btnTransactions_Click_1(object sender, EventArgs e)
        {
            MainformFunctions.HandleTransactions( panel2);
        }
    }
}
