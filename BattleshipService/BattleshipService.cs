namespace BattleshipService
{
    using Battleship;

    public class BattleshipService : IBattleshipService
    {
        Game battleship = new Game();

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
            battleship = new Game();
        }
    }
}
