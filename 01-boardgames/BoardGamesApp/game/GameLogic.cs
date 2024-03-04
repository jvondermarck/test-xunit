namespace BoardGamesApp;

public class GameLogic
{
    protected readonly GameBoard board;
    protected IPlayer currentPlayer;
    protected readonly IPlayer player1;
    protected readonly IPlayer player2;
    protected readonly IGameEvaluator evaluator;

    public GameLogic(IPlayer player1, IPlayer player2, int rows, int columns, int targetCount)
    {
        board = new GameBoard(rows, columns);
        evaluator = new LinearEvaluator(board, targetCount);
        this.player1 = player1;
        this.player2 = player2;
        currentPlayer = player1;
    }

    public void Play()
    {
        do
        {
            board.Display();
            currentPlayer.MakeMove(board);
        } while (!IsGameOver());
    }

    public bool IsGameOver()
    {
        if (evaluator.CheckForVictory(currentPlayer.Symbol))
        {
            EndGame($"Le joueur {(currentPlayer.Symbol == PlayerSymbol.X ? 1 : 2)} a gagné !");
            return true;
        }

        if (board.IsFull())
        {
            EndGame("Aucun vainqueur, la partie se termine sur une égalité.");
            return true;
        }

        currentPlayer = currentPlayer.Symbol == PlayerSymbol.X ? player2 : player1;
        return false;
    }

    public void EndGame(string message)
    {
        Console.Clear();
        board.Display();
        Console.WriteLine(message);
    }

    public void Restart()
    {
        board.Clear();
        currentPlayer = player1;
        Play();
    }

    public GameBoard GetBoard()
    {
        return board;
    }

    public IGameEvaluator GetEvaluator()
    {
        return evaluator;
    }

    public PlayerSymbol GetCurrentPlayerSymbol()
    {
        return currentPlayer.Symbol;
    }
}