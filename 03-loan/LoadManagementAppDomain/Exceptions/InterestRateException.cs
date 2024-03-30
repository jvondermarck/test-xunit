namespace LoadManagementAppDomain;

public class InterestRateException : Exception
{
    public InterestRateException() : base("The annual interest rate must be between 0 and 100%.")
    {
        
    }
}
