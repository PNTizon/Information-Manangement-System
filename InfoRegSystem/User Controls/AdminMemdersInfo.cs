﻿using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminMemdersInfo : UserControl
    {
        private readonly AdminDashboard dashboard;
        private ButtonShadow shadow;
        private readonly Helpers helper = new Helpers();
        private readonly MembersFunctions function = new MembersFunctions();

        public AdminMemdersInfo()
        {
            InitializeComponent();
            dashboard = new AdminDashboard();
            GunaButton();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            MembersFunctions.DeleteMemberInfo(membergrid, Clear, dashboard.TotalMembers);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            function.SaveMemberInfo(txtName.Text, txtLastname.Text, genderbox.Text, countyCode, txtNumber.Text, txtAddress.Text, txtEmail.Text,
                membergrid,Clear, dashboard.TotalMembers);
        }
        private void btnUpdate(object sender, EventArgs e)
        {
            function.UpdateMemberInfo(txtName.Text, txtLastname.Text, genderbox.Text, countyCode, txtNumber.Text, txtAddress.Text, txtEmail.Text,
                membergrid, Clear, dashboard.TotalMembers);
        }
        private void DisplayMembers()
        {
            Display.DisplayMembers(membergrid);
        }
        public void RegistarionFormcs_Load(object sender, EventArgs e)
        {
            DisplayMembers();
            LoadGenders();
            PhoneNumberList.ListPhneNumber(comboBox1_SelectedIndexChanged, CountryCodecmb);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            MembersFunctions.MemberSearch(membergrid, search);
        }
        private void membergrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridSelection.MembersSelection(e.RowIndex, txtName, txtLastname, countyCode, txtNumber, txtAddress, txtEmail, genderbox, membergrid);
        }
        private void LoadGenders()
        {
            helper.HelperGender(genderbox);
        }
        #region Helpers
        public void Clear()
        {
            MembersFunctions.Cleaner(txtName, txtLastname, txtEmail, txtAddress, txtNumber, countyCode, CountryCodecmb, genderbox);
        }
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            helper.HelperNumberRestriction(txtNumber);
            helper.isValidPhoneNumber(countyCode, txtNumber);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhoneNumberList.ComboBox_autoModifier(comboBox1_SelectedIndexChanged, CountryCodecmb, countyCode);
        }
        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            MembersFunctions.MemberSearch(membergrid, search);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            helper.UpperCase(txtName);
        }

        private void txtLastname_Leave(object sender, EventArgs e)
        {
            helper.UpperCase(txtLastname);
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
    }
}
