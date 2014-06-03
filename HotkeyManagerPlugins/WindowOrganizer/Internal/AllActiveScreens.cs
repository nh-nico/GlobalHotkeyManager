using System.Collections.Generic;
using System.Windows.Forms;

namespace nhammerl.WindowOrganizer.Internal
{
    public class AllActiveScreens : IScreens
    {
        public IEnumerable<Screen> List
        {
            get { return Screen.AllScreens; }
        }
    }
}