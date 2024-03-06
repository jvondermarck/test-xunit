namespace BoardGamesApp;

public class Program
{
    static void Main()
    {
        char restartChoice;
        do
        {
            ConsoleHandler.WriteLine("Choose a game: Type 'M' for Morpion, 'P' for Puissance 4, 'L' to Load a saved game.");
            char choice = ConsoleHandler.ReadKey();

            IGame game;
            PlayerFactory playerFactory = new PlayerFactory();

            switch (choice)
            {
                case 'M':
                    IGameFactory gameFactoryM = new TicTacToeFactory(playerFactory);
                    game = gameFactoryM.CreateGame();
                    break;
                case 'P':
                    IGameFactory gameFactoryP = new ConnectFourFactory(playerFactory);
                    game = gameFactoryP.CreateGame();
                    break;
                // case 'L':
                //     game = GameStateHandler.LoadGame();
                //     break;
                default:
                    ConsoleHandler.WriteLine("Invalid choice. Exiting...");
                    return;
            }

            ConsoleHandler.WriteLine("Starting game...");
            game.Play();

            ConsoleHandler.WriteLine("Play another game? Type 'R' to restart, 'Q' to quit.");
            restartChoice = ConsoleHandler.ReadKey();

        } while (restartChoice == 'R');
    }
}