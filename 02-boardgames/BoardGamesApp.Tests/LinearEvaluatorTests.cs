namespace BoardGamesApp.Tests;

public class LinearEvaluatorTests
{
    
    private const int TicTacToeRows = 3;
    private const int TicTacToeColumns = 3;
    private const int TicTacToeTargetCount = 3;
    private const int ConnectFourRows = 6;
    private const int ConnectFourColumns = 7;
    private const int ConnectFourTargetCount = 4;
    
    [Theory]
    [InlineData(TicTacToeRows, TicTacToeColumns, TicTacToeTargetCount)]
    [InlineData(ConnectFourRows, ConnectFourColumns, ConnectFourTargetCount)] 
    public void LinearEvaluator_CheckForVictory_ShouldReturnTrueForWinningCondition(int rows, int columns, int targetCount)
    {
        // Arrange
        GameBoard gameBoard = new GameBoard(rows, columns);
        LinearEvaluator evaluator = new LinearEvaluator(gameBoard, targetCount);

        // Act
        for (int i = 0; i < targetCount; i++)
        {
            gameBoard.SetCell(0, i, PlayerSymbol.X);
        }

        // Assert
        Assert.True(evaluator.CheckForVictory(PlayerSymbol.X));
    }

    [Theory]
    [InlineData(TicTacToeRows, TicTacToeColumns, TicTacToeTargetCount)]
    [InlineData(ConnectFourRows, ConnectFourColumns, ConnectFourTargetCount)] 
    public void LinearEvaluator_CheckForVictory_ShouldReturnFalseForNonWinningCondition(int rows, int columns, int targetCount)
    {
        // Arrange
        GameBoard gameBoard = new GameBoard(rows, columns);
        LinearEvaluator evaluator = new LinearEvaluator(gameBoard, targetCount);

        // Act
        for (int i = 0; i < targetCount - 1; i++)
        {
            gameBoard.SetCell(0, i, PlayerSymbol.X);
        }

        // Assert
        Assert.False(evaluator.CheckForVictory(PlayerSymbol.X));
    }

    [Fact]
    public void LinearEvaluator_CheckForVictory_ShouldReturnTrueForWinningConditionInColumn()
    {
        // Arrange
        int rows = 3;
        int columns = 3;
        GameBoard gameBoard = new GameBoard(rows, columns);
        LinearEvaluator evaluator = new LinearEvaluator(gameBoard, 3);

        // Act
        gameBoard.SetCell(0, 0, PlayerSymbol.X);
        gameBoard.SetCell(1, 0, PlayerSymbol.X);
        gameBoard.SetCell(2, 0, PlayerSymbol.X);

        // Assert
        Assert.True(evaluator.CheckForVictory(PlayerSymbol.X));
    }

    [Theory]
    [InlineData(TicTacToeRows, TicTacToeColumns, TicTacToeTargetCount)]
    [InlineData(ConnectFourRows, ConnectFourColumns, ConnectFourTargetCount)] 
    public void LinearEvaluator_CheckForVictory_ShouldReturnTrueForWinningConditionInDiagonal(int rows, int columns, int targetCount)
    {
        // Arrange
        GameBoard gameBoard = new GameBoard(rows, columns);
        LinearEvaluator evaluator = new LinearEvaluator(gameBoard, targetCount);

        // Act
        for (int i = 0; i < targetCount; i++)
        {
            gameBoard.SetCell(i, i, PlayerSymbol.X);
        }

        // Assert
        Assert.True(evaluator.CheckForVictory(PlayerSymbol.X));
    }

    [Theory]
    [InlineData(TicTacToeRows, TicTacToeColumns, TicTacToeTargetCount)]
    [InlineData(ConnectFourRows, ConnectFourColumns, ConnectFourTargetCount)]
    public void LinearEvaluator_CheckForVictory_ShouldReturnTrueForWinningConditionInReverseDiagonal(int rows, int columns, int targetCount)
    {
        // Arrange
        GameBoard gameBoard = new GameBoard(rows, columns);
        LinearEvaluator evaluator = new LinearEvaluator(gameBoard, targetCount);

        // Act
        for (int i = 0; i < targetCount; i++)
        {
            gameBoard.SetCell(i, targetCount - i - 1, PlayerSymbol.X);
        }

        // Assert
        Assert.True(evaluator.CheckForVictory(PlayerSymbol.X));
    }

    [Theory]
    [InlineData(TicTacToeRows, TicTacToeColumns, TicTacToeTargetCount)]
    [InlineData(ConnectFourRows, ConnectFourColumns, ConnectFourTargetCount)]
    public void LinearEvaluator_CheckForVictory_ShouldReturnFalseForNonWinningConditionInDiagonal(int rows, int columns, int targetCount)
    {
        // Arrange
        GameBoard gameBoard = new GameBoard(rows, columns);
        LinearEvaluator evaluator = new LinearEvaluator(gameBoard, targetCount);

        // Act
        for (int i = 0; i < targetCount - 1; i++)
        {
            gameBoard.SetCell(i, i, PlayerSymbol.X);
        }

        // Assert
        Assert.False(evaluator.CheckForVictory(PlayerSymbol.X));
    }

    [Theory]
    [InlineData(TicTacToeRows, TicTacToeColumns, TicTacToeTargetCount)]
    [InlineData(ConnectFourRows, ConnectFourColumns, ConnectFourTargetCount)]
    public void LinearEvaluator_CheckForVictory_ShouldReturnFalseForNonWinningConditionInReverseDiagonal(int rows, int columns, int targetCount)
    {
        // Arrange
        GameBoard gameBoard = new GameBoard(rows, columns);
        LinearEvaluator evaluator = new LinearEvaluator(gameBoard, targetCount);

        // Act
        for (int i = 0; i < targetCount - 1; i++)
        {
            gameBoard.SetCell(i, targetCount - i - 1, PlayerSymbol.X);
        }

        // Assert
        Assert.False(evaluator.CheckForVictory(PlayerSymbol.X));
    }

    [Theory]
    [InlineData(TicTacToeRows, TicTacToeColumns, TicTacToeTargetCount)]
    [InlineData(ConnectFourRows, ConnectFourColumns, ConnectFourTargetCount)]
    public void LinearEvaluator_CheckForDraw_ShouldReturnTrueForDrawCondition(int rows, int columns, int targetCount)
    {
        // Arrange
        GameBoard gameBoard = new GameBoard(rows, columns);
        LinearEvaluator evaluator = new LinearEvaluator(gameBoard, targetCount);

        // Act
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                gameBoard.SetCell(i, j, PlayerSymbol.X);
            }
        }

        // Assert
        Assert.True(evaluator.CheckForDraw());
    }
}
