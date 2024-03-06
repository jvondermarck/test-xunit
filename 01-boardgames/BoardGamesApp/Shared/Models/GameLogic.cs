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
        this.board = new GameBoard(rows, columns);
        this.player1 = player1;
        this.player2 = player2;
        this.currentPlayer = player1;
        this.targetCount = targetCount;
        this.evaluator = createEvaluator(board);
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
        GameStateHandler.GameState.BoardState = GetBoard().board.Cast<char>().ToList();
        GameStateHandler.GameState.Rows = GetBoard().Rows;
        GameStateHandler.GameState.Columns = GetBoard().Columns;
        GameStateHandler.GameState.TargetCount = targetCount;
        GameStateHandler.GameState.CurrentPlayer = GetNextPlayer().GetType().Name;
        GameStateHandler.GameState.CurrentPlayerSymbol = (char)GetNextPlayer().Symbol;
        GameStateHandler.GameState.Player1Type = player1.GetType().Name;
        GameStateHandler.GameState.Player2Type = player2.GetType().Name;
        GameStateHandler.GameState.Player1Symbol = player1.Symbol.ToString();
        GameStateHandler.GameState.Player2Symbol = player2.Symbol.ToString();
        GameStateHandler.GameState.EvaluatorType = evaluator.GetType().Name;
        GameStateHandler.SaveGame();
    }

    public bool IsGameOver()
    {
        bool IsGameOver = false;
        if (evaluator.CheckForVictory(currentPlayer.Symbol))
        {
            EndGame($"Le joueur {(currentPlayer.Symbol == PlayerSymbol.X ? 1 : 2)} a gagné !");
            IsGameOver = true;
        } else if (board.IsFull())
        {
            EndGame("Aucun vainqueur, la partie se termine sur une égalité.");
            IsGameOver = true;
        }

        UpdateCurrentPlayer();

        return IsGameOver;
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

    private IPlayer GetNextPlayer() =>  currentPlayer == player1 ? player2 : player1;

    public GameBoard GetBoard() => board;

    public PlayerSymbol GetCurrentPlayerSymbol() => currentPlayer.Symbol;

    public void SetCurrentPlayer(IPlayer player) => currentPlayer = player;
}