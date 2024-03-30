using LoadManagementAppDomain;
using LoanManagementApp;

namespace LoanManagementAppTests
{
    public class LoanCalculatorTest
    {
        [Theory]
        [InlineData(200000, 300, 3.92, 1046.85)]
        [InlineData(200000, 180, 0.85, 1183.84)]
        [InlineData(150000, 240, 2, 758.82)]
        public void Test_CalculateMonthlyPayment(decimal amount, int term, decimal rate, decimal expected)
        {
            // Arrange
            var principal = new Principal(amount);
            var duration = new TermInMonths(term);
            var interestRate = new AnnualInterestRate(rate);
            var loan = new Loan(principal, duration, interestRate);
            var calculator = new LoanCalculator(loan);

            // Act
            decimal monthlyPayment = calculator.CalculateMonthlyPayment();

            // Assert
            Assert.Equal(expected, monthlyPayment);
        }

        [Theory]
        [InlineData(200000, 300, 3.92, 314055.00)]
        [InlineData(300000, 240, 1.20, 337586.40)]
        [InlineData(150000, 240, 2, 182116.80)]
        public void Test_GetCalculateTotalCreditCost(decimal amount, int term, decimal rate, decimal expected)
        {
            // Arrange
            var principal = new Principal(amount);
            var duration = new TermInMonths(term);
            var interestRate = new AnnualInterestRate(rate);
            var loan = new Loan(principal, duration, interestRate);
            var calculator = new LoanCalculator(loan);

            // Act
            decimal totalCost = calculator.CalculateTotalCreditCost();

            // Assert
            Assert.Equal(expected, totalCost);
        }

        [Theory]
        [InlineData(200000, 300, 3.92)]
        [InlineData(300000, 240, 1.20)]
        [InlineData(150000, 240, 2)]
        public void Test_GenerateAmortizationSchedule(decimal amount, int term, decimal rate)
        {
            // Arrange
            var principal = new Principal(amount);
            var duration = new TermInMonths(term);
            var interestRate = new AnnualInterestRate(rate);
            var loan = new Loan(principal, duration, interestRate);
            var calculator = new LoanCalculator(loan);

            // Act
            var payments = calculator.GenerateAmortizationSchedule();

            // Assert
            Assert.Equal(term, payments.Count);
        }
    }
}
