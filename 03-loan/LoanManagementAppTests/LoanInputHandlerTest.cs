using LoanManagementApp;

namespace LoanManagementAppTests
{
    public class LoanInputHandlerTest
    {
        [Fact]
        public void Test_GetPrincipal()
        {
            // Arrange
            string[] args = { "1000" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            double principal = loanInputHandler.getPrincipal();

            // Assert
            Assert.Equal(1000, principal);
        }

        [Fact]
        public void Test_GetPrincipal_InvalidInput()
        {
            // Arrange
            string[] args = { "invalid" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            Action act = () => loanInputHandler.getPrincipal();

            // Assert
            var exception = Assert.Throws<FormatException>(act);
            Assert.Equal("Input string was not in a correct format.", exception.Message);
        }
    }
}