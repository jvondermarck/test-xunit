namespace BoardGamesApp;

public class TicTacToeHumanPlayer : IPlayer
{
    public PlayerSymbol Symbol { get; }

    public TicTacToeHumanPlayer(PlayerSymbol symbol)
    {
        Symbol = symbol;
    }

    public void MakeMove(GameBoard board)
    {
        do
        {
            Console.WriteLine($"Joueur {(Symbol == PlayerSymbol.X ? 1 : 2)}, c'est à vous (symbole {Symbol}):");

            if (int.TryParse(Console.ReadLine(), out int position) && position >= 1 && position <= 9)
            {
                int row = (position - 1) / 3;
                int col = (position - 1) % 3;

                if (board.GetCell(row, col) == ' ')
                {
                    board.SetCell(row, col, Symbol);
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
}
