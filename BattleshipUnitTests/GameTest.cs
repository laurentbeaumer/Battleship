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
            Debug.Print(game.CurrentPlayer);

            game.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 2 }, new Point { Row = 2, Column = 4 });
            game.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 3 }, new Point { Row = 4, Column = 5 });
            game.AddShip(new Ship { Orientation = Orientation.Vertical, Length = 3 }, new Point { Row = 5, Column = 2 });
            game.AddShip(new Ship { Orientation = Orientation.Vertical, Length = 4 }, new Point { Row = 6, Column = 9 });

            game.NextPlayer();
            Debug.Print(game.CurrentPlayer);

            game.AddShip(new Ship { Orientation = Orientation.Vertical, Length = 2 }, new Point { Row = 5, Column = 2 });
            game.AddShip(new Ship { Orientation = Orientation.Vertical, Length = 4 }, new Point { Row = 6, Column = 3 });
            game.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 3 }, new Point { Row = 1, Column = 4 });
            game.AddShip(new Ship { Orientation = Orientation.Horizontal, Length = 3 }, new Point { Row = 2, Column = 8 });

            game.NextPlayer();
            Debug.Print(game.CurrentPlayer);
            game.Attack(new Point { Row = 2, Column = 4 });

            game.NextPlayer();
            Debug.Print(game.CurrentPlayer);
            game.Attack(new Point { Row = 1, Column = 5 });

            game.NextPlayer();
            Debug.Print(game.CurrentPlayer);
            game.Attack(new Point { Row = 4, Column = 8 });

            game.NextPlayer();
            Debug.Print(game.CurrentPlayer);
            game.Attack(new Point { Row = 7, Column = 2 });
        }
    }
}
