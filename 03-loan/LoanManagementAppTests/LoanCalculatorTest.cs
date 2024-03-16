using LoanManagementApp;

namespace LoanManagementAppTests;

public class LoanCalculatorTest
{
    [Fact]
    public void Test_CalculateMonthlyPayment()
    {
        // Arrange
        Loan loan = new Loan(200000, 300, 3.92);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        double monthlyPayment = calculator.CalculateMonthlyPayment();

        // Assert
        Assert.Equal(1047, monthlyPayment);
    }

    [Fact]
    public void Test_GetCalculateTotalCreditCost()
    {
        // Arrange
        Loan loan = new Loan(200000, 300, 3.92);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        double totalCost = calculator.CalculateTotalCreditCost();

        // Assert
        Assert.Equal(314100, totalCost);
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
        Assert.Equal(1407, monthlyPayment);
    }

    [Fact]
    public void Test_GenerateAmortizationSchedule()
    {
        // Arrange
        Loan loan = new Loan(200000, 300, 3.92);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        List<Payment> payments = calculator.GenerateAmortizationSchedule();

        // Assert
        Assert.Equal(200000, Math.Round(payments.Sum(p => p.GetPrincipalPaid()), 0));
    }
}
