namespace BoardGamesApp;

public class UserInputHandler
{
    public static char GetPlayerChoice(int playerNumber)
    {
        Console.WriteLine($"Player {playerNumber}: Choose 'H' for Human, 'C' for Computer.");
        char playerChoice = char.ToUpper(Console.ReadKey(true).KeyChar);

        while (playerChoice != 'H' && playerChoice != 'C')
        {
            Console.WriteLine("Invalid choice. Please choose 'H' for Human, 'C' for Computer.");
            playerChoice = char.ToUpper(Console.ReadKey(true).KeyChar);
        }

        return playerChoice;
    }
}
