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
            column = random.Next(0, board.GetColumns());
        } while (board.GetCell(0, column) != ' ');

        for (int row = board.GetRows() - 1; row >= 0; row--)
        {
            if (board.GetCell(row, column) == ' ')
            {
                board.SetCell(row, column, Symbol);
                break;
            }
        }
    }
}
