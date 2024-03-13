namespace TennisApp
{
    public class Tennis
    {
        private readonly IScore _score;

        public Tennis(IScore score)
        {
            _score = score;
        }

        public string DisplayScore(int player1, int player2)
        {
            if (player1 >= 4 && player1 == player2 + 1)
                return "Advantage Player 1";
            else if (player2 >= 4 && player2 == player1 + 1) 
                return "Advantage Player 2";
            else if (player1 >= 4 && player1 > player2 + 1)
                return "Player 1 wins";
            else if (player2 >= 4 && player2 > player1 + 1)
                return "Player 2 wins";
            else if (player1 >= 3 && player1 == player2)
                return "Deuce";

            string scorePlayer1 = _score.GetScore(player1);
            string scorePlayer2 = _score.GetScore(player2);

            return scorePlayer1 + "-" + scorePlayer2;
        }
    }
}
