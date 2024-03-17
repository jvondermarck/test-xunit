using LoanManagementApp;

namespace LoanManagementAppTests;

public class LoanCalculatorTest
{
    [Fact]
    public void Test_CalculateMonthlyPayment()
    {
        // Arrange
        Loan loan = new Loan(200000, 300, 3.92m);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        decimal monthlyPayment = calculator.CalculateMonthlyPayment();

        // Assert
        Assert.Equal(1046.86m, monthlyPayment);
    }

    [Fact]
    public void Test_GetCalculateTotalCreditCost()
    {
        // Arrange
        Loan loan = new Loan(200000, 300, 3.92m);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        decimal totalCost = calculator.CalculateTotalCreditCost();

        // Assert
        Assert.Equal(314058, totalCost);
    }

    [Fact]
    public void Test_GetCalculateTotalCreditCost_2()
    {
        // Arrange
        Loan loan = new Loan(300000, 240, 1.20m);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        decimal totalCost = calculator.CalculateTotalCreditCost();

        // Assert
        Assert.Equal(337588.80m, totalCost);
    }


    [Fact]
    public void Test_CalculateMonthlyPayment_2()
    {
        // Arrange
        Loan loan = new Loan(300000, 240, 1.20m);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        decimal monthlyPayment = calculator.CalculateMonthlyPayment();

        // Assert
        Assert.Equal(1406.62m, monthlyPayment,2);
    }

    [Fact]
    public void Test_GenerateAmortizationSchedule()
    {
        // Arrange
        Loan loan = new Loan(200000, 300, 3.92m);
        LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        List<Payment> payments = calculator.GenerateAmortizationSchedule();

        // Assert
        Assert.Equal(200000, Math.Round(payments.Sum(p => p.GetPrincipalPaid()), 0));
    }
}
