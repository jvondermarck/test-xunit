namespace BoardGamesApp;

public class ConnectFourFactory : IGameFactory
{
    public Game CreateGame()
    {
        IPlayer player1 = CreatePlayer(1);
        IPlayer player2 = CreatePlayer(2);

        IGame connectFourGame = new ConnectFour(player1, player2);
        return new Game(connectFourGame, connectFourGame.GetEvaluator());
    }

    private IPlayer CreatePlayer(int playerNumber)
    {
        Console.WriteLine($"Player {playerNumber}: Choose 'H' for Human, 'C' for Computer.");
        char playerChoice = char.ToUpper(Console.ReadKey(true).KeyChar);
        return (playerChoice == 'H') ? new ConnectFourHumanPlayer(GetPlayerSymbol(playerNumber)) : new ConnectFourComputerPlayer(GetPlayerSymbol(playerNumber));
    }

    private PlayerSymbol GetPlayerSymbol(int playerNumber)
    {
        return (playerNumber == 1) ? PlayerSymbol.X : PlayerSymbol.O;
    }
}
