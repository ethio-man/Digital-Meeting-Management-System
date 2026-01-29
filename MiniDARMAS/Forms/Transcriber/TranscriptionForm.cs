using System;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Domain;
using System.Diagnostics;
using System.IO;
using MiniDARMAS.Forms;
using NAudio.Wave;
using MiniDARMAS.Infrastructure;

namespace MiniDARMAS.Forms.Transcriber
{
    public partial class TranscriptionForm : Form
    {
        private User _currentUser;
        private WorkFlowService _workFlowService;
        private TranscriberAssignmentDto? _selectedAssignment;
        private Transcription? _currentTranscription;

        // Audio player components
        private WaveOutEvent? _waveOut;
        private AudioFileReader? _audioFileReader;
        private System.Windows.Forms.Timer _playbackTimer;
        private bool _isPlaying = false;
        private bool _isDraggingSeekBar = false;

        public TranscriptionForm(User user)
        {
            InitializeComponent();
            FormTheme.Apply(this);
            _currentUser = user;
            _workFlowService = new WorkFlowService();

            // Initialize playback timer
            _playbackTimer = new System.Windows.Forms.Timer();
            _playbackTimer.Interval = 500;
            _playbackTimer.Tick += PlaybackTimer_Tick;

            // Wire up audio control events
            btnPlay.Click += BtnPlay_Click;
            btnPause.Click += BtnPause_Click;
            btnStop.Click += BtnStop_Click;
            trackBarSeek.MouseDown += TrackBarSeek_MouseDown;
            trackBarSeek.MouseUp += TrackBarSeek_MouseUp;
            trackBarSeek.Scroll += TrackBarSeek_Scroll;

            this.FormClosing += TranscriptionForm_FormClosing;

            LocalizationManager.AutoLocalize(this);
        }

        private void TranscriptionForm_Load(object sender, EventArgs e)
        {
            LoadAssignments();
            UpdateAudioControlsState(false);
        }

        private void TranscriptionForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            StopAudio();
            DisposeAudio();
        }

        private void LoadAssignments()
        {
            dgvAssignments.DataSource = _workFlowService.GetTranscriberAssignmentDtos(_currentUser.UserId);
        }

