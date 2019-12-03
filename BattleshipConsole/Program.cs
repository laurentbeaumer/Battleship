namespace BattleshipConsole
{
    using Battleship;

    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            var game = new Game();

            do
            {

            }
            while (!quit && game.NextPlayer());
        }
    }
}
