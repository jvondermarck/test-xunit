namespace BoardGamesApp;

public class ConnectFourFactory : IGameFactory
{
    private readonly PlayerFactory playerFactory;

    public ConnectFourFactory(PlayerFactory playerFactory)
    {
        this.playerFactory = playerFactory;
    }

    public IGame CreateGame()
    {
        IPlayer player1 = playerFactory.CreatePlayer(1, symbol => new ConnectFourHumanPlayer(symbol), symbol => new ConnectFourComputerPlayer(symbol));
        IPlayer player2 = playerFactory.CreatePlayer(2, symbol => new ConnectFourHumanPlayer(symbol), symbol => new ConnectFourComputerPlayer(symbol));
        int targetCount = 4;

        GameLogic gameLogic = new GameLogicBuilder()
            .SetPlayer1(player1)
            .SetPlayer2(player2)
            .SetRows(6)
            .SetColumns(7)
            .SetEvaluator(board => new LinearEvaluator(board, targetCount)) // Pass a factory method to create IGameEvaluator
            .SetTargetCount(targetCount)
            .Build();

        IGame connectFourGame = new ConnectFour(gameLogic);

        return connectFourGame;
    }
}
