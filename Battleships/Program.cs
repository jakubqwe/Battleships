using System;
using Battleships.Core;

namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine(new ConsoleInputProvider(), new RandomGridBuilder(new Random(), 10));
            engine.Run();
        }
    }
}