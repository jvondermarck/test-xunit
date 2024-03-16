using LoanManagementApp;

namespace LoanManagementAppTests;

public class LoanCalculatorTest
{
    [Fact]
    public void Test_CalculateMonthlyPayment()
    {
        // Arrange
        Loan loan = new Loan(200000, 360, 3.92);
        //LoanCalculator calculator = new LoanCalculator(loan);

        // Act
        //double monthlyPayment = calculator.CalculateMonthlyPayment();

        // Assert
        //Assert.Equal(946.78, monthlyPayment, 2);
    }
}
