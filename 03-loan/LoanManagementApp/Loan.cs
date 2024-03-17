namespace LoanManagementApp;

public class Loan
{
    private decimal _principal;
    private int _termInMonths;
    private decimal _annualInterestRate;

    public Loan(decimal principal, int termInMonths, decimal annualInterestRate)
    {
        _principal = principal;
        _termInMonths = termInMonths;
        _annualInterestRate = annualInterestRate;
    }

    public decimal GetPrincipal()
    {
        return _principal;
    }

    public int GetTermInMonths()
    {
        return _termInMonths;
    }

    public decimal GetAnnualInterestRate()
    {
        return _annualInterestRate;
    }
}
