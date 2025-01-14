using InfoRegSystem.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoRegSystem.Classes
{
    public class ErrorMessages
    {
        private AccountCreation create;
        private Helpers helpers;

        public ErrorMessages()
        {
            create = new AccountCreation();
        }
         //bool hasErrors = false; 

         //   #region ErrorMessages
         //   if (!helpers.isValidName(registration_firstname.Text) || !helpers.isValidName(registration_lastname.Text))
         //   {
         //       errorbox1.Text = "First name and last name are required and must contain only letters.";
         //       hasErrors = true;
         //   }
         //   else
         //   {
         //       errorbox1.Text = "";
         //   }
         //   if (!int.TryParse(registration_ages.Text.Trim(), out int age))
         //   {
         //       errorbox2.Text = "Age must be 13 to 50.";
         //       hasErrors = true;
         //   }
         //   else if (age < 13 || age > 50)
         //   {
         //       errorbox2.Text = "";
         //       hasErrors = true;
         //   }
         //   else
         //   {
         //       errorbox2.Text = "";
         //   }
         //   if (!helpers.isValidGender(cmbGender.Text))
         //   {
         //       errorbox3.Text = "Gender must be 'Male', 'Female', or 'Other'.";
         //       hasErrors = true;
         //   }
         //   else
         //   {
         //       errorbox3.Text = "";
         //   }
         //   if (!helpers.isValidAddress(registration_house.Text))
         //   {
         //       errorbox5.Text = "Address is required.";
         //       hasErrors = true;
         //   }
         //   else
         //   {
         //       errorbox5.Text = "";
         //   }
         //   if (!helpers.isValidEmail(registration_emails.Text))
         //   {
         //       errorbox6.Text = "Email must contain @gmail.com.";
         //       hasErrors = true;
         //   }
         //   else
         //   {
         //       errorbox6.Text = "";
         //   }
         //   if (!helpers.isValidUsername(registration_username.Text))
         //   {
         //       errorbox7.Text = "Username must contain letters (a-z) and numbers.";
         //       hasErrors = true;
         //   }
         //   else
         //   {
         //       errorbox7.Text = "";
         //   }
         //   if (!helpers.isValidPassword(registration_pass.Text))
         //   {
         //       errorbox8.Text = "Password must be at least 8 characters long.";
         //       hasErrors = true;
         //   }
         //   else
         //   {
         //       errorbox8.Text = "";
         //   }
         //   //ON PROCESS
         //   if(!helpers.isValidPhoneNumber(cmbCountryCode.Text,registration_number.Text))
         //   {
         //       errorbox4.Text = "Enter a 10-digit phone number with a valid country code.";
         //       hasErrors = true;
         //   }
         //   else
         //   {
         //       errorbox4.Text = "";
         //   }
         //   #endregion

         //   if (hasErrors)
         //   {
         //       return;
         //   }
    }
}
