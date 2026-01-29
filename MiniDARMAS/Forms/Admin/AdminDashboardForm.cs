using System;
using System.Drawing;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Domain;
using MiniDARMAS.Infrastructure;

namespace MiniDARMAS.Forms.Admin
{
    public partial class AdminDashboardForm : Form
    {
        private User _currentUser;
        private DashboardService _dashboardService;

        public AdminDashboardForm(User user)
        {
            InitializeComponent();
            //FormTheme.Apply(this);
            _currentUser = user;
            _dashboardService = new DashboardService();

            lblWelcome.Text = $"Welcome, {user.FullName}";
            
            LocalizationManager.AutoLocalize(this);
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            LoadStatistics();

            // Log dashboard access
            ActivityLogService.Log(_currentUser, "Accessed Admin Dashboard");
        }

        private void LoadStatistics()
        {
            try
            {
                var stats = _dashboardService.GetAllStats();

                lblTotalMeetings.Text = stats.totalMeetings.ToString();
                lblTotalRecordings.Text = stats.totalRecordings.ToString();
                lblPendingTranscriptions.Text = stats.pendingTranscriptions.ToString();
                lblCompletedTranscriptions.Text = stats.completedTranscriptions.ToString();
                lblApprovedDocuments.Text = stats.approvedDocuments.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            using (var form = new UserManagementForm(_currentUser))
            {
                form.ShowDialog();
            }
            LoadStatistics(); // Refresh after returning
        }

        private void btnActivityLogs_Click(object sender, EventArgs e)
        {
            using (var form = new ActivityLogViewerForm())
            {
                form.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ActivityLogService.Log(_currentUser, "Logged Out");
            this.Close();
        }

        private void tabControlDashboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlDashboard.SelectedTab == tabExit)
            {
                ActivityLogService.Log(_currentUser, "Logged Out");
                this.Close();
            }
        }
    }
}
