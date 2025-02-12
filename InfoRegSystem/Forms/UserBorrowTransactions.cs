using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class UserBorrowTransactions : Form
    {
        private Helpers helper;
        private ButtonShadow shadow;
        public UserBorrowTransactions()
        {
            InitializeComponent();
            helper = new Helpers();
            GunaButton();
        }

        private void GunaButton()
        {
            List<Guna2Button> gunabtn = new List<Guna2Button>
            {
                btnBorrow
            };
            shadow = new ButtonShadow(gunabtn);
            shadow.CustomizeGunaButtons();
        }
        private void UserBorrowTransactions_Load(object sender, EventArgs e)
        {
            Helpers.DurationHelper(cmbDuration);
        }
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            UserBorrowTransactionFunctions.Borrowbtn(txtBook.Text, borrowDate.Value, cmbDuration.Text);
            UserBorrowTransactionFunctions.Clear(txtBook,cmbDuration);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
