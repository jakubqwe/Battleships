using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Core
{
    public class BattleshipGameManager
    {
        public Tile[,] Grid { get; }
        public int ShipsNumber { get; private set; } 
        public int ShotsNumber { get; private set; }

        public BattleshipGameManager(IGridBuilder gridBuilder, ICollection<ShipClass> ships)
        {
            ShipsNumber = ships.Count;

            gridBuilder.AddShips(ships);
            Grid = gridBuilder.GetGrid();
        }

        public ShotFeedback ShootTile(Coords coords)
        {
            var tile = Grid[coords.Row, coords.Column];
            if (tile.IsHit)
            {
                throw new InvalidOperationException("The tile was already hit");
            }

            tile.IsHit = true;
            ShotsNumber++;
            if (tile is ShipTile shipTile)
            {
                shipTile.Ship.Hit();
                if (shipTile.Ship.IsSunk)
                {
                    ShipsNumber--;
                }

                return new ShotFeedback(shipTile.Ship.IsSunk, shipTile.Ship.ShipClass);
            }

            return new ShotFeedback();
        }
        
    }
}
