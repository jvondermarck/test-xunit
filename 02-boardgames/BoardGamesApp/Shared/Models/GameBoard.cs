namespace BoardGamesApp;

public class GameBoard
{
    private const char EmptyCell = ' ';
    private char[,] board;

    public int Rows { get; }
    public int Columns { get; }

    public GameBoard(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        board = new char[Rows, Columns];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                board[i, j] = EmptyCell;
            }
        }
    }

    public char GetCell(int row, int column) => board[row, column];

    public void SetCell(int row, int column, PlayerSymbol symbol)
    {
        if (!IsCellEmpty(row, column))
        {
            throw new InvalidOperationException("Cell is already occupied");
        }
        board[row, column] = (char)symbol;
    }

    public bool IsCellEmpty(int row, int column) => board[row, column] == EmptyCell;

    public void Display()
    {
        ConsoleHandler.WriteLine("");
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                SetConsoleColor(board[i, j]);
                ConsoleHandler.Write($" {board[i, j]} ");
                Console.ResetColor();
                if (j < Columns - 1) ConsoleHandler.Write("|");
            }
            ConsoleHandler.WriteLine("");
            if (i < Rows - 1) ConsoleHandler.WriteLine(new string('-', Columns * 4 - 1));
        }
        ConsoleHandler.WriteLine("");
    }

    private void SetConsoleColor(char cell)
    {
        if (cell == (char)PlayerSymbol.X)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (cell == (char)PlayerSymbol.O)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }

    public bool IsFull() => board.Cast<char>().All(cell => cell != EmptyCell);

    public void Clear() => InitializeBoard();

    public char[,] SetBoard(char[,] newBoard) => board = newBoard;
    public char[,] GetBoard() => board;
}
