using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using MiniDARMAS.Domain;

namespace MiniDARMAS.Data
{
    public class UserDao
    {
        public User GetUserByUsername(string username)
        {
            // MSSQL uses @Parameter.
            string query = "SELECT * FROM Users WHERE Username = @Username AND IsActive = 1";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", username)
            };

            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return MapRowToUser(dt.Rows[0]);
            }
            return null;
        }

        public User Authenticate(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @Password AND IsActive = 1";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return MapRowToUser(dt.Rows[0]);
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users";
            DataTable dt = DbHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                users.Add(MapRowToUser(row));
            }
            return users;
        }

        public void AddUser(User user)
        {
            string query = "INSERT INTO Users (Username, PasswordHash, FullName, Role, IsActive) VALUES (@Username, @Password, @FullName, @Role, @IsActive)";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.PasswordHash),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Role", user.Role.ToString()),
                new SqlParameter("@IsActive", user.IsActive)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        public void UpdateUser(User user)
        {
            string query = "UPDATE Users SET PasswordHash = @Password, FullName = @FullName, Role = @Role, IsActive = @IsActive WHERE UserId = @UserId";
            SqlParameter[] parameters = {
                new SqlParameter("@UserId", user.UserId),
                new SqlParameter("@Password", user.PasswordHash),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Role", user.Role.ToString()),
                new SqlParameter("@IsActive", user.IsActive)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        private User MapRowToUser(DataRow row)
        {
            return new User
            {
                UserId = Convert.ToInt32(row["UserId"]),
                Username = row["Username"].ToString(),
                PasswordHash = row["PasswordHash"].ToString(),
                FullName = row["FullName"].ToString(),
                Role = (UserRole)Enum.Parse(typeof(UserRole), row["Role"].ToString()),
                IsActive = Convert.ToBoolean(row["IsActive"])
            };
        }
    }
}
