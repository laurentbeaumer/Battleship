namespace BattleshipService
{
    using System;
    using Battleship;

    public class BattleshipService : IBattleshipService
    {
        private Game game = new Game();

        public string CurrentPlayerName => game.CurrentPlayerName;

        public bool HasWon => game.HasWon;

        public void AddShip(Player player, Ship ship, Point point) => player.AddShip(ship, point);

        public bool Attack(Player player, Point point) => player.Attack(point);
        
        public void AddShip(Ship ship, Point point) => game.AddShip(ship, point);

        public bool Attack(Point point) => game.Attack(point);

        public bool NextPlayer() => game.NextPlayer();

        // Reset Game
        public void NewGame()
        {
            game = new Game();
        }
    }
}
