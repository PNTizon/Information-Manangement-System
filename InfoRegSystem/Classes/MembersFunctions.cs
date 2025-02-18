using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class MembersFunctions
    {
        private Helpers helper = new Helpers();
        public  void SaveMemberInfo(string name, string lastname, string gender, TextBox countryCode, string phonenumber,
            string address, string email, DataGridView membergrid, Action clearMethod, Action displayMemMethod = null)
        {
            try
            {
                if (!helper.isValidName(name) || !helper.isValidName(lastname) || !helper.isValidAddress(address)
                    || string.IsNullOrEmpty(phonenumber) || !helper.isValidEmail(email) || !helper.isValidGender(gender))
                {
                    MessageBox.Show("Please fill all the blank fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SqlConnection sqlConnection = new SqlConnection(Connection.Database))
                {
                    sqlConnection.Open();

                    DateTime day = DateTime.Today;
                    using (SqlCommand cnn = new SqlCommand("AddMember", sqlConnection))
                    {
                        cnn.CommandType = CommandType.StoredProcedure;
                        cnn.Parameters.AddWithValue("@Name", name.Trim());
                        cnn.Parameters.AddWithValue("@Lastname", lastname.Trim());
                        cnn.Parameters.AddWithValue("@Gender", gender.Trim());
                        cnn.Parameters.AddWithValue("@CountryCode", countryCode.Text);
                        cnn.Parameters.AddWithValue("@PhoneNumber", phonenumber.Trim());
                        cnn.Parameters.AddWithValue("@Address", address.Trim());
                        cnn.Parameters.AddWithValue("@Email", email.Trim());
                        cnn.Parameters.AddWithValue("@DateRegister", day);

                        cnn.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                displayMemMethod?.Invoke();
                clearMethod();
                Display.DisplayMembers(membergrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void DeleteMemberInfo(DataGridView membergrid, Action clearMethod, Action displayMemMethod = null)
        {
            try
            {
                if (membergrid.CurrentRow == null)
                {
                    MessageBox.Show("Please select a valid record to delete.");
                    return;
                }

                int selectedID = Convert.ToInt32(membergrid.CurrentRow.Cells["ID"].Value);

                var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(Connection.Database))
                    {
                        sqlConnection.Open();

                        using (SqlCommand cnn = new SqlCommand("DeleteMember", sqlConnection))
                        {
                            cnn.CommandType = CommandType.StoredProcedure;
                            cnn.Parameters.AddWithValue("@ID", selectedID);

                            int rowsAffected = cnn.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayMemMethod?.Invoke();
                            }
                            else
                            {
                                MessageBox.Show("Record not found.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                Display.DisplayMembers(membergrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clearMethod();
        }
        public  void UpdateMemberInfo(string name, string lastname, string gender, TextBox countryCode,
            string phoneNumber, string address, string email, DataGridView membergrid,
            Action displayMethod, Action clearMethod, Action displayMemMethod = null)
        {
            try
            {
                if (membergrid.CurrentRow == null)
                {
                    MessageBox.Show("No record selected. Please select a record to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!helper.isValidName(name) || !helper.isValidName(lastname) || !helper.isValidAddress(address)
                   || string.IsNullOrEmpty(phoneNumber) || !helper.isValidEmail(email) || !helper.isValidGender(gender))
                {
                    MessageBox.Show("Please fill all the blank fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int selectedID = Convert.ToInt32(membergrid.CurrentRow.Cells["ID"].Value);

                using (SqlConnection sqlConnection = new SqlConnection(Connection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cnn = new SqlCommand("UpdateMember", sqlConnection))
                    {

                        cnn.CommandType = CommandType.StoredProcedure;
                        cnn.Parameters.AddWithValue("@Name", name.Trim());
                        cnn.Parameters.AddWithValue("@Lastname", lastname.Trim());
                        cnn.Parameters.AddWithValue("@Gender", gender.Trim());
                        cnn.Parameters.AddWithValue("@CountryCode", countryCode.Text);
                        cnn.Parameters.AddWithValue("@PhoneNumber", phoneNumber.Trim());
                        cnn.Parameters.AddWithValue("@Address", address.Trim());
                        cnn.Parameters.AddWithValue("@Email", email.Trim());
                        cnn.Parameters.AddWithValue("@ID", selectedID);

                        int rowsAffected = cnn.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            displayMemMethod?.Invoke();
                        }
                        else
                        {
                            MessageBox.Show("Record not found.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                displayMethod();
                clearMethod();
                Display.DisplayMembers(membergrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void MemberSearch(DataGridView membergrid, string searchbox)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Connection.Database))
                {
                    sqlConnection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter("SearchMembers", sqlConnection))
                    {
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adapter.SelectCommand.Parameters.AddWithValue("@searchInput", searchbox);

                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            membergrid.DataSource = table;
                        }
                        else
                        {
                            MessageBox.Show("No records found matching your search.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Cleaner(Guna2TextBox name, Guna2TextBox lastname, Guna2TextBox email, Guna2TextBox address,
            Guna2TextBox phoneNum, TextBox countryTxt, ComboBox countrybox, ComboBox genderbox)
        {
            name.Clear();
            lastname.Clear();
            email.Clear();
            address.Clear();
            phoneNum.Clear();
            countryTxt.Clear();
            countrybox.SelectedIndex = -1;
            genderbox.SelectedIndex = -1;
        }
    }
}
