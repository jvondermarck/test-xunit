namespace BoardGamesApp;

public class ConnectFourFactory : IGameFactory
{
    public Game CreateGame()
    {
        IGame connectFourGame = new ConnectFour();
        return new Game(connectFourGame, connectFourGame.GetEvaluator());
    }
}
