using InfoRegSystem.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class UserDashboard : UserControl
    {

        public UserDashboard()
        {
            InitializeComponent();
            BorrowRecords();
        }

        public void BorrowRecords()
        {
            UserDashboardFunctions.DisplayRecords(lblborrowed, lblreturned, lbldueboo);
        }
        private void UserDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
