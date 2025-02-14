using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class Display
    {
        public static void DisplayMembers(DataGridView membergrid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
            {
                sqlConnection.Open();

                using (SqlCommand cnn = new SqlCommand("GetMembers", sqlConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cnn);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    membergrid.DataSource = table;

                    if (membergrid.Columns["Id"] != null)
                        membergrid.Columns["Id"].Visible = false;
                }
            }
        }
        public static void DisplayBorrowRecords(DataGridView borrowrecords)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter("GetBorrowData", sqlConnection);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    borrowrecords.DataSource = dataTable;

                    if (borrowrecords.Columns["Id"] != null)
                        borrowrecords.Columns["Id"].Visible = false;

                    if (borrowrecords.Columns["StudentId"] != null)
                        borrowrecords.Columns["StudentId"].Visible = false;

                    if (borrowrecords.Columns["PaymentStatus"] != null)
                        borrowrecords.Columns["PaymentStatus"].Visible = false;

                    //borrowrecords.Columns["Penalty"].DefaultCellStyle.Format = "N2";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void DisplayBooks(DataGridView books)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter("GetBooks", sqlConnection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    books.DataSource = dataTable;

                    if (books.Columns.Contains("BookID"))
                    {
                        books.Columns["BookID"].Visible = false;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void DisplayUserBooks(DataGridView bookgrid)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter("GetBooks", sqlConnection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    bookgrid.DataSource = dataTable;

                    if (bookgrid.Columns.Contains("BookID"))
                    {
                        bookgrid.Columns["BookID"].Visible = false;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void DisplayUserTransaction(DataGridView transactiongrid)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("DisplayUserRecords", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", GlobalUserInfo.FirstName);
                        cmd.Parameters.AddWithValue("@lastname", GlobalUserInfo.Lastname);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            transactiongrid.DataSource = dataTable;

                            if (transactiongrid.Columns.Contains("Id"))
                            {
                                transactiongrid.Columns["Id"].Visible = false;
                            }
                            //transactiongrid.Columns["Penalty"].DefaultCellStyle.Format = "N0";
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database Error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Transaction(DataGridView transaction)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database))
                {
                    sqlConnection.Open();

                    using (SqlCommand command = new SqlCommand("Transactions", sqlConnection))
                    {
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            // Fill the DataTable and bind it to the DataGridView
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            transaction.DataSource = dataTable;

                            if (transaction.Columns["Id"] != null)
                                transaction.Columns["Id"].Visible = false;
                        }
                    }
                    //transaction.Columns["Penalty"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
