
namespace BoardGamesApp;

public class TicTacToe : IGame
{
    private readonly GameBoard board;
    private readonly IGameEvaluator evaluator;
    private IPlayer currentPlayer;
    private readonly IPlayer player1;
    private readonly IPlayer player2;

    public TicTacToe(IPlayer player1, IPlayer player2)
    {
        board = new GameBoard(3, 3);
        evaluator = new LinearEvaluator(board, 3);
        this.player1 = player1;
        this.player2 = player2;
        currentPlayer = player1;
    }

    public IGameEvaluator GetEvaluator()
    {
        return evaluator;
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

    private void EndGame(string message)
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

    public PlayerSymbol GetCurrentPlayerSymbol()
    {
        return currentPlayer.Symbol;
    }
}