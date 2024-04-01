using System.Text;
using LoadManagementAppDomain;

namespace LoanManagementApp;

public class CSVWriter
{
    private const string PAYMENT_HEADER = "Monthly Payment Number,Principal Paid,Remaining Balance";
    private readonly IFileSystem fileSystem;
    private readonly IClock clock;

    public CSVWriter(IFileSystem fileSystem, IClock clock)
    {
        this.fileSystem = fileSystem;
        this.clock = clock;
    }

    public void WriteToFile(List<Payment> payments, decimal totalCost)
    {
        string fileName = $"LoanPayments_{clock.Now:yyyyMMdd_HHmmss}.csv";
        StringBuilder content = new StringBuilder();
        content.AppendLine($"Total Loan Cost,{totalCost:F2}");
        content.AppendLine(PAYMENT_HEADER);

        foreach (Payment payment in payments)
        {
            content.AppendLine($"{payment.PaymentNumber},{payment.PrincipalPaid:F2},{payment.RemainingBalance:F2}");
        }

        fileSystem.SaveResult(content.ToString(), fileName);
    }
}

