namespace LoanManagementApp;
public class LoanApp
{
    public static void Main(string[] args)
    {
        try  
        {
            LoanInputHandler inputHandler = new LoanInputHandler(args);
            RunLoanCalculations(inputHandler);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }

    private static void RunLoanCalculations(LoanInputHandler inputHandler)
    {
        decimal principal = inputHandler.GetPrincipal();
        int termInMonths = inputHandler.GetTermInMonths();
        decimal annualInterestRate = inputHandler.GetAnnualInterestRate();

        Loan loan = new Loan(principal, termInMonths, annualInterestRate);
        LoanCalculator calculator = new LoanCalculator(loan);
        List<Payment> payments = calculator.GenerateAmortizationSchedule();
        decimal totalCost = calculator.CalculateTotalCreditCost();
        
        CSVWriter.WriteToFile(payments, "amortization_schedule.csv", totalCost);
    }
}