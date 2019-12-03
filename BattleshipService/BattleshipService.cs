namespace BattleshipService
{
    using System;
    using Battleship;

    public class BattleshipService : IBattleshipService
    {
        private Game game = new Game();

        public string CurrentPlayerName => game.CurrentPlayerName;

        public void AddShip(Player player, Ship ship, Point point)
        {
            player.AddShip(ship, point);
        }

        public bool Attack(Player player, Point point)
        {
            return player.Attack(point);
        }

        // Reset Game
        public void NewGame()
        {
            game = new Game();
        }

        public void AddShip(Ship ship, Point point) => game.AddShip(ship, point);

        public bool Attack(Point point) => game.Attack(point);

        void IBattleshipService.NewGame()
        {
            throw new NotImplementedException();
        }

        void IBattleshipService.NextPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
