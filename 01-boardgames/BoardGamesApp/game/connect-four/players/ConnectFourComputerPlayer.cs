namespace BoardGamesApp;

public class ConnectFourComputerPlayer : IPlayer
{
    public PlayerSymbol Symbol { get; }

    public ConnectFourComputerPlayer(PlayerSymbol symbol)
    {
        Symbol = symbol;
    }

    public void MakeMove(GameBoard board)
    {
        var random = new Random();
        int column;
        do
        {
            column = random.Next(0, board.Columns);
        } while (board.IsCellEmpty(0, column) == false);

        for (int row = board.Rows - 1; row >= 0; row--)
        {
            if (board.IsCellEmpty(row, column))
            {
                board.SetCell(row, column, Symbol);
                break;
            }
        }
    }
}
