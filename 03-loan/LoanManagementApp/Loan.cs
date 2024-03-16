namespace LoanManagementApp;

public class Loan
{
    private double _principal;
    private int _termInMonths;
    private double _annualInterestRate;

    public Loan(double principal, int termInMonths, double annualInterestRate)
    {
        _principal = principal;
        _termInMonths = termInMonths;
        _annualInterestRate = annualInterestRate;
    }

    public double GetPrincipal()
    {
        return _principal;
    }

    public int GetTermInMonths()
    {
        return _termInMonths;
    }

    public double GetAnnualInterestRate()
    {
        return _annualInterestRate;
    }
}
