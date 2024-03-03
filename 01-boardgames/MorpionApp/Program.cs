namespace BoardGamesApp;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose a game: Type 'M' for Morpion, 'P' for Puissance 4.");
        char choice = char.ToUpper(Console.ReadKey(true).KeyChar);

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
                Console.WriteLine("Invalid choice. Exiting...");
                return;
        }

        Console.WriteLine("Starting game...");
        game = gameFactory.CreateGame();
        game.Play();

        Console.WriteLine("Play another game? Type 'R' to restart, 'Q' to quit.");
        char restartChoice = char.ToUpper(Console.ReadKey(true).KeyChar);

        if (restartChoice == 'R')
            game.Restart();
    }
}