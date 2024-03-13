namespace BoardGamesApp;

public interface IGame
{
    void Play();
    bool IsGameOver();
    void Restart();
}