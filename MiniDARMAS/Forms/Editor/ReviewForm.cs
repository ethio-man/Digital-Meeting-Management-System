using System;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Domain;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using MiniDARMAS.Forms;
using MiniDARMAS.Infrastructure;
using System.Drawing;

namespace MiniDARMAS.Forms.Editor
{
    public partial class ReviewForm : Form
    {
        private User _currentUser;
        private WorkFlowService _workFlowService;
        private Transcription _selectedTranscription;

        public ReviewForm(User user)
        {
            InitializeComponent();
            FormTheme.Apply(this);
            _currentUser = user;
            _workFlowService = new WorkFlowService();
            // ReviewForm doesn't have an Exit tab in Designer yet.
            // Leaving as is, user encounters standard X button close.

            LocalizationManager.AutoLocalize(this);
        }

        private void ReviewForm_Load(object sender, EventArgs e)
        {
            LoadReviews();
            LoadApprovedMeetings();
        }

        private void LoadApprovedMeetings()
        {
            if (_currentUser.Role == UserRole.Approver || _currentUser.Role == UserRole.Editor)
            {
               var meetings = _workFlowService.GetMeetingsWithApprovedTranscriptions();
               cmbApprovedMeetings.DataSource = meetings;
               cmbApprovedMeetings.DisplayMember = "MeetingNo"; 
               cmbApprovedMeetings.ValueMember = "MeetingId";
            }
        }


        private void LoadReviews()
        {
            if (_currentUser.Role == UserRole.Approver)
            {
                dgvReviews.DataSource = _workFlowService.GetTranscriptionsByStatus(TranscriptionStatus.Approved);
            }
            else
            {
                dgvReviews.DataSource = _workFlowService.GetTranscriptionsByStatus(TranscriptionStatus.Submitted);
            }
        }

