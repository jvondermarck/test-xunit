namespace BoardGamesApp;

public class Game
{
    private readonly IGame currentGame;
    private readonly IGameEvaluator evaluator;

    public Game(IGame currentGame, IGameEvaluator evaluator)
    {
        this.currentGame = currentGame;
        this.evaluator = evaluator;
    }

    public void Play()
    {
        currentGame.Play();
    }

    public void Restart()
    {
        currentGame.Restart();
    }
}
