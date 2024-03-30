namespace LoadManagementAppDomain;

public record Principal
{
    private const decimal MINIMUM_LOAN_AMOUNT = 50000;

    public Principal(decimal value)
    {
        if (value < MINIMUM_LOAN_AMOUNT)
            throw new LoanAmountException();

        this.Value = value;
    }

    public Principal(string input)
    {
        try
        {
            Value = Convert.ToDecimal(input);
            if (Value < MINIMUM_LOAN_AMOUNT)
                throw new LoanAmountException();
        }
        catch
        {
            throw new ArgumentException("input must be a decimal greater than or equal to " + MINIMUM_LOAN_AMOUNT);
        }
    }

    public decimal Value { get; init; }
}