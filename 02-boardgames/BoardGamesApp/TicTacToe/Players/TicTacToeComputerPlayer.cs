namespace BoardGamesApp;

public class TicTacToeComputerPlayer : IPlayer
{
    public PlayerSymbol Symbol { get; }

    public TicTacToeComputerPlayer(PlayerSymbol symbol)
    {
        Symbol = symbol;
    }

    public void MakeMove(GameBoard board)
    {
        var random = new Random();
        int row, column;
        do
        {
            row = random.Next(0, board.Rows);
            column = random.Next(0, board.Columns);
        } while (board.GetCell(row, column) != ' ');

        board.SetCell(row, column, Symbol);
    }
}
