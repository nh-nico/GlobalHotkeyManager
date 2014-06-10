using System.Collections.Generic;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.Internal
{
    public interface IScreens
    {
        IEnumerable<Screen> List { get; }
    }
}