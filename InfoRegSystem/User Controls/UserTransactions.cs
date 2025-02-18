using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoRegSystem.User_Controls
{
    public partial class UserTransactions : UserControl
    {
        public UserTransactions()
        {
            InitializeComponent();
        }

        private void UserTransactions_Load(object sender, EventArgs e)
        {
            Display.UserTransaction(transactiongrid);
        }

        private void transactiongrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
