using System;
using System.Collections.Generic;
using MiniDARMAS.Data;
using MiniDARMAS.Domain;

namespace MiniDARMAS.Business
{
    /// <summary>
    /// Centralized static service for activity logging throughout the application
    /// </summary>
    public static class ActivityLogService
    {
        private static readonly ActivityLogDao _activityLogDao = new ActivityLogDao();

        /// <summary>
        /// Log an activity with user context
        /// </summary>
        /// <param name="user">The user performing the action</param>
        /// <param name="action">Description of the action</param>
        /// <param name="referenceId">Optional ID of related entity</param>
        /// <param name="referenceType">Optional type of related entity (Meeting, Recording, etc.)</param>
        /// <param name="details">Optional additional details</param>
        public static void Log(User? user, string action, int? referenceId = null, 
            string? referenceType = null, string? details = null)
        {
            try
            {
                var log = new ActivityLog
                {
                    UserId = user?.UserId,
                    Username = user?.Username ?? "System",
                    Role = user?.Role.ToString() ?? "System",
                    Action = action,
                    Timestamp = DateTime.Now,
                    ReferenceId = referenceId,
                    ReferenceType = referenceType,
                    Details = details
                };

                _activityLogDao.InsertLog(log);
            }
            catch
            {
                // Logging should not interrupt application flow
                // In production, you might want to log this failure to a file
            }
        }

        /// <summary>
        /// Log an activity without user context (system actions)
        /// </summary>
        public static void LogSystem(string action, string? details = null)
        {
            Log(null, action, null, null, details);
        }

        /// <summary>
        /// Get all activity logs
        /// </summary>
        public static List<ActivityLog> GetAllLogs()
        {
            return _activityLogDao.GetAllLogs();
        }

        /// <summary>
        /// Get logs for a specific user
        /// </summary>
        public static List<ActivityLog> GetLogsByUserId(int userId)
        {
            return _activityLogDao.GetLogsByUserId(userId);
        }

        /// <summary>
        /// Search logs with filters
        /// </summary>
        public static List<ActivityLog> SearchLogs(string? searchText = null, 
            DateTime? fromDate = null, DateTime? toDate = null, string? action = null)
        {
            return _activityLogDao.SearchLogs(searchText, fromDate, toDate, action);
        }

        /// <summary>
        /// Get distinct action types for filtering
        /// </summary>
        public static List<string> GetDistinctActions()
        {
            return _activityLogDao.GetDistinctActions();
        }
    }
}
