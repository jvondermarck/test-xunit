namespace LoadManagementAppDomain;

public record AnnualInterestRate
{
    private const decimal MAXIMUM_PERCENTAGE = 100;

    public AnnualInterestRate(decimal value)
    {
        if (value <= 0 || value > MAXIMUM_PERCENTAGE)
            throw new InterestRateException();

        this.Value = value;
    }

    public AnnualInterestRate(string input)
    {
        Value = Convert.ToDecimal(input);
        if (Value <= 0 || Value > MAXIMUM_PERCENTAGE)
            throw new InterestRateException();
    }

    public decimal Value { get; init; }
}
