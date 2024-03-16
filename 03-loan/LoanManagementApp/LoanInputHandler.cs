namespace LoanManagementApp;

public class LoanInputHandler
{
    private string[] args;
    private const double MINIMUM_LOAN_AMOUNT = 50000;

    public LoanInputHandler(string[] args)
    {
        this.args = args;
    }

    public double GetPrincipal()
    {
        double principal = GetUserInput(0, "Enter the loan amount");
        
        if (principal < MINIMUM_LOAN_AMOUNT)
        {
            throw new LoanAmountException();
        }

        return principal;
    }

    public int GetTermInMonths()
    {
        return 1;
    }

    public double GetAnnualInterestRate()
    {
        return 1;
    }

    private double GetUserInput(int indexArg, string prompt)
    {
        string input;
        if (args.Length == 0)
        {
            Console.WriteLine($"{prompt}: ");
            input = "";
        } else
        {
            input = args[indexArg];
        }

        if (input == null)
        {
            throw new ArgumentNullException();
        }
        
        double value;
        if (!double.TryParse(input, out value))
        {
            throw new FormatException();
        }

        if (value < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        return value;
    }

}
