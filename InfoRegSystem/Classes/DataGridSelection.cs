using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class DataGridSelection
    {
        private static string book { get; set; }


        public static  void MembersSelection(int rowIndex, Guna2TextBox name, Guna2TextBox lastname, TextBox countrybox,
            Guna2TextBox phone, Guna2TextBox address, Guna2TextBox email, ComboBox genderbox, DataGridView membergrid)
        {
            try
            {
                if (rowIndex >= 0)
                {
                    DataGridViewRow row = membergrid.Rows[rowIndex];

                    string GetValue(string columnName) => row.Cells[columnName].Value?.ToString() ?? string.Empty;

                    name.Text = GetValue("Name");
                    lastname.Text = GetValue("LastName");
                    countrybox.Text = GetValue("CountryCode");
                    phone.Text = GetValue("PhoneNumber");
                    address.Text = GetValue("Address");
                    email.Text = GetValue("Email");

                    int selectedID = Convert.ToInt32(row.Cells["ID"].Value);

                    string gender = GetValue("Gender");
                    genderbox.SelectedItem = genderbox.Items.Contains(gender) ? gender : null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting the row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void BorrowRecordsSelection(int rowIndex, DataGridView recordsgrid, Guna2TextBox txtName, TextBox txtBook,
            Guna2TextBox txtLastname, ComboBox duration, DateTimePicker borrowDate, DateTimePicker returnDate)
        {
            try
            {
                if (rowIndex >= 0)
                {
                    DataGridViewRow row = recordsgrid.Rows[rowIndex];

                    string GetValue(string columnName) => row.Cells[columnName].Value?.ToString() ?? string.Empty;

                    txtName.Text = GetValue("name");
                    txtBook.Text = GetValue("book");
                    txtLastname.Text = GetValue("lastname");

                    string durationValue = GetValue("duration");
                    duration.SelectedItem = !string.IsNullOrEmpty(durationValue) ? durationValue : null;

                    borrowDate.Value = DateTime.TryParse(GetValue("borroweddate"), out DateTime borrow) ? borrow : DateTime.Now;
                    returnDate.Value = DateTime.TryParse(GetValue("returndate"), out DateTime returnDt) ? returnDt : DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occurred: " + ex.Message + " - " + ex.Source);
            }
        }
        public static void BookSelection(int rowIndex, TextBox title, TextBox author, TextBox copies, ComboBox genrebox, DataGridView bookgrid)
        {
            try
            {
                if (rowIndex >= 0)
                {
                    DataGridViewRow row = bookgrid.Rows[rowIndex];

                    int selectedID = Convert.ToInt32(bookgrid.CurrentRow.Cells["BookID"].Value);

                    bookgrid.Columns["BookID"].Visible = false;
                    title.Text = row.Cells["title"].Value.ToString();
                    author.Text = row.Cells["author"].Value.ToString();
                    copies.Text = row.Cells["copies"].Value.ToString();

                    string genre = row.Cells["Genres"].Value.ToString();
                    genrebox.SelectedItem = genre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source);
            }
        }
        public static void TransactionSelection(DataGridView transacgrid, int rowIndex)
        {
            #region Old
            //try
            //{
            //    if (rowIndex >= 0)
            //    {
            //        DataGridViewRow row = transacgrid.Rows[rowIndex];

            //        book = row.Cells["book"].Value.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Some error occurred: " + ex.Message + " - " + ex.Source);
            //}
            #endregion
            if (rowIndex >= 0)
                transacgrid.Rows[rowIndex].Cells["book"].Value.ToString();
                
        }
        public static void BorrowbookSelection(DataGridView bookGrid, TextBox txtBook, int rowIndex)
        {
            #region Old
            //if (rowIndex >= 0)
            //{
            //    DataGridViewRow row = bookGrid.Rows[rowIndex];
            //    string bookTitle = row.Cells["Title"].Value.ToString();

            //    // Set the book value
            //    book = bookTitle;

            //    // Update the book TextBox in the main form
            //    txtBook.Text = bookTitle;
            //}
            #endregion
            if (rowIndex >= 0)
                txtBook.Text = book = bookGrid.Rows[rowIndex].Cells["Title"].Value.ToString();
        }
    }
}
