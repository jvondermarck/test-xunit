namespace BoardGamesApp;

public class Program
{
    static void Main(string[] args)
    {
        char restartChoice;
        do
        {
            ConsoleHandler.WriteLine("Choose a game: Type 'M' for Morpion, 'P' for Puissance 4.");
            char choice = ConsoleHandler.ReadKey();

            Game game;
            IGameFactory gameFactory;

            switch (choice)
            {
                case 'M':
                    gameFactory = new TicTacToeFactory();
                    break;
                case 'P':
                    gameFactory = new ConnectFourFactory();
                    break;
                default:
                    ConsoleHandler.WriteLine("Invalid choice. Exiting...");
                    return;
            }

            ConsoleHandler.WriteLine("Starting game...");
            game = gameFactory.CreateGame();
            game.Play();

            ConsoleHandler.WriteLine("Play another game? Type 'R' to restart, 'Q' to quit.");
            restartChoice = ConsoleHandler.ReadKey();

        } while (restartChoice == 'R');
    }
}