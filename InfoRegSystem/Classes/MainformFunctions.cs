using InfoRegSystem.Forms;
using System.Transactions;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class MainformFunctions
    {
        public static void HandleBookInfoForm(Button bookbtn, Panel pnlDash)
        {
            AdminBookInfo bookInfoForm = new AdminBookInfo();
            FormManager.openDashboard(bookInfoForm, pnlDash);
        }
        public static void HandleLogout(Button logoutbtn, Form currentForm)
        {
            Application.Restart();
        }
        public static void HandleMembers(Button membersbtn, Panel pnlDash)
        {
            AdminMemdersInfo membersInfoForm = new AdminMemdersInfo();  
            FormManager.openDashboard(membersInfoForm, pnlDash);
        }
        public static void HandleBorrowRecords(Button borrowbtn, Panel pnlDash)
        {
            AdminBorrowRecords records = new AdminBorrowRecords();
            FormManager.openDashboard(records, pnlDash);
        }
        public static void HandleDashboard(Button dashboardbtn, Panel pnlDash)
        {
            AdminDashboard dashboard = new AdminDashboard();
            FormManager.openDashboard(dashboard,pnlDash);
        }
        public static void HandleTransactions(Button transacbtn, Panel pnlDash)
        {
            AdminTransactions transac = new AdminTransactions();
            UserFormManager.openUserDashboard(transac, pnlDash);
        }
    }
}
