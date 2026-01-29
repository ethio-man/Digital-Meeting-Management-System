namespace MiniDARMAS.Forms.Transcriber
{
    partial class TranscriptionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            groupBoxList = new GroupBox();
            dgvAssignments = new DataGridView();
            groupBoxDetails = new GroupBox();
            pnlAudioPlayer = new Panel();
            lblDuration = new Label();
            lblCurrentTime = new Label();
            trackBarSeek = new TrackBar();
            btnStop = new Button();
            btnPause = new Button();
            btnPlay = new Button();
            btnSubmit = new Button();
            btnSaveDraft = new Button();
            btnPlayAudio = new Button();
            txtTranscription = new TextBox();
            label2 = new Label();
            lblAudioFile = new Label();
            lblComments = new Label();
            txtComments = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).BeginInit();
            groupBoxDetails.SuspendLayout();
            pnlAudioPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBoxList);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBoxDetails);
            splitContainer1.Size = new Size(950, 650);
            splitContainer1.SplitterDistance = 300;
            splitContainer1.TabIndex = 0;
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(dgvAssignments);
            groupBoxList.Dock = DockStyle.Fill;
            groupBoxList.Location = new Point(0, 0);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Size = new Size(300, 650);
            groupBoxList.TabIndex = 0;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "My Assignments";
            // 
            // dgvAssignments
            // 
            dgvAssignments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAssignments.Dock = DockStyle.Fill;
            dgvAssignments.Location = new Point(3, 19);
            dgvAssignments.Name = "dgvAssignments";
            dgvAssignments.RowTemplate.Height = 25;
            dgvAssignments.Size = new Size(294, 628);
            dgvAssignments.TabIndex = 0;
            dgvAssignments.SelectionChanged += dgvAssignments_SelectionChanged;
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(pnlAudioPlayer);
            groupBoxDetails.Controls.Add(btnSubmit);
            groupBoxDetails.Controls.Add(btnSaveDraft);
            groupBoxDetails.Controls.Add(btnPlayAudio);
            groupBoxDetails.Controls.Add(txtTranscription);
            groupBoxDetails.Controls.Add(label2);
            groupBoxDetails.Controls.Add(lblAudioFile);
            groupBoxDetails.Controls.Add(lblComments);
            groupBoxDetails.Controls.Add(txtComments);
            groupBoxDetails.Controls.Add(label1);
            groupBoxDetails.Dock = DockStyle.Fill;
            groupBoxDetails.Location = new Point(0, 0);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Size = new Size(646, 650);
            groupBoxDetails.TabIndex = 0;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Transcription Board";
            // 
            // pnlAudioPlayer
            // 
            pnlAudioPlayer.BackColor = Color.FromArgb(240, 240, 240);
            pnlAudioPlayer.BorderStyle = BorderStyle.FixedSingle;
            pnlAudioPlayer.Controls.Add(lblDuration);
            pnlAudioPlayer.Controls.Add(lblCurrentTime);
            pnlAudioPlayer.Controls.Add(trackBarSeek);
            pnlAudioPlayer.Controls.Add(btnStop);
            pnlAudioPlayer.Controls.Add(btnPause);
            pnlAudioPlayer.Controls.Add(btnPlay);
            pnlAudioPlayer.Location = new Point(20, 60);
            pnlAudioPlayer.Name = "pnlAudioPlayer";
            pnlAudioPlayer.Size = new Size(600, 80);
            pnlAudioPlayer.TabIndex = 9;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(555, 52);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(34, 15);
            lblDuration.TabIndex = 5;
            lblDuration.Text = "00:00";
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Location = new Point(10, 52);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(34, 15);
            lblCurrentTime.TabIndex = 4;
            lblCurrentTime.Text = "00:00";
            // 
            // trackBarSeek
            // 
            trackBarSeek.Location = new Point(50, 52);
            trackBarSeek.Name = "trackBarSeek";
            trackBarSeek.Size = new Size(500, 45);
            trackBarSeek.TabIndex = 3;
            trackBarSeek.TickStyle = TickStyle.None;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(200, 80, 80);
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(180, 8);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 32);
            btnStop.TabIndex = 2;
            btnStop.Text = "⏹ Stop";
            btnStop.UseVisualStyleBackColor = false;
            // 
            // btnPause
            // 
            btnPause.BackColor = Color.FromArgb(255, 180, 60);
            btnPause.FlatAppearance.BorderSize = 0;
            btnPause.FlatStyle = FlatStyle.Flat;
            btnPause.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPause.ForeColor = Color.White;
            btnPause.Location = new Point(95, 8);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(75, 32);
            btnPause.TabIndex = 1;
            btnPause.Text = "⏸ Pause";
            btnPause.UseVisualStyleBackColor = false;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.FromArgb(80, 180, 80);
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(10, 8);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 32);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "▶ Play";
            btnPlay.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.LightGreen;
            btnSubmit.Location = new Point(500, 533);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(120, 40);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnSaveDraft
            // 
            btnSaveDraft.Location = new Point(356, 533);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(120, 40);
            btnSaveDraft.TabIndex = 5;
            btnSaveDraft.Text = "Save Draft";
            btnSaveDraft.UseVisualStyleBackColor = true;
            btnSaveDraft.Click += btnSaveDraft_Click;
            // 
            // btnPlayAudio
            // 
            btnPlayAudio.Location = new Point(450, 25);
            btnPlayAudio.Name = "btnPlayAudio";
            btnPlayAudio.Size = new Size(170, 28);
            btnPlayAudio.TabIndex = 4;
            btnPlayAudio.Text = "Open in External Player";
            btnPlayAudio.UseVisualStyleBackColor = true;
            btnPlayAudio.Click += btnPlayAudio_Click;
            // 
            // txtTranscription
            // 
            txtTranscription.Location = new Point(20, 170);
            txtTranscription.Multiline = true;
            txtTranscription.Name = "txtTranscription";
            txtTranscription.ScrollBars = ScrollBars.Vertical;
            txtTranscription.Size = new Size(600, 357);
            txtTranscription.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 150);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 2;
            label2.Text = "Transcription:";
            // 
            // lblAudioFile
            // 
            lblAudioFile.AutoSize = true;
            lblAudioFile.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            lblAudioFile.Location = new Point(100, 32);
            lblAudioFile.Name = "lblAudioFile";
            lblAudioFile.Size = new Size(16, 15);
            lblAudioFile.TabIndex = 1;
            lblAudioFile.Text = "...";
            // 
            // lblComments
            // 
            lblComments.AutoSize = true;
            lblComments.ForeColor = Color.Red;
            lblComments.Location = new Point(20, 584);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(119, 15);
            lblComments.TabIndex = 7;
            lblComments.Text = "Reviewer Comments:";
            // 
            // txtComments
            // 
            txtComments.Location = new Point(191, 581);
            txtComments.Name = "txtComments";
            txtComments.ReadOnly = true;
            txtComments.Size = new Size(443, 23);
            txtComments.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 32);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Audio File:";
            // 
            // TranscriptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 650);
            Controls.Add(splitContainer1);
            Name = "TranscriptionForm";
            Text = "Transcription Work Area";
            Load += TranscriptionForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).EndInit();
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            pnlAudioPlayer.ResumeLayout(false);
            pnlAudioPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dgvAssignments;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAudioFile;
        private System.Windows.Forms.TextBox txtTranscription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPlayAudio;
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Panel pnlAudioPlayer;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar trackBarSeek;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblDuration;
    }
}
