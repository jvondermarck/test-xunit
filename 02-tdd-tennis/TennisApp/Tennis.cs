namespace TennisApp
{
    public class Tennis
    {
        public Tennis()
        {
                
        }

        private static string ScoreToString(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    return "Invalid score";
            }
        }
        
        public static string DisplayScore(int player1, int player2)
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

            string scorePlayer1 = ScoreToString(player1);
            string scorePlayer2 = ScoreToString(player2);

            return scorePlayer1 + "-" + scorePlayer2;
        }
    }
}
