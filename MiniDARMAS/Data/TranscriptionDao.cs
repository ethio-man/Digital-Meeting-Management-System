using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using MiniDARMAS.Domain;

namespace MiniDARMAS.Data
{
    public class TranscriptionDao
    {
        // --- Recording Methods ---
        public List<Recording> GetRecordingsByAgendaId(int agendaId)
        {
            List<Recording> list = new List<Recording>();
            string query = "SELECT * FROM Recordings WHERE AgendaId = @AgendaId";
            SqlParameter[] parameters = { new SqlParameter("@AgendaId", agendaId) };
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Recording
                {
                    RecordingId = Convert.ToInt32(row["RecordingId"]),
                    AgendaId = Convert.ToInt32(row["AgendaId"]),
                    FilePath = row["FilePath"].ToString()
                });
            }
            return list;
        }

        public void AddRecording(Recording recording)
        {
            string query = "INSERT INTO Recordings (AgendaId, FilePath) VALUES (@AgendaId, @FilePath)";
            SqlParameter[] parameters = {
                new SqlParameter("@AgendaId", recording.AgendaId),
                new SqlParameter("@FilePath", recording.FilePath)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        public void DeleteRecording(int recordingId)
        {
            string query = "DELETE FROM Recordings WHERE RecordingId = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", recordingId) };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        public Recording GetRecordingById(int recordingId)
        {
            string query = "SELECT * FROM Recordings WHERE RecordingId = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", recordingId) };
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            if(dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Recording
                {
                    RecordingId = Convert.ToInt32(row["RecordingId"]),
                    AgendaId = Convert.ToInt32(row["AgendaId"]),
                    FilePath = row["FilePath"].ToString()
                };
            }
            return null;
        }

        // --- Assignment Methods ---
        public void CreateAssignment(Assignment assignment)
        {
            string query = "INSERT INTO Assignments (RecordingId, TranscriberId, Status) VALUES (@RecordingId, @TranscriberId, @Status)";
            SqlParameter[] parameters = {
                new SqlParameter("@RecordingId", assignment.RecordingId),
                new SqlParameter("@TranscriberId", assignment.TranscriberId),
                new SqlParameter("@Status", assignment.Status.ToString())
            };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        public List<Assignment> GetAssignmentsByTranscriber(int transcriberId)
        {
            List<Assignment> list = new List<Assignment>();
            string query = "SELECT * FROM Assignments WHERE TranscriberId = @TranscriberId";
            SqlParameter[] parameters = { new SqlParameter("@TranscriberId", transcriberId) };
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            foreach(DataRow row in dt.Rows)
            {
                 list.Add(MapRowToAssignment(row));
            }
            return list;
        }

        public List<TranscriberAssignmentDto> GetTranscriberAssignmentDtos(int transcriberId)
        {
            List<TranscriberAssignmentDto> list = new List<TranscriberAssignmentDto>();
            string query = @"
                SELECT 
                    a.AssignmentId, 
                    a.RecordingId, 
                    m.MeetingNo, 
                    ag.Title as AgendaTitle, 
                    r.FilePath, 
                    a.Status as AssignmentStatus, 
                    t.Status as TranscriptionStatus, 
                    a.AssignedDate 
                FROM Assignments a
                JOIN Recordings r ON a.RecordingId = r.RecordingId
                JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                JOIN Meetings m ON ag.MeetingId = m.MeetingId
                LEFT JOIN Transcriptions t ON a.AssignmentId = t.AssignmentId
                WHERE a.TranscriberId = @TranscriberId";

            SqlParameter[] parameters = { new SqlParameter("@TranscriberId", transcriberId) };
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            
            foreach(DataRow row in dt.Rows)
            {
                 list.Add(new TranscriberAssignmentDto
                 {
                     AssignmentId = Convert.ToInt32(row["AssignmentId"]),
                     RecordingId = Convert.ToInt32(row["RecordingId"]),
                     MeetingNo = row["MeetingNo"].ToString(),
                     AgendaTitle = row["AgendaTitle"].ToString(),
                     AudioFileName = System.IO.Path.GetFileName(row["FilePath"].ToString()),
                     AssignmentStatus = (AssignmentStatus)Enum.Parse(typeof(AssignmentStatus), row["AssignmentStatus"].ToString()),
                     TranscriptionStatus = row["TranscriptionStatus"] == DBNull.Value ? (TranscriptionStatus?)null : (TranscriptionStatus)Enum.Parse(typeof(TranscriptionStatus), row["TranscriptionStatus"].ToString()),
                     AssignedDate = Convert.ToDateTime(row["AssignedDate"])
                 });
            }
            return list;
        }

        // --- Transcription Methods ---
        
        public Transcription GetTranscriptionByAssignmentId(int assignmentId)
        {
            string query = "SELECT * FROM Transcriptions WHERE AssignmentId = @AssignmentId";
            SqlParameter[] parameters = { new SqlParameter("@AssignmentId", assignmentId) };
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            if(dt.Rows.Count > 0)
            {
                return MapRowToTranscription(dt.Rows[0]);
            }
            return null;
        }

        public void SaveTranscription(Transcription transcription)
        {
             // Check if exists
             var existing = GetTranscriptionByAssignmentId(transcription.AssignmentId);
             if (existing == null)
             {
                 string query = "INSERT INTO Transcriptions (AssignmentId, TranscriptionText, Status, Comments, SubmittedDate, LastUpdatedDate) VALUES (@AssignmentId, @Desc, @Status, @Comments, @SubmittedDate, CURRENT_TIMESTAMP)";
                 SqlParameter[] parameters = {
                    new SqlParameter("@AssignmentId", transcription.AssignmentId),
                    new SqlParameter("@Desc", transcription.TranscriptionText ?? (object)DBNull.Value),
                    new SqlParameter("@Status", transcription.Status.ToString()),
                    new SqlParameter("@Comments", transcription.Comments ?? (object)DBNull.Value),
                    new SqlParameter("@SubmittedDate", transcription.SubmittedDate ?? (object)DBNull.Value)
                 };
                 DbHelper.ExecuteNonQuery(query, parameters);
             }
             else
             {
                 string query = "UPDATE Transcriptions SET TranscriptionText = @Desc, Status = @Status, Comments = @Comments, SubmittedDate = @SubmittedDate, LastUpdatedDate = CURRENT_TIMESTAMP WHERE TranscriptionId = @Id";
                  SqlParameter[] parameters = {
                    new SqlParameter("@Id", existing.TranscriptionId),
                    new SqlParameter("@Desc", transcription.TranscriptionText ?? (object)DBNull.Value),
                    new SqlParameter("@Status", transcription.Status.ToString()),
                    new SqlParameter("@Comments", transcription.Comments ?? (object)DBNull.Value),
                    new SqlParameter("@SubmittedDate", transcription.SubmittedDate ?? (object)DBNull.Value)
                 };
                 DbHelper.ExecuteNonQuery(query, parameters);
             }
        }

        public List<Transcription> GetTranscriptionsByStatus(TranscriptionStatus status)
        {
            List<Transcription> list = new List<Transcription>();
            string query = "SELECT * FROM Transcriptions WHERE Status = @Status";
            SqlParameter[] parameters = { new SqlParameter("@Status", status.ToString()) };
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToTranscription(row));
            }
            return list;
        }

        public List<Transcription> GetTranscriptionsByMeetingId(int meetingId)
        {
            // Join to get transcriptions for a specific meeting
            // Meetings -> Agendas -> Recordings -> Assignments -> Transcriptions
            List<Transcription> list = new List<Transcription>();
            string query = @"
                SELECT t.* 
                FROM Transcriptions t
                JOIN Assignments a ON t.AssignmentId = a.AssignmentId
                JOIN Recordings r ON a.RecordingId = r.RecordingId
                JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                WHERE ag.MeetingId = @MeetingId AND t.Status = 'Approved'";
            
            SqlParameter[] parameters = { new SqlParameter("@MeetingId", meetingId) };
            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToTranscription(row));
            }
            return list;
        }

        public List<Meeting> GetMeetingsWithApprovedTranscriptions()
        {
            List<Meeting> list = new List<Meeting>();
            string query = @"
                SELECT DISTINCT m.* 
                FROM Meetings m
                JOIN Agendas ag ON m.MeetingId = ag.MeetingId
                JOIN Recordings r ON ag.AgendaId = r.AgendaId
                JOIN Assignments a ON r.RecordingId = a.RecordingId
                JOIN Transcriptions t ON a.AssignmentId = t.AssignmentId
                WHERE t.Status = 'Approved'
                ORDER BY m.MeetingDate DESC";
            
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

        public int GetMeetingIdForTranscription(int transcriptionId)
        {
             string query = @"
                SELECT ag.MeetingId
                FROM Transcriptions t
                JOIN Assignments a ON t.AssignmentId = a.AssignmentId
                JOIN Recordings r ON a.RecordingId = r.RecordingId
                JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                WHERE t.TranscriptionId = @TId";
             
             SqlParameter[] parameters = { new SqlParameter("@TId", transcriptionId) };
             object result = DbHelper.ExecuteScalar(query, parameters);
             return result != null ? Convert.ToInt32(result) : 0;
        }

        private Assignment MapRowToAssignment(DataRow row)
        {
            return new Assignment
            {
                AssignmentId = Convert.ToInt32(row["AssignmentId"]),
                RecordingId = Convert.ToInt32(row["RecordingId"]),
                TranscriberId = Convert.ToInt32(row["TranscriberId"]),
                AssignedDate = Convert.ToDateTime(row["AssignedDate"]),
                Status = (AssignmentStatus)Enum.Parse(typeof(AssignmentStatus), row["Status"].ToString())
            };
        }

        private Transcription MapRowToTranscription(DataRow row)
        {
            return new Transcription
            {
                TranscriptionId = Convert.ToInt32(row["TranscriptionId"]),
                AssignmentId = Convert.ToInt32(row["AssignmentId"]),
                TranscriptionText = row["TranscriptionText"] == DBNull.Value ? "" : row["TranscriptionText"].ToString(),
                Status = (TranscriptionStatus)Enum.Parse(typeof(TranscriptionStatus), row["Status"].ToString()),
                Comments = row["Comments"] == DBNull.Value ? "" : row["Comments"].ToString(),
                SubmittedDate = row["SubmittedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["SubmittedDate"]),
                LastUpdatedDate = Convert.ToDateTime(row["LastUpdatedDate"])
            };
        }

        /// <summary>
        /// Get count of transcriptions by status for dashboard
        /// </summary>
        public int GetTranscriptionCountByStatus(TranscriptionStatus status)
        {
            string query = "SELECT COUNT(*) FROM Transcriptions WHERE Status = @Status";
            SqlParameter[] parameters = { new SqlParameter("@Status", status.ToString()) };
            object result = DbHelper.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        /// <summary>
        /// Get total count of recordings for dashboard
        /// </summary>
        public int GetTotalRecordingsCount()
        {
            string query = "SELECT COUNT(*) FROM Recordings";
            object result = DbHelper.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}

