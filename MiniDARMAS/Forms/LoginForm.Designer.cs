namespace MiniDARMAS.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblUsername = new Label();
            lblPassword = new Label();
            lblTitle = new Label();
            pbLeft = new PictureBox();
            pbRight = new PictureBox();
            cmbLanguage = new ComboBox();
            lblLanguage = new Label();
            ((System.ComponentModel.ISupportInitialize)pbLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbRight).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(443, 244);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(443, 280);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(489, 338);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 30);
            btnLogin.TabIndex = 2;
            btnLogin.Tag = "Login";
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(356, 247);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 3;
            lblUsername.Tag = "Username";
            lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(356, 288);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Tag = "Password";
            lblPassword.Text = "Password:";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = SystemColors.MenuHighlight;
            lblTitle.Location = new Point(306, 160);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(356, 65);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Mini-DARMAS";
            // 
            // pbLeft
            // 
            pbLeft.Image = (Image)resources.GetObject("pbLeft.Image");
            pbLeft.Location = new Point(21, 10);
            pbLeft.Name = "pbLeft";
            pbLeft.Size = new Size(200, 150);
            pbLeft.SizeMode = PictureBoxSizeMode.Zoom;
            pbLeft.TabIndex = 6;
            pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            pbRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbRight.Image = (Image)resources.GetObject("pbRight.Image");
            pbRight.Location = new Point(735, 10);
            pbRight.Name = "pbRight";
            pbRight.Size = new Size(200, 150);
            pbRight.SizeMode = PictureBoxSizeMode.Zoom;
            pbRight.TabIndex = 7;
            pbRight.TabStop = false;
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(400, 420);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(150, 23);
            cmbLanguage.TabIndex = 8;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Location = new Point(330, 423);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(62, 15);
            lblLanguage.TabIndex = 9;
            lblLanguage.Text = "Language:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 469);
            Controls.Add(pbRight);
            Controls.Add(pbLeft);
            Controls.Add(lblTitle);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(cmbLanguage);
            Controls.Add(lblLanguage);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pbLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbRight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
    }
}
