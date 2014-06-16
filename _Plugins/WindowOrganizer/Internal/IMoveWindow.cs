namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Moves a window to another position.
    /// </summary>
    public interface IMoveWindow
    {
        /// <summary>
        /// Position to move to.
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="with">With</param>
        /// <param name="height">Height</param>
        void To(int x, int y, int with, int height);
    }
}