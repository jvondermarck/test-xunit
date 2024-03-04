namespace BoardGamesApp;

public class ConnectFourFactory : IGameFactory
{
    public Game CreateGame()
    {
        IPlayer player1 = CreatePlayer(1);
        IPlayer player2 = CreatePlayer(2);

        GameLogic gameLogic = new GameLogicBuilder()
            .SetPlayer1(player1)
            .SetPlayer2(player2)
            .SetRows(4)
            .SetColumns(7)
            .SetTargetCount(4)
            .Build();

        IGame connectFourGame = new ConnectFour(gameLogic);

        return new Game(connectFourGame, gameLogic.GetEvaluator());
    }

    private IPlayer CreatePlayer(int playerNumber)
    {
        char playerChoice = UserInputHandler.GetPlayerChoice(playerNumber);
        return (playerChoice == 'H') ? new ConnectFourHumanPlayer(GetPlayerSymbol(playerNumber)) : new ConnectFourComputerPlayer(GetPlayerSymbol(playerNumber));
    }

    private PlayerSymbol GetPlayerSymbol(int playerNumber)
    {
        return (playerNumber == 1) ? PlayerSymbol.X : PlayerSymbol.O;
    }
}
