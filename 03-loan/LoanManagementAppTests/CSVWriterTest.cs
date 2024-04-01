using LoanManagementApp;

namespace LoanManagementAppTests;

public class CSVWriterTest
{
    [Fact]
    public void Test_WriteToFile()
    {
        // Arrange
        var fileSystem = new FileSystemFake();
        var clock = new FakeClock(new DateTime(2022, 1, 1));
        var csvWriter = new CSVWriter(fileSystem, clock);
        var payments = new List<Payment>
        {
            new Payment(1, 500, 1500),
            new Payment(2, 600, 900),
            new Payment(3, 900, 0)
        };
        decimal totalCost = 2000;

        // Act
        csvWriter.WriteToFile(payments, totalCost);

        // Assert
        string fileName = "LoanPayments_20220101_000000.csv";
        string expectedContent = "Total Loan Cost,2000.00\r\n" +
                                 "Monthly Payment Number,Principal Paid,Remaining Balance\r\n" +
                                 "1,500.00,1500.00\r\n" +
                                 "2,600.00,900.00\r\n" +
                                 "3,900.00,0.00\r\n";
        Assert.Equal(expectedContent, fileSystem.Files[fileName]);
    }

    [Fact]
    public void Test_FileName()
    {
        // Arrange
        var fileSystem = new FileSystemFake();
        var clock = new FakeClock(new DateTime(2022, 1, 1));
        var csvWriter = new CSVWriter(fileSystem, clock);
        var payments = new List<Payment>();
        decimal totalCost = 0;

        // Act
        csvWriter.WriteToFile(payments, totalCost);

        // Assert
        string fileName = "LoanPayments_20220101_000000.csv";
        
        Assert.True(fileSystem.Files.ContainsKey(fileName));
    }


}