        private void dgvAssignments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAssignments.SelectedRows.Count > 0)
            {
                var assignment = (TranscriberAssignmentDto)dgvAssignments.SelectedRows[0].DataBoundItem;
                _selectedAssignment = assignment;

                // Stop any playing audio when changing selection
                StopAudio();

                // Load detailed recording info to get path
                var recording = _workFlowService.GetRecording(assignment.RecordingId);
                if (recording != null)
                {
                    lblAudioFile.Text = $"File: {Path.GetFileName(recording.FilePath)}";
                    lblAudioFile.Tag = recording.FilePath; // Store path in Tag

                    // Load audio if file exists
                    LoadAudioFile(recording.FilePath);
                }
                else
                {
                    lblAudioFile.Text = "Recording file not found.";
                    lblAudioFile.Tag = null;
                    UpdateAudioControlsState(false);
                }

                _currentTranscription = _workFlowService.GetTranscription(assignment.AssignmentId);
                if (_currentTranscription != null)
                {
                    txtTranscription.Text = _currentTranscription.TranscriptionText;

                    // Show comments if returned
                    if (_currentTranscription.Status == TranscriptionStatus.Returned)
                    {
                        lblComments.Visible = true;
                        txtComments.Visible = true;
                        txtComments.Text = _currentTranscription.Comments;
                    }
                    else
                    {
                        lblComments.Visible = false;
                        txtComments.Visible = false;
                    }
                }
                else
                {
                    txtTranscription.Text = "";
                    lblComments.Visible = false;
                    txtComments.Visible = false;

                    _currentTranscription = new Transcription
                    {
                        AssignmentId = assignment.AssignmentId,
                        Status = TranscriptionStatus.Draft
                    };
                }
            }
        }

        #region Audio Playback Methods

        private void LoadAudioFile(string filePath)
        {
            DisposeAudio();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                lblCurrentTime.Text = "00:00";
                lblDuration.Text = "00:00";
                trackBarSeek.Value = 0;
                UpdateAudioControlsState(false);

                if (!string.IsNullOrEmpty(filePath) && !File.Exists(filePath))
                {
                    lblAudioFile.Text = $"File not found: {Path.GetFileName(filePath)}";
                }
                return;
            }

            try
            {
                _audioFileReader = new AudioFileReader(filePath);
                _waveOut = new WaveOutEvent();
                _waveOut.Init(_audioFileReader);
                _waveOut.PlaybackStopped += WaveOut_PlaybackStopped;

                // Set up trackbar
                trackBarSeek.Minimum = 0;
                trackBarSeek.Maximum = (int)_audioFileReader.TotalTime.TotalSeconds;
                trackBarSeek.Value = 0;

                lblCurrentTime.Text = "00:00";
                lblDuration.Text = FormatTime(_audioFileReader.TotalTime);

                UpdateAudioControlsState(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading audio file: {ex.Message}", "Audio Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UpdateAudioControlsState(false);
            }
        }

        private void BtnPlay_Click(object? sender, EventArgs e)
        {
            if (_waveOut != null && _audioFileReader != null)
            {
                if (_waveOut.PlaybackState == PlaybackState.Stopped)
                {
                    _audioFileReader.Position = 0;
                }
                _waveOut.Play();
                _isPlaying = true;
                _playbackTimer.Start();
                UpdatePlayPauseButtons();
            }
        }

        private void BtnPause_Click(object? sender, EventArgs e)
        {
            if (_waveOut != null)
            {
                _waveOut.Pause();
                _isPlaying = false;
                _playbackTimer.Stop();
                UpdatePlayPauseButtons();
            }
        }

        private void BtnStop_Click(object? sender, EventArgs e)
        {
            StopAudio();
        }

        private void StopAudio()
        {
            if (_waveOut != null)
            {
                _waveOut.Stop();
                _isPlaying = false;
                _playbackTimer.Stop();

                if (_audioFileReader != null)
                {
                    _audioFileReader.Position = 0;
                }

                trackBarSeek.Value = 0;
                lblCurrentTime.Text = "00:00";
                UpdatePlayPauseButtons();
            }
        }

        private void WaveOut_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => HandlePlaybackStopped()));
            }
            else
            {
                HandlePlaybackStopped();
            }
        }

        private void HandlePlaybackStopped()
        {
            _isPlaying = false;
            _playbackTimer.Stop();
            UpdatePlayPauseButtons();
        }

        private void PlaybackTimer_Tick(object? sender, EventArgs e)
        {
            if (_audioFileReader != null && !_isDraggingSeekBar)
            {
                int currentSeconds = (int)_audioFileReader.CurrentTime.TotalSeconds;
                if (currentSeconds <= trackBarSeek.Maximum)
                {
                    trackBarSeek.Value = currentSeconds;
                }
                lblCurrentTime.Text = FormatTime(_audioFileReader.CurrentTime);
            }
        }

        private void TrackBarSeek_MouseDown(object? sender, MouseEventArgs e)
        {
            _isDraggingSeekBar = true;
        }

        private void TrackBarSeek_MouseUp(object? sender, MouseEventArgs e)
        {
            _isDraggingSeekBar = false;
            SeekToPosition();
        }

        private void TrackBarSeek_Scroll(object? sender, EventArgs e)
        {
            if (_isDraggingSeekBar && _audioFileReader != null)
            {
                lblCurrentTime.Text = FormatTime(TimeSpan.FromSeconds(trackBarSeek.Value));
            }
        }

        private void SeekToPosition()
        {
            if (_audioFileReader != null)
            {
                _audioFileReader.CurrentTime = TimeSpan.FromSeconds(trackBarSeek.Value);
                lblCurrentTime.Text = FormatTime(_audioFileReader.CurrentTime);
            }
        }

        private void UpdateAudioControlsState(bool enabled)
        {
            btnPlay.Enabled = enabled;
            btnPause.Enabled = enabled;
            btnStop.Enabled = enabled;
            trackBarSeek.Enabled = enabled;
        }

        private void UpdatePlayPauseButtons()
        {
            btnPlay.Enabled = !_isPlaying && _waveOut != null;
            btnPause.Enabled = _isPlaying;
        }

        private void DisposeAudio()
        {
            _playbackTimer.Stop();

            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
                _waveOut = null;
            }

            if (_audioFileReader != null)
            {
                _audioFileReader.Dispose();
                _audioFileReader = null;
            }
        }

        private string FormatTime(TimeSpan time)
        {
            return $"{(int)time.TotalMinutes:D2}:{time.Seconds:D2}";
        }

        #endregion

        #region Transcription Methods

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            SaveTranscription(TranscriptionStatus.Draft);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to submit? It will be sent for review.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SaveTranscription(TranscriptionStatus.Submitted);
            }
        }

        private void SaveTranscription(TranscriptionStatus status)
        {
            try
            {
                if (_selectedAssignment == null) return;

                _currentTranscription!.TranscriptionText = txtTranscription.Text;
                _currentTranscription.Status = status;
                if (status == TranscriptionStatus.Submitted)
                {
                    _currentTranscription.SubmittedDate = DateTime.Now;
                }

                _workFlowService.UpdateTranscription(_currentTranscription);

                // Log the action
                string action = status == TranscriptionStatus.Submitted ? "Submitted Transcription" : "Saved Transcription Draft";
                ActivityLogService.Log(_currentUser, action, _selectedAssignment.AssignmentId, "Assignment");

                MessageBox.Show("Saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #endregion

        // Legacy button handler - now replaced by embedded player
        private void btnPlayAudio_Click(object sender, EventArgs e)
        {
            // This is kept for backward compatibility but the new player is preferred
            if (lblAudioFile.Tag != null)
            {
                string path = lblAudioFile.Tag.ToString()!;
                if (File.Exists(path))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening audio player: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show($"Audio file not found at path: {path}\nPlease check if the file exists.");
                }
            }
            else
            {
                MessageBox.Show("No audio file selected.");
            }
        }
    }
}
