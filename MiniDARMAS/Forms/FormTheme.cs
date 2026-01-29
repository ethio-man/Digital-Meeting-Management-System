using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniDARMAS.Forms
{
    public static class FormTheme
    {
        // Color Palette
        public static readonly Color PrimaryColor = Color.FromArgb(0, 120, 215); // Windows Blue
        public static readonly Color SecondaryColor = Color.FromArgb(243, 243, 243); // Light Gray
        public static readonly Color BackgroundColor = Color.White;
        public static readonly Color TextColor = Color.FromArgb(33, 33, 33);
        public static readonly Color AccentColor = Color.FromArgb(0, 153, 188);

        public static readonly Font HeaderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 10F, FontStyle.Regular);

        public static void Apply(Form form)
        {
            if (form == null) return;

            form.BackColor = BackgroundColor;
            form.Font = BodyFont;
            form.ForeColor = TextColor;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.StartPosition = FormStartPosition.CenterScreen;

            ApplyRecursive(form.Controls);
        }

        private static void ApplyRecursive(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is Button btn)
                {
                    StyleButton(btn);
                }
                else if (ctrl is DataGridView dgv)
                {
                    StyleDataGridView(dgv);
                }
                else if (ctrl is Label lbl)
                {
                    StyleLabel(lbl);
                }
                else if (ctrl is TextBox txt)
                {
                    StyleTextBox(txt);
                }
                else if (ctrl is ComboBox cmb)
                {
                    StyleComboBox(cmb);
                }
                else if (ctrl is Panel pnl)
                {
                    // pnl.BackColor = SecondaryColor; // Optional: depending on layout
                }
                
                if (ctrl.HasChildren && !(ctrl is DataGridView) && !(ctrl is UserControl)) // Avoid diving into complex custom controls if unwanted
                {
                    ApplyRecursive(ctrl.Controls);
                }
            }
        }

        private static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = PrimaryColor;
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            // btn.Padding = new Padding(10, 5, 10, 5); // Can cause layout shifts if not careful
        }

        private static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 40;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TextColor;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250); // Very light blue
            dgv.DefaultCellStyle.SelectionForeColor = TextColor;
            dgv.DefaultCellStyle.Padding = new Padding(5);
            dgv.DefaultCellStyle.Font = BodyFont;
            
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private static void StyleLabel(Label lbl)
        {
            lbl.ForeColor = TextColor;
            // Detect if it is a title label? (Simple heuristic: Font size)
            if (lbl.Font.Size >= 14)
            {
                lbl.ForeColor = PrimaryColor;
            }
        }

        private static void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
            txt.ForeColor = TextColor;
        }

        private static void StyleComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.BackColor = Color.White;
            cmb.ForeColor = TextColor;
        }
    }
}
