using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using InfoRegSystem.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoRegSystem.User_Controls
{
    public partial class UserBorrowing : UserControl
    {
        private ButtonShadow shadow;
        private readonly UserMainForm userMainForm;

        public UserBorrowing(UserMainForm exisitngPanel)
        {
            InitializeComponent();
            userMainForm = exisitngPanel;
            GunaButton();
        }
        private void GunaButton()
        {
             List<Guna2Button> gunabtn = new List<Guna2Button>
             {
                 BtnBorrow,
                 BtnReturn
             };
                shadow = new ButtonShadow(gunabtn);
                shadow.CustomizeGunaButtons();
        }
       
        private void BtnBorrow_Click(object sender, EventArgs e)
        {
            UserTransactionFunction.BorrowTransaction(userpanel);
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            UserDashboard dash = new UserDashboard();
            UserTransactionFunction.RetunTransaction(transactiongrid, dash.BorrowRecords);
        }

        private void transactiongrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridSelection.TransactionSelection(transactiongrid, e.RowIndex);
        }

        private void UserBorrowing_Load(object sender, EventArgs e)
        {
            Display.DisplayUserTransaction(transactiongrid);
        }
    }
}
