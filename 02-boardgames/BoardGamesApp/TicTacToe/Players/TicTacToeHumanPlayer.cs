namespace BoardGamesApp;

public class TicTacToeHumanPlayer : IPlayer
{
    public PlayerSymbol Symbol { get; }
    private const int MAX_POSITION = 9;
    private const int MIN_POSITION = 1;

    public TicTacToeHumanPlayer(PlayerSymbol symbol)
    {
        Symbol = symbol;
    }

    public void MakeMove(GameBoard board)
    {
        do
        {
            ConsoleHandler.DisplayPlayerTurn(Symbol, MAX_POSITION);

            int position = ConsoleHandler.ReadIntInRange(MIN_POSITION, MAX_POSITION);

            int row = (position - 1) / board.Columns;
            int col = (position - 1) % board.Columns;

            if (board.IsCellEmpty(row, col))
            {
                board.SetCell(row, col, Symbol);
                return;
            }
            else
            {
                ConsoleHandler.WriteLine("The position is already taken. Please try again.");
            }
        } while (true);
    }
}
