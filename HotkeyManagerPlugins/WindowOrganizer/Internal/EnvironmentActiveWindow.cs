using System;
using System.Runtime.InteropServices;

namespace nhammerl.WindowOrganizer.Internal
{
    public class EnvironmentActiveWindow : IActiveWindow
    {
        public IntPtr Value
        {
            get { return GetForegroundWindow(); }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
    }
}