using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace MiniDARMAS.Data
{
    public static class DbHelper
    {
        // Connection string from App.config
        public static string ConnectionString;

        static DbHelper()
        {
            var settings = ConfigurationManager.ConnectionStrings["MiniDARMAS_DB"];
            if (settings != null)
            {
                ConnectionString = settings.ConnectionString;
            }
            else
            {
                ConnectionString = ""; // Or throw explicit exception
            }
        }

        public static SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new Exception("Connection string 'MiniDARMAS_DB' not found in App.config.");
            }
            return new SqlConnection(ConnectionString);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                var dt = new DataTable();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
