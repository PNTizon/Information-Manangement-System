using InfoRegSystem.Forms;
using System.Transactions;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class MainformFunctions
    {
        private FormManager formManager;
        private UserFormManager manager;

        public MainformFunctions()
        {
            formManager = new FormManager();
            manager =  new UserFormManager();
        }

        public void HandleBookInfoForm(Button bookbtn, Panel pnlDash)
        {
            AdminBookInfo bookInfoForm = new AdminBookInfo();
            formManager.openDashboard(bookInfoForm, pnlDash);
        }
        public void HandleLogout(Button logoutbtn, Form currentForm)
        {
            Application.Restart();
        }
        public void HandleMembers(Button membersbtn, Panel pnlDash)
        {
            AdminMemdersInfo membersInfoForm = new AdminMemdersInfo();  
            formManager.openDashboard(membersInfoForm, pnlDash);
        }
        public void HandleBorrowRecords(Button borrowbtn, Panel pnlDash)
        {
            AdminBorrowRecords records = new AdminBorrowRecords();
            formManager.openDashboard(records, pnlDash);
        }
        public void HandleDashboard(Button dashboardbtn, Panel pnlDash)
        {
            AdminDashboard dashboard = new AdminDashboard();
            formManager.openDashboard(dashboard,pnlDash);
        }
        public void HandleTransactions(Button transacbtn, Panel pnlDash)
        {
            AdminTransactions transac = new AdminTransactions();
            manager.openUserDashboard(transac, pnlDash);
        }
    }
}
