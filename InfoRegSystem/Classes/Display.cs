using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InfoRegSystem.Classes
{
    public class Display
    {

        public void DisplayMembers(DataGridView membergrid)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

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
            sqlConnection.Close();
        }
        public void DisplayBorrowRecords(DataGridView borrowrecords)
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

                    borrowrecords.Columns["Penalty"].DefaultCellStyle.Format = "N2";

                    if (borrowrecords.Columns.Contains("Id"))
                    {
                        borrowrecords.Columns["Id"].Visible = false;
                    }

                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DisplayBooks(DataGridView books)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("GetBooks", sqlConnection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                books.DataSource = dataTable;

                if (books.Columns.Contains("BookID"))
                {
                    books.Columns["BookID"].Visible = false;
                }
                sqlConnection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DisplayUserBooks(DataGridView bookgrid)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlconnection.Database);

                sqlConnection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("GetBooks", sqlConnection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                bookgrid.DataSource = dataTable;

                if (bookgrid.Columns.Contains("BookID"))
                {
                    bookgrid.Columns["BookID"].Visible = false;
                }
                sqlConnection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DisplayUserTransaction(DataGridView transactiongrid)
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

                            transactiongrid.Columns["Penalty"].DefaultCellStyle.Format = "N2";
                        }
                    }
                    sqlConnection.Close();
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
    }
}
