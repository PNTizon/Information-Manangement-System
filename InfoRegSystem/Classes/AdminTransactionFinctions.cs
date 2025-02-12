using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class AdminTransactionFinctions
    {
        public static void PaidButton(DataGridView transactiongrid)
        {
            if (transactiongrid.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to mark as paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int recordId = Convert.ToInt32(transactiongrid.CurrentRow.Cells["Id"].Value);
            object returnDateObj = transactiongrid.CurrentRow.Cells["ReturnDate"].Value;

            if (returnDateObj == DBNull.Value || returnDateObj == null)
            {
                MessageBox.Show("The book has not been returned yet. Payment cannot be processed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to mark as Paid this record?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("Payment", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = recordId;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transactiongrid.CurrentRow.Cells["PaymentStatus"].Value = "Paid";
                            transactiongrid.CurrentRow.Cells["Status"].Value = "Returned";
                            //transactiongrid.CurrentRow.Cells["ReturnDate"].Value = DateTime.Now;

                            MessageBox.Show("Payment successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not update payment status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        public static void SearchTransactions(DataGridView transactiongrid, string searchbox)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("SearchTransactions", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SearchInput", searchbox?.Trim() ?? (object)DBNull.Value);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            transactiongrid.DataSource = table;
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
    }
}