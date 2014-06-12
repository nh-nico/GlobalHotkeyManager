using System.Runtime.InteropServices;

namespace nhammerl.WindowOrganizer.Internal
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowRectangle
    {
        public int xUpperLeft;        // xUpperLeft position of upper-left corner
        public int yUpperLeft;         // yUpperLeft position of upper-left corner
        public int xLowerRight;       // xUpperLeft position of lower-right corner
        public int yLowerRight;      // yUpperLeft position of lower-right corner
    }
}