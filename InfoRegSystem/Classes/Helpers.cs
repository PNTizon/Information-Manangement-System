using InfoRegSystem.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class Helpers
    {
        private AdminMemdersInfo adminMemdersInfo;
        private Helpers helper;

        public void HelperGender(ComboBox comboBox)
        {
            List<string> genders = new List<string> { "Male", "Female", "Other" };
            comboBox.DataSource = genders;
            comboBox.SelectedIndex = -1;
        }
        public void HelperKeypress(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void HelperNumberRestriction(TextBox phoneNum)
        {
            string currentText = phoneNum.Text;
            phoneNum.Text = string.Concat(currentText.Where(char.IsDigit));

            if (phoneNum.Text.Length > 10)
            {
                phoneNum.Text = phoneNum.Text.Substring(0, 10);
            }

            phoneNum.SelectionStart = phoneNum.Text.Length;
        }
        public void HelperAge(TextBox agetext)
        {
            string currentText = agetext.Text;
            agetext.Text = string.Concat(currentText.Where(char.IsDigit));

            if (agetext.Text.Length > 2)
            {
                agetext.Text = agetext.Text.Substring(0, 2);
            }

            agetext.SelectionStart = agetext.Text.Length;
        }
        public void PasswordHelper(TextBox passwordtext)
        {
            string currentText = passwordtext.Text;

            if (currentText.Length > 8)
            {
                passwordtext.Text = currentText.Substring(0, 8);
            }
            passwordtext.SelectionStart = passwordtext.Text.Length;
        }
        public void GenresHelper(ComboBox combo)
        {
            List<string> genres = new List<string> { "Fiction", "Non-Fiction", "Mystery", "Fantasy", "Sci-Fi", "Biography", "History", "Romance" };
            combo.DataSource = genres;
            combo.SelectedIndex = -1;
        }
    }
}
