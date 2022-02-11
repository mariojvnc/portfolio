using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wettesensoren
{
    class RequestDataEventArgs : EventArgs
    {
        public DateTime Time { get; }

        public RequestDataEventArgs(DateTime time)
        {
            Time = time;
        }
    }
}

