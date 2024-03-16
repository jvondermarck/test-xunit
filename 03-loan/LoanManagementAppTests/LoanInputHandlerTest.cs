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
    }
}