using InfoRegSystem.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Forms
{
    public partial class AdminTransactions : Form
    {
        private Display display = new Display();

        public AdminTransactions()
        {
            InitializeComponent();
        }

        private void AdminTransactions_Load(object sender, EventArgs e)
        {
            display.Transaction(transactiongrid);
        }

        private void transactiongrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (transactiongrid.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to mark as paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int recordId = Convert.ToInt32(transactiongrid.CurrentRow.Cells["Id"].Value);
            object returnDateObj = transactiongrid.CurrentRow.Cells["ReturnDate"].Value;

            // Check if the book has been returned
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

                    using (SqlCommand cmd = new SqlCommand("UPDATE borrowtable SET PaymentStatus = 'Paid' , Status = 'Returned' WHERE Id = @Id", sqlConnection))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = recordId;
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transactiongrid.CurrentRow.Cells["PaymentStatus"].Value = "Paid";
                            transactiongrid.CurrentRow.Cells["Status"].Value = "Returned";

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
    }
}
