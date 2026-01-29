namespace MiniDARMAS.Forms.Editor
{
    partial class ReviewForm
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
            tabControlReview = new TabControl();
            tabReviewQueue = new TabPage();
            splitContainer1 = new SplitContainer();
            groupBoxList = new GroupBox();
            dgvReviews = new DataGridView();
            groupBoxContent = new GroupBox();
            btnReturn = new Button();
            btnUnderReview = new Button();
            btnApprove = new Button();
            rtbContent = new RichTextBox();
            label1 = new Label();
            txtReviewComment = new TextBox();
            labelComment = new Label();
            tabFinalize = new TabPage();
            rtbFinalPreview = new RichTextBox();
            btnFinalize = new Button();
            pnlFinalizeTop = new Panel();
            cmbApprovedMeetings = new ComboBox();
            labelSelMeeting = new Label();
            pnlSignature = new Panel();
            lblSignatureInfo = new Label();
            btnBrowseSignature = new Button();
            picSignature = new PictureBox();
            tabControlReview.SuspendLayout();
            tabReviewQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).BeginInit();
            groupBoxContent.SuspendLayout();
            tabFinalize.SuspendLayout();
            pnlFinalizeTop.SuspendLayout();
            pnlSignature.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSignature).BeginInit();
            SuspendLayout();
            // 
            // tabControlReview
            // 
            tabControlReview.Controls.Add(tabReviewQueue);
            tabControlReview.Controls.Add(tabFinalize);
            tabControlReview.Dock = DockStyle.Fill;
            tabControlReview.Location = new Point(0, 0);
            tabControlReview.Name = "tabControlReview";
            tabControlReview.SelectedIndex = 0;
            tabControlReview.Size = new Size(900, 600);
            tabControlReview.TabIndex = 0;
            // 
            // tabReviewQueue
            // 
            tabReviewQueue.Controls.Add(splitContainer1);
            tabReviewQueue.Location = new Point(4, 24);
            tabReviewQueue.Name = "tabReviewQueue";
            tabReviewQueue.Padding = new Padding(3);
            tabReviewQueue.Size = new Size(892, 572);
            tabReviewQueue.TabIndex = 0;
            tabReviewQueue.Text = "Review Queue";
            tabReviewQueue.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBoxList);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBoxContent);
            splitContainer1.Size = new Size(886, 566);
            splitContainer1.SplitterDistance = 300;
            splitContainer1.TabIndex = 0;
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(dgvReviews);
            groupBoxList.Dock = DockStyle.Fill;
            groupBoxList.Location = new Point(0, 0);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Size = new Size(300, 566);
            groupBoxList.TabIndex = 0;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "Review Queue";
            // 
            // dgvReviews
            // 
            dgvReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReviews.Dock = DockStyle.Fill;
            dgvReviews.Location = new Point(3, 19);
            dgvReviews.Name = "dgvReviews";
            dgvReviews.RowTemplate.Height = 25;
            dgvReviews.Size = new Size(294, 544);
            dgvReviews.TabIndex = 0;
            dgvReviews.SelectionChanged += dgvReviews_SelectionChanged;
            // 
            // groupBoxContent
            // 
            groupBoxContent.Controls.Add(btnReturn);
            groupBoxContent.Controls.Add(btnUnderReview);
            groupBoxContent.Controls.Add(btnApprove);
            groupBoxContent.Controls.Add(rtbContent);
            groupBoxContent.Controls.Add(label1);
            groupBoxContent.Controls.Add(txtReviewComment);
            groupBoxContent.Controls.Add(labelComment);
            groupBoxContent.Dock = DockStyle.Fill;
            groupBoxContent.Location = new Point(0, 0);
            groupBoxContent.Name = "groupBoxContent";
            groupBoxContent.Size = new Size(582, 566);
            groupBoxContent.TabIndex = 0;
            groupBoxContent.TabStop = false;
            groupBoxContent.Text = "Editor / Approver Board";
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.LightCoral;
            btnReturn.Location = new Point(180, 475);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(150, 40);
            btnReturn.TabIndex = 3;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnUnderReview
            // 
            btnUnderReview.Location = new Point(336, 475);
            btnUnderReview.Name = "btnUnderReview";
            btnUnderReview.Size = new Size(120, 40);
            btnUnderReview.TabIndex = 6;
            btnUnderReview.Text = "Under Review";
            btnUnderReview.UseVisualStyleBackColor = true;
            btnUnderReview.Visible = false;
            btnUnderReview.Click += btnUnderReview_Click;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.LightGreen;
            btnApprove.Location = new Point(24, 475);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(150, 40);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(20, 60);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(550, 409);
            rtbContent.TabIndex = 1;
            rtbContent.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 0;
            label1.Text = "Transcription Text:";
            // 
            // txtReviewComment
            // 
            txtReviewComment.Location = new Point(20, 550);
            txtReviewComment.Name = "txtReviewComment";
            txtReviewComment.Size = new Size(500, 23);
            txtReviewComment.TabIndex = 5;
            // 
            // labelComment
            // 
            labelComment.AutoSize = true;
            labelComment.Location = new Point(20, 530);
            labelComment.Name = "labelComment";
            labelComment.Size = new Size(178, 15);
            labelComment.TabIndex = 6;
            labelComment.Text = "Comment (Required for Return):";
            // 
            // tabFinalize
            // 
            tabFinalize.Controls.Add(rtbFinalPreview);
            tabFinalize.Controls.Add(btnFinalize);
            tabFinalize.Controls.Add(pnlFinalizeTop);
            tabFinalize.Controls.Add(pnlSignature);
            tabFinalize.Location = new Point(4, 24);
            tabFinalize.Name = "tabFinalize";
            tabFinalize.Padding = new Padding(3);
            tabFinalize.Size = new Size(892, 572);
            tabFinalize.TabIndex = 1;
            tabFinalize.Text = "Approved";
            tabFinalize.UseVisualStyleBackColor = true;
            // 
            // rtbFinalPreview
            // 
            rtbFinalPreview.Location = new Point(3, 53);
            rtbFinalPreview.Name = "rtbFinalPreview";
            rtbFinalPreview.ReadOnly = true;
            rtbFinalPreview.Size = new Size(886, 350);
            rtbFinalPreview.TabIndex = 1;
            rtbFinalPreview.Text = "";
            // 
            // btnFinalize
            // 
            btnFinalize.BackColor = Color.Gold;
            btnFinalize.Location = new Point(500, 480);
            btnFinalize.Name = "btnFinalize";
            btnFinalize.Size = new Size(200, 50);
            btnFinalize.TabIndex = 4;
            btnFinalize.Text = "Export as (PDF ,RTF, TXT)";
            btnFinalize.UseVisualStyleBackColor = false;
            btnFinalize.Visible = false;
            btnFinalize.Click += btnFinalize_Click;
            // 
            // pnlFinalizeTop
            // 
            pnlFinalizeTop.Controls.Add(cmbApprovedMeetings);
            pnlFinalizeTop.Controls.Add(labelSelMeeting);
            pnlFinalizeTop.Dock = DockStyle.Top;
            pnlFinalizeTop.Location = new Point(3, 3);
            pnlFinalizeTop.Name = "pnlFinalizeTop";
            pnlFinalizeTop.Size = new Size(886, 50);
            pnlFinalizeTop.TabIndex = 0;
            // 
            // cmbApprovedMeetings
            // 
            cmbApprovedMeetings.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbApprovedMeetings.FormattingEnabled = true;
            cmbApprovedMeetings.Location = new Point(120, 12);
            cmbApprovedMeetings.Name = "cmbApprovedMeetings";
            cmbApprovedMeetings.Size = new Size(300, 23);
            cmbApprovedMeetings.TabIndex = 1;
            cmbApprovedMeetings.SelectedIndexChanged += cmbApprovedMeetings_SelectedIndexChanged;
            // 
            // labelSelMeeting
            // 
            labelSelMeeting.AutoSize = true;
            labelSelMeeting.Location = new Point(20, 15);
            labelSelMeeting.Name = "labelSelMeeting";
            labelSelMeeting.Size = new Size(88, 15);
            labelSelMeeting.TabIndex = 0;
            labelSelMeeting.Text = "Select Meeting:";
            // 
            // pnlSignature
            // 
            pnlSignature.BorderStyle = BorderStyle.FixedSingle;
            pnlSignature.Controls.Add(lblSignatureInfo);
            pnlSignature.Controls.Add(btnBrowseSignature);
            pnlSignature.Controls.Add(picSignature);
            pnlSignature.Location = new Point(20, 410);
            pnlSignature.Name = "pnlSignature";
            pnlSignature.Size = new Size(300, 150);
            pnlSignature.TabIndex = 5;
            // 
            // lblSignatureInfo
            // 
            lblSignatureInfo.AutoSize = true;
            lblSignatureInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            lblSignatureInfo.Location = new Point(10, 125);
            lblSignatureInfo.Name = "lblSignatureInfo";
            lblSignatureInfo.Size = new Size(123, 15);
            lblSignatureInfo.TabIndex = 2;
            lblSignatureInfo.Text = "No signature selected.";
            // 
            // btnBrowseSignature
            // 
            btnBrowseSignature.Location = new Point(10, 80);
            btnBrowseSignature.Name = "btnBrowseSignature";
            btnBrowseSignature.Size = new Size(130, 30);
            btnBrowseSignature.TabIndex = 1;
            btnBrowseSignature.Text = "Add Signature Image";
            btnBrowseSignature.UseVisualStyleBackColor = true;
            btnBrowseSignature.Click += btnBrowseSignature_Click;
            // 
            // picSignature
            // 
            picSignature.BorderStyle = BorderStyle.FixedSingle;
            picSignature.Location = new Point(150, 10);
            picSignature.Name = "picSignature";
            picSignature.Size = new Size(135, 130);
            picSignature.SizeMode = PictureBoxSizeMode.Zoom;
            picSignature.TabIndex = 0;
            picSignature.TabStop = false;
            // 
            // ReviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(tabControlReview);
            Name = "ReviewForm";
            Text = "Review Dashboard";
            Load += ReviewForm_Load;
            tabControlReview.ResumeLayout(false);
            tabReviewQueue.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReviews).EndInit();
            groupBoxContent.ResumeLayout(false);
            groupBoxContent.PerformLayout();
            tabFinalize.ResumeLayout(false);
            pnlFinalizeTop.ResumeLayout(false);
            pnlFinalizeTop.PerformLayout();
            pnlSignature.ResumeLayout(false);
            pnlSignature.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSignature).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControlReview;
        private System.Windows.Forms.TabPage tabReviewQueue;
        private System.Windows.Forms.TabPage tabFinalize;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dgvReviews;
        private System.Windows.Forms.GroupBox groupBoxContent;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnUnderReview;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.TextBox txtReviewComment;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Panel pnlFinalizeTop;
        private System.Windows.Forms.ComboBox cmbApprovedMeetings;
        private System.Windows.Forms.Label labelSelMeeting;
        private System.Windows.Forms.RichTextBox rtbFinalPreview;
        private System.Windows.Forms.Panel pnlSignature;
        private System.Windows.Forms.PictureBox picSignature;
        private System.Windows.Forms.Button btnBrowseSignature;
        private System.Windows.Forms.Label lblSignatureInfo;
    }
}
