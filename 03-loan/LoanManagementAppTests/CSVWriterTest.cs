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

        // Act
        //CSVWriter.WriteToFile(payments, filePath);

        // Assert
        string[] lines = File.ReadAllLines(filePath);
        Assert.Equal(4, lines.Length);
        Assert.Equal("PaymentNumber,PrincipalPaid,RemainingBalance", lines[0]);
        Assert.Equal("1,500.00,1500.00", lines[1]);
        Assert.Equal("2,600.00,900.00", lines[2]);
        Assert.Equal("3,900.00,0.00", lines[3]);

        // Clean up
        File.Delete(filePath);
    }
}
