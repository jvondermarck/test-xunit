namespace LoanManagementApp;

public class LoanInputHandler
{
    private Dictionary<string, string> args;
    private const decimal MINIMUM_LOAN_AMOUNT = 50000;
    private const decimal MINIMUM_DURATION_IN_MONTHS = 9*12;
    private const decimal MAXIMUM_DURATION_IN_MONTHS = 25*12;
    private const decimal MAXIMUM_PERCENTAGE = 100;

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

    public decimal GetPrincipal()
    {
        decimal principal = GetUserInput("principal");
        
        if (principal < MINIMUM_LOAN_AMOUNT)
        {
            throw new LoanAmountException();
        }

        return principal;
    }

    public int GetTermInMonths()
    {
        int termInMonths = (int)GetUserInput("term");

        if (termInMonths < MINIMUM_DURATION_IN_MONTHS || termInMonths > MAXIMUM_DURATION_IN_MONTHS)
        {
            throw new LoanTermException();
        }

        return termInMonths;
    }

    public decimal GetAnnualInterestRate()
    {
        decimal annualInterestRate = GetUserInput("rate");
        if (annualInterestRate <= 0 || annualInterestRate > MAXIMUM_PERCENTAGE)
        {
            throw new InterestRateException();
        }

        return annualInterestRate;
    }

    private decimal GetUserInput(string argName)
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
        
        decimal value;
        if (!decimal.TryParse(input, out value))
        {
            throw new FormatException($"The argument '{argName}' is not a valid number.");
        }

        if (value < 0)
        {
            throw new ArgumentOutOfRangeException($"The argument '{argName}' cannot be negative.");
        }
        return value;
    }

}
