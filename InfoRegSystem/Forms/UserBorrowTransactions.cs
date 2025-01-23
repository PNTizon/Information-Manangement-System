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
        private UserBorrowTransactionFunctions functions;
        public UserBorrowTransactions()
        {
            InitializeComponent();
            helper = new Helpers();
            functions = new UserBorrowTransactionFunctions();
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
            helper.DurationHelper(cmbDuration);
        }
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            functions.Borrowbtn(txtBook.Text, borrowDate.Value, cmbDuration.Text);
            functions.Clear(txtBook,cmbDuration);
        }
    }
}
