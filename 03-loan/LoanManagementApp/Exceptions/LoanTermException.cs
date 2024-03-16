namespace LoanManagementApp;

public class LoanTermException : Exception
{
    public LoanTermException() : base("The loan term must be between 108 and 300 months.")
    {
        
    }
}
