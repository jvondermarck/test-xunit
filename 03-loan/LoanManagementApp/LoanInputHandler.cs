namespace LoanManagementApp;

public class LoanInputHandler
{
    private string[] args;
    private const double MINIMUM_LOAN_AMOUNT = 50000;
    private const double MINIMUM_DURATION_IN_MONTHS = 9*12;
    private const double MAXIMUM_DURATION_IN_MONTHS = 25*12;
    private const double MAXIMUM_PERCENTAGE = 100;

    public LoanInputHandler(string[] args)
    {
        this.args = args;
    }

    public double GetPrincipal()
    {
        double principal = GetUserInput(0);
        
        if (principal < MINIMUM_LOAN_AMOUNT)
        {
            throw new LoanAmountException();
        }

        return principal;
    }

    public int GetTermInMonths()
    {
        int termInMonths = (int)GetUserInput(1);

        if (termInMonths < MINIMUM_DURATION_IN_MONTHS || termInMonths > MAXIMUM_DURATION_IN_MONTHS)
        {
            throw new LoanTermException();
        }

        return termInMonths;
    }

    public double GetAnnualInterestRate()
    {
        double annualInterestRate = GetUserInput(2);

        if (annualInterestRate <= 0 || annualInterestRate > MAXIMUM_PERCENTAGE)
        {
            throw new InterestRateException();
        }

        return annualInterestRate;
    }

    private double GetUserInput(int indexArg)
    {
        string input = args[indexArg];

        // Check if the input is not empty or null
        if (string.IsNullOrEmpty(input))
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
