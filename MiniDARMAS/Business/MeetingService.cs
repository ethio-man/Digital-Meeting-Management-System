using System;
using System.Collections.Generic;
using MiniDARMAS.Data;
using MiniDARMAS.Domain;

namespace MiniDARMAS.Business
{
    public class MeetingService
    {
        private MeetingDao _meetingDao;

        public MeetingService()
        {
            _meetingDao = new MeetingDao();
        }

        public List<Meeting> GetAllMeetings()
        {
            return _meetingDao.GetAllMeetings();
        }

        public void CreateMeeting(Meeting meeting)
        {
            if (string.IsNullOrEmpty(meeting.MeetingNo))
                throw new ArgumentException("Meeting Number is required.");
            
            _meetingDao.AddMeeting(meeting);
        }

        public void CreateAgenda(Agenda agenda)
        {
            if (string.IsNullOrEmpty(agenda.Title))
                throw new ArgumentException("Agenda Title is required.");
            
            _meetingDao.AddAgenda(agenda);
        }

        public List<Agenda> GetAgendas(int meetingId)
        {
            return _meetingDao.GetAgendasByMeetingId(meetingId);
        }

        public void UpdateMeeting(Meeting meeting)
        {
            _meetingDao.UpdateMeeting(meeting);
        }

        public void DeleteMeeting(int meetingId)
        {
            _meetingDao.DeleteMeeting(meetingId);
        }

        public void UpdateAgenda(Agenda agenda)
        {
            if (string.IsNullOrEmpty(agenda.Title))
                throw new ArgumentException("Agenda Title is required.");
            _meetingDao.UpdateAgenda(agenda);
        }

        public void DeleteAgenda(int agendaId)
        {
            _meetingDao.DeleteAgenda(agendaId);
        }
    }
}
