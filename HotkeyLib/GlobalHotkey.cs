using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace nhammerl.HotkeyLib
{
    /// <summary>
    /// Global System Hotkey
    /// </summary>
    public class GlobalHotkey
    {
        private readonly int _modifier;
        public readonly Keys Key;
        private readonly Action _keyPressedAction;
        private readonly IntPtr _hWnd;
        private readonly int _id;

        public GlobalHotkey(int modifier, Keys key, IWin32Window form, Action keyPressedAction)
        {
            this._modifier = modifier;
            this.Key = key;
            _keyPressedAction = keyPressedAction;
            this._hWnd = form.Handle;
            _id = this.GetHashCode();
        }

        /// <summary>
        /// Register Hotkey in System
        /// </summary>
        /// <returns></returns>
        public bool Register()
        {
            return RegisterHotKey(_hWnd, _id, _modifier, (int)Key);
        }

        /// <summary>
        /// Unregister Hotkey in System
        /// </summary>
        /// <returns></returns>
        public bool Unregiser()
        {
            return UnregisterHotKey(_hWnd, _id);
        }

        /// <summary>
        /// Run the Delegate
        /// </summary>
        public void RunAction()
        {
            _keyPressedAction.Invoke();
        }

        /// <summary>
        /// Gets the HashCode of Build Combination Keys
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _modifier ^ (int)Key ^ _hWnd.ToInt32();
        }

        /// <summary>
        /// External Register Hotkey
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        /// <summary>
        /// External Register Hotkey
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}