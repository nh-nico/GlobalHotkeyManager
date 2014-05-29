using System;
using System.Windows.Forms;

namespace nhammerl.HotkeyLib
{
    /// <summary>
    /// Hotkey Helper Utilities
    /// </summary>
    public static class KeyUtilities
    {
        /// <summary>
        /// Get the currently pressed Key
        /// </summary>
        /// <param name="lParam"></param>
        /// <returns>pressed Key</returns>
        public static Keys GetKey(IntPtr lParam)
        {
            return (Keys)((lParam.ToInt32()) >> 16);
        }
    }
}