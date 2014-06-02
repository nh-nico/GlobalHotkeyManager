using nhammerlGlobalHotkeyPluginLib;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }

    public class SplitHalfAttachTop : IGlobalHotkeyPlugin
    {
        public string PluginName
        {
            get { return "Split Active Window, Attach on Top"; }
        }

        public void Execute()
        {
            var allScreens = Screen.AllScreens;

            var activeWindow = GetActiveWindow();

            var rect = new RECT();

            var x = GetWindowRect(activeWindow, out rect);

            //MessageBox.Show(
            //    "Left: " + rect.Left + " - " + "Bottom: " + rect.Bottom + "Right: " + rect.Right + " - " + "Top: " +
            //    rect.Top);

            var resolutionWithBeginDraw = 0;
            var currentScreenIndex = 0;
            foreach (var screen in allScreens)
            {
                if (rect.Left > screen.WorkingArea.Width + resolutionWithBeginDraw)
                {
                    resolutionWithBeginDraw += screen.WorkingArea.Width;
                    currentScreenIndex++;
                    //MessageBox.Show(screen.WorkingArea.Width.ToString());
                }
            }
            var currentScreen = allScreens[currentScreenIndex];
            var y = Screen.PrimaryScreen.WorkingArea.Height - currentScreen.WorkingArea.Height;

            //MessageBox.Show(y.ToString());

            MoveWindow(
                activeWindow,
                resolutionWithBeginDraw,
                y,
                currentScreen.WorkingArea.Width,
                currentScreen.WorkingArea.Height / 2,
                true);

            //MessageBox.Show(resolutionWithBeginDraw.ToString() + " - " + allScreens[currentScreenIndex].WorkingArea.Width);

            //int i = 0;
            //while (screenResolutionWith < rect.Left)
            //{
            //    screenResolutionWith = allScreens[i].WorkingArea.Width;
            //    i++;
            //}

            //MessageBox.Show(screenResolutionWith.ToString());
            //MessageBox.Show(rect.Left.ToString());
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        private IntPtr GetActiveWindow()
        {
            return GetForegroundWindow();
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);
    }
}