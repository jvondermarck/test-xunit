namespace BoardGamesApp;

public interface IGameEvaluator
{
    bool CheckForVictory(PlayerSymbol playerSymbol);
}