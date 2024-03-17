using LoanManagementApp;

namespace LoanManagementAppTests;

public class CSVWriterTest
{
    [Fact]
    public void Test_WriteToFile()
    {
        // Arrange
        List<Payment> payments = new List<Payment>
        {
            new Payment(1, 500, 1500),
            new Payment(2, 600, 900),
            new Payment(3, 900, 0)
        };
        string filePath = "test.csv";
        decimal totalCost = 2000;

        // Act
        CSVWriter.WriteToFile(payments, filePath, totalCost);

        // Assert
        string[] lines = File.ReadAllLines(filePath);
        Assert.Equal(5, lines.Length);
        Assert.Equal("Total Loan Cost,2000.00", lines[0]);
        Assert.Equal("Monthly Payment Number,Principal Paid,Remaining Balance", lines[1]);
        Assert.Equal("1,500.00,1500.00", lines[2]);
        Assert.Equal("2,600.00,900.00", lines[3]);
        Assert.Equal("3,900.00,0.00", lines[4]);

        // Clean up
        File.Delete(filePath);
    }
}
