using System;

namespace BattleshipService
{
    using Battleship;

    public class BattleshipService : IBattleshipService
    {
        private Game game = new Game();

        public string CurrentPlayerName => game.CurrentPlayerName;

        public bool HasWon => game.HasWon;

        public void AddShip(Ship ship, Point point) => game.AddShip(ship, point);

        public string Attack(Point point) => game.Attack(point);

        public bool NextPlayer() => game.NextPlayer();

        // Reset Game
        public void NewGame()
        {
            game = new Game();
        }
    }
}
