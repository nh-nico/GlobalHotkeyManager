using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.Internal
{
    public interface IWindowScreenInfos
    {
        void GetInfos(out int currentWindowTopLeftCorner, out Screen currentScreen);
    }
}