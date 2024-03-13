namespace TennisApp
{
    public class Tennis
    {
        private readonly IScore _score;
        private readonly ITennisScoreEvaluator _evaluator;

        public Tennis(IScore score, ITennisScoreEvaluator evaluator)
        {
            _score = score;
            _evaluator = evaluator;
        }

        public string DisplayScore(int player1, int player2)
        {
            var result = _evaluator.Evaluate(player1, player2);

            result ??= _score.GetScore(player1) + "-" + _score.GetScore(player2);

            return result;
        }
    }
}
