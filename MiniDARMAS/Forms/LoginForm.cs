using MiniDARMAS.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Domain;
using MiniDARMAS.Forms.Admin;
using MiniDARMAS.Forms.Operator;
using MiniDARMAS.Forms.Transcriber;
using MiniDARMAS.Forms.Editor;

namespace MiniDARMAS.Forms
{
    public partial class LoginForm : Form
    {
        private AuthService _authService;

        public LoginForm()
        {
            InitializeComponent();
            
            FormTheme.Apply(this);
            // Custom adjustments for Login Form
            lblTitle.ForeColor = FormTheme.PrimaryColor;

            // Initialize Language Switcher
            cmbLanguage.DataSource = new BindingSource(LocalizationManager.AvailableLanguages, null);
            cmbLanguage.DisplayMember = "Value";
            cmbLanguage.ValueMember = "Key";
            cmbLanguage.SelectedValue = LocalizationManager.CurrentLanguage;

            // Layout Logic for Centering
            this.Resize += LoginForm_Resize;
            
            _authService = new AuthService();
            // Initial localization and subscription
            LocalizationManager.AutoLocalize(this);
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedValue is string cultureCode)
            {
                LocalizationManager.SetLanguage(cultureCode);
                LocalizationManager.ApplyToForm(this);
                CenterControls(); // Re-center in case text size changed
            }
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            // Adjusted logic for larger title and spacing
            
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Absolute Positioning for Images to prevent overflow
            if(pbLeft != null) pbLeft.Location = new Point(10, 10);
            if(pbRight != null) pbRight.Location = new Point(this.ClientSize.Width - pbRight.Width - 10, 10);

            // Input rows ~25px height each
            // Total stack: Title (65) + Gap (30) + UserRow (25) + Gap (20) + PassRow (25) + Gap (20) + Button (30)
            // Total height approx 215px
            
            int totalHeight = 220;
            int startY = centerY - (totalHeight / 2);

            // Title
            lblTitle.Location = new Point(centerX - (lblTitle.Width / 2), startY);
            
            // Username Row
            int row1Y = startY + 80; // Increased gap below title

            txtUsername.Location = new Point(centerX - (txtUsername.Width / 2) + 40, row1Y); 
            lblUsername.Location = new Point(txtUsername.Location.X - 100, row1Y + 3);

            // Password Row
            int row2Y = row1Y + 40;
            txtPassword.Location = new Point(centerX - (txtPassword.Width / 2) + 40, row2Y);
            lblPassword.Location = new Point(txtPassword.Location.X - 100, row2Y + 3);

            // Button
            int row3Y = row2Y + 50;
            btnLogin.Location = new Point(centerX - (btnLogin.Width / 2), row3Y);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text; 
            
            try
            {
                var user = _authService.Login(username, password);
                if (user != null)
                {
                    // Log the login action
                    ActivityLogService.Log(user, "Logged In");

                    this.Hide();
                    Form nextForm = null;

                    switch(user.Role)
                    {
                        case UserRole.Admin:
                           // Navigate to Dashboard instead of UserManagementForm
                           nextForm = new AdminDashboardForm(user);
                           break;
                        case UserRole.Operator:
                           nextForm = new MeetingManagerForm(user);
                           break;
                        case UserRole.Transcriber:
                           nextForm = new TranscriptionForm(user);
                           break;
                        case UserRole.Editor:
                        case UserRole.Approver:
                           nextForm = new ReviewForm(user);
                           break;
                        default:
                            MessageBox.Show("No interface for this role yet.");
                            this.Show();
                            return;
                    }

                    if(nextForm != null)
                    {
                        nextForm.ShowDialog();
                        
                        // Clear password field for security
                        txtPassword.Text = "";
                        
                        this.Show(); // Re-show login when sub-form closes (Exit)
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            catch(Exception ex) 
            {
                MessageBox.Show("Error logging in: " + ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}

