using Guna.UI2.WinForms;
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
        private ButtonShadow shadow;

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
            GunaButton();
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
            string search = searchbox.Text;

            bookFunction.SearchBooks(search, cmbGenre, bookgridView);
        }
        private void BookInfo_Load(object sender, EventArgs e)
        {
            display.DisplayBooks(bookgridView);
            LoadGenres();
            LoadGenresForSearch();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bookFunction.AddBook(txtTitle.Text, txtAuthor.Text, txtCopies.Text, cmbGenres.Text, bookgridView);
            bookFunction.Cleaner(txtTitle, txtAuthor, txtCopies,cmbGenres);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
           bookFunction.UpdateBook(txtTitle.Text, txtAuthor.Text, txtCopies.Text,cmbGenres, bookgridView);
            bookFunction.Cleaner(txtTitle, txtAuthor, txtCopies, cmbGenres);

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bookFunction.DeleteBook(txtTitle.Text, txtAuthor.Text, txtCopies.Text, bookgridView);
            bookFunction.Cleaner(txtTitle, txtAuthor, txtCopies, cmbGenres);
        }

        private void bookgridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selection.BookSelection(e.RowIndex, txtTitle, txtAuthor, txtCopies, cmbGenres, bookgridView);
        }
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            display.DisplayBooks(bookgridView);
        }
        public void GunaButton()
        {
            List<Guna2Button> gunabtn = new List<Guna2Button>
            {
                btnAdd,
                btnDetele,
                btnEdit,
                btnSearch
            };
            shadow = new ButtonShadow(gunabtn);
            shadow.CustomizeGunaButtons();
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            string search = searchbox.Text;

            bookFunction.SearchBooks(search, cmbGenre, bookgridView);
        }
    }
}
 