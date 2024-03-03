namespace BoardGamesApp;

public class ConnectFour : IGame
{
    private readonly GameBoard board;
    private PlayerSymbol currentPlayer = PlayerSymbol.X;
    private readonly IGameEvaluator evaluator;

    public ConnectFour()
    {
        board = new GameBoard(4, 7);
        evaluator = new LinearEvaluator(board, 4);
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
            HandlePlayerTurn();
        } while (!IsGameOver());
    }

    private void HandlePlayerTurn()
    {
        do
        {
            Console.WriteLine($"Joueur {(currentPlayer == PlayerSymbol.X ? 1 : 2)}, c'est à vous (symbole {currentPlayer}):");

            if (int.TryParse(Console.ReadLine(), out int column) && column >= 1 && column <= 7)
            {
                int row = FindEmptyRow(column - 1);

                if (row != -1)
                {
                    board.SetCell(row, column - 1, currentPlayer);
                    return;
                }
                else
                {
                    Console.WriteLine("La colonne est pleine. Veuillez réessayer.");
                }
            }
            else
            {
                Console.WriteLine("Saisie invalide. Veuillez entrer un nombre entre 1 et 7.");
            }
        } while (true);
    }

    private int FindEmptyRow(int column)
    {
        for (int row = board.GetRows() - 1; row >= 0; row--)
        {
            if (board.GetCell(row, column) == ' ')
            {
                return row;
            }
        }
        return -1; // Column is full
    }

    public bool IsGameOver()
    {
        if (evaluator.CheckForVictory(currentPlayer))
        {
            EndGame($"Le joueur {(currentPlayer == PlayerSymbol.X ? 1 : 2)} a gagné !");
            return true;
        }

        if (board.IsFull())
        {
            EndGame("Aucun vainqueur, la partie se termine sur une égalité.");
            return true;
        }

        currentPlayer = currentPlayer == PlayerSymbol.X ? PlayerSymbol.O : PlayerSymbol.X;
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
        currentPlayer = PlayerSymbol.X;
    }

    public GameBoard GetBoard()
    {
        return board;
    }

    public PlayerSymbol GetCurrentPlayerSymbol()
    {
        return currentPlayer;
    }
}
