using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace BoardGamesApp.Tests;

public class GameBoardTests
{
    private readonly GameBoard gameBoard;

    public GameBoardTests()
    {
        // Common setup for all tests
        int rows = 3;
        int columns = 3;
        gameBoard = new GameBoard(rows, columns);
    }

    [Fact]
    public void GameBoard_Initialization_ShouldCreateEmptyBoard()
    {
        // Act
        char[,] board = gameBoard.GetBoard();

        // Assert
        Assert.All(board.Cast<char>(), cell => Assert.Equal(' ', cell));
    }

    [Fact]
    public void GameBoard_SetCell_ShouldSetCellCorrectly()
    {
        // Act
        gameBoard.SetCell(1, 1, PlayerSymbol.X);

        // Assert
        Assert.Equal('X', gameBoard.GetCell(1, 1));
    }

    [Fact]
    public void GameBoard_SetCell_ShouldThrowException_WhenCellIsOccupied()
    {
        // Arrange
        gameBoard.SetCell(1, 1, PlayerSymbol.X);

        // Act
        Action act = () => gameBoard.SetCell(1, 1, PlayerSymbol.O);

        // Assert
        var exception = Assert.Throws<InvalidOperationException>(act);
        Assert.Equal("Cell is already occupied", exception.Message);
    }

    [Fact]
    public void GameBoard_IsCellEmpty_ShouldReturnTrue_WhenCellIsEmpty()
    {
        // Act
        bool result = gameBoard.IsCellEmpty(1, 1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GameBoard_IsCellEmpty_ShouldReturnFalse_WhenCellIsOccupied()
    {
        // Arrange
        gameBoard.SetCell(1, 1, PlayerSymbol.X);

        // Act
        bool result = gameBoard.IsCellEmpty(1, 1);

        // Assert
        Assert.False(result);
    }
}
