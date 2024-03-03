namespace BoardGamesApp;

public class TicTacToeFactory : IGameFactory
{
    public Game CreateGame()
    {
        IPlayer player1 = CreatePlayer(1);
        IPlayer player2 = CreatePlayer(2);

        IGame ticTacToeGame = new TicTacToe(player1, player2);
        return new Game(ticTacToeGame, ticTacToeGame.GetEvaluator());
    }

    private IPlayer CreatePlayer(int playerNumber)
    {
        Console.WriteLine($"Player {playerNumber}: Choose 'H' for Human, 'C' for Computer.");
        char playerChoice = char.ToUpper(Console.ReadKey(true).KeyChar);
        return (playerChoice == 'H') ? new TicTacToeHumanPlayer(GetPlayerSymbol(playerNumber)) : new TicTacToeComputerPlayer(GetPlayerSymbol(playerNumber));
    }

    private PlayerSymbol GetPlayerSymbol(int playerNumber)
    {
        return (playerNumber == 1) ? PlayerSymbol.X : PlayerSymbol.O;
    }
}