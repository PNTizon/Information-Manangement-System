using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminBookInfo : UserControl
    {
        private AdminDashboard _dashboard;
        private ButtonShadow shadow;
        private Helpers helper = new Helpers();
       
        public AdminBookInfo()
        {
            InitializeComponent();
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

            AdminBookFunction.SearchBooks(search, cmbGenre, bookgridView);
        }
        private void BookInfo_Load(object sender, EventArgs e)
        {
            Display.DisplayBooks(bookgridView);
            LoadGenres();
            LoadGenresForSearch();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            AdminBookFunction.AddBook(txtTitle.Text, txtAuthor.Text, txtCopies.Text, cmbGenres.Text, bookgridView);
            AdminBookFunction.Cleaner(txtTitle, txtAuthor, txtCopies, cmbGenres);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminBookFunction.UpdateBook(txtTitle.Text, txtAuthor.Text, txtCopies.Text, cmbGenres, bookgridView);
            AdminBookFunction.Cleaner(txtTitle, txtAuthor, txtCopies, cmbGenres);

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            AdminBookFunction.DeleteBook(txtTitle.Text, txtAuthor.Text, txtCopies.Text, bookgridView);
            AdminBookFunction.Cleaner(txtTitle, txtAuthor, txtCopies, cmbGenres);
        }

        private void bookgridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridSelection.BookSelection(e.RowIndex, txtTitle, txtAuthor, txtCopies, cmbGenres, bookgridView);
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

            AdminBookFunction.SearchBooks(search, cmbGenre, bookgridView);
        }

        private void txtCopies_TextChanged(object sender, EventArgs e)
        {
            helper.Copies(txtCopies);
        }
    }
}
