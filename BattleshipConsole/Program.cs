namespace BattleshipConsole
{
    using BattleshipService;

    class Program
    {
        static void Main(string[] args)
        {

            bool quit = false;
            var service = new BattleshipService();

            // Loop "Player 1" to add ship

            // Loop "Player 2" to add ship

            // Start the attacks with "Player 1"
            do
            {

            }
            while (!quit && service.NextPlayer()); 
            // Either players decide to quit, or one of other player has lost during the turn

            // Display result to players
        }
    }
}
