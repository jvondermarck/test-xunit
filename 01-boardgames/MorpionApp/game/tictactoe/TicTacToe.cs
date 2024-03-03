using System.Dynamic;

namespace BoardGamesApp;

public class Morpion : IGame
{
    private readonly GameBoard board;
    private readonly IGameEvaluator evaluator;
    private PlayerSymbol currentPlayer = PlayerSymbol.X;

    public Morpion()
    {
        board = new GameBoard(3, 3);
        evaluator = new LinearEvaluator(board, 3);
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

            if (int.TryParse(Console.ReadLine(), out int position) && position >= 1 && position <= 9)
            {
                int row = (position - 1) / 3;
                int col = (position - 1) % 3;

                if (board.GetCell(row, col) == ' ')
                {
                    board.SetCell(row, col, currentPlayer);
                    return;
                }
                else
                {
                    Console.WriteLine("La case est déjà occupée. Veuillez réessayer.");
                }
            }
            else
            {
                Console.WriteLine("Saisie invalide. Veuillez entrer un nombre entre 1 et 9.");
            }
        } while (true);
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
        Play();
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
