namespace TennisApp;

public class TennisScoreEvaluator : ITennisScoreEvaluator
{
    private const int AdvantageScore = 4;
    private const int DeuceScore = 3;

    public string? Evaluate(int player1, int player2)
    {
        if (player1 >= AdvantageScore && player1 == player2 + 1)
            return "Advantage Player 1";
        else if (player2 >= AdvantageScore && player2 == player1 + 1) 
            return "Advantage Player 2";
        else if (player1 >= AdvantageScore && player1 > player2 + 1)
            return "Player 1 wins";
        else if (player2 >= AdvantageScore && player2 > player1 + 1)
            return "Player 2 wins";
        else if (player1 >= DeuceScore && player1 == player2)
            return "Deuce";
        else
            return null;
    }
}
