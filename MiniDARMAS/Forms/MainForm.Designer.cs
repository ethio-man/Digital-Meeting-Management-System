namespace MiniDARMAS.Forms
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            adminToolStripMenuItem = new ToolStripMenuItem();
            manageUsersToolStripMenuItem = new ToolStripMenuItem();
            operatorToolStripMenuItem = new ToolStripMenuItem();
            manageMeetingsToolStripMenuItem = new ToolStripMenuItem();
            transcriberToolStripMenuItem = new ToolStripMenuItem();
            myAssignmentsToolStripMenuItem = new ToolStripMenuItem();
            editorToolStripMenuItem = new ToolStripMenuItem();
            reviewTranscriptionsToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, adminToolStripMenuItem, operatorToolStripMenuItem, transcriberToolStripMenuItem, editorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Tag = "File";
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Tag = "Close";
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manageUsersToolStripMenuItem });
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(55, 20);
            adminToolStripMenuItem.Tag = "Admin";
            adminToolStripMenuItem.Text = "Admin";
            // 
            // manageUsersToolStripMenuItem
            // 
            manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            manageUsersToolStripMenuItem.Size = new Size(180, 22);
            manageUsersToolStripMenuItem.Tag = "ManageUsers";
            manageUsersToolStripMenuItem.Text = "Manage Users";
            manageUsersToolStripMenuItem.Click += manageUsersToolStripMenuItem_Click;
            // 
            // operatorToolStripMenuItem
            // 
            operatorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manageMeetingsToolStripMenuItem });
            operatorToolStripMenuItem.Name = "operatorToolStripMenuItem";
            operatorToolStripMenuItem.Size = new Size(66, 20);
            operatorToolStripMenuItem.Tag = "Operator";
            operatorToolStripMenuItem.Text = "Operator";
            // 
            // manageMeetingsToolStripMenuItem
            // 
            manageMeetingsToolStripMenuItem.Name = "manageMeetingsToolStripMenuItem";
            manageMeetingsToolStripMenuItem.Size = new Size(180, 22);
            manageMeetingsToolStripMenuItem.Tag = "ManageMeetings";
            manageMeetingsToolStripMenuItem.Text = "Manage Meetings";
            manageMeetingsToolStripMenuItem.Click += manageMeetingsToolStripMenuItem_Click;
            // 
            // transcriberToolStripMenuItem
            // 
            transcriberToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { myAssignmentsToolStripMenuItem });
            transcriberToolStripMenuItem.Name = "transcriberToolStripMenuItem";
            transcriberToolStripMenuItem.Size = new Size(77, 20);
            transcriberToolStripMenuItem.Tag = "Transcriber";
            transcriberToolStripMenuItem.Text = "Transcriber";
            // 
            // myAssignmentsToolStripMenuItem
            // 
            myAssignmentsToolStripMenuItem.Name = "myAssignmentsToolStripMenuItem";
            myAssignmentsToolStripMenuItem.Size = new Size(180, 22);
            myAssignmentsToolStripMenuItem.Tag = "MyAssignments";
            myAssignmentsToolStripMenuItem.Text = "My Assignments";
            myAssignmentsToolStripMenuItem.Click += myAssignmentsToolStripMenuItem_Click;
            // 
            // editorToolStripMenuItem
            // 
            editorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reviewTranscriptionsToolStripMenuItem });
            editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            editorToolStripMenuItem.Size = new Size(50, 20);
            editorToolStripMenuItem.Tag = "Editor";
            editorToolStripMenuItem.Text = "Editor";
            // 
            // reviewTranscriptionsToolStripMenuItem
            // 
            reviewTranscriptionsToolStripMenuItem.Name = "reviewTranscriptionsToolStripMenuItem";
            reviewTranscriptionsToolStripMenuItem.Size = new Size(188, 22);
            reviewTranscriptionsToolStripMenuItem.Tag = "ReviewTranscriptions";
            reviewTranscriptionsToolStripMenuItem.Text = "Review Transcriptions";
            reviewTranscriptionsToolStripMenuItem.Click += reviewTranscriptionsToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 17);
            lblStatus.Text = "Ready";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mini-DARMAS Dashboard";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageMeetingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transcriberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myAssignmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewTranscriptionsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
