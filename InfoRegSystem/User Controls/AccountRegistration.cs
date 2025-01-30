using InfoRegSystem.Classes;
using InfoRegSystem.Forms;
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
    public partial class AccountRegistration : UserControl
    {
        private AdminMemdersInfo function;

        public AccountRegistration()
        {
            InitializeComponent();
            function = new AdminMemdersInfo();
        }

    }
}
