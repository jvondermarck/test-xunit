using LoanManagementApp;

namespace LoanManagementAppTests
{
    public class LoanInputHandlerTest
    {
        [Fact]
        public void Test_GetPrincipal()
        {
            // Arrange
            String[] args = new String[] { "1000" };
            LoanInputHandler loanInputHandler = new LoanInputHandler(args);

            // Act
            double principal = loanInputHandler.getPrincipal();

            // Assert
            Assert.Equal(1000, principal);
        }
    }
}