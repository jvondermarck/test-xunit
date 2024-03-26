namespace LoanManagementApp
{
    public class Loan
    {
        public decimal Principal { get; private set; }
        public int TermInMonths { get; private set; }
        public decimal AnnualInterestRate { get; private set; }

        public Loan(decimal principal, int termInMonths, decimal annualInterestRate)
        {
            Principal = principal;
            TermInMonths = termInMonths;
            AnnualInterestRate = annualInterestRate;
        }
    }
}
