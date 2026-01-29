using System;
using MiniDARMAS.Data;
using MiniDARMAS.Domain;

namespace MiniDARMAS.Business
{
    /// <summary>
    /// Service for retrieving dashboard statistics
    /// </summary>
    public class DashboardService
    {
        private readonly MeetingDao _meetingDao;
        private readonly TranscriptionDao _transcriptionDao;

        public DashboardService()
        {
            _meetingDao = new MeetingDao();
            _transcriptionDao = new TranscriptionDao();
        }

        /// <summary>
        /// Get total number of meetings
        /// </summary>
        public int GetTotalMeetings()
        {
            return _meetingDao.GetTotalMeetingsCount();
        }

        /// <summary>
        /// Get total number of recordings
        /// </summary>
        public int GetTotalRecordings()
        {
            return _transcriptionDao.GetTotalRecordingsCount();
        }

        /// <summary>
        /// Get count of pending transcriptions (Draft + Submitted + UnderReview)
        /// </summary>
        public int GetPendingTranscriptions()
        {
            return _transcriptionDao.GetTranscriptionCountByStatus(TranscriptionStatus.Draft)
                + _transcriptionDao.GetTranscriptionCountByStatus(TranscriptionStatus.Submitted)
                + _transcriptionDao.GetTranscriptionCountByStatus(TranscriptionStatus.UnderReview);
        }

        /// <summary>
        /// Get count of completed transcriptions (Approved + Final)
        /// </summary>
        public int GetCompletedTranscriptions()
        {
            return _transcriptionDao.GetTranscriptionCountByStatus(TranscriptionStatus.Approved)
                + _transcriptionDao.GetTranscriptionCountByStatus(TranscriptionStatus.Final);
        }

        /// <summary>
        /// Get count of approved final documents
        /// </summary>
        public int GetApprovedDocuments()
        {
            return _transcriptionDao.GetTranscriptionCountByStatus(TranscriptionStatus.Approved);
        }

        /// <summary>
        /// Get count of finalized documents
        /// </summary>
        public int GetFinalizedDocuments()
        {
            return _transcriptionDao.GetTranscriptionCountByStatus(TranscriptionStatus.Final);
        }

        /// <summary>
        /// Get all dashboard stats as a tuple
        /// </summary>
        public (int totalMeetings, int totalRecordings, int pendingTranscriptions, 
            int completedTranscriptions, int approvedDocuments) GetAllStats()
        {
            return (
                GetTotalMeetings(),
                GetTotalRecordings(),
                GetPendingTranscriptions(),
                GetCompletedTranscriptions(),
                GetApprovedDocuments()
            );
        }
    }
}
