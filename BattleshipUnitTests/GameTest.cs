using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace BattleshipUnitTests
{
    using Battleship;

    [TestClass]
    public class GameTest
    {
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestPointHasBeenAlreadyHit()
        {
            var game = new Game();
            Debug.Print(game.Attack(new Point { Row = 1, Column = 1 }));
            Debug.Print(game.Attack(new Point { Row = 1, Column = 1 }));
        }


        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestPointOutOfRange()
        {
            var game = new Game();
            Debug.Print(game.Attack(new Point { Row = 11, Column = 10 }));
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestShipAlreadyThere()
        {
            var game = new Game();
            Debug.Print(game.CurrentPlayerName);
            game.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 3 }, new Point { Row = 1, Column = 1 });
            game.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 1 }, new Point { Row = 1, Column = 3 });
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestShipDoesntFit()
        {
            var game = new Game();
            Debug.Print(game.CurrentPlayerName);
            game.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 2 }, new Point { Row = 10, Column = 10 });
        }

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

            if (game.HasWon) Debug.Print(string.Format("{0} has won", game.CurrentPlayerName));
        }
    }
}
