namespace BoardGamesApp;

public class TicTacToe : IGame
{
    private readonly GameLogic gameLogic;

    public TicTacToe(GameLogic gameLogic)
    {
        this.gameLogic = gameLogic;
    }

    // Delegate methods to gameLogic
    public void Play() => gameLogic.Play();
    public bool IsGameOver() => gameLogic.IsGameOver();
    public void Restart() => gameLogic.Restart();
}