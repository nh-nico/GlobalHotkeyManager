namespace nhammerl.WindowOrganizer.Internal
{
    /// <summary>
    /// Validates window title of current active window. Is no Startmenue and is one selected?
    /// </summary>
    public class ActiveWindowTitleNotStartMenuePluginState : IPluginState
    {
        private readonly IWindowTitle _windowTitle;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="windowTitle"></param>
        public ActiveWindowTitleNotStartMenuePluginState(IWindowTitle windowTitle)
        {
            _windowTitle = windowTitle;
        }

        /// <summary>
        /// State of the active window.
        /// </summary>
        public bool State
        {
            get
            {
                return (_windowTitle.Value != null && !_windowTitle.Value.Equals("Startmenü"));
            }
        }
    }
}