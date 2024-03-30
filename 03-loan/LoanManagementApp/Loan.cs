using LoadManagementAppDomain;

namespace LoanManagementApp
{
    public class Loan
    {
        public Principal Principal { get; private set; }
        public TermInMonths TermInMonths { get; private set; }
        public AnnualInterestRate AnnualInterestRate { get; private set; }

        public Loan(Principal principal, TermInMonths termInMonths, AnnualInterestRate annualInterestRate)
        {
            Principal = principal;
            TermInMonths = termInMonths;
            AnnualInterestRate = annualInterestRate;
        }
    }
}
