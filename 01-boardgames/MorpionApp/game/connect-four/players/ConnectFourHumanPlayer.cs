namespace BoardGamesApp;

public class ConnectFourHumanPlayer : IPlayer
{
    public PlayerSymbol Symbol { get; set; }

    public ConnectFourHumanPlayer(PlayerSymbol symbol)
    {
        Symbol = symbol;
    }

    public void MakeMove(GameBoard board)
    {
        do
        {
            Console.WriteLine($"Joueur {(Symbol == PlayerSymbol.X ? 1 : 2)}, c'est à vous (symbole {Symbol}):");

            if (int.TryParse(Console.ReadLine(), out int column) && column >= 1 && column <= 7)
            {
                int row = FindEmptyRow(column - 1, board);

                if (row != -1)
                {
                    board.SetCell(row, column - 1, Symbol);
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

    private int FindEmptyRow(int column, GameBoard board)
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
}
