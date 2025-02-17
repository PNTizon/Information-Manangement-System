using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class CountryCode
    {
        public string Country { get; set; }
        public string Code { get; set; }
    }
    public class PhoneNumberList
    {
        public static void ListPhneNumber(EventHandler eventHandler, ComboBox comboBox)
        {
            var countryCodes = new List<CountryCode>
        {
            new CountryCode { Country = "AFG", Code = "+93" },
            new CountryCode { Country = "ARM", Code = "+374" },
            new CountryCode { Country = "AZE", Code = "+994" },
            new CountryCode { Country = "BGD", Code = "+880" },
            new CountryCode { Country = "BHR", Code = "+973" },
            new CountryCode { Country = "BRN", Code = "+673" },
            new CountryCode { Country = "BTN", Code = "+975" },
            new CountryCode { Country = "BLR", Code = "+375" },
            new CountryCode { Country = "KHM", Code = "+855" },
            new CountryCode { Country = "CHN", Code = "+86" },
            new CountryCode { Country = "GEO", Code = "+995" },
            new CountryCode { Country = "IND", Code = "+91" },
            new CountryCode { Country = "IDN", Code = "+62" },
            new CountryCode { Country = "IRQ", Code = "+964" },
            new CountryCode { Country = "IRN", Code = "+98" },
            new CountryCode { Country = "JOR", Code = "+962" },
            new CountryCode { Country = "JPN", Code = "+81" },
            new CountryCode { Country = "KEN", Code = "+254" },
            new CountryCode { Country = "KGZ", Code = "+996" },
            new CountryCode { Country = "KOR", Code = "+82" },
            new CountryCode { Country = "KWT", Code = "+965" },
            new CountryCode { Country = "KAZ", Code = "+7" },
            new CountryCode { Country = "LAO", Code = "+856" },
            new CountryCode { Country = "LBN", Code = "+961" },
            new CountryCode { Country = "MYS", Code = "+60" },
            new CountryCode { Country = "MDV", Code = "+960" },
            new CountryCode { Country = "MNG", Code = "+976" },
            new CountryCode { Country = "MMR", Code = "+95" },
            new CountryCode { Country = "NPL", Code = "+977" },
            new CountryCode { Country = "OMN", Code = "+968" },
            new CountryCode { Country = "PAK", Code = "+92" },
            new CountryCode { Country = "PHL", Code = "+63" },
            new CountryCode { Country = "QAT", Code = "+974" },
            new CountryCode { Country = "SAU", Code = "+966" },
            new CountryCode { Country = "SGP", Code = "+65" },
            new CountryCode { Country = "LKA", Code = "+94" },
            new CountryCode { Country = "SYR", Code = "+963" },
            new CountryCode { Country = "TJK", Code = "+992" },
            new CountryCode { Country = "THA", Code = "+66" },
            new CountryCode { Country = "TUR", Code = "+90" },
            new CountryCode { Country = "TKM", Code = "+993" },
            new CountryCode { Country = "ARE", Code = "+971" },
            new CountryCode { Country = "UZB", Code = "+998" },
            new CountryCode { Country = "VNM", Code = "+84" },
            new CountryCode { Country = "YEM", Code = "+967" }
         };

            comboBox.DataSource = null;

            foreach (var countryCode in countryCodes)
            {
                comboBox.Items.Add($"{countryCode.Country} | {countryCode.Code}");
            }
            comboBox.SelectedIndexChanged += eventHandler; 
        }
        public static void ComboBox_autoModifier(EventHandler eventHandler, ComboBox comboBox, TextBox textBox)
        {
            if (comboBox.SelectedIndex >= 0)
            {
                string selectedItem = comboBox.SelectedItem.ToString();

                var parts = selectedItem.Split('|');
                if (parts.Length == 2)
                {
                    string countryCode = parts[1].Trim();
                    comboBox.SelectedIndexChanged -= eventHandler;
                    textBox.Text = countryCode;
                    comboBox.SelectedIndexChanged += eventHandler;
                }
            }
            else
            {
                textBox.Text = string.Empty;
            }
        }
    }
}