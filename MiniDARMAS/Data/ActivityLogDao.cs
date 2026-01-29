using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using MiniDARMAS.Domain;

namespace MiniDARMAS.Data
{
    /// <summary>
    /// Data Access Object for Activity Logs
    /// </summary>
    public class ActivityLogDao
    {
        /// <summary>
        /// Insert a new activity log entry
        /// </summary>
        public void InsertLog(ActivityLog log)
        {
            string query = @"
                INSERT INTO ActivityLogs (UserId, Username, Role, Action, Timestamp, ReferenceId, ReferenceType, Details) 
                VALUES (@UserId, @Username, @Role, @Action, @Timestamp, @ReferenceId, @ReferenceType, @Details)";

            SqlParameter[] parameters = {
                new SqlParameter("@UserId", log.UserId ?? (object)DBNull.Value),
                new SqlParameter("@Username", log.Username ?? (object)DBNull.Value),
                new SqlParameter("@Role", log.Role ?? (object)DBNull.Value),
                new SqlParameter("@Action", log.Action),
                new SqlParameter("@Timestamp", log.Timestamp),
                new SqlParameter("@ReferenceId", log.ReferenceId ?? (object)DBNull.Value),
                new SqlParameter("@ReferenceType", log.ReferenceType ?? (object)DBNull.Value),
                new SqlParameter("@Details", log.Details ?? (object)DBNull.Value)
            };

            DbHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Get all activity logs ordered by timestamp descending
        /// </summary>
        public List<ActivityLog> GetAllLogs()
        {
            string query = "SELECT * FROM ActivityLogs ORDER BY Timestamp DESC";
            return ExecuteLogQuery(query);
        }

        /// <summary>
        /// Get logs by user ID
        /// </summary>
        public List<ActivityLog> GetLogsByUserId(int userId)
        {
            string query = "SELECT * FROM ActivityLogs WHERE UserId = @UserId ORDER BY Timestamp DESC";
            SqlParameter[] parameters = { new SqlParameter("@UserId", userId) };
            return ExecuteLogQuery(query, parameters);
        }

        /// <summary>
        /// Search logs with optional filters
        /// </summary>
        public List<ActivityLog> SearchLogs(string? searchText, DateTime? fromDate, DateTime? toDate, string? action)
        {
            string query = "SELECT * FROM ActivityLogs WHERE 1=1";
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(searchText))
            {
                query += " AND (Username LIKE @Search OR Action LIKE @Search OR Details LIKE @Search)";
                parameters.Add(new SqlParameter("@Search", $"%{searchText}%"));
            }

            if (fromDate.HasValue)
            {
                query += " AND Timestamp >= @FromDate";
                parameters.Add(new SqlParameter("@FromDate", fromDate.Value.Date));
            }

            if (toDate.HasValue)
            {
                query += " AND Timestamp <= @ToDate";
                parameters.Add(new SqlParameter("@ToDate", toDate.Value.Date.AddDays(1).AddSeconds(-1)));
            }

            if (!string.IsNullOrEmpty(action))
            {
                query += " AND Action = @Action";
                parameters.Add(new SqlParameter("@Action", action));
            }

            query += " ORDER BY Timestamp DESC";

            return ExecuteLogQuery(query, parameters.ToArray());
        }

        /// <summary>
        /// Get distinct action types for filtering
        /// </summary>
        public List<string> GetDistinctActions()
        {
            var actions = new List<string>();
            string query = "SELECT DISTINCT Action FROM ActivityLogs ORDER BY Action";
            DataTable dt = DbHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                actions.Add(row["Action"].ToString() ?? "");
            }

            return actions;
        }

        private List<ActivityLog> ExecuteLogQuery(string query, SqlParameter[]? parameters = null)
        {
            var logs = new List<ActivityLog>();
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                logs.Add(MapRowToActivityLog(row));
            }

            return logs;
        }

        private ActivityLog MapRowToActivityLog(DataRow row)
        {
            return new ActivityLog
            {
                LogId = Convert.ToInt32(row["LogId"]),
                UserId = row["UserId"] == DBNull.Value ? null : Convert.ToInt32(row["UserId"]),
                Username = row["Username"]?.ToString() ?? "",
                Role = row["Role"]?.ToString() ?? "",
                Action = row["Action"]?.ToString() ?? "",
                Timestamp = Convert.ToDateTime(row["Timestamp"]),
                ReferenceId = row["ReferenceId"] == DBNull.Value ? null : Convert.ToInt32(row["ReferenceId"]),
                ReferenceType = row["ReferenceType"]?.ToString(),
                Details = row["Details"]?.ToString()
            };
        }
    }
}
