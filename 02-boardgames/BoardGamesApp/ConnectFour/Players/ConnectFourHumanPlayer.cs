namespace BoardGamesApp;

public class ConnectFourHumanPlayer : IPlayer
{
    public PlayerSymbol Symbol { get; set; }
    private const int COLUMN_FULL = -1;
    private const int MIN_COLUMN = 1;
    private const int MAX_COLUMN = 7;

    public ConnectFourHumanPlayer(PlayerSymbol symbol)
    {
        Symbol = symbol;
    }

    public void MakeMove(GameBoard board)
    {
        do
        {
            ConsoleHandler.DisplayPlayerTurn(Symbol, MAX_COLUMN);

            int column = ConsoleHandler.ReadIntInRange(MIN_COLUMN, MAX_COLUMN);

            int row = FindEmptyRow(column - 1, board);

            if (row != COLUMN_FULL)
            {
                board.SetCell(row, column - 1, Symbol);
                return;
            }
            else
            {
                ConsoleHandler.WriteLine("The column is full. Please try again.");
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
