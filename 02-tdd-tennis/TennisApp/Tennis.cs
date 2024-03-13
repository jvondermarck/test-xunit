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
                case 4:
                    return "Advantage";
                default:
                    return "Invalid score";
            }
        }
        
        public static string DisplayScore(int player1, int player2)
        {
            string scorePlayer1 = ScoreToString(player1);
            string scorePlayer2 = ScoreToString(player2);
            
            

            return scorePlayer1 + "-" + scorePlayer2;
        }
    }
}
