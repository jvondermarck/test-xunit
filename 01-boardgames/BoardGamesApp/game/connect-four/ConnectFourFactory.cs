namespace BoardGamesApp;

public class ConnectFourFactory : IGameFactory
{
    public Game CreateGame()
    {
        IPlayer player1 = CreatePlayer(1);
        IPlayer player2 = CreatePlayer(2);
        int targetCount = 4;

        GameLogic gameLogic = new GameLogicBuilder()
            .SetPlayer1(player1)
            .SetPlayer2(player2)
            .SetRows(4)
            .SetColumns(7)
            .SetEvaluator(board => new LinearEvaluator(board, targetCount)) // Pass a factory method to create IGameEvaluator
            .SetTargetCount(targetCount)
            .Build();

        IGame connectFourGame = new ConnectFour(gameLogic);

        return new Game(connectFourGame);
    }

    private IPlayer CreatePlayer(int playerNumber)
    {
        char playerChoice = ConsoleHandler.GetPlayerChoice($"Player {playerNumber}: Choose 'H' for Human, 'C' for Computer.", new char[] { 'H', 'C' });
        return (playerChoice == 'H') ? new ConnectFourHumanPlayer(GetPlayerSymbol(playerNumber)) : new ConnectFourComputerPlayer(GetPlayerSymbol(playerNumber));
    }

    private PlayerSymbol GetPlayerSymbol(int playerNumber)
    {
        return (playerNumber == 1) ? PlayerSymbol.X : PlayerSymbol.O;
    }
}
