namespace MiniDARMAS.Forms.Admin
{
    partial class ActivityLogViewerForm
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
            pnlFilters = new Panel();
            btnClose = new Button();
            btnClearFilters = new Button();
            btnRefresh = new Button();
            lblRecordCount = new Label();
            chkToDate = new CheckBox();
            chkFromDate = new CheckBox();
            dtpToDate = new DateTimePicker();
            dtpFromDate = new DateTimePicker();
            cmbActionFilter = new ComboBox();
            lblAction = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            lblTitle = new Label();
            dgvLogs = new DataGridView();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            SuspendLayout();
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.FromArgb(245, 245, 245);
            pnlFilters.Controls.Add(btnClose);
            pnlFilters.Controls.Add(btnClearFilters);
            pnlFilters.Controls.Add(btnRefresh);
            pnlFilters.Controls.Add(lblRecordCount);
            pnlFilters.Controls.Add(chkToDate);
            pnlFilters.Controls.Add(chkFromDate);
            pnlFilters.Controls.Add(dtpToDate);
            pnlFilters.Controls.Add(dtpFromDate);
            pnlFilters.Controls.Add(cmbActionFilter);
            pnlFilters.Controls.Add(lblAction);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Controls.Add(lblSearch);
            pnlFilters.Controls.Add(lblTitle);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 0);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(984, 100);
            pnlFilters.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(100, 100, 100);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(889, 60);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 28);
            btnClose.TabIndex = 12;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnClearFilters
            // 
            btnClearFilters.Location = new Point(795, 60);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(85, 28);
            btnClearFilters.TabIndex = 11;
            btnClearFilters.Text = "Clear Filters";
            btnClearFilters.UseVisualStyleBackColor = true;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(710, 60);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 28);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblRecordCount
            // 
            lblRecordCount.AutoSize = true;
            lblRecordCount.ForeColor = Color.Gray;
            lblRecordCount.Location = new Point(20, 70);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(100, 15);
            lblRecordCount.TabIndex = 9;
            lblRecordCount.Text = "Showing 0 records";
            // 
            // chkToDate
            // 
            chkToDate.AutoSize = true;
            chkToDate.Location = new Point(510, 42);
            chkToDate.Name = "chkToDate";
            chkToDate.Size = new Size(39, 19);
            chkToDate.TabIndex = 8;
            chkToDate.Text = "To";
            chkToDate.UseVisualStyleBackColor = true;
            chkToDate.CheckedChanged += chkToDate_CheckedChanged;
            // 
            // chkFromDate
            // 
            chkFromDate.AutoSize = true;
            chkFromDate.Location = new Point(345, 42);
            chkFromDate.Name = "chkFromDate";
            chkFromDate.Size = new Size(55, 19);
            chkFromDate.TabIndex = 7;
            chkFromDate.Text = "From";
            chkFromDate.UseVisualStyleBackColor = true;
            chkFromDate.CheckedChanged += chkFromDate_CheckedChanged;
            // 
            // dtpToDate
            // 
            dtpToDate.Enabled = false;
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(555, 40);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(120, 23);
            dtpToDate.TabIndex = 6;
            dtpToDate.ValueChanged += dtpToDate_ValueChanged;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Enabled = false;
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(405, 40);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(100, 23);
            dtpFromDate.TabIndex = 5;
            dtpFromDate.Value = DateTime.Today.AddDays(-7);
            dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;
            // 
            // cmbActionFilter
            // 
            cmbActionFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActionFilter.FormattingEnabled = true;
            cmbActionFilter.Location = new Point(710, 40);
            cmbActionFilter.Name = "cmbActionFilter";
            cmbActionFilter.Size = new Size(170, 23);
            cmbActionFilter.TabIndex = 4;
            cmbActionFilter.SelectedIndexChanged += cmbActionFilter_SelectedIndexChanged;
            // 
            // lblAction
            // 
            lblAction.AutoSize = true;
            lblAction.Location = new Point(710, 20);
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(75, 15);
            lblAction.TabIndex = 3;
            lblAction.Text = "Action Type:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by user, action, or details...";
            txtSearch.Size = new Size(300, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(20, 20);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblTitle.Location = new Point(889, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 25);
            lblTitle.TabIndex = 0;
            // 
            // dgvLogs
            // 
            dgvLogs.AllowUserToAddRows = false;
            dgvLogs.AllowUserToDeleteRows = false;
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogs.Dock = DockStyle.Fill;
            dgvLogs.Location = new Point(0, 100);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.ReadOnly = true;
            dgvLogs.RowTemplate.Height = 25;
            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.Size = new Size(984, 461);
            dgvLogs.TabIndex = 1;
            // 
            // ActivityLogViewerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(dgvLogs);
            Controls.Add(pnlFilters);
            Name = "ActivityLogViewerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Activity Log Viewer";
            Load += ActivityLogViewerForm_Load;
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlFilters;
        private Label lblTitle;
        private TextBox txtSearch;
        private Label lblSearch;
        private ComboBox cmbActionFilter;
        private Label lblAction;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private CheckBox chkFromDate;
        private CheckBox chkToDate;
        private Label lblRecordCount;
        private Button btnRefresh;
        private Button btnClearFilters;
        private Button btnClose;
        private DataGridView dgvLogs;
    }
}
