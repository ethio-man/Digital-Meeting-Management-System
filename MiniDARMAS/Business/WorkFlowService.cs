using System;
using System.Collections.Generic;
using MiniDARMAS.Data;
using MiniDARMAS.Domain;

namespace MiniDARMAS.Business
{
    public class WorkFlowService
    {
        private TranscriptionDao _transcriptionDao;

        public WorkFlowService()
        {
            _transcriptionDao = new TranscriptionDao();
        }

        public void AddRecording(Recording recording)
        {
            _transcriptionDao.AddRecording(recording);
        }

        public List<Recording> GetRecordings(int agendaId)
        {
            return _transcriptionDao.GetRecordingsByAgendaId(agendaId);
        }

        public void DeleteRecording(int recordingId)
        {
            _transcriptionDao.DeleteRecording(recordingId);
        }

        public Recording GetRecording(int recordingId)
        {
            return _transcriptionDao.GetRecordingById(recordingId);
        }

        public void AssignTranscriber(int recordingId, int transcriberId)
        {
            var assignment = new Assignment
            {
                RecordingId = recordingId,
                TranscriberId = transcriberId,
                Status = AssignmentStatus.Assigned
            };
            _transcriptionDao.CreateAssignment(assignment);
        }

        public List<Assignment> GetTranscriberAssignments(int transcriberId)
        {
            return _transcriptionDao.GetAssignmentsByTranscriber(transcriberId);
        }

        public List<TranscriberAssignmentDto> GetTranscriberAssignmentDtos(int transcriberId)
        {
            return _transcriptionDao.GetTranscriberAssignmentDtos(transcriberId);
        }

        public Transcription GetTranscription(int assignmentId)
        {
            return _transcriptionDao.GetTranscriptionByAssignmentId(assignmentId);
        }

        public void UpdateTranscription(Transcription transcription)
        {
            _transcriptionDao.SaveTranscription(transcription);
        }

        public List<Transcription> GetTranscriptionsByStatus(TranscriptionStatus status)
        {
            return _transcriptionDao.GetTranscriptionsByStatus(status);
        }

        public List<Meeting> GetMeetingsWithApprovedTranscriptions()
        {
            return _transcriptionDao.GetMeetingsWithApprovedTranscriptions();
        }

        public string GetCombinedTranscriptionForMeeting(int transcriptionId)
        {
            // Find the meeting ID from this transcription
            int meetingId = _transcriptionDao.GetMeetingIdForTranscription(transcriptionId);
            if(meetingId == 0) return "";

            // Get all approved transcriptions for this meeting
            List<Transcription> all = _transcriptionDao.GetTranscriptionsByMeetingId(meetingId);
            
            // Combine
            string combined = $"MEETING MINUTES (ID: {meetingId})\n\n";
            foreach(var t in all)
            {
                combined += $"--- AGENDA ITEM ---\n{t.TranscriptionText}\n\n";
            }
            combined += "--- END OF MEETING ---";
            return combined;
        }

        public string GetCombinedTranscriptionByMeetingId(int meetingId)
        {
            List<Transcription> all = _transcriptionDao.GetTranscriptionsByMeetingId(meetingId);
             
            // We need to order them by Agenda logic preferably?
            // The DAO currently just gets them. 
            // Better to order by Agenda ID or Title in the DAO if possible, or here?
            // Let's assume DAO returns them in some order or we accept list order.
            
            string combined = $"MEETING MINUTES (ID: {meetingId})\n\n";
            foreach(var t in all)
            {
                // Retrieve Agenda title?
                // DAO only returns Transcription object.
                // We might want to enrich the text with Agenda Title.
                // For now sticking to simple requirement.
                combined += $"--- AGENDA ITEM ---\n{t.TranscriptionText}\n\n";
            }
            combined += "--- END OF MEETING ---";
            return combined;
        }
    }
}
