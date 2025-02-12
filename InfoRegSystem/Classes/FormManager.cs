using InfoRegSystem.Forms;
using System;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class FormManager
    {
        public static Form activeForm = null;

        public static void openDashboard(UserControl control, Panel container)
        {
            container.Controls.Clear();
            control.Dock = DockStyle.Fill;
            container.Controls.Add(control);
            control.BringToFront();
        }
    }
}
