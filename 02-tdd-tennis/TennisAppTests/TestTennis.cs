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
        [InlineData(3, 3, "Forty-Forty")]
        [InlineData(4, 4, "Advantage-Advantage")]
        public void Test_DisplayScore(int scorePlayer1, int scorePlayer2, string expectedResult)
        {
            string displayedScore = Tennis.DisplayScore(scorePlayer1, scorePlayer2);

            // Assert
            Assert.Equal(expectedResult, displayedScore);
        }
    }
}