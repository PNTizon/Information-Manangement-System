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

        //public AdminBorrowRecords(AdminDashboard dashboard)
        //{
        //    this.dashboard = dashboard;
        //}
        private void LoadData()
        {
            display.DisplayBorrowRecords(dataGridViewBorrow);
            helper.DurationHelper(cmbBorrowDuration);
        }
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            borrowFunction.BorrowHandler(txtName.Text, txtLastname.Text, txtBook.Text, cmbBorrowDuration,
                dashboard.displayBorrow, dashboard.loadbookslist, dataGridViewBorrow);
            borrowFunction.Clear(txtBook, txtLastname, txtName, cmbBorrowDuration);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            borrowFunction.UpdateHandler(txtName, txtLastname, txtBook, cmbBorrowDuration,
                dashboard.displayBorrow, dashboard.loadbookslist, dataGridViewBorrow);
            borrowFunction.Clear(txtBook, txtLastname, txtName, cmbBorrowDuration);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            borrowFunction.DeleteHandler(dataGridViewBorrow, dashboard.displayBorrow, dashboard.loadbookslist);
            borrowFunction.Clear(txtBook, txtLastname, txtName, cmbBorrowDuration);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            borrowFunction.HandleReturn(
            dataGridViewBorrow,
            returnDate,
            txtBook.Text,
            dashboard.displayBorrow,
            dashboard.loadbookslist
            );
            borrowFunction.Clear(txtBook, txtLastname, txtName, cmbBorrowDuration);
            LoadData();
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
            string search = searchbox.Text;
            borrowFunction.SearchHandler(search, dataGridViewBorrow);
        }

        private void Approvedbtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrow.SelectedRows.Count > 0)
            {
                int borrowId = Convert.ToInt32(dataGridViewBorrow.SelectedRows[0].Cells["Id"].Value);

                borrowFunction.ApproveRequest(txtBook.Text,borrowId,txtName.Text,dataGridViewBorrow);
            }
            else
            {
                MessageBox.Show("Please select a request to approve.");
            }
            borrowFunction.Clear(txtBook,txtLastname,txtName,cmbBorrowDuration);
        }

        private void Declinbtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrow.SelectedRows.Count > 0)
            {
                int borrowId = Convert.ToInt32(dataGridViewBorrow.SelectedRows[0].Cells["Id"].Value);

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
                btnSearch
            };
            shadow = new ButtonShadow(gunabtn);
            shadow.CustomizeGunaButtons();
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            borrowFunction.SearchHandler(search, dataGridViewBorrow);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            helper.UpperCase(txtLastname);
        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {
            helper.UpperCase(txtLastname);
        }
        
    }
}
