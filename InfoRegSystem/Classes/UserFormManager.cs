using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class UserFormManager
    {
        public static  Form activeForm = null;

        public static void openUserDashboard(Form control, Panel container)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = control;
            container.Controls.Clear();
            control.TopLevel = false;
            control.FormBorderStyle = FormBorderStyle.None;
            control.Dock = DockStyle.Fill;
            container.Controls.Add(control);
            container.Tag = control;
            control.BringToFront();
            control.Show();
        }
    }
}
