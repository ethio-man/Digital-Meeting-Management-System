namespace MiniDARMAS.Forms.Operator
{
    partial class MeetingManagerForm
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
            tabControl1 = new TabControl();
            tabMeetings = new TabPage();
            dgvMeetings = new DataGridView();
            groupBoxMeeting = new GroupBox();
            btnDeleteMeeting = new Button();
            btnSaveMeeting = new Button();
            txtChairperson = new TextBox();
            label3 = new Label();
            txtLocation = new TextBox();
            label2 = new Label();
            dtpDate = new DateTimePicker();
            labelDate = new Label();
            txtMeetingNo = new TextBox();
            label1 = new Label();
            tabAgendas = new TabPage();
            panelAgendaContent = new Panel();
            dgvAgendas = new DataGridView();
            groupBoxAgenda = new GroupBox();
            btnDeleteAgenda = new Button();
            btnUpdateAgenda = new Button();
            btnSaveAgenda = new Button();
            txtDocPath = new TextBox();
            labelDoc = new Label();
            txtOffice = new TextBox();
            labelOffice = new Label();
            txtAgendaTitle = new TextBox();
            labelTitle = new Label();
            panelMeetingSelect = new Panel();
            cmbMeetings = new ComboBox();
            labelSelectMeeting = new Label();
            tabRecordings = new TabPage();
            dgvRecordings = new DataGridView();
            groupBoxRecording = new GroupBox();
            btnBrowseRec = new Button();
            btnDeleteRecording = new Button();
            btnAddRecording = new Button();
            txtRecordingPath = new TextBox();
            labelRecording = new Label();
            lblSelectedAgendaRec = new Label();
            tabAssignments = new TabPage();
            groupBoxAssignment = new GroupBox();
            labelTranscriberList = new Label();
            btnAssignTranscriber = new Button();
            cmbTranscribers = new ComboBox();
            labelTranscriber = new Label();
            tabExit = new TabPage();
            tabControl1.SuspendLayout();
            tabMeetings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMeetings).BeginInit();
            groupBoxMeeting.SuspendLayout();
            tabAgendas.SuspendLayout();
            panelAgendaContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAgendas).BeginInit();
            groupBoxAgenda.SuspendLayout();
            panelMeetingSelect.SuspendLayout();
            tabRecordings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecordings).BeginInit();
            groupBoxRecording.SuspendLayout();
            tabAssignments.SuspendLayout();
            groupBoxAssignment.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabMeetings);
            tabControl1.Controls.Add(tabAgendas);
            tabControl1.Controls.Add(tabRecordings);
            tabControl1.Controls.Add(tabAssignments);
            tabControl1.Controls.Add(tabExit);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(900, 600);
            tabControl1.TabIndex = 0;
            // 
            // tabMeetings
            // 
            tabMeetings.Controls.Add(dgvMeetings);
            tabMeetings.Controls.Add(groupBoxMeeting);
            tabMeetings.Location = new Point(4, 24);
            tabMeetings.Name = "tabMeetings";
            tabMeetings.Padding = new Padding(3);
            tabMeetings.Size = new Size(892, 572);
            tabMeetings.TabIndex = 0;
            tabMeetings.Text = "Meetings";
            tabMeetings.UseVisualStyleBackColor = true;
            // 
            // dgvMeetings
            // 
            dgvMeetings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeetings.Dock = DockStyle.Fill;
            dgvMeetings.Location = new Point(3, 183);
            dgvMeetings.Name = "dgvMeetings";
            dgvMeetings.RowTemplate.Height = 25;
            dgvMeetings.Size = new Size(886, 386);
            dgvMeetings.TabIndex = 1;
            dgvMeetings.SelectionChanged += dgvMeetings_SelectionChanged;
            // 
            // groupBoxMeeting
            // 
            groupBoxMeeting.Controls.Add(btnDeleteMeeting);
            groupBoxMeeting.Controls.Add(btnSaveMeeting);
            groupBoxMeeting.Controls.Add(txtChairperson);
            groupBoxMeeting.Controls.Add(label3);
            groupBoxMeeting.Controls.Add(txtLocation);
            groupBoxMeeting.Controls.Add(label2);
            groupBoxMeeting.Controls.Add(dtpDate);
            groupBoxMeeting.Controls.Add(labelDate);
            groupBoxMeeting.Controls.Add(txtMeetingNo);
            groupBoxMeeting.Controls.Add(label1);
            groupBoxMeeting.Dock = DockStyle.Top;
            groupBoxMeeting.Location = new Point(3, 3);
            groupBoxMeeting.Name = "groupBoxMeeting";
            groupBoxMeeting.Size = new Size(886, 180);
            groupBoxMeeting.TabIndex = 0;
            groupBoxMeeting.TabStop = false;
            groupBoxMeeting.Text = "Meeting Details";
            // 
            // btnDeleteMeeting
            // 
            btnDeleteMeeting.Location = new Point(130, 140);
            btnDeleteMeeting.Name = "btnDeleteMeeting";
            btnDeleteMeeting.Size = new Size(100, 30);
            btnDeleteMeeting.TabIndex = 9;
            btnDeleteMeeting.Text = "Delete Meeting";
            btnDeleteMeeting.UseVisualStyleBackColor = true;
            btnDeleteMeeting.Click += btnDeleteMeeting_Click;
            // 
            // btnSaveMeeting
            // 
            btnSaveMeeting.Location = new Point(20, 140);
            btnSaveMeeting.Name = "btnSaveMeeting";
            btnSaveMeeting.Size = new Size(100, 30);
            btnSaveMeeting.TabIndex = 8;
            btnSaveMeeting.Text = "Save / Update";
            btnSaveMeeting.UseVisualStyleBackColor = true;
            btnSaveMeeting.Click += btnSaveMeeting_Click;
            // 
            // txtChairperson
            // 
            txtChairperson.Location = new Point(400, 40);
            txtChairperson.Name = "txtChairperson";
            txtChairperson.Size = new Size(200, 23);
            txtChairperson.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(400, 20);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 6;
            label3.Text = "Chairperson:";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(20, 100);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(200, 23);
            txtLocation.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 80);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 4;
            label2.Text = "Location:";
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(400, 100);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 3;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(400, 80);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(34, 15);
            labelDate.TabIndex = 2;
            labelDate.Text = "Date:";
            // 
            // txtMeetingNo
            // 
            txtMeetingNo.Location = new Point(20, 40);
            txtMeetingNo.Name = "txtMeetingNo";
            txtMeetingNo.Size = new Size(200, 23);
            txtMeetingNo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Tag = "Meeting";
            label1.Text = "Meeting No:";
            // 
            // tabAgendas
            // 
            tabAgendas.Controls.Add(panelAgendaContent);
            tabAgendas.Controls.Add(panelMeetingSelect);
            tabAgendas.Location = new Point(4, 24);
            tabAgendas.Name = "tabAgendas";
            tabAgendas.Padding = new Padding(3);
            tabAgendas.Size = new Size(892, 572);
            tabAgendas.TabIndex = 1;
            tabAgendas.Text = "Agendas";
            tabAgendas.UseVisualStyleBackColor = true;
            // 
            // panelAgendaContent
            // 
            panelAgendaContent.Controls.Add(dgvAgendas);
            panelAgendaContent.Controls.Add(groupBoxAgenda);
            panelAgendaContent.Dock = DockStyle.Fill;
            panelAgendaContent.Location = new Point(3, 59);
            panelAgendaContent.Name = "panelAgendaContent";
            panelAgendaContent.Size = new Size(886, 510);
            panelAgendaContent.TabIndex = 1;
            // 
            // dgvAgendas
            // 
            dgvAgendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAgendas.Dock = DockStyle.Fill;
            dgvAgendas.Location = new Point(0, 0);
            dgvAgendas.Name = "dgvAgendas";
            dgvAgendas.RowTemplate.Height = 25;
            dgvAgendas.Size = new Size(500, 510);
            dgvAgendas.TabIndex = 1;
            dgvAgendas.SelectionChanged += dgvAgendas_SelectionChanged;
            // 
            // groupBoxAgenda
            // 
            groupBoxAgenda.Controls.Add(btnDeleteAgenda);
            groupBoxAgenda.Controls.Add(btnUpdateAgenda);
            groupBoxAgenda.Controls.Add(btnSaveAgenda);
            groupBoxAgenda.Controls.Add(txtDocPath);
            groupBoxAgenda.Controls.Add(labelDoc);
            groupBoxAgenda.Controls.Add(txtOffice);
            groupBoxAgenda.Controls.Add(labelOffice);
            groupBoxAgenda.Controls.Add(txtAgendaTitle);
            groupBoxAgenda.Controls.Add(labelTitle);
            groupBoxAgenda.Dock = DockStyle.Right;
            groupBoxAgenda.Location = new Point(500, 0);
            groupBoxAgenda.Name = "groupBoxAgenda";
            groupBoxAgenda.Size = new Size(386, 510);
            groupBoxAgenda.TabIndex = 0;
            groupBoxAgenda.TabStop = false;
            groupBoxAgenda.Text = "Agenda Actions";
            // 
            // btnDeleteAgenda
            // 
            btnDeleteAgenda.Location = new Point(240, 200);
            btnDeleteAgenda.Name = "btnDeleteAgenda";
            btnDeleteAgenda.Size = new Size(100, 30);
            btnDeleteAgenda.TabIndex = 8;
            btnDeleteAgenda.Text = "Delete Agenda";
            btnDeleteAgenda.UseVisualStyleBackColor = true;
            btnDeleteAgenda.Click += btnDeleteAgenda_Click;
            // 
            // btnUpdateAgenda
            // 
            btnUpdateAgenda.Location = new Point(130, 200);
            btnUpdateAgenda.Name = "btnUpdateAgenda";
            btnUpdateAgenda.Size = new Size(100, 30);
            btnUpdateAgenda.TabIndex = 7;
            btnUpdateAgenda.Text = "Update Agenda";
            btnUpdateAgenda.UseVisualStyleBackColor = true;
            btnUpdateAgenda.Click += btnUpdateAgenda_Click;
            // 
            // btnSaveAgenda
            // 
            btnSaveAgenda.Location = new Point(20, 200);
            btnSaveAgenda.Name = "btnSaveAgenda";
            btnSaveAgenda.Size = new Size(100, 30);
            btnSaveAgenda.TabIndex = 6;
            btnSaveAgenda.Text = "Add Agenda";
            btnSaveAgenda.UseVisualStyleBackColor = true;
            btnSaveAgenda.Click += btnSaveAgenda_Click;
            // 
            // txtDocPath
            // 
            txtDocPath.Location = new Point(20, 160);
            txtDocPath.Name = "txtDocPath";
            txtDocPath.Size = new Size(350, 23);
            txtDocPath.TabIndex = 5;
            // 
            // labelDoc
            // 
            labelDoc.AutoSize = true;
            labelDoc.Location = new Point(20, 140);
            labelDoc.Name = "labelDoc";
            labelDoc.Size = new Size(93, 15);
            labelDoc.TabIndex = 4;
            labelDoc.Text = "Document Path:";
            // 
            // txtOffice
            // 
            txtOffice.Location = new Point(20, 100);
            txtOffice.Name = "txtOffice";
            txtOffice.Size = new Size(250, 23);
            txtOffice.TabIndex = 3;
            // 
            // labelOffice
            // 
            labelOffice.AutoSize = true;
            labelOffice.Location = new Point(20, 80);
            labelOffice.Name = "labelOffice";
            labelOffice.Size = new Size(42, 15);
            labelOffice.TabIndex = 2;
            labelOffice.Text = "Office:";
            // 
            // txtAgendaTitle
            // 
            txtAgendaTitle.Location = new Point(20, 40);
            txtAgendaTitle.Name = "txtAgendaTitle";
            txtAgendaTitle.Size = new Size(350, 23);
            txtAgendaTitle.TabIndex = 1;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(20, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(33, 15);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Title:";
            // 
            // panelMeetingSelect
            // 
            panelMeetingSelect.Controls.Add(cmbMeetings);
            panelMeetingSelect.Controls.Add(labelSelectMeeting);
            panelMeetingSelect.Dock = DockStyle.Top;
            panelMeetingSelect.Location = new Point(3, 3);
            panelMeetingSelect.Name = "panelMeetingSelect";
            panelMeetingSelect.Size = new Size(886, 56);
            panelMeetingSelect.TabIndex = 0;
            // 
            // cmbMeetings
            // 
            cmbMeetings.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMeetings.FormattingEnabled = true;
            cmbMeetings.Location = new Point(120, 15);
            cmbMeetings.Name = "cmbMeetings";
            cmbMeetings.Size = new Size(300, 23);
            cmbMeetings.TabIndex = 1;
            cmbMeetings.SelectedIndexChanged += cmbMeetings_SelectedIndexChanged;
            // 
            // labelSelectMeeting
            // 
            labelSelectMeeting.AutoSize = true;
            labelSelectMeeting.Location = new Point(20, 18);
            labelSelectMeeting.Name = "labelSelectMeeting";
            labelSelectMeeting.Size = new Size(88, 15);
            labelSelectMeeting.TabIndex = 0;
            labelSelectMeeting.Text = "Select Meeting:";
            // 
            // tabRecordings
            // 
            tabRecordings.Controls.Add(dgvRecordings);
            tabRecordings.Controls.Add(groupBoxRecording);
            tabRecordings.Controls.Add(lblSelectedAgendaRec);
            tabRecordings.Location = new Point(4, 24);
            tabRecordings.Name = "tabRecordings";
            tabRecordings.Padding = new Padding(3);
            tabRecordings.Size = new Size(892, 572);
            tabRecordings.TabIndex = 2;
            tabRecordings.Text = "Recordings";
            tabRecordings.UseVisualStyleBackColor = true;
            // 
            // dgvRecordings
            // 
            dgvRecordings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecordings.Location = new Point(20, 260);
            dgvRecordings.Name = "dgvRecordings";
            dgvRecordings.RowTemplate.Height = 25;
            dgvRecordings.Size = new Size(600, 200);
            dgvRecordings.TabIndex = 3;
            // 
            // groupBoxRecording
            // 
            groupBoxRecording.Controls.Add(btnBrowseRec);
            groupBoxRecording.Controls.Add(btnDeleteRecording);
            groupBoxRecording.Controls.Add(btnAddRecording);
            groupBoxRecording.Controls.Add(txtRecordingPath);
            groupBoxRecording.Controls.Add(labelRecording);
            groupBoxRecording.Location = new Point(20, 50);
            groupBoxRecording.Name = "groupBoxRecording";
            groupBoxRecording.Size = new Size(600, 200);
            groupBoxRecording.TabIndex = 0;
            groupBoxRecording.TabStop = false;
            groupBoxRecording.Text = "Manage Recording (Select Agenda in Agendas Tab first)";
            // 
            // btnBrowseRec
            // 
            btnBrowseRec.Location = new Point(380, 58);
            btnBrowseRec.Name = "btnBrowseRec";
            btnBrowseRec.Size = new Size(80, 25);
            btnBrowseRec.TabIndex = 10;
            btnBrowseRec.Text = "Browse...";
            btnBrowseRec.UseVisualStyleBackColor = true;
            btnBrowseRec.Click += btnBrowseRec_Click;
            // 
            // btnDeleteRecording
            // 
            btnDeleteRecording.Location = new Point(190, 100);
            btnDeleteRecording.Name = "btnDeleteRecording";
            btnDeleteRecording.Size = new Size(120, 30);
            btnDeleteRecording.TabIndex = 11;
            btnDeleteRecording.Text = "Delete Recording";
            btnDeleteRecording.UseVisualStyleBackColor = true;
            btnDeleteRecording.Click += btnDeleteRecording_Click;
            // 
            // btnAddRecording
            // 
            btnAddRecording.Location = new Point(20, 100);
            btnAddRecording.Name = "btnAddRecording";
            btnAddRecording.Size = new Size(150, 30);
            btnAddRecording.TabIndex = 9;
            btnAddRecording.Text = "Add Recording (File)";
            btnAddRecording.UseVisualStyleBackColor = true;
            btnAddRecording.Click += btnAddRecording_Click;
            // 
            // txtRecordingPath
            // 
            txtRecordingPath.Location = new Point(20, 60);
            txtRecordingPath.Name = "txtRecordingPath";
            txtRecordingPath.Size = new Size(350, 23);
            txtRecordingPath.TabIndex = 8;
            // 
            // labelRecording
            // 
            labelRecording.AutoSize = true;
            labelRecording.Location = new Point(20, 40);
            labelRecording.Name = "labelRecording";
            labelRecording.Size = new Size(91, 15);
            labelRecording.TabIndex = 7;
            labelRecording.Text = "Recording Path:";
            // 
            // lblSelectedAgendaRec
            // 
            lblSelectedAgendaRec.AutoSize = true;
            lblSelectedAgendaRec.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectedAgendaRec.Location = new Point(20, 20);
            lblSelectedAgendaRec.Name = "lblSelectedAgendaRec";
            lblSelectedAgendaRec.Size = new Size(126, 19);
            lblSelectedAgendaRec.TabIndex = 2;
            lblSelectedAgendaRec.Text = "Selected Agenda:";
            // 
            // tabAssignments
            // 
            tabAssignments.Controls.Add(groupBoxAssignment);
            tabAssignments.Location = new Point(4, 24);
            tabAssignments.Name = "tabAssignments";
            tabAssignments.Padding = new Padding(3);
            tabAssignments.Size = new Size(892, 572);
            tabAssignments.TabIndex = 3;
            tabAssignments.Text = "Assignments";
            tabAssignments.UseVisualStyleBackColor = true;
            // 
            // groupBoxAssignment
            // 
            groupBoxAssignment.Controls.Add(labelTranscriberList);
            groupBoxAssignment.Controls.Add(btnAssignTranscriber);
            groupBoxAssignment.Controls.Add(cmbTranscribers);
            groupBoxAssignment.Controls.Add(labelTranscriber);
            groupBoxAssignment.Location = new Point(20, 20);
            groupBoxAssignment.Name = "groupBoxAssignment";
            groupBoxAssignment.Size = new Size(600, 200);
            groupBoxAssignment.TabIndex = 0;
            groupBoxAssignment.TabStop = false;
            groupBoxAssignment.Text = "Assign Transcriber (Select Agenda in Agendas Tab first)";
            // 
            // labelTranscriberList
            // 
            labelTranscriberList.AutoSize = true;
            labelTranscriberList.ForeColor = Color.Gray;
            labelTranscriberList.Location = new Point(20, 150);
            labelTranscriberList.Name = "labelTranscriberList";
            labelTranscriberList.Size = new Size(0, 15);
            labelTranscriberList.TabIndex = 13;
            // 
            // btnAssignTranscriber
            // 
            btnAssignTranscriber.Location = new Point(300, 60);
            btnAssignTranscriber.Name = "btnAssignTranscriber";
            btnAssignTranscriber.Size = new Size(150, 30);
            btnAssignTranscriber.TabIndex = 12;
            btnAssignTranscriber.Text = "Assign Transcriber";
            btnAssignTranscriber.UseVisualStyleBackColor = true;
            btnAssignTranscriber.Click += btnAssignTranscriber_Click;
            // 
            // cmbTranscribers
            // 
            cmbTranscribers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTranscribers.FormattingEnabled = true;
            cmbTranscribers.Location = new Point(20, 60);
            cmbTranscribers.Name = "cmbTranscribers";
            cmbTranscribers.Size = new Size(250, 23);
            cmbTranscribers.TabIndex = 11;
            // 
            // labelTranscriber
            // 
            labelTranscriber.AutoSize = true;
            labelTranscriber.Location = new Point(20, 40);
            labelTranscriber.Name = "labelTranscriber";
            labelTranscriber.Size = new Size(102, 15);
            labelTranscriber.TabIndex = 10;
            labelTranscriber.Text = "Select Transcriber:";
            // 
            // tabExit
            // 
            tabExit.Location = new Point(4, 24);
            tabExit.Name = "tabExit";
            tabExit.Size = new Size(892, 572);
            tabExit.TabIndex = 4;
            tabExit.Text = "Exit";
            tabExit.UseVisualStyleBackColor = true;
            // 
            // MeetingManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(tabControl1);
            Name = "MeetingManagerForm";
            Text = "Meeting Management (Operator)";
            Load += MeetingManagerForm_Load;
            tabControl1.ResumeLayout(false);
            tabMeetings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMeetings).EndInit();
            groupBoxMeeting.ResumeLayout(false);
            groupBoxMeeting.PerformLayout();
            tabAgendas.ResumeLayout(false);
            panelAgendaContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAgendas).EndInit();
            groupBoxAgenda.ResumeLayout(false);
            groupBoxAgenda.PerformLayout();
            panelMeetingSelect.ResumeLayout(false);
            panelMeetingSelect.PerformLayout();
            tabRecordings.ResumeLayout(false);
            tabRecordings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecordings).EndInit();
            groupBoxRecording.ResumeLayout(false);
            groupBoxRecording.PerformLayout();
            tabAssignments.ResumeLayout(false);
            groupBoxAssignment.ResumeLayout(false);
            groupBoxAssignment.PerformLayout();
            ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMeetings;
        private System.Windows.Forms.TabPage tabAgendas;
        private System.Windows.Forms.TabPage tabRecordings;
        private System.Windows.Forms.TabPage tabAssignments;
        private System.Windows.Forms.TabPage tabExit; // ADDED
        private System.Windows.Forms.DataGridView dgvMeetings;

        private System.Windows.Forms.GroupBox groupBoxMeeting;
        private System.Windows.Forms.TextBox txtMeetingNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChairperson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveMeeting;
        private System.Windows.Forms.Button btnDeleteMeeting;
        private System.Windows.Forms.Panel panelAgendaContent;
        private System.Windows.Forms.Panel panelMeetingSelect;
        private System.Windows.Forms.ComboBox cmbMeetings;
        private System.Windows.Forms.Label labelSelectMeeting;
        private System.Windows.Forms.GroupBox groupBoxAgenda;
        private System.Windows.Forms.DataGridView dgvAgendas;
        private System.Windows.Forms.TextBox txtAgendaTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox txtOffice;
        private System.Windows.Forms.Label labelOffice;
        private System.Windows.Forms.TextBox txtDocPath;
        private System.Windows.Forms.Label labelDoc;
        private System.Windows.Forms.Button btnSaveAgenda;
        private System.Windows.Forms.Button btnUpdateAgenda;
        private System.Windows.Forms.Button btnDeleteAgenda;
        
        // Moved controls
        private System.Windows.Forms.GroupBox groupBoxRecording;
        private System.Windows.Forms.TextBox txtRecordingPath;
        private System.Windows.Forms.Label labelRecording;
        private System.Windows.Forms.Button btnAddRecording;
        private System.Windows.Forms.Button btnDeleteRecording;
        private System.Windows.Forms.Button btnBrowseRec;
        private System.Windows.Forms.Label lblSelectedAgendaRec;
        private System.Windows.Forms.DataGridView dgvRecordings;
        
        private System.Windows.Forms.GroupBox groupBoxAssignment;
        private System.Windows.Forms.Label labelTranscriber;
        private System.Windows.Forms.ComboBox cmbTranscribers;
        private System.Windows.Forms.Button btnAssignTranscriber;
        private System.Windows.Forms.Label labelTranscriberList;
    }
}
