namespace MiniDARMAS.Forms.Admin
{
    partial class UserManagementForm
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
            tabControlAdmin = new TabControl();
            tabUserList = new TabPage();
            dgvUsers = new DataGridView();
            pnlControls = new Panel();
            btnSort = new Button();
            cmbFilterRole = new ComboBox();
            lblFilter = new Label();
            cmbSort = new ComboBox();
            lblSort = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            tabUserEdit = new TabPage();
            groupBox1 = new GroupBox();
            btnClear = new Button();
            chkActive = new CheckBox();
            btnSave = new Button();
            cmbRole = new ComboBox();
            label4 = new Label();
            txtFullName = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            tabExit = new TabPage();
            tabControlAdmin.SuspendLayout();
            tabUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            pnlControls.SuspendLayout();
            tabUserEdit.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlAdmin
            // 
            tabControlAdmin.Controls.Add(tabUserList);
            tabControlAdmin.Controls.Add(tabUserEdit);
            tabControlAdmin.Controls.Add(tabExit);
            tabControlAdmin.Dock = DockStyle.Fill;
            tabControlAdmin.Location = new Point(0, 0);
            tabControlAdmin.Name = "tabControlAdmin";
            tabControlAdmin.SelectedIndex = 0;
            tabControlAdmin.Size = new Size(800, 450);
            tabControlAdmin.TabIndex = 0;
            tabControlAdmin.Tag = "ManageUsers";
            // 
            // tabUserList
            // 
            tabUserList.Controls.Add(dgvUsers);
            tabUserList.Controls.Add(pnlControls);
            tabUserList.Location = new Point(4, 24);
            tabUserList.Name = "tabUserList";
            tabUserList.Padding = new Padding(3);
            tabUserList.Size = new Size(792, 422);
            tabUserList.TabIndex = 0;
            tabUserList.Text = "User Management";
            tabUserList.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(3, 53);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowTemplate.Height = 35;
            dgvUsers.Size = new Size(786, 366);
            dgvUsers.TabIndex = 0;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            dgvUsers.MouseDown += dgvUsers_MouseDown;
            // 
            // pnlControls
            // 
            pnlControls.BackColor = Color.WhiteSmoke;
            pnlControls.Controls.Add(btnSort);
            pnlControls.Controls.Add(cmbFilterRole);
            pnlControls.Controls.Add(lblFilter);
            pnlControls.Controls.Add(cmbSort);
            pnlControls.Controls.Add(lblSort);
            pnlControls.Controls.Add(txtSearch);
            pnlControls.Controls.Add(lblSearch);
            pnlControls.Dock = DockStyle.Top;
            pnlControls.Location = new Point(3, 3);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(786, 50);
            pnlControls.TabIndex = 1;
            // 
            // btnSort
            // 
            btnSort.Location = new Point(500, 10);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(75, 25);
            btnSort.TabIndex = 4;
            btnSort.Text = "Sort";
            btnSort.UseVisualStyleBackColor = true;
            // 
            // cmbFilterRole
            // 
            cmbFilterRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterRole.FormattingEnabled = true;
            cmbFilterRole.Location = new Point(630, 12);
            cmbFilterRole.Name = "cmbFilterRole";
            cmbFilterRole.Size = new Size(120, 23);
            cmbFilterRole.TabIndex = 6;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(590, 15);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(36, 15);
            lblFilter.TabIndex = 5;
            lblFilter.Text = "Filter:";
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] { "Username Asc", "Username Desc", "Role Asc", "Role Desc" });
            cmbSort.Location = new Point(340, 12);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(150, 23);
            cmbSort.TabIndex = 3;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.Location = new Point(300, 15);
            lblSort.Name = "lblSort";
            lblSort.Size = new Size(31, 15);
            lblSort.TabIndex = 2;
            lblSort.Text = "Sort:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(61, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Tag = "Search";
            lblSearch.Text = "Search:";
            // 
            // tabUserEdit
            // 
            tabUserEdit.Controls.Add(groupBox1);
            tabUserEdit.Location = new Point(4, 24);
            tabUserEdit.Name = "tabUserEdit";
            tabUserEdit.Padding = new Padding(3);
            tabUserEdit.Size = new Size(792, 422);
            tabUserEdit.TabIndex = 1;
            tabUserEdit.Text = "User Edit";
            tabUserEdit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(chkActive);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(cmbRole);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtFullName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(600, 300);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "User Details";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(370, 220);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 30);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(370, 150);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(70, 19);
            chkActive.TabIndex = 9;
            chkActive.Text = "Is Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(130, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 30);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save / Update";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(370, 80);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(200, 23);
            cmbRole.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(370, 60);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 6;
            label4.Text = "Role:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(130, 80);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(200, 23);
            txtFullName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 83);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 4;
            label3.Text = "Full Name:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(130, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 153);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(130, 40);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 43);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // tabExit
            // 
            tabExit.Location = new Point(4, 24);
            tabExit.Name = "tabExit";
            tabExit.Size = new Size(792, 422);
            tabExit.TabIndex = 2;
            tabExit.Text = "Exit";
            tabExit.UseVisualStyleBackColor = true;
            // 
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlAdmin);
            Name = "UserManagementForm";
            Text = "Manage Users (Admin)";
            Load += UserManagementForm_Load;
            tabControlAdmin.ResumeLayout(false);
            tabUserList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            tabUserEdit.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabUserList;
        private System.Windows.Forms.TabPage tabUserEdit;
        private System.Windows.Forms.TabPage tabExit; // ADDED
        private System.Windows.Forms.DataGridView dgvUsers;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilterRole;
    }
}
