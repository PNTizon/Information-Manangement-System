﻿using InfoRegSystem.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Guna.UI2.Native.WinApi;

namespace InfoRegSystem.Classes
{
    public class UserBorrowTransactionFunctions
    {
        public  void Borrowbtn(string Book,DateTime Borrowdate, string durationcmb)
        {
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

                    using (SqlConnection con = new SqlConnection(Connection.Database))
                    {
                        con.Open();

                        using (SqlCommand checkDuplicateCmd = new SqlCommand("CheckDuplication", con))
                        {
                            checkDuplicateCmd.CommandType = CommandType.StoredProcedure;
                            checkDuplicateCmd.Parameters.AddWithValue("@Id", GlobalUserInfo.UserId);
                            checkDuplicateCmd.Parameters.AddWithValue("@Book", Book);

                            int duplicateCount = (int)checkDuplicateCmd.ExecuteScalar();
                            if (duplicateCount > 0)
                            {
                                MessageBox.Show("This book is already borrowed and not yet returned.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        
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
        public  void Clear(TextBox book, ComboBox duration)
        {
            book.Clear();
            duration.SelectedIndex = -1;
        }
    }
}
