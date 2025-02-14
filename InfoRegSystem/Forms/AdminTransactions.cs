using InfoRegSystem.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminTransactions : Form
    {
        public AdminTransactions()
        {
            InitializeComponent();
        }

        private void AdminTransactions_Load(object sender, EventArgs e)
        {
            Display.Transaction(transactiongrid);
        }
        private void transactiongrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridSelection.TransactionSelection(transactiongrid,e.RowIndex);
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
           AdminTransactionFunctions.PaidButton(transactiongrid);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            AdminTransactionFunctions.SearchTransactions(transactiongrid, search);
        }
        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            AdminTransactionFunctions.SearchTransactions(transactiongrid, search);
        }
    }
}
