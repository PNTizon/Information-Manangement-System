using InfoRegSystem.Forms;
using System;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class FormManager
    {
        public Form activeForm = null;

        public void openDashboard(UserControl control, Panel container)
        {
            container.Controls.Clear();
            control.Dock = DockStyle.Fill;
            container.Controls.Add(control);
            control.BringToFront();
        }
    }
}
