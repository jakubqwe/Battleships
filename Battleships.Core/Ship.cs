using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Core
{
    public class Ship
    {
        public int TilesNumber;
        public ShipClass ShipClass { get; }
        public bool IsSunk => TilesNumber == 0;

        public Ship(int tilesNumber, ShipClass shipClass)
        {
            TilesNumber = tilesNumber;
            ShipClass = shipClass;
        }

        public void Hit()
        {
            TilesNumber--;
        }
    }
}
