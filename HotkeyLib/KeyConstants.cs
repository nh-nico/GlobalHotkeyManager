namespace nhammerl.HotkeyLib
{
    ///<summary>
    ///Key Constatnt modifiers
    ///</summary>
    public static class KeyConstants
    {
        //modifiers
        // ReSharper disable InconsistentNaming
        public const int NOMOD = 0x0000;

        public const int ALT = 0x0001;
        public const int CTRL = 0x0002;
        public const int SHIFT = 0x0004;
        public const int WIN = 0x0008;

        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        // ReSharper restore InconsistentNaming
    }
}