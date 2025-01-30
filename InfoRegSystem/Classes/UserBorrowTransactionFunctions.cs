using InfoRegSystem.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class UserBorrowTransactionFunctions
    {
        private FormManager formManager;
        private Helpers helper;

        public UserBorrowTransactionFunctions()
        {
            helper = new Helpers();
            formManager = new FormManager();
        }

        public void Borrowbtn(string Book,DateTime Borrowdate, string durationcmb)
        {
            //DateTime borrowedDate = Borrowdate;
            //string durationText = durationcmb;

            try
            {
                if (string.IsNullOrEmpty(Book) || string.IsNullOrEmpty(durationcmb))
                {
                    MessageBox.Show("Please enter all required fields.");
                    return;
                }
                if (int.TryParse(durationcmb, out int duration))
                {
                    DateTime expectedReturnDate = Borrowdate.AddDays(duration);

                    using (SqlConnection con = new SqlConnection(sqlconnection.Database))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand("AddUserBorrowRecord", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@StudentId", GlobalUserInfo.UserId);
                            cmd.Parameters.AddWithValue("@Name", GlobalUserInfo.FirstName);
                            cmd.Parameters.AddWithValue("@Lastname", GlobalUserInfo.Lastname);
                            cmd.Parameters.AddWithValue("@Book", Book);
                            cmd.Parameters.AddWithValue("@BorrowedDate", Borrowdate);
                            cmd.Parameters.AddWithValue("@ExpectedReturnDate", expectedReturnDate);
                            cmd.Parameters.AddWithValue("@Duration", durationcmb);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Borrow request submitted! Waiting for admin approval.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid duration.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Clear(TextBox book, ComboBox duration)
        {
            book.Clear();
            duration.SelectedIndex = -1;
        }
    }
}
