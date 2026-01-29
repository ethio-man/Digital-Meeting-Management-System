namespace MiniDARMAS.Forms.Admin
{
    partial class AdminDashboardForm
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
            tabControlDashboard = new TabControl();
            tabDashboard = new TabPage();
            pnlContent = new Panel();
            pnlButtons = new Panel();
            btnLogout = new Button();
            btnActivityLogs = new Button();
            btnUserManagement = new Button();
            btnRefresh = new Button();
            pnlStats = new Panel();
            pnlApproved = new Panel();
            lblApprovedDocuments = new Label();
            lblApprovedTitle = new Label();
            pnlCompleted = new Panel();
            lblCompletedTranscriptions = new Label();
            lblCompletedTitle = new Label();
            pnlPending = new Panel();
            lblPendingTranscriptions = new Label();
            lblPendingTitle = new Label();
            pnlRecordings = new Panel();
            lblTotalRecordings = new Label();
            lblRecordingsTitle = new Label();
            pnlMeetings = new Panel();
            lblTotalMeetings = new Label();
            lblMeetingsTitle = new Label();
            pnlHeader = new Panel();
            lblWelcome = new Label();
            lblTitle = new Label();
            tabExit = new TabPage();
            tabControlDashboard.SuspendLayout();
            tabDashboard.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlStats.SuspendLayout();
            pnlApproved.SuspendLayout();
            pnlCompleted.SuspendLayout();
            pnlPending.SuspendLayout();
            pnlRecordings.SuspendLayout();
            pnlMeetings.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlDashboard
            // 
            tabControlDashboard.Controls.Add(tabDashboard);
            tabControlDashboard.Controls.Add(tabExit);
            tabControlDashboard.Dock = DockStyle.Fill;
            tabControlDashboard.Location = new Point(0, 0);
            tabControlDashboard.Name = "tabControlDashboard";
            tabControlDashboard.SelectedIndex = 0;
            tabControlDashboard.Size = new Size(900, 550);
            tabControlDashboard.TabIndex = 0;
            tabControlDashboard.Tag = "";
            tabControlDashboard.SelectedIndexChanged += tabControlDashboard_SelectedIndexChanged;
            // 
            // tabDashboard
            // 
            tabDashboard.Controls.Add(pnlContent);
            tabDashboard.Controls.Add(pnlHeader);
            tabDashboard.Location = new Point(4, 24);
            tabDashboard.Name = "tabDashboard";
            tabDashboard.Padding = new Padding(3);
            tabDashboard.Size = new Size(892, 522);
            tabDashboard.TabIndex = 0;
            tabDashboard.Text = "Dashboard";
            tabDashboard.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(pnlButtons);
            pnlContent.Controls.Add(pnlStats);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(3, 83);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(886, 436);
            pnlContent.TabIndex = 1;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnLogout);
            pnlButtons.Controls.Add(btnActivityLogs);
            pnlButtons.Controls.Add(btnUserManagement);
            pnlButtons.Controls.Add(btnRefresh);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 376);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(886, 60);
            pnlButtons.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(200, 80, 80);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(746, 15);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(120, 35);
            btnLogout.TabIndex = 3;
            btnLogout.Tag = "Logout";
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnActivityLogs
            // 
            btnActivityLogs.Location = new Point(280, 15);
            btnActivityLogs.Name = "btnActivityLogs";
            btnActivityLogs.Size = new Size(140, 35);
            btnActivityLogs.TabIndex = 2;
            btnActivityLogs.Tag = "ActivityLogs";
            btnActivityLogs.Text = "View Activity Logs";
            btnActivityLogs.UseVisualStyleBackColor = true;
            btnActivityLogs.Click += btnActivityLogs_Click;
            // 
            // btnUserManagement
            // 
            btnUserManagement.Location = new Point(140, 15);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Size = new Size(130, 35);
            btnUserManagement.TabIndex = 1;
            btnUserManagement.Tag = "ManageUsers";
            btnUserManagement.Text = "Manage Users";
            btnUserManagement.UseVisualStyleBackColor = true;
            btnUserManagement.Click += btnUserManagement_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(20, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 0;
            btnRefresh.Tag = "Refresh";
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlStats
            // 
            pnlStats.Controls.Add(pnlApproved);
            pnlStats.Controls.Add(pnlCompleted);
            pnlStats.Controls.Add(pnlPending);
            pnlStats.Controls.Add(pnlRecordings);
            pnlStats.Controls.Add(pnlMeetings);
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(0, 0);
            pnlStats.Name = "pnlStats";
            pnlStats.Padding = new Padding(10);
            pnlStats.Size = new Size(886, 180);
            pnlStats.TabIndex = 0;
            // 
            // pnlApproved
            // 
            pnlApproved.BackColor = Color.FromArgb(76, 175, 80);
            pnlApproved.Controls.Add(lblApprovedDocuments);
            pnlApproved.Controls.Add(lblApprovedTitle);
            pnlApproved.Location = new Point(700, 20);
            pnlApproved.Name = "pnlApproved";
            pnlApproved.Size = new Size(160, 140);
            pnlApproved.TabIndex = 4;
            // 
            // lblApprovedDocuments
            // 
            lblApprovedDocuments.Dock = DockStyle.Fill;
            lblApprovedDocuments.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblApprovedDocuments.ForeColor = Color.White;
            lblApprovedDocuments.Location = new Point(0, 40);
            lblApprovedDocuments.Name = "lblApprovedDocuments";
            lblApprovedDocuments.Size = new Size(160, 100);
            lblApprovedDocuments.TabIndex = 1;
            lblApprovedDocuments.Text = "0";
            lblApprovedDocuments.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblApprovedTitle
            // 
            lblApprovedTitle.Dock = DockStyle.Top;
            lblApprovedTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblApprovedTitle.ForeColor = Color.White;
            lblApprovedTitle.Location = new Point(0, 0);
            lblApprovedTitle.Name = "lblApprovedTitle";
            lblApprovedTitle.Size = new Size(160, 40);
            lblApprovedTitle.TabIndex = 0;
            lblApprovedTitle.Tag = "Approved";
            lblApprovedTitle.Text = "Approved Docs";
            lblApprovedTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCompleted
            // 
            pnlCompleted.BackColor = Color.FromArgb(33, 150, 243);
            pnlCompleted.Controls.Add(lblCompletedTranscriptions);
            pnlCompleted.Controls.Add(lblCompletedTitle);
            pnlCompleted.Location = new Point(530, 20);
            pnlCompleted.Name = "pnlCompleted";
            pnlCompleted.Size = new Size(160, 140);
            pnlCompleted.TabIndex = 3;
            // 
            // lblCompletedTranscriptions
            // 
            lblCompletedTranscriptions.Dock = DockStyle.Fill;
            lblCompletedTranscriptions.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblCompletedTranscriptions.ForeColor = Color.White;
            lblCompletedTranscriptions.Location = new Point(0, 40);
            lblCompletedTranscriptions.Name = "lblCompletedTranscriptions";
            lblCompletedTranscriptions.Size = new Size(160, 100);
            lblCompletedTranscriptions.TabIndex = 1;
            lblCompletedTranscriptions.Text = "0";
            lblCompletedTranscriptions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCompletedTitle
            // 
            lblCompletedTitle.Dock = DockStyle.Top;
            lblCompletedTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblCompletedTitle.ForeColor = Color.White;
            lblCompletedTitle.Location = new Point(0, 0);
            lblCompletedTitle.Name = "lblCompletedTitle";
            lblCompletedTitle.Size = new Size(160, 40);
            lblCompletedTitle.TabIndex = 0;
            lblCompletedTitle.Tag = "Completed";
            lblCompletedTitle.Text = "Completed";
            lblCompletedTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPending
            // 
            pnlPending.BackColor = Color.FromArgb(255, 152, 0);
            pnlPending.Controls.Add(lblPendingTranscriptions);
            pnlPending.Controls.Add(lblPendingTitle);
            pnlPending.Location = new Point(360, 20);
            pnlPending.Name = "pnlPending";
            pnlPending.Size = new Size(160, 140);
            pnlPending.TabIndex = 2;
            // 
            // lblPendingTranscriptions
            // 
            lblPendingTranscriptions.Dock = DockStyle.Fill;
            lblPendingTranscriptions.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblPendingTranscriptions.ForeColor = Color.White;
            lblPendingTranscriptions.Location = new Point(0, 40);
            lblPendingTranscriptions.Name = "lblPendingTranscriptions";
            lblPendingTranscriptions.Size = new Size(160, 100);
            lblPendingTranscriptions.TabIndex = 1;
            lblPendingTranscriptions.Text = "0";
            lblPendingTranscriptions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPendingTitle
            // 
            lblPendingTitle.Dock = DockStyle.Top;
            lblPendingTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblPendingTitle.ForeColor = Color.White;
            lblPendingTitle.Location = new Point(0, 0);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.Size = new Size(160, 40);
            lblPendingTitle.TabIndex = 0;
            lblPendingTitle.Tag = "Pending";
            lblPendingTitle.Text = "Pending";
            lblPendingTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRecordings
            // 
            pnlRecordings.BackColor = Color.FromArgb(156, 39, 176);
            pnlRecordings.Controls.Add(lblTotalRecordings);
            pnlRecordings.Controls.Add(lblRecordingsTitle);
            pnlRecordings.Location = new Point(190, 20);
            pnlRecordings.Name = "pnlRecordings";
            pnlRecordings.Size = new Size(160, 140);
            pnlRecordings.TabIndex = 1;
            // 
            // lblTotalRecordings
            // 
            lblTotalRecordings.Dock = DockStyle.Fill;
            lblTotalRecordings.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalRecordings.ForeColor = Color.White;
            lblTotalRecordings.Location = new Point(0, 40);
            lblTotalRecordings.Name = "lblTotalRecordings";
            lblTotalRecordings.Size = new Size(160, 100);
            lblTotalRecordings.TabIndex = 1;
            lblTotalRecordings.Text = "0";
            lblTotalRecordings.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRecordingsTitle
            // 
            lblRecordingsTitle.Dock = DockStyle.Top;
            lblRecordingsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblRecordingsTitle.ForeColor = Color.White;
            lblRecordingsTitle.Location = new Point(0, 0);
            lblRecordingsTitle.Name = "lblRecordingsTitle";
            lblRecordingsTitle.Size = new Size(160, 40);
            lblRecordingsTitle.TabIndex = 0;
            lblRecordingsTitle.Tag = "Recording";
            lblRecordingsTitle.Text = "Recordings";
            lblRecordingsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMeetings
            // 
            pnlMeetings.BackColor = Color.FromArgb(0, 120, 215);
            pnlMeetings.Controls.Add(lblTotalMeetings);
            pnlMeetings.Controls.Add(lblMeetingsTitle);
            pnlMeetings.Location = new Point(20, 20);
            pnlMeetings.Name = "pnlMeetings";
            pnlMeetings.Size = new Size(160, 140);
            pnlMeetings.TabIndex = 0;
            // 
            // lblTotalMeetings
            // 
            lblTotalMeetings.Dock = DockStyle.Fill;
            lblTotalMeetings.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalMeetings.ForeColor = Color.White;
            lblTotalMeetings.Location = new Point(0, 40);
            lblTotalMeetings.Name = "lblTotalMeetings";
            lblTotalMeetings.Size = new Size(160, 100);
            lblTotalMeetings.TabIndex = 1;
            lblTotalMeetings.Text = "0";
            lblTotalMeetings.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMeetingsTitle
            // 
            lblMeetingsTitle.Dock = DockStyle.Top;
            lblMeetingsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMeetingsTitle.ForeColor = Color.White;
            lblMeetingsTitle.Location = new Point(0, 0);
            lblMeetingsTitle.Name = "lblMeetingsTitle";
            lblMeetingsTitle.Size = new Size(160, 40);
            lblMeetingsTitle.TabIndex = 0;
            lblMeetingsTitle.Tag = "Meetings";
            lblMeetingsTitle.Text = "Total Meetings";
            lblMeetingsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(245, 245, 245);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(3, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(886, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.Location = new Point(20, 50);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(99, 15);
            lblWelcome.TabIndex = 1;
            lblWelcome.Tag = "";
            lblWelcome.Text = "Welcome, Admin";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(305, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Tag = "Dashboard";
            lblTitle.Text = "Administrator Dashboard";
            // 
            // tabExit
            // 
            tabExit.Location = new Point(4, 24);
            tabExit.Name = "tabExit";
            tabExit.Padding = new Padding(3);
            tabExit.Size = new Size(892, 522);
            tabExit.TabIndex = 1;
            tabExit.Text = "Exit";
            tabExit.UseVisualStyleBackColor = true;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(tabControlDashboard);
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mini-DARMAS - Administrator Dashboard";
            Load += AdminDashboardForm_Load;
            tabControlDashboard.ResumeLayout(false);
            tabDashboard.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            pnlStats.ResumeLayout(false);
            pnlApproved.ResumeLayout(false);
            pnlCompleted.ResumeLayout(false);
            pnlPending.ResumeLayout(false);
            pnlRecordings.ResumeLayout(false);
            pnlMeetings.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        private TabControl tabControlDashboard;
        private TabPage tabDashboard;
        private TabPage tabExit;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblWelcome;
        private Panel pnlContent;
        private Panel pnlStats;
        private Panel pnlMeetings;
        private Label lblMeetingsTitle;
        private Label lblTotalMeetings;
        private Panel pnlRecordings;
        private Label lblRecordingsTitle;
        private Label lblTotalRecordings;
        private Panel pnlPending;
        private Label lblPendingTitle;
        private Label lblPendingTranscriptions;
        private Panel pnlCompleted;
        private Label lblCompletedTitle;
        private Label lblCompletedTranscriptions;
        private Panel pnlApproved;
        private Label lblApprovedTitle;
        private Label lblApprovedDocuments;
        private Panel pnlButtons;
        private Button btnRefresh;
        private Button btnUserManagement;
        private Button btnActivityLogs;
        private Button btnLogout;
    }
}
