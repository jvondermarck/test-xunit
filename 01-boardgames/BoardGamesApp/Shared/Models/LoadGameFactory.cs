namespace BoardGamesApp;

public class LoadGameFactory
{
    public IGame CreateGame()
    {
        GameState state = GameStateHandler.GameState;

        // Create the board
        GameBoard board = new GameBoard(state.Rows, state.Columns);
        for (int i = 0; i < state.Rows; i++)
        {
            for (int j = 0; j < state.Columns; j++)
            {
                board.board[i, j] = state.BoardState[i * state.Columns + j];
            }
        }

        // Create the players
        IPlayer player1 = CreatePlayer(state.Player1Type, GetPlayerSymbol(state.Player1Symbol));
        IPlayer player2 = CreatePlayer(state.Player2Type, GetPlayerSymbol(state.Player2Symbol));

        // Create the evaluator
        Func<GameBoard, IGameEvaluator> evaluator = CreateEvaluator(state.EvaluatorType, board, state.TargetCount);

        // Create the game logic
        GameLogic game = new GameLogic(player1, player2, state.Rows, state.Columns, state.TargetCount, evaluator);
        game.GetBoard().board = board.board;
        game.SetCurrentPlayer(state.CurrentPlayer == player1.Symbol.ToString() ? player1 : player2);

        return game;
    }

    public IPlayer CreatePlayer(string playerType, PlayerSymbol symbol)
    {
        switch(playerType)
        {
            case "TicTacToeHumanPlayer":
                return new TicTacToeHumanPlayer(symbol);
            case "TicTacToeComputerPlayer":
                return new TicTacToeComputerPlayer(symbol);
            case "ConnectFourHumanPlayer":
                return new ConnectFourHumanPlayer(symbol);
            case "ConnectFourComputerPlayer":
                return new ConnectFourComputerPlayer(symbol);
            default:
                throw new InvalidOperationException("Invalid player type");
        }
    }

    public Func<GameBoard, IGameEvaluator> CreateEvaluator(string gameType, GameBoard board, int targetCount)
    {
        switch(gameType)
        {
            case "LinearEvaluator":
                return b => new LinearEvaluator(b, targetCount);
            default:
                throw new InvalidOperationException("Invalid game type");
        }
    }

    private PlayerSymbol GetPlayerSymbol(string symbol)
    {
        return symbol == "X" ? PlayerSymbol.X : PlayerSymbol.O;
    }
}
