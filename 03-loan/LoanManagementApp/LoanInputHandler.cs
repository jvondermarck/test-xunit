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
            throw new ArgumentException("Invalid arguments. Please provide only the principal, term, and rate.\n" +
                                        "Example: dotnet run --principal 50000 --term 12 --rate 0.1");
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
        return new Principal(GetUserInput("principal"));
    }

    public TermInMonths GetTermInMonths()
    {
        return new TermInMonths(GetUserInput("term"));
    }

    public AnnualInterestRate GetAnnualInterestRate()
    {
        return new AnnualInterestRate(GetUserInput("rate"));
    }

    private string GetUserInput(string argName)
    {
        string? input;
        if (!args.TryGetValue(argName, out input))
        {
            throw new ArgumentNullException($"The argument '{argName}' is required.");
        }

        // Check if the input is not empty or null
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException($"The argument '{argName}' is required.");
        }

        return input;
    }
}
