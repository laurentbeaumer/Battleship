using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipUnitTests
{
    using Battleship;

    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestScenario()
        {
            var game = new Game();
            game.Player1.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 2 }, new Point { Row = 2, Column = 4 });
            game.Player1.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 3 }, new Point { Row = 4, Column = 5 });
            game.Player1.AddShip(new Ship { Orientation = Orientation.Vertical, Length = 3 }, new Point { Row = 5, Column = 2 });
            game.Player1.AddShip(new Ship { Orientation = Orientation.Vertical, Length = 4 }, new Point { Row = 6, Column = 9 });
        }
    }
}
