using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

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
            Debug.Print(game.CurrentPlayerName);
            game.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 3 }, new Point { Row = 1, Column = 1 });
            game.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 1 }, new Point { Row = 2, Column = 1 });

            game.NextPlayer();
            Debug.Print(game.CurrentPlayerName);
            game.AddShip(new Ship { Orientation = Orientation.Vertical, Length = 2 }, new Point { Row = 1, Column = 2 });

            game.NextPlayer();
            Debug.Print(game.CurrentPlayerName);
            Debug.Print(game.Attack(new Point { Row = 1, Column = 2 }));
            Assert.IsFalse(game.HasWon);

            game.NextPlayer();
            Debug.Print(game.CurrentPlayerName);
            Debug.Print(game.Attack(new Point { Row = 1, Column = 1 }));
            Assert.IsFalse(game.HasWon);

            game.NextPlayer();
            Debug.Print(game.CurrentPlayerName);
            Debug.Print(game.Attack(new Point { Row = 2, Column = 2 }));
            Assert.IsTrue(game.HasWon);
        }
    }
}
