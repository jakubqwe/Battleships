using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Core
{
    public class Tile
    {
        public bool IsHit { get; set; }
        public Tile()
        {
            IsHit = false;
        }
    }
}
