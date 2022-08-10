using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Core
{
    public struct ShotFeedback
    {
        public ShipClass ShipClass { get; }
        public bool Sink { get; }

        public ShotFeedback(bool sink = false, ShipClass shipClass = ShipClass.None)
        {
            Sink = sink;
            ShipClass = shipClass;
        }
    }
}
