namespace Battleship
{
    public interface IGameService
    {
        void Create();

        void AddShip(Player player, Ship ship, Point point);

        bool Attack(Player player, Point point);
    }
}
