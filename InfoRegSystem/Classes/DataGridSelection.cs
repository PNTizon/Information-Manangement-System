using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Guna.UI2.Native.WinApi;

namespace InfoRegSystem.Classes
{
    public class DataGridSelection
    {
        private string book { get; set; }


        public void MembersSelection(int rowIndex,TextBox name , TextBox lastname, TextBox age, ComboBox countrybox, TextBox phone, TextBox address, TextBox email,ComboBox genderbox, DataGridView membergrid)
        {
            try
            {
                if (rowIndex >= 0)
                {
                    DataGridViewRow row = membergrid.Rows[rowIndex];

                    name.Text = row.Cells["Name"].Value?.ToString() ?? string.Empty;
                    lastname.Text = row.Cells["LastName"].Value?.ToString() ?? string.Empty;
                    age.Text = row.Cells["Age"].Value?.ToString() ?? string.Empty;
                    countrybox.Text = row.Cells["CountryCode"].Value?.ToString() ?? string.Empty;
                    phone.Text = row.Cells["PhoneNumber"].Value?.ToString() ?? string.Empty;
                    address.Text = row.Cells["Address"].Value?.ToString() ?? string.Empty;
                    email.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;

                    int selectedID = Convert.ToInt32(row.Cells["ID"].Value);
                    string gender = row.Cells["Gender"].Value?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(gender) && genderbox.Items.Contains(gender))
                    {
                        genderbox.SelectedItem = gender;
                    }
                    else
                    {
                        genderbox.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting the row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BorrowRecordsSelection(int rowIndex, DataGridView recordsgrid, TextBox txtName, TextBox txtBook, TextBox txtLastname,ComboBox duration, DateTimePicker borrowDate, DateTimePicker returnDate)
        {
            try
            {
                if (rowIndex >= 0)
                {
                    DataGridViewRow row = recordsgrid.Rows[rowIndex];

                    txtName.Text = row.Cells["name"].Value.ToString();
                    txtBook.Text = row.Cells["book"].Value.ToString();
                    txtLastname.Text = row.Cells["lastname"].Value.ToString();
                    if (row.Cells["duration"].Value != DBNull.Value)
                    {
                        duration.SelectedItem = row.Cells["duration"].Value.ToString(); 
                    }
                    borrowDate.Value = row.Cells["borroweddate"].Value != DBNull.Value ? Convert.ToDateTime(row.Cells["borroweddate"].Value) : DateTime.Now;
                    returnDate.Value = row.Cells["returndate"].Value != DBNull.Value ? Convert.ToDateTime(row.Cells["returndate"].Value) : DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occurred: " + ex.Message + " - " + ex.Source);
            }
        }
        public void BookSelection(int rowIndex,TextBox title,TextBox author,TextBox copies,ComboBox genrebox,DataGridView bookgrid)
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
        public void TransactionSelection(DataGridView transacgrid,int rowIndex)
        {
            try
            {
                if (rowIndex >= 0)
                {
                    DataGridViewRow row = transacgrid.Rows[rowIndex];

                    book = row.Cells["book"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occurred: " + ex.Message + " - " + ex.Source);
            }
        }


    }
}
