using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminBookInfo : UserControl
    {
        private AdminDashboard _dashboard;
        private Helpers helper;
        private AdminBookFunction bookFunction;
        private Display display;
        private DataGridSelection selection;
        public AdminBookInfo(AdminDashboard dashboard)
        {
            InitializeComponent();
            _dashboard = dashboard;
        }
        public AdminBookInfo()
        {
            InitializeComponent();
            helper = new Helpers();
            bookFunction = new AdminBookFunction();
            display = new Display();
            selection = new DataGridSelection();
        }
        private void LoadGenres()
        {
            helper.GenresHelper(cmbGenres);
        }
        private void LoadGenresForSearch()
        {
            helper.GenresHelper(cmbGenre);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            bookFunction.SearchBooks(searchbox, cmbGenre, bookgridView);
        }
        private void BookInfo_Load(object sender, EventArgs e)
        {
            display.DisplayBooks(bookgridView);
            LoadGenres();
            LoadGenresForSearch();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bookFunction.AddBook(txtTitle, txtAuthor, txtCopies, cmbGenres, bookgridView);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
           bookFunction.UpdateBook(txtTitle,txtAuthor,txtCopies,cmbGenres, bookgridView);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bookFunction.DeleteBook(txtTitle, txtAuthor, txtCopies, bookgridView);
        }

        private void txtCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
           helper.HelperKeypress(e);
        }

        private void bookgridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selection.BookSelection(e.RowIndex, txtTitle, txtAuthor, txtCopies, cmbGenres, bookgridView);
        }
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            display.DisplayBooks(bookgridView);
        }
    }
}
 