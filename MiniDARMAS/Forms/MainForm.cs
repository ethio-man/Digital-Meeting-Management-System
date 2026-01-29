using System;
using System.Windows.Forms;
using MiniDARMAS.Domain;
using MiniDARMAS.Forms.Admin;
using MiniDARMAS.Forms.Operator;
using MiniDARMAS.Forms.Transcriber;
using MiniDARMAS.Forms.Editor;

using MiniDARMAS.Infrastructure;

namespace MiniDARMAS.Forms
{
    public partial class MainForm : Form
    {
        private User _currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            FormTheme.Apply(this);
            _currentUser = user;

            ApplyRolePermissions();
            lblStatus.Text = $"Logged in as: {_currentUser.Username} ({_currentUser.Role})";

            LocalizationManager.AutoLocalize(this);
        }

        private void ApplyRolePermissions()
        {
            adminToolStripMenuItem.Visible = false;
            operatorToolStripMenuItem.Visible = false;
            transcriberToolStripMenuItem.Visible = false;
            editorToolStripMenuItem.Visible = false;

            switch (_currentUser.Role)
            {
                case UserRole.Admin:
                    adminToolStripMenuItem.Visible = true;
                    // Support for others? usually admin can do all? Requirement says "Role (Admin, Operator, ...)" implies separation.
                    // But often Admin manages users primarily.
                    break;
                case UserRole.Operator:
                    operatorToolStripMenuItem.Visible = true;
                    break;
                case UserRole.Transcriber:
                    transcriberToolStripMenuItem.Visible = true;
                    break;
                case UserRole.Editor:
                    editorToolStripMenuItem.Visible = true;
                    break;
                case UserRole.Approver:
                    editorToolStripMenuItem.Visible = true; // Approver uses same module or similar
                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagementForm form = new UserManagementForm(_currentUser);
            form.ShowDialog();
        }

        private void manageMeetingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeetingManagerForm form = new MeetingManagerForm(_currentUser);
            form.ShowDialog();
        }

        private void myAssignmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TranscriptionForm form = new TranscriptionForm(_currentUser);
            form.ShowDialog();
        }

        private void reviewTranscriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReviewForm form = new ReviewForm(_currentUser);
            form.ShowDialog();
        }
    }
}
