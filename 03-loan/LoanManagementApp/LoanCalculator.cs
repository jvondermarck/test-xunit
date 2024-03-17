namespace LoanManagementApp;

public class LoanCalculator
{
    private Loan loan;
    private const int MonthsInYear = 12;

    public LoanCalculator(Loan loan)
    {
        this.loan = loan;
    }

    public decimal CalculateMonthlyPayment()
    {
        decimal monthlyInterestRate = ConvertAnnualInterestRateToMonthlyInterestRate();
        int termInMonths = loan.GetTermInMonths();
        decimal principal = loan.GetPrincipal();

        decimal rawMonthlyPayment = principal * (monthlyInterestRate / (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -termInMonths)));

        return Math.Round(rawMonthlyPayment, 2, MidpointRounding.AwayFromZero);
    }

    public List<Payment> GenerateAmortizationSchedule()
    {
        List<Payment> payments = new List<Payment>();
        decimal remainingBalance = loan.GetPrincipal();
        decimal monthlyPayment = CalculateMonthlyPayment();
        decimal monthlyInterestRate = ConvertAnnualInterestRateToMonthlyInterestRate();

        for (int i = 1; i <= loan.GetTermInMonths(); i++)
        {
            decimal interestPaid = remainingBalance * monthlyInterestRate;
            decimal principalPaid = monthlyPayment - interestPaid;
            
            if (i == loan.GetTermInMonths())
            {
                principalPaid = remainingBalance;
                remainingBalance = 0;
            }
            else
            {
                remainingBalance -= principalPaid;
            }

            payments.Add(new Payment(i, principalPaid, remainingBalance));
        }

        return payments;
    }

    private decimal ConvertAnnualInterestRateToMonthlyInterestRate()
    {
        return loan.GetAnnualInterestRate() / 100 / MonthsInYear;
    }

    public decimal  CalculateTotalCreditCost()
    {
        decimal rawTotalCost = CalculateMonthlyPayment() * loan.GetTermInMonths();
        return Math.Round(rawTotalCost, 2, MidpointRounding.AwayFromZero);
    }

}