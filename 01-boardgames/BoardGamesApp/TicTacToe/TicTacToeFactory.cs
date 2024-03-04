namespace BoardGamesApp;

public class TicTacToeFactory : IGameFactory
{
    public Game CreateGame()
    {
        IPlayer player1 = CreatePlayer(1);
        IPlayer player2 = CreatePlayer(2);
        int targetCount = 3;

        GameLogic gameLogic = new GameLogicBuilder()
            .SetPlayer1(player1)
            .SetPlayer2(player2)
            .SetEvaluator(board => new LinearEvaluator(board, targetCount)) // Pass a factory method to create IGameEvaluator
            .SetRows(3)
            .SetColumns(3)
            .SetTargetCount(targetCount)
            .Build();

        IGame ticTacToeGame = new TicTacToe(gameLogic);

        return new Game(ticTacToeGame);
    }

    private IPlayer CreatePlayer(int playerNumber)
    {
        char playerChoice = ConsoleHandler.GetPlayerChoice($"Player {playerNumber}: Choose 'H' for Human, 'C' for Computer.", new char[] { 'H', 'C' });
        return (playerChoice == 'H') ? new TicTacToeHumanPlayer(GetPlayerSymbol(playerNumber)) : new TicTacToeComputerPlayer(GetPlayerSymbol(playerNumber));
    }

    private PlayerSymbol GetPlayerSymbol(int playerNumber)
    {
        return (playerNumber == 1) ? PlayerSymbol.X : PlayerSymbol.O;
    }
}