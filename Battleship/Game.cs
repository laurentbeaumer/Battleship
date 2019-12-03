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
        private Player[] players = new Player[] { new Player(), new Player() };

        private bool firstPlayer = true; // True = Player 1, False = Player 2 

        private Player GetCurrentPlayer() => players[firstPlayer ? 1 : 0];

        private Player GetOtherPlayer() => players[firstPlayer ? 0 : 1];

        public string CurrentPlayer => string.Format("Player {0}", firstPlayer ? 1 : 2);

        public void AddShip(Ship ship, Point point) => GetCurrentPlayer().AddShip(ship, point);

        public void Attack(Point point) => GetOtherPlayer().Attack(point);

        public bool NextPlayer()
        {
            if (GetOtherPlayer().HasLost) return false;
            firstPlayer = !firstPlayer;
            return true;
        }
    }
}
