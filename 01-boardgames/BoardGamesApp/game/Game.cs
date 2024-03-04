namespace BoardGamesApp;

public class Game
{
    private readonly IGame currentGame;

    public Game(IGame currentGame)
    {
        this.currentGame = currentGame;
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
