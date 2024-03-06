namespace BoardGamesApp.Tests;

public class TicTacToeComputerPlayerTests
{
    [Fact]
    public void TicTacToeComputerPlayer_MakeMove_ShouldMakeValidMove()
    {
        // Arrange
        GameBoard gameBoard = new GameBoard(3, 3);
        TicTacToeComputerPlayer computerPlayer = new TicTacToeComputerPlayer(PlayerSymbol.X);

        // Act
        computerPlayer.MakeMove(gameBoard);

        // Assert that the computer player made a valid move
        Assert.All(gameBoard.GetBoard().Cast<char>(), cell => {
            if (cell != 'X') {
                Assert.Equal(' ', cell);
            }
        });
    }
}
