using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.Internal
{
    public class PrimaryScreenDependentScreenHeight : IScreenHeight
    {
        public int ForScreen(Screen screen)
        {
            return Screen.PrimaryScreen.WorkingArea.Height - screen.WorkingArea.Height;
        }
    }
}