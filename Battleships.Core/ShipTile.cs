using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Core
{
    public class ShipTile : Tile
    {
        public readonly Ship Ship;
        
        public ShipTile(Ship ship)
        {
            Ship = ship;
        }
    }
}