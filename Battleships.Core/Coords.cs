using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Core
{
    public struct Coords
    {
        public int Column;
        public int Row;

        public Coords(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}
