using InfoRegSystem.Classes;
using System;
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

        public AdminMemdersInfo()
        {
            InitializeComponent();
            dashboard = new AdminDashboard();
            functions = new MembersFunctions();
            helpers = new Helpers();
            display = new Display();
            selection = new DataGridSelection();
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
            DateTime currentDate = DateTime.Now;
            functions.UpdateMemberInfo(txtName.Text, txtLastname.Text, txtAge.Text,
                genderbox.Text, countyCode, txtNumber.Text, txtAddress.Text,
                txtEmail.Text, currentDate, membergrid, Display, Clear, dashboard.displayMem);
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
            functions.MemberSearch(membergrid, searchbox);
        }
        private void membergrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selection.MembersSelection(e.RowIndex, txtName, txtLastname, txtAge, CountryCodecmb, txtNumber, txtAddress, txtEmail, genderbox, membergrid);
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
        public void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            helpers.HelperKeypress(e);
        }
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            helpers.HelperKeypress(e);
        }
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            helpers.HelperNumberRestriction(txtNumber);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhoneNumberList.comboBox_autoModifier(comboBox1_SelectedIndexChanged, CountryCodecmb, countyCode);
        }
        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            helpers.HelperAge(txtAge);
        }
        #endregion
    }
}
