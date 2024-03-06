namespace BoardGamesApp;

public class Program
{
    static void Main()
    {
        char restartChoice = 'R';
        do
        {
            ConsoleHandler.Write("Type 'T' for TicTacToe, 'C' for ConnectFour, 'L' to Load a saved game: ");
            char choice = ConsoleHandler.ReadKey();

            IGame game;
            PlayerFactory playerFactory = new PlayerFactory();

            switch (choice)
            {
                case 'T':
                    IGameFactory gameFactoryM = new TicTacToeFactory(playerFactory);
                    game = gameFactoryM.CreateGame();
                    break;
                case 'C':
                    IGameFactory gameFactoryP = new ConnectFourFactory(playerFactory);
                    game = gameFactoryP.CreateGame();
                    break;
                case 'L':
                    try {
                        GameStateHandler.LoadGame();
                        LoadGameFactory gameFactoryL = new LoadGameFactory();
                        game = gameFactoryL.CreateGame();
                    } catch (Exception) {
                        goto default;
                    }
                    break;
                default:
                    ConsoleHandler.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            game.Play();

            ConsoleHandler.Write("Play another game? Type 'R' to restart, 'Q' to quit: ");
            restartChoice = ConsoleHandler.ReadKey();

        } while (restartChoice == 'R');
    }
}