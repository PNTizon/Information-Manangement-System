using InfoRegSystem.Forms;
using Guna.UI2.WinForms;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using System.Xml.Linq;

namespace InfoRegSystem.Classes
{
    public class MembersFunctions
    {
        private Helpers helpers;
        public MembersFunctions()
        {
            helpers = new Helpers();
        }

        public void SaveMemberInfo(string name, string lastname, int age, string gender, TextBox countryCode, string phonenumber,
            string address, string email, Action displayMethod, Action clearMethod, Action displayMemMethod = null)
        {
            try
            {
                helpers.isValidEmail(email);
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    DateTime day = DateTime.Today;
                    using (SqlCommand cnn = new SqlCommand("AddMember", sqlConnection))
                    {
                        cnn.CommandType = CommandType.StoredProcedure;
                        cnn.Parameters.AddWithValue("@Name", name.Trim());
                        cnn.Parameters.AddWithValue("@Lastname", lastname.Trim());
                        cnn.Parameters.AddWithValue("@Age", age);
                        cnn.Parameters.AddWithValue("@Gender", gender.Trim());
                        cnn.Parameters.AddWithValue("@CountryCode", countryCode.Text);
                        cnn.Parameters.AddWithValue("@PhoneNumber", phonenumber.Trim());
                        cnn.Parameters.AddWithValue("@Address", address.Trim());
                        cnn.Parameters.AddWithValue("@Email", email.Trim());
                        cnn.Parameters.AddWithValue("@DateRegister", day);

                        cnn.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    displayMemMethod?.Invoke();
                    displayMethod();
                    clearMethod();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DeleteMemberInfo(DataGridView membergrid, Action displayMethod, Action clearMethod, Action displayMemMethod = null)
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
                    using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
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
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clearMethod();
            displayMethod();
        }
        public void UpdateMemberInfo(string name, string lastname, string ageText, string gender, TextBox countryCode, 
            string phoneNumber,  string address, string email, DataGridView membergrid,
            Action displayMethod, Action clearMethod, Action displayMemMethod = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || gender == null)
                {
                    MessageBox.Show("Please ensure all fields are filled, including the gender.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                helpers.isValidEmail(email);

                if (membergrid.CurrentRow == null)
                {
                    MessageBox.Show("No record selected. Please select a record to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedID = Convert.ToInt32(membergrid.CurrentRow.Cells["ID"].Value);

                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cnn = new SqlCommand("UpdateMember", sqlConnection))
                    {
                        if (!int.TryParse(ageText, out int parsedAge) || parsedAge < 13 || parsedAge > 60)
                        {
                            MessageBox.Show("Please enter a valid age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        cnn.CommandType = CommandType.StoredProcedure;
                        cnn.Parameters.AddWithValue("@Name", name.Trim());
                        cnn.Parameters.AddWithValue("@Lastname", lastname.Trim());
                        cnn.Parameters.AddWithValue("@Age", parsedAge);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MemberSearch(DataGridView membergrid, Guna2TextBox searchbox)
        {
            string searchInput = searchbox.Text;

            if (string.IsNullOrWhiteSpace(searchInput))
            {
                MessageBox.Show("Search input cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SearchMembers", sqlConnection))
                    {
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adapter.SelectCommand.Parameters.AddWithValue("@searchInput", $"%{searchInput}%");

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
        public void Cleaner(TextBox name, TextBox lastname, TextBox age, TextBox email, TextBox address, TextBox phoneNum, 
            TextBox countryTxt,ComboBox countrybox,ComboBox genderbox)
        {
            name.Clear();
            lastname.Clear();
            age.Clear();
            email.Clear();
            address.Clear();
            phoneNum.Clear();
            countryTxt.Clear();
            countrybox.SelectedIndex = -1;
            genderbox.SelectedIndex = -1;
        }
    }
}
