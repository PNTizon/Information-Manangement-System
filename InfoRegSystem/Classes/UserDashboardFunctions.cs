using InfoRegSystem.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class UserDashboardFunctions
    {
        private UserDashboard userdash;
        private FormManager formManager;
        
        public UserDashboardFunctions()
        {
            formManager = new FormManager();
        }

        public void UserLogout(Button logoutbtn, Form currentForm)
        {
            Application.Restart();
        }
        public void UserBookInfo(Button bookbtn, Form currentForm, Panel pnlDash)
        {
            UserBook bookInfo = new UserBook();
            formManager.openDashboard(bookInfo, pnlDash);
            bookInfo.Location = currentForm.Location;
        }
        public void UserTransaction(Button transacbtn, Form currentForm, Panel pnlDash, UserMainForm Panel = null)
        {
            UserTransaction transac = new UserTransaction(Panel);
            formManager.openDashboard(transac, pnlDash);
            transac.Location = currentForm.Location;
        }
        public void UserDashboard(Button button, Panel pnlDash, Form currentForm)
        {
            UserDashboard userDashboard = new UserDashboard();
            formManager.openDashboard(userDashboard, pnlDash);
            userDashboard.Location = currentForm.Location;
        }
    }
}
