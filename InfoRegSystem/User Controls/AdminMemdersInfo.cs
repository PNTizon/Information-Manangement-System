using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminMemdersInfo : UserControl
    {
        private AdminDashboard dashboard;
        private MembersFunctions functions;
        private Helpers helpers;
        private Display display;
        private DataGridSelection selection;
        private ButtonShadow shadow;

        public AdminMemdersInfo()
        {
            InitializeComponent();
            dashboard = new AdminDashboard();
            functions = new MembersFunctions();
            helpers = new Helpers();
            display = new Display();
            selection = new DataGridSelection();
            GunaButton();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            functions.DeleteMemberInfo(membergrid, Display, Clear, dashboard.displayMem);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            functions.SaveMemberInfo(txtName.Text, txtLastname.Text, int.Parse(txtAge.Text),
                genderbox.Text,
                countyCode,
                txtNumber.Text,
                txtAddress.Text,
                txtEmail.Text,
                Display, Clear,
                dashboard.displayMem);
        }
        private void btnUpdate(object sender, EventArgs e)
        {
            functions.UpdateMemberInfo(txtName.Text, txtLastname.Text, txtAge.Text,
                genderbox.Text, countyCode, txtNumber.Text, txtAddress.Text,
                txtEmail.Text, membergrid, Display, Clear, dashboard.displayMem);
        }
        private void Display()
        {
            display.DisplayMembers(membergrid);
        }
        public void RegistarionFormcs_Load(object sender, EventArgs e)
        {
            Display();
            LoadGenders();
            PhoneNumberList.ListPhneNumber(comboBox1_SelectedIndexChanged, CountryCodecmb);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            functions.MemberSearch(membergrid, search);
        }
        private void membergrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selection.MembersSelection(e.RowIndex, txtName, txtLastname, txtAge, countyCode, txtNumber, 
                txtAddress, txtEmail, genderbox, membergrid);
        }
        private void LoadGenders()
        {
            helpers.HelperGender(genderbox);
        }
        #region Helpers
        public void Clear()
        {
            functions.Cleaner(txtName, txtLastname, txtAge, txtEmail, txtAddress, txtNumber, countyCode, CountryCodecmb, genderbox);
        }
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            helpers.HelperNumberRestriction(txtNumber);
            helpers.isValidPhoneNumber(countyCode, txtNumber);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhoneNumberList.comboBox_autoModifier(comboBox1_SelectedIndexChanged, CountryCodecmb, countyCode);
        }
        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            helpers.HelperAge(txtAge);
        }
        private void GunaButton()
        {
            List<Guna2Button> gunabtn = new List<Guna2Button>
            {
                btnAdd,
                btnDetele,
                btnSearch,
                btnEdit
            };
            shadow = new ButtonShadow(gunabtn);
            shadow.CustomizeGunaButtons();
        }
        #endregion
        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            functions.MemberSearch(membergrid, search);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            helpers.UpperCase(txtName);
        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {
            helpers.UpperCase(txtLastname);
        }
    }
}
