namespace LoanManagementApp;

public class CSVWriter
{
    private const string PAYMENT_HEADER = "Monthly Payment Number,Principal Paid,Remaining Balance";
        
    public static void WriteToFile(List<Payment> payments, string filePath, decimal totalCost)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine($"Total Loan Cost,{totalCost:F2}");
            writer.WriteLine(PAYMENT_HEADER);

            foreach (Payment payment in payments)
            {
                writer.WriteLine($"{payment.GetPaymentNumber()},{payment.GetPrincipalPaid():F2},{payment.GetRemainingBalance():F2}");
            }
        }
    }
}
