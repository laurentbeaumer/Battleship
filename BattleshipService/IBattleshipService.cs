namespace BattleshipService
{
    using Battleship;

    public interface IBattleshipService
    {
        void NewGame();

        void AddShip(Player player, Ship ship, Point point);

        bool Attack(Player player, Point point);
    }
}
