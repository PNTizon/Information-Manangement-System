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
    public partial class UserBorrowTransactions : Form
    {
        private Helpers helper;
        public UserBorrowTransactions()
        {
            InitializeComponent();
            helper = new Helpers();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastname = txtLastname.Text;
            string book = txtBook.Text;
            DateTime borrowedDate = borrowDate.Value;
            string durationText = cmbDuration.Text;

            // Check if the duration is a valid integer
            if (int.TryParse(durationText, out int duration))
            {
                DateTime expectedReturnDate = borrowedDate.AddDays(duration);

                string query = "INSERT INTO borrowtable (Id, Name, Lastname, Book, BorrowedDate, ExpectedReturnDate, Duration, Status) " +
                               "VALUES (@id, @Name, @Lastname, @Book, @BorrowedDate, @ExpectedReturnDate, @Duration, 'Pending')";

                using (SqlConnection con = new SqlConnection(sqlconnection.Database))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", GlobalUserInfo.UserId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Lastname", lastname);
                    cmd.Parameters.AddWithValue("@Book", book);
                    cmd.Parameters.AddWithValue("@BorrowedDate", borrowedDate);
                    cmd.Parameters.AddWithValue("@ExpectedReturnDate", expectedReturnDate);
                    cmd.Parameters.AddWithValue("@Duration", durationText); // Store the string value as duration

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Borrow request submitted! Waiting for admin approval.");
                }
            }
            else
            {
                // Show error if duration is not a valid integer
                MessageBox.Show("Please enter a valid duration.");
            }
        }

        private void UserBorrowTransactions_Load(object sender, EventArgs e)
        {
            helper.DurationHelper(cmbDuration);
        }
    }
}
