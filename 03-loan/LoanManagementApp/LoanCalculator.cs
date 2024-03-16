namespace LoanManagementApp;

public class LoanCalculator
{
    private Loan loan;

    public LoanCalculator(Loan loan)
    {
        this.loan = loan;
    }

    public double CalculateMonthlyPayment()
    {
        double monthlyInterestRate = loan.GetAnnualInterestRate() / 100 / 12;
        int termInMonths = loan.GetTermInMonths();

        double rawMonthlyPayment = loan.GetPrincipal() * (monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -termInMonths)));

        return Math.Round(rawMonthlyPayment, 0);
    }

    public List<Payment> GenerateAmortizationSchedule()
    {
        List<Payment> payments = new List<Payment>();
        double remainingBalance = loan.GetPrincipal();
        double monthlyPayment = CalculateMonthlyPayment();
        double monthlyInterestRate = loan.GetAnnualInterestRate() / 100 / 12;

        for (int i = 1; i <= loan.GetTermInMonths(); i++)
        {
            double interestPaid = remainingBalance * monthlyInterestRate;
            double principalPaid = monthlyPayment - interestPaid;
            
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

    public double CalculateTotalCreditCost()
    {
        return CalculateMonthlyPayment() * loan.GetTermInMonths();
    }
}