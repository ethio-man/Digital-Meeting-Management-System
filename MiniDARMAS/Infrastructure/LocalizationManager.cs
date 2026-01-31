using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace MiniDARMAS.Infrastructure
{
    public static class LocalizationManager
    {
        private static ResourceManager? _resourceManager;
        private static string _currentLanguage = "en";


        public static readonly Dictionary<string, string> AvailableLanguages = new Dictionary<string, string>
        {
            { "en", "English" },
            { "am", "አማርኛ (Amharic)" }
        };


        // Current language code (e.g., "en" or "am")
        public static string CurrentLanguage => _currentLanguage;

       
        /// Event raised when language changes
        public static event EventHandler? LanguageChanged;

        static LocalizationManager()
        {
            // Initialize with default resource manager
            try
            {
                _resourceManager = new ResourceManager("MiniDARMAS.Resources.Strings", typeof(LocalizationManager).Assembly);
            }
            catch
            {
                _resourceManager = null;
            }
        }

  
        /// <param name="cultureCode">Culture code (e.g., "en" or "am")</param>
        public static void SetLanguage(string cultureCode)
        {
            if (!AvailableLanguages.ContainsKey(cultureCode))
            {
                cultureCode = "en"; // Default to English
            }

            _currentLanguage = cultureCode;

            try
            {
                var culture = new CultureInfo(cultureCode == "am" ? "am-ET" : "en-US");
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;
            }
            catch
            {
                // If culture not available, use invariant
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            }

            // Notify subscribers
            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }

     
        /// <param name="key">Resource key</param>
        /// <returns>Localized string or key if not found</returns>
        public static string GetString(string key)
        {
            if (_resourceManager == null)
                return key;

            try
            {
                string? value = _resourceManager.GetString(key);
                return value ?? key;
            }
            catch
            {
                return key;
            }
        }

        
        
        /// <param name="form">Form to localize</param>
        public static void AutoLocalize(Form form)
        {
            // Initial localization
            ApplyToForm(form);

            // Subscribe to future changes
            LanguageChanged += (s, e) => {
                if (!form.IsDisposed)
                {
                    ApplyToForm(form);
                }
            };
        }

        
        /// <param name="form">Form to localize</param>
        public static void ApplyToForm(Form form)
        {
            // Set font for Amharic support
            if (_currentLanguage == "am")
            {
                SetAmharicFont(form);
            }

            ApplyToControls(form.Controls);
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Check if control has a Tag with resource key
                if (control.Tag is string resourceKey && !string.IsNullOrEmpty(resourceKey))
                {
                    string localizedText = GetString(resourceKey);
                    control.Text = localizedText;
                }

                // Recursively apply to children
                if (control.HasChildren)
                {
                    ApplyToControls(control.Controls);
                }

                // Handle specific control types
                if (control is MenuStrip menuStrip)
                {
                    foreach (ToolStripItem item in menuStrip.Items)
                    {
                        LocalizeToolStripItem(item);
                    }
                }
            }
        }

        private static void LocalizeToolStripItem(ToolStripItem item)
        {
            if (item.Tag is string resourceKey && !string.IsNullOrEmpty(resourceKey))
            {
                item.Text = GetString(resourceKey);
            }

            if (item is ToolStripMenuItem menuItem)
            {
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    LocalizeToolStripItem(subItem);
                }
            }
        }

        private static void SetAmharicFont(Form form)
        {
            // Try to use a font that supports Amharic Unicode
            // Common options: Nyala, Ebrima, Ethiopian Jiret
            Font amharicFont = GetAmharicFont();
            if (amharicFont != null)
            {
                SetFontRecursive(form.Controls, amharicFont);
            }
        }

        private static Font GetAmharicFont()
        {
            // Try fonts that support Ethiopic script
            string[] fontNames = { "Nyala", "Ebrima", "Ethiopian Jiret", "Segoe UI" };

            foreach (var fontName in fontNames)
            {
                try
                {
                    var testFont = new Font(fontName, 10);
                    if (testFont.Name == fontName)
                    {
                        return testFont;
                    }
                    testFont.Dispose();
                }
                catch { }
            }

            return new Font("Segoe UI", 10); // Fallback
        }

        private static void SetFontRecursive(Control.ControlCollection controls, Font font)
        {
            foreach (Control control in controls)
            {
                // Only set font if it's a text-displaying control
                if (control is Label || control is Button || control is TextBox || 
                    control is ComboBox || control is GroupBox)
                {
                    control.Font = new Font(font.FontFamily, control.Font.Size, control.Font.Style);
                }

                if (control.HasChildren)
                {
                    SetFontRecursive(control.Controls, font);
                }
            }
        }

        
        public static class Strings
        {
            // Login
            public static string Login => GetString("Login");
            public static string Username => GetString("Username");
            public static string Password => GetString("Password");
            public static string Logout => GetString("Logout");

            // Common actions
            public static string Save => GetString("Save");
            public static string Cancel => GetString("Cancel");
            public static string Delete => GetString("Delete");
            public static string Update => GetString("Update");
            public static string Refresh => GetString("Refresh");
            public static string Close => GetString("Close");
            public static string Submit => GetString("Submit");

            // Meeting related
            public static string Meeting => GetString("Meeting");
            public static string Meetings => GetString("Meetings");
            public static string Agenda => GetString("Agenda");
            public static string Recording => GetString("Recording");
            public static string Transcription => GetString("Transcription");

            // Status
            public static string Pending => GetString("Pending");
            public static string Approved => GetString("Approved");
            public static string Completed => GetString("Completed");

            // Messages
            public static string ConfirmDelete => GetString("ConfirmDelete");
            public static string SaveSuccess => GetString("SaveSuccess");
            public static string Error => GetString("Error");
        }
    }
}
