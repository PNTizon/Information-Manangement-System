using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminBorrowRecords : UserControl
    {
        private AdminDashboard dashboard;
        private UserMainForm userDashboard;
        private AdminBorrowFunctions borrowFunction;
        private Display display;
        private Helpers helper;
        private DataGridSelection select;
        private ButtonShadow shadow;

        public AdminBorrowRecords()
        {
            InitializeComponent();
            borrowFunction = new AdminBorrowFunctions();
            display = new Display();
            dashboard = new AdminDashboard();
            helper = new Helpers();
            select = new DataGridSelection();
            GunaButton();
        }

        public AdminBorrowRecords(AdminDashboard dashboard)
        {
            this.dashboard = dashboard;
        }
        private void LoadData()
        {
            display.DisplayBorrowRecords(dataGridViewBorrow);
            helper.DurationHelper(cmbBorrowDuration);
        }
        //ON PROCESS
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            borrowFunction.BorrowHandler(txtName.Text, txtLastname.Text, txtBook.Text, cmbBorrowDuration, dashboard.displayBorrow, dashboard.loadbookslist, dataGridViewBorrow);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            borrowFunction.UpdateHandler(txtName, txtLastname, txtBook, cmbBorrowDuration,  dashboard.displayBorrow, dashboard.loadbookslist, dataGridViewBorrow);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            borrowFunction.DeleteHandler(dataGridViewBorrow, dashboard.displayBorrow, dashboard.loadbookslist);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            UpdateReturnDate();
            dashboard?.displayBorrow();
            LoadData();
        }
        private void UpdateReturnDate()
        {
            borrowFunction.HandleReturn(
            dataGridViewBorrow,
            returnDate,
            txtBook.Text,
            dashboard.displayBorrow,
            dashboard.loadbookslist
            );
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dataGridViewBorrow.CurrentCell.RowIndex;
            select.BorrowRecordsSelection(selectedRowIndex, dataGridViewBorrow, txtName, txtBook, txtLastname, cmbBorrowDuration, borrowDate, returnDate);
        }
        private void BorrowForm_Load(object sender, EventArgs e)
        {
            display.DisplayBorrowRecords(dataGridViewBorrow);
            helper.DurationHelper(cmbBorrowDuration);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            borrowFunction.SearchHandler(searchbox, dataGridViewBorrow);
        }

        private void Approvedbtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrow.SelectedRows.Count > 0)
            {
                // Get the hidden Id value from the selected row
                int borrowId = Convert.ToInt32(dataGridViewBorrow.SelectedRows[0].Cells["Id"].Value);

                // Call the ApproveRequest method
                borrowFunction.ApproveRequest(txtBook.Text,borrowId,dataGridViewBorrow);
            }
            else
            {
                MessageBox.Show("Please select a request to approve.");
            }
        }

        private void Rejectbtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrow.SelectedRows.Count > 0)
            {
                // Get the hidden Id value from the selected row
                int borrowId = Convert.ToInt32(dataGridViewBorrow.SelectedRows[0].Cells["Id"].Value);

                // Call the RejectRequest method
                borrowFunction.RejectRequest(borrowId,txtBook.Text,dataGridViewBorrow);
            }
            else
            {
                MessageBox.Show("Please select a request to reject.");
            }
        }
        private void GunaButton()
        {
            List<Guna2Button> gunabtn = new List<Guna2Button>
            {
                btnBorrow,
                btnReturn,
                btnDelete,
                btnUpdate,
                Approvedbtn,
                Rejectbtn,
                btnSearch
            };
            shadow = new ButtonShadow(gunabtn);
            shadow.CustomizeGunaButtons();
        }
    }
}
