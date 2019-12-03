namespace Battleship
{
    // There is only and always 2 players
    // Each player should have a board
    // Each board should have battleships
    // Each cell should be either empty or filled (with a battleship) => boolean
    // Each player chooses one cell at the time => stack
    // Report if the attack hits a battleship

    public class Game
    {
        #region Properties
        private const int defaultSize = 10;

        private Player[] players;

        private bool firstPlayer = true; // True = Player 1, False = Player 2 

        private Player GetCurrentPlayer => players[firstPlayer ? 1 : 0];

        private Player GetOtherPlayer => players[firstPlayer ? 0 : 1];

        public string CurrentPlayerName => string.Format("Player {0}", firstPlayer ? 1 : 2);
        #endregion

        #region Contructors
        public Game() : this(defaultSize) { }

        public Game(int size)
        {
            players = new Player[] { new Player(size), new Player(size) };
        }
        #endregion

        #region Methods
        public void AddShip(Ship ship, Point point) => GetCurrentPlayer.AddShip(ship, point);

        public bool Attack(Point point) => GetOtherPlayer.Attack(point);

        public bool NextPlayer()
        {
            if (GetOtherPlayer.HasLost) return false;
            firstPlayer = !firstPlayer;
            return true;
        }
        #endregion
    }
}
