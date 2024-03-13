using TennisApp;

namespace TennisAppTests
{
    public class TestTennis
    {
        [Theory]
        [InlineData(1, 0, "Fifteen-Love")]
        [InlineData(2, 0, "Thirty-Love")]
        public void Test_DisplayScore(int scorePlayer1, int scorePlayer2, string expectedResult)
        {
            string displayedScore = Tennis.DisplayScore(scorePlayer1, scorePlayer2);

            // Assert
            Assert.Equal(expectedResult, displayedScore);
        }
    }
}