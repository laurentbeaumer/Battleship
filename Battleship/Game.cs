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
        public Player Player1 = new Player();

        public Player Player2 = new Player();

        private bool turn = true; // True = Player 1, False = Player 2 
    }
}
