namespace LoadManagementAppDomain;

public class LoanAmountException : Exception
{
    public LoanAmountException() : base("The loan amount must be greater than 50,000 euros.")
    {
        
    }
}
