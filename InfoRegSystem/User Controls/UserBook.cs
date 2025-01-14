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

        public UserBook()
        {
            InitializeComponent();
            helper = new Helpers();
            display = new Display();
            function = new UserBookFunction();
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
    }
}
