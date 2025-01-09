using InfoRegSystem.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminMemdersInfo : UserControl
    {
        private AdminDashboard dashboard ;
        private ButtonHandler handler;
        private Helpers helpers = new Helpers();
        public AdminMemdersInfo()
        {
            InitializeComponent();

        }
        //ON PROCESS
        private void btnDelete_Click(object sender, EventArgs e)
        {
            AdminDashboard dashboard = new AdminDashboard();
            if (dashboard != null)
            {
                handler.DeleteMemberInfo(membergrid, Display, Clear, dashboard.displayMem);
            }
            else 
            {
                MessageBox.Show("Dashboard is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

        }
        //ON PROCESS
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dashboard != null)
            {
                handler.SaveMemberInfo(txtName.Text, txtLastname.Text, int.Parse(txtAge.Text),
                    CountryCodecmb.Text,
                    CountryCodecmb.Text,
                    txtNumber.Text,
                    txtAddress.Text,
                    txtEmail.Text,
                    Display, Clear,
                    dashboard.displayMem
                    );
            }
            else
            {
                handler.SaveMemberInfo(txtName.Text, txtLastname.Text, int.Parse(txtAge.Text)
                    , CountryCodecmb.Text,
                    CountryCodecmb.Text,
                    txtNumber.Text,
                    txtAddress.Text,
                    txtEmail.Text,
                    Display,
                    Clear,
                    null);
            }
        }
        private void btnUpdate(object sender, EventArgs e)
        {
            handler.UpdateMemberInfo(txtName.Text, txtLastname.Text, txtAge.Text,
                CountryCodecmb.Text, CountryCodecmb.Text, txtNumber.Text, txtAddress.Text,
                txtEmail.Text, membergrid, Display, Clear, dashboard.displayMem);
        }
        private void Display()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

            sqlConnection.Open();

            using (SqlCommand cnn = new SqlCommand("GetMembers", sqlConnection))
            {
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);

                membergrid.DataSource = table;

                if (membergrid.Columns["Id"] != null)
                    membergrid.Columns["Id"].Visible = false;
            }
            sqlConnection.Close();
        }

        #region Helpers
        public void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public bool IsValidGmailAddress(string email)
        {
            return email.EndsWith("@gmail.com") && email.Contains("@");
        }
        #endregion
        public void RegistarionFormcs_Load(object sender, EventArgs e)
        {
            Display();
            LoadGenders();
            PhoneNumberList.ListPhneNumber(comboBox1_SelectedIndexChanged, CountryCodecmb);

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            handler.MemberSearch(membergrid, searchbox);
        }
        private void membergrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = membergrid.Rows[e.RowIndex];

                    txtName.Text = row.Cells["Name"].Value?.ToString() ?? string.Empty;
                    txtLastname.Text = row.Cells["LastName"].Value?.ToString() ?? string.Empty;
                    txtAge.Text = row.Cells["Age"].Value?.ToString() ?? string.Empty;
                    CountryCodecmb.Text = row.Cells["CountryCode"].Value?.ToString() ?? string.Empty;
                    txtNumber.Text = row.Cells["PhoneNumber"].Value?.ToString() ?? string.Empty;
                    txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? string.Empty;
                    txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;

                    int selectedID = Convert.ToInt32(row.Cells["ID"].Value);

                    string gender = row.Cells["Gender"].Value.ToString();
                    genderbox.SelectedItem = gender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting the row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadGenders()
        {
            helpers.HelperGender(genderbox);
        }
        #region Helpers
        public void Clear()
        {
            txtName.Clear();
            txtLastname.Clear();
            txtAge.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtNumber.Clear();
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
        #endregion

        private void countyCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void genderbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            helpers.HelperAge(txtAge);
        }
    }
}
