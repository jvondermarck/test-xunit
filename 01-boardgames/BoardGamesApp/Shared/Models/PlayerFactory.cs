namespace BoardGamesApp;

public class PlayerFactory
{
    public IPlayer CreatePlayer(int playerNumber, Func<PlayerSymbol, IPlayer> createHumanPlayer, Func<PlayerSymbol, IPlayer> createComputerPlayer)
    {
        char playerChoice = ConsoleHandler.GetPlayerChoice($"Player {playerNumber}: Choose 'H' for Human, 'C' for Computer.", new char[] { 'H', 'C' });
        PlayerSymbol symbol = GetPlayerSymbol(playerNumber);
        return (playerChoice == 'H') ? createHumanPlayer(symbol) : createComputerPlayer(symbol);
    }

    private PlayerSymbol GetPlayerSymbol(int playerNumber)
    {
        return (playerNumber == 1) ? PlayerSymbol.X : PlayerSymbol.O;
    }
}