namespace LoadManagementAppDomain;

public record AnnualInterestRate
{
    private const decimal MAXIMUM_PERCENTAGE = 100;

    public AnnualInterestRate(decimal value)
    {
        if (value <= 0 || value > MAXIMUM_PERCENTAGE)
            throw new ArgumentOutOfRangeException("value");

        this.Value = value;
    }

    public AnnualInterestRate(string input)
    {
        try
        {
            Value = Convert.ToDecimal(input);
            if (Value <= 0 || Value > MAXIMUM_PERCENTAGE)
                throw new Exception();
        }
        catch
        {
            throw new ArgumentException("input must be a decimal between 0 and " + MAXIMUM_PERCENTAGE);
        }
    }

    public decimal Value { get; init; }
}
