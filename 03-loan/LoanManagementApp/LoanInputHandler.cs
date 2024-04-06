using LoadManagementAppDomain;

namespace LoanManagementApp;

public class LoanInputHandler
{
    private Dictionary<string, string> args;

    public LoanInputHandler(string[] argsCommand)
    {
        args = ParseArguments(argsCommand);

        // Check if the dictionary contains only the expected keys
        var expectedKeys = new HashSet<string> { "principal", "term", "rate" };
        if (!expectedKeys.SetEquals(args.Keys))
        {
            throw new ArgumentException("Invalid arguments. Please provide only the principal, term, and rate.\n" + "Example: dotnet run --principal 50000 --term 12 --rate 0.1");
        }
    }

    private Dictionary<string, string> ParseArguments(string[] argsCommand)
    {
        var argDictionary = new Dictionary<string, string>();
        for (int i = 0; i < argsCommand.Length; i += 2)
        {
            argDictionary[argsCommand[i].TrimStart('-')] = argsCommand[i + 1];
        }
        return argDictionary;
    }

    public Principal GetPrincipal()
    {
        try {
            return new Principal(GetUserInput("principal"));
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public TermInMonths GetTermInMonths()
    {
        try {
            return new TermInMonths(GetUserInput("term"));
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public AnnualInterestRate GetAnnualInterestRate()
    {
        try {
            return new AnnualInterestRate(GetUserInput("rate"));
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private string GetUserInput(string argName)
    {
        string? input;
        if (!args.TryGetValue(argName, out input) || string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException($"The argument '{argName}' is required.");
        }

        return input;
    }
}
