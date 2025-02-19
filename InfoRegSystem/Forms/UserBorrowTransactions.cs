using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class UserBorrowTransactions : Form
    {
        private Helpers helper = new Helpers();
        private ButtonShadow shadow;
        private UserBorrowTransactionFunctions function = new UserBorrowTransactionFunctions();
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
            helper.DurationHelper(cmbDuration);
            Display.DisplayBooks(bookgrid);
        }
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            function.Borrowbtn(txtBook.Text, borrowDate.Value, cmbDuration.Text);
            function.Clear(txtBook,cmbDuration);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bookgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridSelection.BorrowBookSelection(bookgrid, e.RowIndex,txtBook);
        }
    }
}
