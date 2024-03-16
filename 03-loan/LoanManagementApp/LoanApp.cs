namespace LoanManagementApp
{
    public class LoanApp
    {
        public static void Main(string[] args)
        {
            LoanInputHandler inputHandler = new LoanInputHandler(args);

            double principal = inputHandler.GetPrincipal();
            int termInMonths = inputHandler.GetTermInMonths();
            double annualInterestRate = inputHandler.GetAnnualInterestRate();

            Loan loan = new Loan(principal, termInMonths, annualInterestRate);
            LoanCalculator calculator = new LoanCalculator(loan);
            List<Payment> payments = calculator.GenerateAmortizationSchedule();
            double totalCost = calculator.CalculateTotalCreditCost();

            CSVWriter.WriteToFile(payments, "amortization_schedule.csv", totalCost);
        }
    }
}