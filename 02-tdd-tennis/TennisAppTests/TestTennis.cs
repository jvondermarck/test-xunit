using TennisApp;

namespace TennisAppTests
{
    public class TestTennis
    {
        [Theory]
        [InlineData(1, 0, "Fifteen-Love")]
        [InlineData(2, 0, "Thirty-Love")]
        [InlineData(3, 0, "Forty-Love")]
        [InlineData(0, 1, "Love-Fifteen")]
        [InlineData(0, 2, "Love-Thirty")]
        [InlineData(0, 3, "Love-Forty")]
        [InlineData(1, 1, "Fifteen-Fifteen")]
        [InlineData(2, 2, "Thirty-Thirty")]
        [InlineData(3, 3, "Deuce")]
        [InlineData(4, 4, "Deuce")]
        [InlineData(5, 5, "Deuce")]
        [InlineData(4, 3, "Advantage Player 1")]
        [InlineData(3, 4, "Advantage Player 2")]
        [InlineData(5, 4, "Advantage Player 1")]
        [InlineData(4, 5, "Advantage Player 2")]
        [InlineData(5, 3, "Player 1 wins")]
        [InlineData(3, 5, "Player 2 wins")]
        [InlineData(4, 1, "Player 1 wins")]
        [InlineData(1, 4, "Player 2 wins")]
        [InlineData(4, 2, "Player 1 wins")]
        [InlineData(2, 4, "Player 2 wins")]
        public void Test_DisplayScore(int scorePlayer1, int scorePlayer2, string expectedResult)
        {
            string displayedScore = Tennis.DisplayScore(scorePlayer1, scorePlayer2);

            // Assert
            Assert.Equal(expectedResult, displayedScore);
        }
    }
}