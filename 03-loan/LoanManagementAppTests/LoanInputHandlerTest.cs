using LoanManagementApp;

namespace LoanManagementAppTests
{
    public class LoanInputHandlerTest
    {
        [Fact]
        public void Test_GetPrincipal()
        {
            // Arrange
            string[] args = { "50000" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            double principal = loanInputHandler.GetPrincipal();

            // Assert
            Assert.Equal(50000, principal);
        }

        [Fact]
        public void Test_GetPrincipal_InvalidLoanAmount()
        {
            // Arrange
            string[] args = { "100" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetPrincipal();

            // Assert
            var exception = Assert.Throws<LoanAmountException>(act);
            Assert.Equal("The loan amount must be greater than 50,000 euros.", exception.Message);
        }



        [Fact]
        public void Test_GetPrincipal_InvalidInput()
        {
            // Arrange
            string[] args = { "invalid" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetPrincipal();

            // Assert
            var exception = Assert.Throws<FormatException>(act);
            Assert.Equal("One of the identified items was in an invalid format.", exception.Message);
        }

        [Fact]
        public void Test_GetPrincipal_NegativeInput()
        {
            // Arrange
            string[] args = { "-100" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetPrincipal();

            // Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("Specified argument was out of the range of valid values.", exception.Message);
        }

        [Fact]
        public void Test_GetPrincipal_ValidButTrailingSpaces()
        {
            // Arrange
            string[] args = { "  500000  " };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            double principal = loanInputHandler.GetPrincipal();

            // Assert
            Assert.Equal(500000, principal);
        }

        [Fact]
        public void Test_GetPrincipal_NullInput()
        {
            // Arrange
            string[] args = { null! };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetPrincipal();

            // Assert
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Value cannot be null.", exception.Message);
        }

        [Fact]
        public void Test_GetTermInMonths()
        {
            // Arrange
            string[] args = { "50000", "240" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            int termInMonths = loanInputHandler.GetTermInMonths();

            // Assert
            Assert.Equal(240, termInMonths);
        }

        [Fact]
        public void Test_GetTermInMonths_InvalidTerm()
        {
            // Arrange
            string[] args = { "50000", "50" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetTermInMonths();

            // Assert
            var exception = Assert.Throws<LoanTermException>(act);
            Assert.Equal("The loan term must be between 108 and 300 months.", exception.Message);
        }

        [Fact]
        public void Test_GetAnnualInterestRate()
        {
            // Arrange
            string[] args = { "50000", "240", "3.5" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            double annualInterestRate = loanInputHandler.GetAnnualInterestRate();

            // Assert
            Assert.Equal(3.5, annualInterestRate);
        }

        [Fact]
        public void Test_GetAnnualInterestRate_InvalidRate()
        {
            // Arrange
            string[] args = { "50000", "240", "122" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetAnnualInterestRate();

            // Assert
            var exception = Assert.Throws<InterestRateException>(act);
            Assert.Equal("The annual interest rate must be between 0 and 100%.", exception.Message);
        }
    }
}