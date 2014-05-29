using System;
using System.Windows.Forms;

namespace nhammerl.GlobalHotkeyManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start BackgroundListener
            Application.Run(new GlobalKeyBackgroundListener());
        }
    }
}