namespace LoadManagementAppDomain;

public class TermInMonths
{
    public TermInMonths(int value)
    {
        if (value < 108 || value > 300) throw new ArgumentOutOfRangeException("value");

        this.Value = value;
    }
    public TermInMonths(string input)
    {
        try
        {
            Value = Convert.ToInt32(input);
            if (Value < 0)
                throw new Exception();
        } catch
        {
            throw new ArgumentException("input must be strictly positive integer");
        }
    }
    public int Value { get; init; }
}
