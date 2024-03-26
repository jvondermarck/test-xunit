using LoanManagementApp;

namespace LoanManagementAppTests;

public class LoanTest
{
    [Fact]
    public void GetPrincipal_ValidPrincipal_ReturnsPrincipal()
    {
        // Arrange
        var loan = new Loan(1000, 12, 0.1m);
        
        // Act
        var principal = loan.Principal;
        
        // Assert
        Assert.Equal(1000, principal);
    }
    
    [Fact]
    public void GetTermInMonths_ValidTerm_ReturnsTerm()
    {
        // Arrange
        var loan = new Loan(1000, 12, 0.1m);
        
        // Act
        var term = loan.TermInMonths;
        
        // Assert
        Assert.Equal(12, term);
    }
    
    [Fact]
    public void GetAnnualInterestRate_ValidInterestRate_ReturnsInterestRate()
    {
        // Arrange
        var loan = new Loan(1000, 12, 0.1m);
        
        // Act
        var interestRate = loan.AnnualInterestRate;
        
        // Assert
        Assert.Equal(0.1m, interestRate);
    }
}
