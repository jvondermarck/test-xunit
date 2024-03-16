using LoanManagementApp;

namespace LoanManagementAppTests;

public class LoanTest
{
    [Fact]
    public void GetPrincipal_ValidPrincipal_ReturnsPrincipal()
    {
        // Arrange
        var loan = new Loan(1000, 12, 0.1);
        
        // Act
        var principal = loan.GetPrincipal();
        
        // Assert
        Assert.Equal(1000, principal);
    }
    
    [Fact]
    public void GetTermInMonths_ValidTerm_ReturnsTerm()
    {
        // Arrange
        var loan = new Loan(1000, 12, 0.1);
        
        // Act
        var term = loan.GetTermInMonths();
        
        // Assert
        Assert.Equal(12, term);
    }
    
    [Fact]
    public void GetAnnualInterestRate_ValidInterestRate_ReturnsInterestRate()
    {
        // Arrange
        var loan = new Loan(1000, 12, 0.1);
        
        // Act
        var interestRate = loan.GetAnnualInterestRate();
        
        // Assert
        Assert.Equal(0.1, interestRate);
    }
}
