namespace BoardGamesApp;

public class GameLogic : IGame
{
    protected GameBoard board;
    protected IPlayer currentPlayer;
    protected readonly IPlayer player1;
    protected readonly IPlayer player2;
    protected IGameEvaluator evaluator;
    protected int targetCount;

    public GameLogic(IPlayer player1, IPlayer player2, int rows, int columns, int targetCount, Func<GameBoard, IGameEvaluator> createEvaluator)
    {
        board = new GameBoard(rows, columns);
        this.player1 = player1;
        this.player2 = player2;
        currentPlayer = player1;
        this.targetCount = targetCount;
        evaluator = createEvaluator(board);
    }

    public void Play()
    {
        do
        {
            board.Display();
            currentPlayer.MakeMove(board);
            UpdateGameState();
        } while (!IsGameOver());
    }

    public void UpdateGameState()
    {
        var gameState = GameStateHandler.GameState;
        gameState.BoardState = GetBoard().board.Cast<char>().ToList();
        gameState.Rows = GetBoard().Rows;
        gameState.Columns = GetBoard().Columns;
        gameState.TargetCount = targetCount;
        gameState.CurrentPlayer = GetNextPlayer().GetType().Name;
        gameState.CurrentPlayerSymbol = (char)GetNextPlayer().Symbol;
        gameState.Player1Type = player1.GetType().Name;
        gameState.Player2Type = player2.GetType().Name;
        gameState.Player1Symbol = player1.Symbol.ToString();
        gameState.Player2Symbol = player2.Symbol.ToString();
        gameState.EvaluatorType = evaluator.GetType().Name;
        GameStateHandler.SaveGame();
    }

    public bool IsGameOver()
    {
        if (evaluator.CheckForVictory(currentPlayer.Symbol))
        {
            EndGame($"The player {(currentPlayer.Symbol == PlayerSymbol.X ? 1 : 2)} won!");
            return true;
        }

        if (evaluator.CheckForDraw())
        {
            EndGame("Arrh, this game is a draw!");
            return true;
        }

        UpdateCurrentPlayer();
        return false;
    }

    public void EndGame(string message)
    {
        ConsoleHandler.Clear();
        board.Display();
        ConsoleHandler.WriteLine(message);
    }

    public void Restart()
    {
        board.Clear();
        currentPlayer = player1;
        Play();
    }

    private void UpdateCurrentPlayer() => currentPlayer = GetNextPlayer();

    private IPlayer GetNextPlayer() => currentPlayer == player1 ? player2 : player1;

    public GameBoard GetBoard() => board;

    public PlayerSymbol GetCurrentPlayerSymbol() => currentPlayer.Symbol;

    public void SetCurrentPlayer(IPlayer player) => currentPlayer = player;
}
