using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Domain;
using MiniDARMAS.Infrastructure;

namespace MiniDARMAS.Forms.Admin
{
    public partial class ActivityLogViewerForm : Form
    {
        private List<ActivityLog>? _allLogs;

        public ActivityLogViewerForm()
        {
            InitializeComponent();
            FormTheme.Apply(this);

            LocalizationManager.AutoLocalize(this);
        }

        private void ActivityLogViewerForm_Load(object sender, EventArgs e)
        {
            LoadActionTypes();
            LoadLogs();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvLogs.AutoGenerateColumns = false;
            dgvLogs.Columns.Clear();

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Timestamp",
                HeaderText = "Date/Time",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm:ss" }
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Username",
                HeaderText = "User",
                Width = 100
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Role",
                HeaderText = "Role",
                Width = 80
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Action",
                HeaderText = "Action",
                Width = 180
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReferenceType",
                HeaderText = "Ref Type",
                Width = 80
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReferenceId",
                HeaderText = "Ref ID",
                Width = 60
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Details",
                HeaderText = "Details",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void LoadActionTypes()
        {
            var actions = new List<string> { "All Actions" };
            actions.AddRange(ActivityLogService.GetDistinctActions());
            cmbActionFilter.DataSource = actions;
            cmbActionFilter.SelectedIndex = 0;
        }

        private void LoadLogs()
        {
            _allLogs = ActivityLogService.GetAllLogs();
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string? search = string.IsNullOrWhiteSpace(txtSearch.Text) ? null : txtSearch.Text.Trim();
            DateTime? fromDate = chkFromDate.Checked ? dtpFromDate.Value.Date : null;
            DateTime? toDate = chkToDate.Checked ? dtpToDate.Value.Date : null;
            string? action = cmbActionFilter.SelectedIndex > 0 ? cmbActionFilter.SelectedItem?.ToString() : null;

            var filtered = ActivityLogService.SearchLogs(search, fromDate, toDate, action);
            dgvLogs.DataSource = filtered;

            lblRecordCount.Text = $"Showing {filtered.Count} records";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbActionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (chkFromDate.Checked)
                ApplyFilters();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (chkToDate.Checked)
                ApplyFilters();
        }

        private void chkFromDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromDate.Enabled = chkFromDate.Checked;
            ApplyFilters();
        }

        private void chkToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpToDate.Enabled = chkToDate.Checked;
            ApplyFilters();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadActionTypes();
            LoadLogs();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbActionFilter.SelectedIndex = 0;
            chkFromDate.Checked = false;
            chkToDate.Checked = false;
            dtpFromDate.Value = DateTime.Today.AddDays(-7);
            dtpToDate.Value = DateTime.Today;
            ApplyFilters();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
