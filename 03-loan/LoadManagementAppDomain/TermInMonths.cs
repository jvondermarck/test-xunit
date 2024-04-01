namespace LoadManagementAppDomain;

public class TermInMonths
{
    public TermInMonths(int value)
    {
        if (value < 108 || value > 300) throw new LoanTermException();

        this.Value = value;
    }
    public TermInMonths(string input)
    {
        Value = Convert.ToInt32(input);
        if (Value < 108 || Value > 300)
            throw new LoanTermException();   
    }
    public int Value { get; init; }
}
