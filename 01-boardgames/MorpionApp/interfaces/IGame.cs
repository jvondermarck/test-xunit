namespace BoardGamesApp;

public interface IGame
{
    void Play();
    bool IsGameOver();
    void Restart();
    //GameBoard GetBoard();
    // IGameEvaluator GetEvaluator();
    PlayerSymbol GetCurrentPlayerSymbol();
}