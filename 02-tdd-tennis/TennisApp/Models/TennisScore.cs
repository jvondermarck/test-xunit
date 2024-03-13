namespace TennisApp;

public class TennisScore : IScore
{
    private static readonly Dictionary<int, string> ScoreMap = new Dictionary<int, string>
    {
        {0, "Love"},
        {1, "Fifteen"},
        {2, "Thirty"},
        {3, "Forty"}
    };

    public string GetScore(int score)
    {
        return ScoreMap.ContainsKey(score) ? ScoreMap[score] : "Invalid score";
    }
}