        private void dgvReviews_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReviews.SelectedRows.Count > 0)
            {
                _selectedTranscription = (Transcription)dgvReviews.SelectedRows[0].DataBoundItem;
                
                if (_currentUser.Role == UserRole.Approver)
                {
                    // For Approver, show the Combined Text automatically
                    rtbContent.Text = _workFlowService.GetCombinedTranscriptionForMeeting(_selectedTranscription.TranscriptionId);
                }
                else
                {
                    rtbContent.Text = _selectedTranscription.TranscriptionText;
                }
                
                // Logic for Under Review Button
                // Show if status is Submitted (Neither Returned Nor Approved)
                if (_selectedTranscription.Status == TranscriptionStatus.Submitted)
                {
                    btnUnderReview.Visible = true;
                }
                else
                {
                    btnUnderReview.Visible = false;
                }
            }
        }

        private string? _signaturePath = null;

        private void btnBrowseSignature_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _signaturePath = ofd.FileName;
                    picSignature.Image = Image.FromFile(_signaturePath);
                    lblSignatureInfo.Text = Path.GetFileName(_signaturePath);
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if(_selectedTranscription == null) return;
            UpdateStatus(TranscriptionStatus.Approved);
        }

        private void btnUnderReview_Click(object sender, EventArgs e)
        {
             if(_selectedTranscription == null) return;
             UpdateStatus(TranscriptionStatus.UnderReview);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if(_selectedTranscription == null) return;
            
            if(string.IsNullOrWhiteSpace(txtReviewComment.Text))
            {
                MessageBox.Show("Please enter a comment when returning.", "Comment Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedTranscription.Comments = txtReviewComment.Text;
            UpdateStatus(TranscriptionStatus.Returned);
        }

        private void UpdateStatus(TranscriptionStatus status)
        {
             try
            {
                var oldStatus = _selectedTranscription!.Status;
                _selectedTranscription.Status = status;
                _selectedTranscription.TranscriptionText = rtbContent.Text; // Save edits
                _workFlowService.UpdateTranscription(_selectedTranscription);
                
                // Log the action
                ActivityLogService.Log(_currentUser, $"Updated Transcription Status: {oldStatus} -> {status}", 
                    _selectedTranscription.TranscriptionId, "Transcription");

                MessageBox.Show($"Transcription marked as {status}.");
                LoadReviews();
                LoadApprovedMeetings(); // Refresh list if something was just approved
                rtbContent.Text = "";
                txtReviewComment.Text = "";
                _selectedTranscription = null;
            }
             catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmbApprovedMeetings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbApprovedMeetings.SelectedItem != null)
            {
                var meeting = (Meeting)cmbApprovedMeetings.SelectedItem;
                rtbFinalPreview.Text = _workFlowService.GetCombinedTranscriptionByMeetingId(meeting.MeetingId);
                btnFinalize.Visible = true; // Ensure visible
            }
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
             if(string.IsNullOrEmpty(rtbFinalPreview.Text)) { MessageBox.Show("No content to export."); return; }
             
             SaveFileDialog sfd = new SaveFileDialog();
             sfd.Filter = "PDF File|*.pdf|Text File|*.txt|RTF File|*.rtf";
             sfd.FileName = $"Meeting_Transcript_Final_{DateTime.Now:yyyyMMdd}";
             
             if(sfd.ShowDialog() == DialogResult.OK)
             {
                 try
                 {
                     string ext = Path.GetExtension(sfd.FileName).ToLower();
                      if(ext == ".rtf")
                      {
                          rtbFinalPreview.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                      }
                      else if (ext == ".pdf")
                      {
                          PdfDocument document = new PdfDocument();
                          document.Info.Title = "Meeting Minutes";
                          PdfPage page = document.AddPage();
                          XGraphics gfx = XGraphics.FromPdfPage(page);
                          XFont font = new XFont("Verdana", 10);
                          XFont headerFont = new XFont("Verdana", 14, XFontStyle.Bold);

                          gfx.DrawString("MEETING MINUTES", headerFont, XBrushes.DarkBlue, new XRect(0, 40, page.Width, 40), XStringFormats.TopCenter);
                          gfx.DrawLine(XPens.Black, 40, 75, page.Width - 40, 75);

                          var tf = new XTextFormatter(gfx);
                          var rect = new XRect(40, 90, page.Width - 80, page.Height - 250);
                          tf.DrawString(rtbFinalPreview.Text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

                          int signatureY = (int)page.Height - 150;
                          gfx.DrawLine(XPens.Gray, 40, signatureY - 10, page.Width - 40, signatureY - 10);

                          string signatureText = $"Digitally Approved by {_currentUser.FullName} on {DateTime.Now:yyyy-MM-dd HH:mm}";
                          gfx.DrawString(signatureText, font, XBrushes.DarkSlateGray, new XPoint(40, signatureY));

                          if (!string.IsNullOrEmpty(_signaturePath) && File.Exists(_signaturePath))
                          {
                              XImage image = XImage.FromFile(_signaturePath);
                              gfx.DrawImage(image, 40, signatureY + 20, 100, 50);
                          }
                          else
                          {
                              gfx.DrawString("[Digital Signature Placeholder]", new XFont("Verdana", 8, XFontStyle.Italic), XBrushes.Gray, new XPoint(40, signatureY + 20));
                          }
                          
                          document.Save(sfd.FileName);
                      }
                      else
                      {
                          File.WriteAllText(sfd.FileName, rtbFinalPreview.Text);
                      }
                      
                      var meeting = (Meeting)cmbApprovedMeetings.SelectedItem;
                      ActivityLogService.Log(_currentUser, "Generated Final Meeting Document", meeting.MeetingId, "Meeting", $"File: {sfd.FileName}");

                      MessageBox.Show("Export successful.");
                  }
                 catch(Exception ex)
                 {
                     MessageBox.Show("Error saving file: " + ex.Message);
                 }
             }
        }
    }
}

