namespace BattleshipService
{
    using Battleship;

    public interface IBattleshipService
    {
        void NewGame();

        void NextPlayer();

        string CurrentPlayerName { get; }

        void AddShip(Ship ship, Point point);

        bool Attack(Point point);
    }
}
