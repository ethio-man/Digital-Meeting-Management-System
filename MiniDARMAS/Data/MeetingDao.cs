using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using MiniDARMAS.Domain;

namespace MiniDARMAS.Data
{
    public class MeetingDao
    {
        public List<Meeting> GetAllMeetings()
        {
            List<Meeting> list = new List<Meeting>();
            string query = "SELECT * FROM Meetings ORDER BY MeetingDate DESC";
            DataTable dt = DbHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Meeting
                {
                    MeetingId = Convert.ToInt32(row["MeetingId"]),
                    MeetingNo = row["MeetingNo"].ToString(),
                    MeetingDate = Convert.ToDateTime(row["MeetingDate"]),
                    Location = row["Location"].ToString(),
                    Chairperson = row["Chairperson"].ToString()
                });
            }
            return list;
        }

        public void AddMeeting(Meeting meeting)
        {
            string query = "INSERT INTO Meetings (MeetingNo, MeetingDate, Location, Chairperson) VALUES (@MeetingNo, @MeetingDate, @Location, @Chairperson)";
            SqlParameter[] parameters = {
                new SqlParameter("@MeetingNo", meeting.MeetingNo),
                new SqlParameter("@MeetingDate", meeting.MeetingDate),
                new SqlParameter("@Location", meeting.Location),
                new SqlParameter("@Chairperson", meeting.Chairperson)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        public void UpdateMeeting(Meeting meeting)
        {
            string query = "UPDATE Meetings SET MeetingDate = @MeetingDate, Location = @Location, Chairperson = @Chairperson WHERE MeetingId = @MeetingId";
            SqlParameter[] parameters = {
                new SqlParameter("@MeetingId", meeting.MeetingId),
                new SqlParameter("@MeetingDate", meeting.MeetingDate),
                new SqlParameter("@Location", meeting.Location),
                new SqlParameter("@Chairperson", meeting.Chairperson)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        public void DeleteMeeting(int meetingId)
        {
            string query = "DELETE FROM Meetings WHERE MeetingId = @MeetingId";
            SqlParameter[] parameters = { new SqlParameter("@MeetingId", meetingId) };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        // --- Agenda Methods ---

        public List<Agenda> GetAgendasByMeetingId(int meetingId)
        {
            List<Agenda> list = new List<Agenda>();
            string query = "SELECT * FROM Agendas WHERE MeetingId = @MeetingId";
            SqlParameter[] parameters = { new SqlParameter("@MeetingId", meetingId) };
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Agenda
                {
                    AgendaId = Convert.ToInt32(row["AgendaId"]),
                    MeetingId = Convert.ToInt32(row["MeetingId"]),
                    Title = row["Title"].ToString(),
                    Office = row["Office"].ToString(),
                    DocumentPath = row["DocumentPath"].ToString()
                });
            }
            return list;
        }

        public void AddAgenda(Agenda agenda)
        {
            string query = "INSERT INTO Agendas (MeetingId, Title, Office, DocumentPath) VALUES (@MeetingId, @Title, @Office, @DocumentPath)";
            SqlParameter[] parameters = {
                new SqlParameter("@MeetingId", agenda.MeetingId),
                new SqlParameter("@Title", agenda.Title),
                new SqlParameter("@Office", agenda.Office),
                new SqlParameter("@DocumentPath", agenda.DocumentPath ?? (object)DBNull.Value)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        public void DeleteAgenda(int agendaId)
        {
            string query = "DELETE FROM Agendas WHERE AgendaId = @AgendaId";
            SqlParameter[] parameters = { new SqlParameter("@AgendaId", agendaId) };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        public void UpdateAgenda(Agenda agenda)
        {
             string query = "UPDATE Agendas SET Title = @Title, Office = @Office, DocumentPath = @DocumentPath WHERE AgendaId = @AgendaId";
             SqlParameter[] parameters = {
                new SqlParameter("@AgendaId", agenda.AgendaId),
                new SqlParameter("@Title", agenda.Title),
                new SqlParameter("@Office", agenda.Office),
                new SqlParameter("@DocumentPath", agenda.DocumentPath ?? (object)DBNull.Value)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Get total count of meetings for dashboard
        /// </summary>
        public int GetTotalMeetingsCount()
        {
            string query = "SELECT COUNT(*) FROM Meetings";
            object result = DbHelper.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}
