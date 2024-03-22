using LoanManagementApp;

namespace LoanManagementAppTests
{
    public class LoanInputHandlerTest
    {
        
        [Fact]
        public void Test_MissingArguments()
        {
            // Arrange
            string[] args = { "--principal", "50000", "--term", "240" };

            // Act
            Action act = () => new LoanInputHandler(args);

            // Assert
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Invalid arguments. Please provide only the principal, term, and rate.\n" +
                         "Example: dotnet run --principal 50000 --term 12 --rate 0.1", exception.Message);
        }

        [Fact]
        public void Test_ParseArguments()
        {
            // Arrange
            string[] args = { "--principal", "50000", "--term", "240", "--rate", "0.1" };

            // Act
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Assert
            Assert.Equal(50000, loanInputHandler.GetPrincipal());
            Assert.Equal(240, loanInputHandler.GetTermInMonths());
            Assert.Equal(0.1m, loanInputHandler.GetAnnualInterestRate());
        }
        
        [Fact]
        public void Test_GetPrincipal()
        {
            // Arrange
            string[] args = { "--principal", "50000", "--term", "0", "--rate", "0"};
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            decimal principal = loanInputHandler.GetPrincipal();

            // Assert
            Assert.Equal(50000, principal);
        }

        [Fact]
        public void Test_GetPrincipal_InvalidLoanAmount()
        {
            // Arrange
            string[] args = { "--principal", "100", "--term", "0", "--rate", "0" };
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
            string[] args = { "--principal","invalid", "--term", "0", "--rate", "0" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetPrincipal();

            // Assert
            var exception = Assert.Throws<FormatException>(act);
            Assert.Equal("The argument 'principal' is not a valid number.", exception.Message);
        }

        [Fact]
        public void Test_GetPrincipal_NegativeInput()
        {
            // Arrange
            string[] args = { "--principal","-100" , "--term", "0", "--rate", "0"};
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetPrincipal();

            // Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("Specified argument was out of the range of valid values. (Parameter 'The argument 'principal' cannot be negative.')", exception.Message);
        }

        [Fact]
        public void Test_GetPrincipal_ValidButTrailingSpaces()
        {
            // Arrange
            string[] args = { "--principal","  500000  ", "--term", "0", "--rate", "0" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            decimal principal = loanInputHandler.GetPrincipal();

            // Assert
            Assert.Equal(500000, principal);
        }

        [Fact]
        public void Test_GetPrincipal_NullInput()
        {
            // Arrange
            string[] args = { "--principal",null!, "--term", "0", "--rate", "0" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetPrincipal();

            // Assert
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Value cannot be null. (Parameter 'The argument 'principal' is required.')", exception.Message);
        }

        [Fact]
        public void Test_GetTermInMonths()
        {
            // Arrange
            string[] args = { "--term", "240", "--rate", "0", "--principal", "0"};
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
            string[] args = { "--term", "50", "--rate", "0", "--principal", "0" };
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
            string[] args = { "--rate", "3.5", "--term", "0", "--principal", "0" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            decimal annualInterestRate = loanInputHandler.GetAnnualInterestRate();

            // Assert
            Assert.Equal(3.5m, annualInterestRate);
        }

        [Fact]
        public void Test_GetAnnualInterestRate_InvalidRate()
        {
            // Arrange
            string[] args = { "--principal", "50000", "--term", "240", "--rate", "122" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetAnnualInterestRate();

            // Assert
            var exception = Assert.Throws<InterestRateException>(act);
            Assert.Equal("The annual interest rate must be between 0 and 100%.", exception.Message);
        }

        [Fact]
        public void Test_GetAnnualInterestRate_InvalidInput()
        {
            // Arrange
            string[] args = { "--principal", "50000", "--term", "240", "--rate", "invalid" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.GetAnnualInterestRate();

            // Assert
            var exception = Assert.Throws<FormatException>(act);
            Assert.Equal("The argument 'rate' is not a valid number.", exception.Message);
        }
    }
}