namespace TennisApp
{
    public class Tennis
{
    private readonly IScore _score;
    private const int AdvantageScore = 4;
    private const int DeuceScore = 3;

    public Tennis(IScore score)
    {
        _score = score;
    }

    public string DisplayScore(int player1, int player2)
    {
        string result;

        if (player1 >= AdvantageScore && player1 == player2 + 1)
            result = "Advantage Player 1";
        else if (player2 >= AdvantageScore && player2 == player1 + 1) 
            result = "Advantage Player 2";
        else if (player1 >= AdvantageScore && player1 > player2 + 1)
            result = "Player 1 wins";
        else if (player2 >= AdvantageScore && player2 > player1 + 1)
            result = "Player 2 wins";
        else if (player1 >= DeuceScore && player1 == player2)
            result = "Deuce";
        else
            result = _score.GetScore(player1) + "-" + _score.GetScore(player2);

        return result;
        }
    }
}
