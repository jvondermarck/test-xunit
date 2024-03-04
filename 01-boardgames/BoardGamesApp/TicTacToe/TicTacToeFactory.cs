namespace BoardGamesApp;

public class TicTacToeFactory : IGameFactory
{
    private readonly PlayerFactory playerFactory;

    public TicTacToeFactory(PlayerFactory playerFactory)
    {
        this.playerFactory = playerFactory;
    }

    public Game CreateGame()
    {
        IPlayer player1 = playerFactory.CreatePlayer(1, symbol => new TicTacToeHumanPlayer(symbol), symbol => new TicTacToeComputerPlayer(symbol));
        IPlayer player2 = playerFactory.CreatePlayer(2, symbol => new TicTacToeHumanPlayer(symbol), symbol => new TicTacToeComputerPlayer(symbol));
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
}