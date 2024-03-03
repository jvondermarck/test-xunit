namespace BoardGamesApp;

public class ConnectFour : IGame
{
    private readonly GameLogic gameLogic;

    public ConnectFour(GameLogic gameLogic)
    {
        this.gameLogic = gameLogic;
    }

    // Delegate methods to gameLogic
    public void Play() => gameLogic.Play();
    public bool IsGameOver() => gameLogic.IsGameOver();
    public void Restart() => gameLogic.Restart();
    public GameBoard GetBoard() => gameLogic.GetBoard();
    public PlayerSymbol GetCurrentPlayerSymbol() => gameLogic.GetCurrentPlayerSymbol();
}
