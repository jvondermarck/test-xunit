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
        int row;
        int column;
        do
        {
            row = random.Next(0, board.GetRows());
            column = random.Next(0, board.GetColumns());
        } while (board.GetCell(row, column) != ' ');

        board.SetCell(row, column, Symbol);
    }
}
