using System;

namespace MiniDARMAS.Domain
{
    public enum UserRole
    {
        Admin,
        Operator,
        Transcriber,
        Editor,
        Approver
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string FullName { get; set; } = "";
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public string PreferredLanguage { get; set; } = "en"; // For multi-language UI
    }

    public class Meeting
    {
        public int MeetingId { get; set; }
        public string MeetingNo { get; set; } = "";
        public DateTime MeetingDate { get; set; }
        public string Location { get; set; } = "";
        public string Chairperson { get; set; } = "";
    }

    public class Agenda
    {
        public int AgendaId { get; set; }
        public int MeetingId { get; set; }
        public string Title { get; set; } = "";
        public string Office { get; set; } = "";
        public string DocumentPath { get; set; } = "";
    }

    public class Recording
    {
        public int RecordingId { get; set; }
        public int AgendaId { get; set; }
        public string FilePath { get; set; } = "";
    }

    public enum AssignmentStatus
    {
        Assigned,
        InProgress,
        Completed
    }

    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int RecordingId { get; set; }
        public int TranscriberId { get; set; }
        public DateTime AssignedDate { get; set; }
        public AssignmentStatus Status { get; set; }
    }

    public enum TranscriptionStatus
    {
        Draft,
        Submitted,
        UnderReview,
        Approved,
        Returned,
        Final
    }

    public class Transcription
    {
        public int TranscriptionId { get; set; }
        public int AssignmentId { get; set; }
        public string TranscriptionText { get; set; } = "";
        public TranscriptionStatus Status { get; set; }
        public string Comments { get; set; } = "";
        public DateTime? SubmittedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }

    public class TranscriberAssignmentDto
    {
        public int AssignmentId { get; set; }
        public int RecordingId { get; set; }
        public string MeetingNo { get; set; } = "";
        public string AgendaTitle { get; set; } = "";
        public string AudioFileName { get; set; } = "";
        public AssignmentStatus AssignmentStatus { get; set; }
        public TranscriptionStatus? TranscriptionStatus { get; set; }
        public DateTime AssignedDate { get; set; }
    }

    /// <summary>
    /// Activity log entry for audit trail
    /// </summary>
    public class ActivityLog
    {
        public int LogId { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";
        public string Action { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; }
        public string? Details { get; set; }
    }
}

