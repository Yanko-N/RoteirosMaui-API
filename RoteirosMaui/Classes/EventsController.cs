using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteirosMaui.Classes
{
    public static class EventsController
    {
        public static event EventHandler UserProfileNavigated;
        public static void Raise_UserProfileNavigated()
        {
            UserProfileNavigated?.Invoke(null,EventArgs.Empty);
        }
    }
}
