﻿namespace BoardGamesApp;

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
        Console.WriteLine($"Player {playerNumber}: Choose 'H' for Human, 'C' for Computer.");
        char playerChoice = char.ToUpper(Console.ReadKey(true).KeyChar);

        while (playerChoice != 'H' && playerChoice != 'C')
        {
            Console.WriteLine("Invalid choice. Please choose 'H' for Human, 'C' for Computer.");
            playerChoice = char.ToUpper(Console.ReadKey(true).KeyChar);
        }

        return (playerChoice == 'H') ? new ConnectFourHumanPlayer(GetPlayerSymbol(playerNumber)) : new ConnectFourComputerPlayer(GetPlayerSymbol(playerNumber));
    }

    private PlayerSymbol GetPlayerSymbol(int playerNumber)
    {
        return (playerNumber == 1) ? PlayerSymbol.X : PlayerSymbol.O;
    }
}
