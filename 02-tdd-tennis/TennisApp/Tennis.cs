namespace TennisApp
{
    public class Tennis
    {
        public Tennis()
        {
                
        }


        
        public static string DisplayScore(int player1, int player2)
        {
            if(player1 == 1 && player2 == 0)
            {
                return "Fifteen-Love";
            } 
            else if(player1 == 2 && player2 == 0)
            {
                return "Thirty-Love";
            }

            return "";
        }
    }
}
