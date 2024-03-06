namespace BoardGamesApp;

public class GameBoard
{
    public char[,] board;
    private const char EMPTY_CELL = ' ';
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
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                ConsoleHandler.Write($" {board[i, j]} ");
                if (j < Columns - 1) ConsoleHandler.Write("|");
            }
            ConsoleHandler.WriteLine("");
            if (i < Rows - 1) Console.WriteLine(new string('-', Columns * 4 - 1));
        }
        ConsoleHandler.WriteLine("");
    }
    public bool IsFull()
    {
        foreach (var cell in board)
            if (cell == EMPTY_CELL) return false; 
        
        return true;
    }

    public void Clear()
    {
        InitializeBoard();
    }

    public char[,] SetBoard(char[,] board)
    {
        return this.board = board;
    }
}
