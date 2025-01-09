using InfoRegSystem.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace InfoRegSystem
{
    public partial class MainForm : Form
    {
        private frmRegistration frmRegistration;
        private FormManager formManager;
        private MainformFunctions mainFuction;
        

        public MainForm()
        {
            InitializeComponent();
            formManager = new FormManager();
            mainFuction = new MainformFunctions();
        }
        public MainForm(frmRegistration frmRegistration) : this()
        {
            this.frmRegistration = frmRegistration;
        }
        private void btnBookInfo_Click(object sender, EventArgs e)
        {
            mainFuction.HandleBookInfoForm(btnBookInfo, this, panel2);
        }
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            mainFuction.HandleReturnBook(btnReturnBook, panel2);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            mainFuction.HandleLogout(btnLogout, this);
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            mainFuction.HandleMembership(btnRegister, panel2, this);
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            mainFuction.HandleDashboard(btnDashboard, panel2, this);
        }

        private void adminDashboard1_Load(object sender, EventArgs e)
        {

        }
    }
}
