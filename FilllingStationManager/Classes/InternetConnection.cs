                          using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.InteropServices;

namespace FilllingStationManager.Classes
{
    
    class InternetConnection
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public bool isConnected()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
    }
}
