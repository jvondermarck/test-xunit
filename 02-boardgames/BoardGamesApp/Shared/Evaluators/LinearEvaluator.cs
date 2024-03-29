namespace BoardGamesApp;

public class LinearEvaluator : IGameEvaluator
{
    private readonly GameBoard board;
    private readonly int targetCount;

    public LinearEvaluator(GameBoard board, int targetCount)
    {
        this.board = board;
        this.targetCount = targetCount;
    }

    public bool CheckForVictory(PlayerSymbol playerSymbol)
    {
        char symbol = (char)playerSymbol;

        return CheckRowsForWin(symbol) ||
               CheckColumnsForWin(symbol) ||
               CheckDiagonalsForWin(symbol);
    }

    public bool CheckForDraw()
    {
        for (int i = 0; i < board.Rows; i++)
        {
            for (int j = 0; j < board.Columns; j++)
            {
                if (board.GetCell(i, j) == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }

    private bool CheckRowsForWin(char symbol)
    {
        for (int i = 0; i < board.Rows; i++)
        {
            for (int j = 0; j <= board.Columns - targetCount; j++)
            {
                if (AreEqualInRow(symbol, i, j))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool CheckColumnsForWin(char symbol)
    {
        for (int i = 0; i <= board.Rows - targetCount; i++)
        {
            for (int j = 0; j < board.Columns; j++)
            {
                if (AreEqualInColumn(symbol, i, j))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool CheckDiagonalsForWin(char symbol)
    {
        if (CheckDiagonalsForWinDirection(symbol, 1, 1) || // Check diagonals from top-left to bottom-right
            CheckDiagonalsForWinDirection(symbol, 1, -1))   // Check diagonals from bottom-left to top-right
        {
            return true;
        }

        return false;
    }

    private bool CheckDiagonalsForWinDirection(char symbol, int rowIncrement, int colIncrement)
    {
        int rows = board.Rows;
        int cols = board.Columns;

        for (int i = 0; i <= rows - targetCount; i++)
        {
            for (int j = 0; j <= cols - targetCount; j++)
            {
                // Ensure we stay within bounds for diagonal evaluation
                if (i + targetCount <= rows && j + targetCount <= cols)
                {
                    if (AreEqualInDiagonal(symbol, i, j, rowIncrement, colIncrement) ||
                        AreEqualInReverseDiagonal(symbol, i, j + targetCount - 1))
                    {
                        return true;
                    }

                }
            }
        }

        return false;
    }


    private bool AreEqualInDiagonal(char symbol, int startRow, int startCol, int rowIncrement, int colIncrement)
    {
        for (int i = 0; i < targetCount; i++)
        {
            int row = startRow + i * rowIncrement;
            int col = startCol + i * colIncrement;

            // Ensure that both row and column indices are within bounds
            if (row < 0 || row >= board.Rows || col < 0 || col >= board.Columns)
            {
                return false;
            }

            if (board.GetCell(row, col) != symbol)
            {
                return false;
            }
        }

        return true;
    }

    private bool AreEqualInReverseDiagonal(char symbol, int startRow, int startCol)
    {
        for (int i = 0; i < targetCount; i++)
        {
            if (board.GetCell(startRow + i, startCol - i) != symbol)
            {
                return false;
            }
        }

        return true;
    }


    private bool AreEqualInRow(char symbol, int row, int startCol)
    {
        for (int i = 0; i < targetCount; i++)
        {
            if (board.GetCell(row, startCol + i) != symbol)
            {
                return false;
            }
        }

        return true;
    }

    private bool AreEqualInColumn(char symbol, int startRow, int col)
    {
        for (int i = 0; i < targetCount; i++)
        {
            if (board.GetCell(startRow + i, col) != symbol)
            {
                return false;
            }
        }

        return true;
    }
}
