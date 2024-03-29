namespace BoardGamesApp;

public class ConsoleHandler
{
    public static void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public static void Write(string message)
    {
        Console.Write(message);
    }

    public static void Clear()
    {
        Console.Clear();
    }

    public static char ReadKey()
    {
        char input = char.ToUpper(Console.ReadKey(false).KeyChar);
        Console.WriteLine("");
        return input;
    }

    public static void DisplayPlayerTurn(PlayerSymbol symbol, int maxPosition)
    {
        Write($"Player {(symbol == PlayerSymbol.X ? 1 : 2)} - ({symbol}): choose a position (1-{maxPosition}) : ");
    }

    public static int ReadIntInRange(int min, int max)
    {
        int number;
        do
        {
            if (int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max)
            {
                return number;
            }
            else
            {
                WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
        } while (true);
    }

    public static char GetPlayerChoice(string prompt, char[] validChoices)
    {
        Write(prompt);
        char playerChoice = ReadKey();

        while (!validChoices.Contains(playerChoice))
        {
            WriteLine($"Invalid choice. Please choose one of the following: {string.Join(", ", validChoices)}");
            playerChoice = ReadKey();
        }

        return playerChoice;
    }
    
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
