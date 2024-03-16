using LoanManagementApp;

namespace LoanManagementAppTests;

public class LoanCalculatorTest
{
    [Fact]
    public void Test_CalculateMonthlyPayment()
    {
        // Arrange
        Loan loan = new Loan(200000, 360, 3.92);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        double monthlyPayment = calculator.CalculateMonthlyPayment();

        // Assert
        Assert.Equal(945.63, monthlyPayment, 2);
    }

    [Fact]
    public void Test_CalculateMonthlyPayment_2()
    {
        // Arrange
        Loan loan = new Loan(300000, 240, 1.20);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        double monthlyPayment = calculator.CalculateMonthlyPayment();

        // Assert
        Assert.Equal(1406.62, monthlyPayment, 2);
    }

    [Fact]
    public void Test_GenerateAmortizationSchedule()
    {
        // Arrange
        Loan loan = new Loan(200000, 360, 3.92);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        List<Payment> payments = calculator.GenerateAmortizationSchedule();

        // Assert
        Assert.Equal(360, payments.Count);
        Assert.Equal(200000.37, payments.Sum(p => p.GetPrincipalPaid()), 2);
    }
}
