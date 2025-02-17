using InfoRegSystem.Forms;
using System.Transactions;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class MainformFunctions
    {
        public static void HandleBookInfoForm( Panel pnlDash)
        {
            AdminBookInfo bookInfoForm = new AdminBookInfo();
            FormManager.openDashboard(bookInfoForm, pnlDash);
        }
        public static void HandleLogout(Form currentForm)
        {
            Application.Restart();
        }
        public static void HandleMembers(Panel pnlDash)
        {
            AdminMemdersInfo membersInfoForm = new AdminMemdersInfo();  
            FormManager.openDashboard(membersInfoForm, pnlDash);
        }
        public static void HandleBorrowRecords( Panel pnlDash)
        {
            AdminBorrowRecords records = new AdminBorrowRecords();
            FormManager.openDashboard(records, pnlDash);
        }
        public static void HandleDashboard( Panel pnlDash)
        {
            AdminDashboard dashboard = new AdminDashboard();
            FormManager.openDashboard(dashboard,pnlDash);
        }
        public static void HandleTransactions( Panel pnlDash)
        {
            AdminTransactions transac = new AdminTransactions();
            UserFormManager.openUserDashboard(transac, pnlDash);
        }
    }
}
