using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminBorrowRecords : UserControl
    {
        private readonly AdminDashboard dashboard = new AdminDashboard();
        private ButtonShadow shadow;

        public AdminBorrowRecords()
        {
            InitializeComponent();
            GunaButton();
        }
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            AdminBorrowFunctions.BorrowHandler(txtName.Text, txtLastname.Text, txtBook.Text, borrowDate.Value, cmbBorrowDuration,
                dashboard.BorrowRecords, dashboard.loadbookslist, dataGridViewBorrow);
            AdminBorrowFunctions.Clear(txtBook, txtLastname, txtName, cmbBorrowDuration);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminBorrowFunctions.UpdateHandler(txtName, txtLastname, txtBook, cmbBorrowDuration, dashboard.BorrowRecords, dashboard.loadbookslist, dataGridViewBorrow);
            AdminBorrowFunctions.Clear(txtBook, txtLastname, txtName, cmbBorrowDuration);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            AdminBorrowFunctions.DeleteHandler(dataGridViewBorrow, dashboard.BorrowRecords, dashboard.loadbookslist);
            AdminBorrowFunctions.Clear(txtBook, txtLastname, txtName, cmbBorrowDuration);
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            AdminBorrowFunctions.HandleReturn(dataGridViewBorrow, returnDate, txtBook.Text, dashboard.BorrowRecords, dashboard.loadbookslist);
            AdminBorrowFunctions.Clear(txtBook, txtLastname, txtName, cmbBorrowDuration);
        }
        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dataGridViewBorrow.CurrentCell.RowIndex;
            DataGridSelection.BorrowRecordsSelection(selectedRowIndex, dataGridViewBorrow, txtName, txtBook, txtLastname, cmbBorrowDuration, borrowDate, returnDate);
        }
        private void BorrowForm_Load(object sender, EventArgs e)
        {
            Display.DisplayBorrowRecords(dataGridViewBorrow);
            Helpers.DurationHelper(cmbBorrowDuration);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            AdminBorrowFunctions.SearchHandler(search, dataGridViewBorrow);
        }
        private void Approvedbtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrow.SelectedRows.Count > 0)
            {
                int borrowId = Convert.ToInt32(dataGridViewBorrow.SelectedRows[0].Cells["Id"].Value);
                AdminBorrowFunctions.ApproveRequest(txtBook.Text, borrowId, txtName.Text, dataGridViewBorrow);
            }
            else
            {
                MessageBox.Show("Please select a request to approve.");
            }
            AdminBorrowFunctions.Clear(txtBook, txtLastname, txtName, cmbBorrowDuration);
        }
        private void Declinbtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrow.SelectedRows.Count > 0)
            {
                int borrowId = Convert.ToInt32(dataGridViewBorrow.SelectedRows[0].Cells["Id"].Value);
                AdminBorrowFunctions.RejectRequest(borrowId, dataGridViewBorrow);
            }
            else
            {
                MessageBox.Show("Please select a request to reject.");
            }
            AdminBorrowFunctions.Clear(txtBook, txtLastname, txtName, cmbBorrowDuration);
        }
        private void GunaButton()
        {
            List<Guna2Button> gunabtn = new List<Guna2Button>
            {
                btnSearch
            };
            shadow = new ButtonShadow(gunabtn);
            shadow.CustomizeGunaButtons();
        }
        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            AdminBorrowFunctions.SearchHandler(search, dataGridViewBorrow);
        }
        private void TxtName_Leave(object sender, EventArgs e)
        {
            Helpers.UpperCase(txtName);
        }
        private void TxtLastname_Leave(object sender, EventArgs e)
        {
            Helpers.UpperCase(txtLastname);
        }
    }
}