using LoanManagementApp;
using Xunit;

namespace LoanManagementAppTests
{
    public class LoanCalculatorTest
    {
        [Theory]
        [InlineData(200000, 300, 3.92, 1046.86)]
        [InlineData(200000, 180, 0.85, 1183.84)]
        [InlineData(300000, 240, 1.20, 1406.62)]
        public void Test_CalculateMonthlyPayment(decimal amount, int term, decimal rate, decimal expected)
        {
            // Arrange
            var loan = new Loan(amount, term, rate);
            var calculator = new LoanCalculator(loan);

            // Act
            decimal monthlyPayment = calculator.CalculateMonthlyPayment();

            // Assert
            Assert.Equal(expected, monthlyPayment);
        }

        [Theory]
        [InlineData(200000, 300, 3.92, 314058)]
        [InlineData(300000, 240, 1.20, 337588.80)]
        public void Test_GetCalculateTotalCreditCost(decimal amount, int term, decimal rate, decimal expected)
        {
            // Arrange
            var loan = new Loan(amount, term, rate);
            var calculator = new LoanCalculator(loan);

            // Act
            decimal totalCost = calculator.CalculateTotalCreditCost();

            // Assert
            Assert.Equal(expected, totalCost);
        }

        [Fact]
        public void Test_GenerateAmortizationSchedule()
        {
            // Arrange
            var loan = new Loan(200000, 300, 3.92m);
            var calculator = new LoanCalculator(loan);

            // Act
            List<Payment> payments = calculator.GenerateAmortizationSchedule();

            // Assert
            Assert.Equal(200000, Math.Round(payments.Sum(p => p.PrincipalPaid), 0));
        }
    }
}
