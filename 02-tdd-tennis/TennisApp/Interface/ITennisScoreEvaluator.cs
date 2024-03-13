namespace TennisApp;

public interface ITennisScoreEvaluator
{
    string? Evaluate(int player1, int player2);
}
