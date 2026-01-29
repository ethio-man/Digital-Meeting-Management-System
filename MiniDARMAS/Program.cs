using System;
using System.Windows.Forms;
using MiniDARMAS.Forms;

namespace MiniDARMAS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Register Encoding Provider for PdfSharp 1.50
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}