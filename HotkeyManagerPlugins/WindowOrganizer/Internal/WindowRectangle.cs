using System.Runtime.InteropServices;

namespace nhammerl.WindowOrganizer.Internal
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowRectangle
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }
}