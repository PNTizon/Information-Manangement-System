using InfoRegSystem.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminTransactions : Form
    {
        private Display display = new Display();
        private AdminTransactionFinctions functions =  new AdminTransactionFinctions();

        public AdminTransactions()
        {
            InitializeComponent();
        }

        private void AdminTransactions_Load(object sender, EventArgs e)
        {
            display.Transaction(transactiongrid);
        }

        private void transactiongrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
           functions.PaidButton(transactiongrid);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            functions.SearchTransactions(transactiongrid, search);
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            functions.SearchTransactions(transactiongrid, search);
        }
    }
}
