namespace BoardGamesApp;

public interface IPlayer
{
    PlayerSymbol Symbol { get; }
    void MakeMove(GameBoard board);
}