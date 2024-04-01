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
        Value = Convert.ToDecimal(input);
        if (Value < MINIMUM_LOAN_AMOUNT)
            throw new LoanAmountException();
    }

    public decimal Value { get; init; }
}