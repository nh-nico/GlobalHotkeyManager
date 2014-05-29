using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hotkeys
{
    public class GlobalHotkey
    {
        private readonly int _modifier;
        public readonly Keys Key;
        private readonly Action _keyPressedAction;
        private readonly IntPtr _hWnd;
        private readonly int _id;

        public GlobalHotkey(int modifier, Keys key, Form form, Action keyPressedAction)
        {
            this._modifier = modifier;
            this.Key = key;
            _keyPressedAction = keyPressedAction;
            this._hWnd = form.Handle;
            _id = this.GetHashCode();
        }

        public bool Register()
        {
            return RegisterHotKey(_hWnd, _id, _modifier, (int)Key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(_hWnd, _id);
        }

        public void RunAction()
        {
            _keyPressedAction.Invoke();
        }

        public override int GetHashCode()
        {
            return _modifier ^ (int)Key ^ _hWnd.ToInt32();
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}