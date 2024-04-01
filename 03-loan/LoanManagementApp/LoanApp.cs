using LoadManagementAppDomain;

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
        Principal principal = inputHandler.GetPrincipal();
        TermInMonths termInMonths = inputHandler.GetTermInMonths();
        AnnualInterestRate annualInterestRate = inputHandler.GetAnnualInterestRate();

        Loan loan = new Loan(principal, termInMonths, annualInterestRate);
        LoanCalculator calculator = new LoanCalculator(loan);
        List<Payment> payments = calculator.GenerateAmortizationSchedule();
        decimal totalCost = calculator.CalculateTotalCreditCost();
        
        IFileSystem fileSystem = new FileSystem();
        IClock clock = new Clock();
        CSVWriter csvWriter = new CSVWriter(fileSystem, clock);
        csvWriter.WriteToFile(payments, totalCost);
    }
}