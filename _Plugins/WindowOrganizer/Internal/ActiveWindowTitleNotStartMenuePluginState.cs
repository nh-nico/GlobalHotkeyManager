namespace nhammerl.WindowOrganizer.Internal
{
    public class ActiveWindowTitleNotStartMenuePluginState : IPluginState
    {
        private readonly IWindowTitle _windowTitle;

        public ActiveWindowTitleNotStartMenuePluginState(IWindowTitle windowTitle)
        {
            _windowTitle = windowTitle;
        }

        public bool State
        {
            get
            {
                return (_windowTitle.Value != null && !_windowTitle.Value.Equals("Startmenü"));
            }
        }
    }
}