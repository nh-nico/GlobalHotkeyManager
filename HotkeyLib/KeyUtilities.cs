using System;
using System.Windows.Forms;

namespace Hotkeys
{
    public static class KeyUtilities
    {
        public static Keys GetKey(IntPtr lParam)
        {
            // not all of the parenthesis are needed, I just found it easier to see what's happening
            return (Keys)((lParam.ToInt32()) >> 16);
        }
    }
}