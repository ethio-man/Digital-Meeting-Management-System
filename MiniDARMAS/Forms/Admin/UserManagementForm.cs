using System;
using System.Collections.Generic;
using System.Linq; // Added for filtering/sorting
using System.Windows.Forms;
using MiniDARMAS.Data;
using MiniDARMAS.Domain;
using MiniDARMAS.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Infrastructure;

namespace MiniDARMAS.Forms.Admin
{
    public partial class UserManagementForm : Form
    {
        private User _currentUser;
        private UserDao _userDao;
        private User? _selectedUser;
        private List<User>? _allUsers; // Store all users for client-side filtering

        public UserManagementForm(User user)
        {
            InitializeComponent();
            FormTheme.Apply(this);
            _currentUser = user;

            _userDao = new UserDao();
            this.tabControlAdmin.SelectedIndexChanged += new System.EventHandler(this.tabControlAdmin_SelectedIndexChanged);
            
            // Event handlers for new controls
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            this.cmbFilterRole.SelectedIndexChanged += new System.EventHandler(this.cmbFilterRole_SelectedIndexChanged);
            
            LoadFilterRoles();

            LocalizationManager.AutoLocalize(this);
        }

        private void LoadFilterRoles()
        {
            var roles = new List<string> { "All" };
            roles.AddRange(Enum.GetNames(typeof(UserRole)));
            cmbFilterRole.DataSource = roles;
            cmbFilterRole.SelectedIndex = 0;
        }

        private void tabControlAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlAdmin.SelectedTab == tabExit)
            {
                this.Close();
            }
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadUsers();
            ClearForm();
        }

        private void LoadRoles()
        {
            cmbRole.DataSource = Enum.GetValues(typeof(UserRole));
        }

        private void LoadUsers()
        {
            _allUsers = _userDao.GetAllUsers();
            BindGrid();
        }

        private void BindGrid()
        {
            if (_allUsers == null) return;

            var filtered = _allUsers.AsEnumerable();

            // Search
            string search = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(search))
            {
                filtered = filtered.Where(u => u.Username.ToLower().Contains(search) 
                                            || u.FullName.ToLower().Contains(search));
            }

            // Filter Role
            if (cmbFilterRole.SelectedItem != null && cmbFilterRole.SelectedItem.ToString() != "All")
            {
                string role = cmbFilterRole.SelectedItem.ToString();
                filtered = filtered.Where(u => u.Role.ToString() == role);
            }

            // Sort
            if (cmbSort.SelectedItem != null)
            {
                string sortOption = cmbSort.SelectedItem.ToString();
                switch (sortOption)
                {
                    case "Username Asc":
                        filtered = filtered.OrderBy(u => u.Username);
                        break;
                    case "Username Desc":
                        filtered = filtered.OrderByDescending(u => u.Username);
                        break;
                    case "Role Asc":
                        filtered = filtered.OrderBy(u => u.Role);
                        break;
                    case "Role Desc":
                        filtered = filtered.OrderByDescending(u => u.Role);
                        break;
                }
            }

            dgvUsers.DataSource = filtered.ToList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void cmbFilterRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void dgvUsers_MouseDown(object sender, MouseEventArgs e)
        {
             var hit = dgvUsers.HitTest(e.X, e.Y);
             if (hit.Type == DataGridViewHitTestType.None)
             {
                 dgvUsers.ClearSelection();
                 _selectedUser = null;
                 ClearForm(); // Also clear the edit form since no user is selected
             }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Username and Password are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                User user = new User
                {
                    Username = txtUsername.Text,
                    PasswordHash = txtPassword.Text,
                    FullName = txtFullName.Text,
                    Role = (UserRole)cmbRole.SelectedItem,
                    IsActive = chkActive.Checked
                };

                if (_selectedUser == null)
                {
                    // Add
                    _userDao.AddUser(user);
                    ActivityLogService.Log(_currentUser, "Added User", null, "User", $"Username: {user.Username}, Role: {user.Role}");
                    MessageBox.Show("User added successfully.");
                }
                else
                {
                    // Update
                    user.UserId = _selectedUser.UserId;
                    _userDao.UpdateUser(user);
                    ActivityLogService.Log(_currentUser, "Updated User", user.UserId, "User", $"Username: {user.Username}, Role: {user.Role}");
                    MessageBox.Show("User updated successfully.");
                }
                LoadUsers();
                ClearForm();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedUser = null;
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            chkActive.Checked = true;
            cmbRole.SelectedIndex = 0;
            btnSave.Text = "Save";
            dgvUsers.ClearSelection();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var user = (User)dgvUsers.SelectedRows[0].DataBoundItem;
                _selectedUser = user;
                txtUsername.Text = user.Username;
                txtPassword.Text = user.PasswordHash;
                txtFullName.Text = user.FullName;
                cmbRole.SelectedItem = user.Role;
                chkActive.Checked = user.IsActive;
                btnSave.Text = "Update";
            }
        }
    }
}
