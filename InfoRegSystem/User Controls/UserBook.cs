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
        private Helpers helper;
        private Display display;
        private UserBookFunction function;
        private ButtonShadow shadow;

        public UserBook()
        {
            InitializeComponent();
            helper = new Helpers();
            display = new Display();
            function = new UserBookFunction();
            GunaButton();
        }

        private void UserBookInfo_Load(object sender, EventArgs e)
        {
            display.DisplayUserBooks(bookgridView);
            LoadGenresForSearch();
        }
        private void LoadGenresForSearch()
        {
            helper.GenresHelper(cmbGenre);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            function.UserBookSearch(searchbox, cmbGenre, bookgridView);
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            display.DisplayUserBooks(bookgridView);
        }
        public void GunaButton()
        {
            List<Guna2Button> gunabtn = new List<Guna2Button>
            {
                btnSearch,
                btnViewAll
            };
            shadow = new ButtonShadow(gunabtn);
            shadow.CustomizeGunaButtons();
        }
    }
}
