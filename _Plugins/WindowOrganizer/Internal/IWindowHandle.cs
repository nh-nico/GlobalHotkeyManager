using System;

namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Represents the IntPtr handle of an window.
    /// </summary>
    public interface IWindowHandle
    {
        /// <summary>
        /// IntPtr handle for an window.
        /// </summary>
        IntPtr Value { get; }
    }
}