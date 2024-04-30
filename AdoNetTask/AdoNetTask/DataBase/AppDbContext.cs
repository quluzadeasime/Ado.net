using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTask.DataBase
{
    internal class AppDbContext
    {
        readonly string connectionStr = "Server = DESKTOP\\SQLEXPRESS;Database = AdoNet;Trusted_connection = true;Integrated security = true";
        SqlConnection sqlConnection;
        public AppDbContext()
        {
            sqlConnection = new SqlConnection(connectionStr);
        }

        public int NonQuery(string command)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                int result = sqlCommand.ExecuteNonQuery();
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"NonQuery error: {ex.Message}");
                return -1;
            }
            finally
            {
                sqlConnection.Close();

            }
        }

        public DataTable Query(string query)
        {
            DataTable table = new DataTable();
            try
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                adapter.Fill(table);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Query error: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }
            return table;
        }
    }
}
