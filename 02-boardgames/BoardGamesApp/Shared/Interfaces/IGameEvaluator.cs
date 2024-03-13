namespace BoardGamesApp;

public interface IGameEvaluator
{
    bool CheckForVictory(PlayerSymbol playerSymbol);
    bool CheckForDraw();
}