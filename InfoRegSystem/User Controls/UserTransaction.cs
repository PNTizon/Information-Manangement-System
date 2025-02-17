using Guna.UI2.WinForms;
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
        private ButtonShadow shadow;
        private readonly UserMainForm userMainForm;

        public UserTransaction(UserMainForm exisitngPanel)
        {
            InitializeComponent();
            userMainForm = exisitngPanel;
            GunaButton();
        }
        
        private void borrowedbtn_Click(object sender, EventArgs e)
        {
            UserTransactionFunction.BorrowTransaction( userpanel);
        }
        private void Transactiongrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridSelection.TransactionSelection(transactiongrid,e.RowIndex);
        }
        private void UserTransac_Load(object sender, EventArgs e)
        {
            Display.DisplayUserTransaction(transactiongrid);
        }
        private void GunaButton()
        {
            List<Guna2Button> gunabtn = new List<Guna2Button>
            {
                borrowedbtn,
                Returnbtn
            };
            shadow = new ButtonShadow(gunabtn);
            shadow.CustomizeGunaButtons();
        }
        private void Returnbtn_Click(object sender, EventArgs e)
        {
            UserDashboard dash = new UserDashboard();
            UserTransactionFunction.RetunTransaction(transactiongrid, dash.BorrowRecords);
        }
    }
}
