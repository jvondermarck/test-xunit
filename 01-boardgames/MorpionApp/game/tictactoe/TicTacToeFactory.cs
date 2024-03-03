namespace BoardGamesApp;

public class TicTacToeFactory : IGameFactory
{
    public Game CreateGame()
    {
        IGame ticTacToeGame = new TicTacToe();
        return new Game(ticTacToeGame, ticTacToeGame.GetEvaluator());
    }
}