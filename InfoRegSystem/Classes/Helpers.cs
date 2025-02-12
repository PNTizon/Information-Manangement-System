using Guna.UI2.WinForms;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class Helpers
    {
        public static void HelperGender(ComboBox comboBox)
        {
            List<string> genders = new List<string> { "Male", "Female", "Other" };
            comboBox.DataSource = genders;
            comboBox.SelectedIndex = -1;
        }
        public static void HelperNumberRestriction(Guna2TextBox phoneNum)
        {
            string currentText = phoneNum.Text;//ginakuha niya ang sulod sa phoneNum na textbox 
            phoneNum.Text = string.Concat(currentText.Where(char.IsDigit));//ang purpose ani kay gina kuha lang nya kay 0-9  ug gina wala ang letra o  special char
                                                                           //human i butang ang value sa textbox

            if (phoneNum.Text.Length > 10)// if ang gi input na nuumber kay subra sa 10 putlon niya ang subra 
            {
                phoneNum.Text = phoneNum.Text.Substring(0, 10); //ang unang 10 digits lang ang kuhaon niya
            }

            phoneNum.SelectionStart = phoneNum.Text.Length;// para ang cursur magpundo sa last
        }
        public static void Copies(TextBox copy)
        {
            string currentText = copy.Text;
            copy.Text = string.Concat(currentText.Where(char.IsDigit));
            if (currentText.Length > 2 )
            {
                copy.Text = currentText.Substring(0, 2);
            }
            copy.SelectionStart = copy.Text.Length;
        }
        public static void PasswordHelper(Guna2TextBox passwordtext)
        {
            string currentText = passwordtext.Text;

            if (currentText.Length > 8)
            {
                passwordtext.Text = currentText.Substring(0, 8);
            }
            passwordtext.SelectionStart = passwordtext.Text.Length;
        }
        public static void GenresHelper(ComboBox combo)
        {
            List<string> genres = new List<string> { "Fiction", "Non-Fiction", "Mystery", "Fantasy", "Sci-Fi", "Biography", "History", "Romance" };
            combo.DataSource = genres;
            combo.SelectedIndex = -1;
        }

        public static void DurationHelper(ComboBox durationBox)
        {
            List<string> duration = new List<string>
            { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
              "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
              "21","22","23","24","25","26","27","28","29", "30" };
            durationBox.DataSource = duration;
            durationBox.SelectedIndex = -1;
        }
        public static bool isValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }
        public static bool isValidGender(string gender)
        {
            return gender == "Male" || gender == "Female" || gender == "Other";
        }
        public static bool isValidAddress(string street)
        {
            return !string.IsNullOrEmpty(street);
        }
        public static bool isValidEmail(string email)
        {
            return email.EndsWith("@gmail.com") && email.Contains("@");
        }
        public static bool isValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]{5,15}$");
        }
        public static bool isValidPhoneNumber(TextBox countryCode, Guna2TextBox phoneNumber)
        {
            string fullNumber = countryCode.Text + phoneNumber.Text;

            if (string.IsNullOrWhiteSpace(countryCode.Text) || string.IsNullOrWhiteSpace(phoneNumber.Text))
            {
                return false;
            }

            return Regex.IsMatch(fullNumber, @"^\+\d{1,3}\d{10}$");
        }

        public static bool isValidPassword(string password)
        {
            return password.Length >= 8;
        }

        public static void HidePassword(PictureBox show, PictureBox hide, Guna2TextBox password)
        {
            show.Show();
            hide.Hide();

            password.PasswordChar = '\0';
        }
        public static void ShowPassord(PictureBox show, PictureBox hide, Guna2TextBox password)
        {
            show.Hide();
            hide.Show();

            password.PasswordChar = '●';
        }

        public static void UpperCase(Guna2TextBox textBox)
        {
            if (textBox.Text.Length > 0)
            {
                textBox.Text = char.ToUpper(textBox.Text[0]) + textBox.Text.Substring(1);
                textBox.SelectionStart = textBox.Text.Length; // Keep cursor position
            }
        }
    }
}
