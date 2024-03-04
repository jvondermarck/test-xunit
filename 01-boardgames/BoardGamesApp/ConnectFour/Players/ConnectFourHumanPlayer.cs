namespace BoardGamesApp;

public class ConnectFourHumanPlayer : IPlayer
{
    public PlayerSymbol Symbol { get; set; }
    private const int COLUMN_FULL = -1;

    public ConnectFourHumanPlayer(PlayerSymbol symbol)
    {
        Symbol = symbol;
    }

    public void MakeMove(GameBoard board)
    {
        do
        {
            ConsoleHandler.WriteLine($"Joueur {(Symbol == PlayerSymbol.X ? 1 : 2)}, c'est à vous (symbole {Symbol}):");

            int column = ConsoleHandler.ReadIntInRange(1, 7);

            int row = FindEmptyRow(column - 1, board);

            if (row != COLUMN_FULL)
            {
                board.SetCell(row, column - 1, Symbol);
                return;
            }
            else
            {
                ConsoleHandler.WriteLine("La colonne est pleine. Veuillez réessayer.");
            }
        } while (true);
    }

    private int FindEmptyRow(int column, GameBoard board)
    {
        for (int row = board.Rows - 1; row >= 0; row--)
        {
            if (board.IsCellEmpty(row, column))
            {
                return row;
            }
        }
        return COLUMN_FULL;
    }
}
