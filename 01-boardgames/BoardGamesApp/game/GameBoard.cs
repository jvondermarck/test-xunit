namespace BoardGamesApp;

public class GameBoard
{
    private char[,] board;
    private readonly int rows;
    private readonly int columns;
    public const char EMPTY_CELL = ' ';

    public GameBoard(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        board = new char[rows, columns];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                board[i, j] = EMPTY_CELL;
            }
        }
    }

    public char GetCell(int row, int column) => board[row, column];

    public void SetCell(int row, int column, PlayerSymbol symbol) => board[row, column] =  (char)symbol;

    public bool IsCellEmpty(int row, int column) => board[row, column] == EMPTY_CELL;

    public void Display()
    {
        ConsoleHandler.WriteLine("");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                ConsoleHandler.Write($" {board[i, j]} ");
                if (j < columns - 1) ConsoleHandler.Write("|");
            }
            ConsoleHandler.WriteLine("");
            if (i < rows - 1) Console.WriteLine(new string('-', columns * 4 - 1));
        }
        ConsoleHandler.WriteLine("");
    }

    public bool IsFull()
    {
        foreach (var cell in board)
            if (cell == EMPTY_CELL) return false; 
        
        return true;
    }

    public int GetRows() {
        return rows;
    }

    public int GetColumns() {
        return columns;
    }

    public void Clear()
    {
        InitializeBoard();
    }
}
