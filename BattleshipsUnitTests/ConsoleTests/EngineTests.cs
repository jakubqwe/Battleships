using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships;
using BattleshipsUnitTests.CoreTests;

namespace BattleshipsUnitTests.ConsoleTests
{
    public class EngineTests
    {
        [Fact]
        public void RunTest()
        {
            var engine = new Engine(new DummyInputProvider(), new DummyGridBuilder());
            engine.Run();
        }
    }
}
