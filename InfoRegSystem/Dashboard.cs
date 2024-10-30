using System;
using System.Windows.Forms;

namespace InfoRegSystem
{
    public partial class Dashboard : Form
    {
        private frmRegistration frmRegistration;

        public Dashboard()
        {
            InitializeComponent();
            customizeDesign();
        }
        public Dashboard(frmRegistration frmRegistration)
        {
            this.frmRegistration = frmRegistration;
        }
        public void customizeDesign()
        {
            pnlBooks.Visible = false;
            panel1.Visible = false;
        }
        private void hideSubMenu()
        {
            if (pnlBooks.Visible == true)
                pnlBooks.Visible = false;
            if (panel1.Visible == true)
                panel1.Visible = false;
        }
        private void showSubMenu(Panel subMEnu)
        {
            if (subMEnu.Visible == false)
            {
                hideSubMenu();
                subMEnu.Visible = true;
            }
            else
                subMEnu.Visible = false;
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            showSubMenu(panel1);
        }
        private void btnBooks_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlBooks);
        }
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Location = this.Location;

            mainForm.Show();

            hideSubMenu();
        }
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            BorrowForm borrowForm = new BorrowForm();
            borrowForm.Location = this.Location;

            borrowForm.Show();

            hideSubMenu();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmRegistration registarionform = new frmRegistration();

            registarionform.Show();
            this.Close();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistarionFormcs registarionform = new RegistarionFormcs();
            registarionform.Location = this.Location;

            registarionform.Show();
            hideSubMenu();
        }

    }
}
