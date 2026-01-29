using System;
using System.Collections.Generic;
using System.Linq; // Need for specific queries ta use them for finding items
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Data;
using MiniDARMAS.Domain;
using MiniDARMAS.Infrastructure;

namespace MiniDARMAS.Forms.Operator
{
    public partial class MeetingManagerForm : Form
    {
        private User _currentUser;
        private MeetingService _meetingService;
        private WorkFlowService _workFlowService;
        private UserDao _userDao; // Need to list transcribers

        private Meeting? _selectedMeeting;
        private Agenda? _selectedAgenda;

        public MeetingManagerForm(User user)
        {
            InitializeComponent();
            FormTheme.Apply(this);
            _currentUser = user;
            _meetingService = new MeetingService();
            _workFlowService = new WorkFlowService();
            _userDao = new UserDao();
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);

            LocalizationManager.AutoLocalize(this);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabExit)
            {
                this.Close();
            }
        }


        private void MeetingManagerForm_Load(object sender, EventArgs e)
        {
            LoadMeetings();
            LoadTranscribers();
        }

        // --- Tab 1: Meetings ---

        private void LoadMeetings()
        {
            var meetings = _meetingService.GetAllMeetings();
            dgvMeetings.DataSource = meetings;
            
            // Also update combobox in Tab 2
            cmbMeetings.DataSource = null; // Reset
            cmbMeetings.DataSource = meetings;
            cmbMeetings.DisplayMember = "MeetingNo";
            cmbMeetings.ValueMember = "MeetingId";
        }

        private void btnSaveMeeting_Click(object sender, EventArgs e)
        {
            try
            {
                var meeting = new Meeting
                {
                    MeetingNo = txtMeetingNo.Text,
                    MeetingDate = dtpDate.Value,
                    Location = txtLocation.Text,
                    Chairperson = txtChairperson.Text
                };

                if (_selectedMeeting == null)
                {
                    _meetingService.CreateMeeting(meeting);
                    ActivityLogService.Log(_currentUser, "Created Meeting", null, "Meeting", $"Meeting No: {meeting.MeetingNo}");
                    MessageBox.Show("Meeting created.");
                }
                else
                {
                    meeting.MeetingId = _selectedMeeting.MeetingId;
                    _meetingService.UpdateMeeting(meeting);
                    ActivityLogService.Log(_currentUser, "Updated Meeting", meeting.MeetingId, "Meeting", $"Meeting No: {meeting.MeetingNo}");
                    MessageBox.Show("Meeting updated.");
                }
                LoadMeetings();
                ClearMeetingForm();
                LoadMeetings();
                ClearMeetingForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnDeleteMeeting_Click(object sender, EventArgs e)
        {
             if (_selectedMeeting == null) return;
             var result = MessageBox.Show("Are you sure? This will delete all agendas and recordings.", "Confirm", MessageBoxButtons.YesNo);
             if (result == DialogResult.Yes)
             {
                  try {
                      int mId = _selectedMeeting.MeetingId;
                      string mNo = _selectedMeeting.MeetingNo;
                      _meetingService.DeleteMeeting(mId);
                      ActivityLogService.Log(_currentUser, "Deleted Meeting", mId, "Meeting", $"Meeting No: {mNo}");
                      LoadMeetings();
                      ClearMeetingForm();
                  } catch(Exception ex) { MessageBox.Show("Error: " + ex.Message); }
             }
        }

        private void dgvMeetings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMeetings.SelectedRows.Count > 0)
            {
                _selectedMeeting = (Meeting)dgvMeetings.SelectedRows[0].DataBoundItem;
                txtMeetingNo.Text = _selectedMeeting.MeetingNo;
                dtpDate.Value = _selectedMeeting.MeetingDate;
                txtLocation.Text = _selectedMeeting.Location;
                txtChairperson.Text = _selectedMeeting.Chairperson;
                btnSaveMeeting.Text = "Update Meeting";
            }
        }

        private void ClearMeetingForm()
        {
            _selectedMeeting = null;
            txtMeetingNo.Text = "";
            txtLocation.Text = "";
            txtChairperson.Text = "";
            dtpDate.Value = DateTime.Now;
            btnSaveMeeting.Text = "Save Meeting";
        }


        // --- Tab 2: Agendas ---

        private void LoadTranscribers()
        {
            var users = _userDao.GetAllUsers();
            var transcribers = new List<User>();
            foreach(var u in users) if(u.Role == UserRole.Transcriber) transcribers.Add(u);

            cmbTranscribers.DataSource = transcribers;
            cmbTranscribers.DisplayMember = "Username";
            cmbTranscribers.ValueMember = "UserId";
        }

        private void cmbMeetings_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAgendaList();
        }
        
        // --- Added for Recordings List management ---
        private void RefreshRecordingsList()
        {
            if (_selectedAgenda != null)
            {
                lblSelectedAgendaRec.Text = "Selected Agenda: " + _selectedAgenda.Title;
                // We need to access GetRecordings from WorkFlowService or move it to MeetingService?
                // It is in WorkFlowService.
                dgvRecordings.DataSource = _workFlowService.GetRecordings(_selectedAgenda.AgendaId);
            }
            else
            {
                lblSelectedAgendaRec.Text = "Selected Agenda: None";
                dgvRecordings.DataSource = null;
            }
        }
        
        private void btnBrowseRec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Audio Files|*.mp3;*.wav;*.m4a|All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtRecordingPath.Text = ofd.FileName;
            }
        }

        private void RefreshAgendaList()
        {
             if (cmbMeetings.SelectedItem != null)
            {
                var meeting = (Meeting)cmbMeetings.SelectedItem;
                dgvAgendas.DataSource = _meetingService.GetAgendas(meeting.MeetingId);
            }
        }

        private void btnSaveAgenda_Click(object sender, EventArgs e)
        {
            if (cmbMeetings.SelectedItem == null) { MessageBox.Show("Select a meeting first."); return; }

            try
            {
                var meeting = (Meeting)cmbMeetings.SelectedItem;
                var agenda = new Agenda
                {
                    MeetingId = meeting.MeetingId,
                    Title = txtAgendaTitle.Text,
                    Office = txtOffice.Text,
                    DocumentPath = txtDocPath.Text
                };
                _meetingService.CreateAgenda(agenda);
                ActivityLogService.Log(_currentUser, "Added Agenda", meeting.MeetingId, "Meeting", $"Agenda Title: {agenda.Title}");
                RefreshAgendaList();
                txtAgendaTitle.Text = "";
                txtOffice.Text = "";
                txtDocPath.Text = "";
                MessageBox.Show("Agenda added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
             
        private void btnUpdateAgenda_Click(object sender, EventArgs e)
        {
             if (_selectedAgenda == null) return;
             
             try
             {
                 _selectedAgenda.Title = txtAgendaTitle.Text;
                 _selectedAgenda.Office = txtOffice.Text;
                 _selectedAgenda.DocumentPath = txtDocPath.Text;
                 
                 _meetingService.UpdateAgenda(_selectedAgenda);
                 ActivityLogService.Log(_currentUser, "Updated Agenda", _selectedAgenda.AgendaId, "Agenda", $"Title: {_selectedAgenda.Title}");
                 RefreshAgendaList();
                 MessageBox.Show("Agenda updated.");
             }
             catch(Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnDeleteAgenda_Click(object sender, EventArgs e)
        {
             if (_selectedAgenda == null) return;
             if(MessageBox.Show("Delete this agenda?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                 try
                 {
                     int aId = _selectedAgenda.AgendaId;
                     string aTitle = _selectedAgenda.Title;
                     _meetingService.DeleteAgenda(aId);
                     ActivityLogService.Log(_currentUser, "Deleted Agenda", aId, "Agenda", $"Title: {aTitle}");
                     RefreshAgendaList();
                     ClearAgendaForm(); // Need to implement or just clear fields
                 }
                 catch(Exception ex) { MessageBox.Show("Error: " + ex.Message); }
             }
        }
        
        private void ClearAgendaForm()
        {
            _selectedAgenda = null;
            txtAgendaTitle.Text = "";
            txtOffice.Text = "";
            txtDocPath.Text = "";
        }

        private void dgvAgendas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAgendas.SelectedRows.Count > 0)
            {
                _selectedAgenda = (Agenda)dgvAgendas.SelectedRows[0].DataBoundItem;
                txtAgendaTitle.Text = _selectedAgenda.Title;
                txtOffice.Text = _selectedAgenda.Office;
                txtDocPath.Text = _selectedAgenda.DocumentPath;
                RefreshRecordingsList(); // Update recordings view if we are on that tab or switching
            }
        }


        private void btnDeleteRecording_Click(object sender, EventArgs e)
        {
             if(dgvRecordings.SelectedRows.Count == 0) return;
             if(MessageBox.Show("Delete selected recording?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                 try
                 {
                     var rec = (Recording)dgvRecordings.SelectedRows[0].DataBoundItem;
                     _workFlowService.DeleteRecording(rec.RecordingId);
                     ActivityLogService.Log(_currentUser, "Deleted Recording", rec.RecordingId, "Recording", $"Path: {rec.FilePath}");
                     RefreshRecordingsList();
                 }
                 catch(Exception ex) { MessageBox.Show("Error: " + ex.Message); }
             }
        }
        
        private void btnAddRecording_Click(object sender, EventArgs e)
        {
            if(_selectedAgenda == null) { MessageBox.Show("Select an agenda first."); return; }
            if(string.IsNullOrEmpty(txtRecordingPath.Text)) { MessageBox.Show("Enter file path."); return; }

            try
            {
                var rec = new Recording
                {
                    AgendaId = _selectedAgenda.AgendaId,
                    FilePath = txtRecordingPath.Text
                };
                _workFlowService.AddRecording(rec);

                ActivityLogService.Log(_currentUser, "Added Recording", rec.RecordingId, "Recording", $"Path: {rec.FilePath}");
                MessageBox.Show("Recording attached to Agenda.");
                RefreshRecordingsList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAssignTranscriber_Click(object sender, EventArgs e)
        {
            if(_selectedAgenda == null) { MessageBox.Show("Select an agenda first."); return; }
            
            // We need to find the recording for this agenda.
            var recordings = _workFlowService.GetRecordings(_selectedAgenda.AgendaId);
            if(recordings.Count == 0)
            {
                 MessageBox.Show("No recording found for this agenda. Add one first.");
                 return;
            }
            
            // Just take the first one or last one
            var rec = recordings[recordings.Count - 1];

            if(cmbTranscribers.SelectedItem == null) return;
            var transcriber = (User)cmbTranscribers.SelectedItem;

            try
            {
                _workFlowService.AssignTranscriber(rec.RecordingId, transcriber.UserId);
                ActivityLogService.Log(_currentUser, "Assigned Transcriber", rec.RecordingId, "Recording", $"Assigned to: {transcriber.Username}");
                MessageBox.Show($"Assigned to {transcriber.Username}");
            }
             catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
