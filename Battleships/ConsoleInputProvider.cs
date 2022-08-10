using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Core;

namespace Battleships
{
    internal class ConsoleInputProvider : IInputProvider
    {
        public Coords GetCoordinates()
        {
            Console.WriteLine(@"Provide shot coordinates (ex. A5): ");
            return InputParser.ParseCoords(Console.ReadLine());
        }
    }

    internal interface IInputProvider
    {
        Coords GetCoordinates();
    }
}
