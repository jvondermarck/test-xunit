namespace BoardGamesApp;

public class TicTacToeFactory : IGameFactory
{
    public Game CreateGame()
    {
        IPlayer player1 = CreatePlayer(1);
        IPlayer player2 = CreatePlayer(2);

        GameLogic gameLogic = new GameLogicBuilder()
            .SetPlayer1(player1)
            .SetPlayer2(player2)
            .SetRows(3)
            .SetColumns(3)
            .SetTargetCount(3)
            .Build();

        IGame ticTacToeGame = new TicTacToe(gameLogic);

        return new Game(ticTacToeGame, gameLogic.GetEvaluator());
    }

    private IPlayer CreatePlayer(int playerNumber)
    {
        Console.WriteLine($"Player {playerNumber}: Choose 'H' for Human, 'C' for Computer.");
        char playerChoice = char.ToUpper(Console.ReadKey(true).KeyChar);

        while (playerChoice != 'H' && playerChoice != 'C')
        {
            Console.WriteLine("Invalid choice. Please choose 'H' for Human, 'C' for Computer.");
            playerChoice = char.ToUpper(Console.ReadKey(true).KeyChar);
        }

        return (playerChoice == 'H') ? new TicTacToeHumanPlayer(GetPlayerSymbol(playerNumber)) : new TicTacToeComputerPlayer(GetPlayerSymbol(playerNumber));
    }

    private PlayerSymbol GetPlayerSymbol(int playerNumber)
    {
        return (playerNumber == 1) ? PlayerSymbol.X : PlayerSymbol.O;
    }
}