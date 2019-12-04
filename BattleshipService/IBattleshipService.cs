namespace BattleshipService
{
    using Battleship;

    public interface IBattleshipService
    {
        void NewGame();

        bool NextPlayer();

        string CurrentPlayerName { get; }

        bool HasWon { get; }

        void AddShip(Ship ship, Point point);

        string Attack(Point point);
    }
}
