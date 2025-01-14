using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace InfoRegSystem.Forms
{
    public partial class UserTransaction : UserControl
    {
        private UserDashboard formdash;
        private UserTransactionFunction function;
        private Display display;
        private DataGridSelection selection;
        private UserBorrowTransactions transaction;
      
        public UserTransaction()
        {
            InitializeComponent();
            function = new UserTransactionFunction();
            display = new Display();
            selection = new DataGridSelection();
            transaction = new UserBorrowTransactions();
        }
        public UserTransaction( UserDashboard formdash)
        {
            this.formdash = formdash;
        }
        private void returnbtn_Click(object sender, EventArgs e)
        {
            function.RetunTransaction(transactiongrid,formdash.DisplayBorrow);
        }
        //ON PROCESS
        private void borrowedbtn_Click(object sender, EventArgs e)
        {
           UserBorrowTransactions transactions = new UserBorrowTransactions();
            transaction.Show();
            transactions.Location = this.Location;
        }
        private void transactiongrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selection.TransactionSelection(transactiongrid,e.RowIndex);
        }

        private void UserTransac_Load(object sender, EventArgs e)
        {
            display.DisplayUserTransaction(transactiongrid);
        }
    }
}
