using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminDashboard : UserControl
    {
        private ButtonShadow shadow;
        public AdminDashboard()
        {
            InitializeComponent();
            BorrowRecords();
            TotalMembers();
            GunaButton();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadbookslist();
        }
        public void TotalMembers()
        {
            AdminDashboardFunctions.DisplayMembers(lblTotalMem);
        }
        public void BorrowRecords()
        {
            AdminDashboardFunctions.DisplayRecords(lblBorrowBoo, lblReturnBoo, lblduebooks);
        }
        public void loadbookslist()
        {
            Display.DisplayBooks(dataGridViewBookInfo);
        }
        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            AdminDashboardFunctions.HandleSearch(dataGridViewBookInfo, search);
        }
        private void GunaButton()
        {
            List<Guna2Button> gunabtn = new List<Guna2Button>
            {
                btnSearch
            };
            shadow = new ButtonShadow(gunabtn);
            shadow.CustomizeGunaButtons();
        }
        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            AdminDashboardFunctions.HandleSearch(dataGridViewBookInfo, search);
        }
    }
}
