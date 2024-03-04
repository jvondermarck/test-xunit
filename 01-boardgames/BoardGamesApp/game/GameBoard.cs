namespace BoardGamesApp;

public class GameBoard
{
    private char[,] board;
    private readonly int rows;
    private readonly int columns;

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
                board[i, j] = ' ';
            }
        }
    }

    public char GetCell(int row, int column) => board[row, column];

    public void SetCell(int row, int column, PlayerSymbol symbol) => board[row, column] =  (char)symbol;

    public void Display()
    {
        Console.WriteLine();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($" {board[i, j]} ");
                if (j < columns - 1) Console.Write("|");
            }
            Console.WriteLine();
            if (i < rows - 1) Console.WriteLine(new string('-', columns * 4 - 1));
        }
        Console.WriteLine();
    }

    public bool IsFull()
    {
        foreach (var cell in board)
        {
            if (cell == ' ')
            {
                return false; // There's an empty space, the board is not full
            }
        }

        return true; // All cells are filled, the board is full
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
