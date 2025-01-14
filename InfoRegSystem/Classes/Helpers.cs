using InfoRegSystem.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
        public bool GmailHelper(TextBox email)
        {
            return email.Text.EndsWith("@gmail.com") && email.Text.Contains("@"); 
        }
        public void DurationHelper(ComboBox durationBox)
        {
            List<string> genres = new List<string> { "7", "14", "21", "30"};
            durationBox.DataSource = genres;
            durationBox.SelectedIndex = -1;
        }
        public bool isValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }
        public bool isValidAge(string age)
        {
            return int.TryParse(age, out int num)
                && num > 13 && num <= 50;
        }
        public bool isValidGender(string gender)
        {
            return gender == "Male" || gender == "Female" || gender == "Other";
        }
        public bool isValidAddress(string street)
        {
            return !string.IsNullOrEmpty(street);
        }
        public bool isValidEmail(string email)
        {
            return email.EndsWith("@gmail.com") && email.Contains("@");
        }
        public bool isValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]{5,15}$");
        }
        //ON PROCESS
        public bool isValidPhoneNumber(TextBox countryCode, TextBox phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(countryCode.Text) || string.IsNullOrWhiteSpace(phoneNumber.Text))
            {
                return false; // One of the inputs is empty
            }

            string fullNumber = countryCode.Text + phoneNumber.Text;

            // Ensure it starts with "+" followed by 1-3 digits (country code), and exactly 10 digits for the phone number
            return Regex.IsMatch(fullNumber, @"^\+\d{1,3}\d{10}$");
        }


        public bool isValidPassword(string password)
        {
            return password.Length >= 8;
        }

        public void registration_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void HidePassword(PictureBox show,PictureBox hide,TextBox password)
        {
            show.Show();
            hide.Hide();

            password.PasswordChar = '\0';
        }
        public void ShowPassord(PictureBox show, PictureBox hide, TextBox password)
        {
            show.Hide();
            hide.Show();

            password.PasswordChar = '●';
        }


    }
}
