using Guna.UI2.WinForms;
using InfoRegSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class UserBook : UserControl
    {
        private ButtonShadow shadow;

        public UserBook()
        {
            InitializeComponent();
            GunaButton();
        }

        private void UserBookInfo_Load(object sender, EventArgs e)
        {
            Display.DisplayUserBooks(bookgridView);
            LoadGenresForSearch();
        }
        private void LoadGenresForSearch()
        {
            Helpers.GenresHelper(cmbGenre);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            UserBookFunction.UserBookSearch(search, cmbGenre, bookgridView);
        }
        public void GunaButton()
        {
            List<Guna2Button> gunabtn = new List<Guna2Button>
            {
                btnSearch,
            };
            shadow = new ButtonShadow(gunabtn);
            shadow.CustomizeGunaButtons();
        }
        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            string search = searchbox.Text;
            UserBookFunction.UserBookSearch(search, cmbGenre, bookgridView);
        }
    }
}
