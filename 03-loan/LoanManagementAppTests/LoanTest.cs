using LoadManagementAppDomain;
using LoanManagementApp;

namespace LoanManagementAppTests;

public class LoanTest
{
    [Fact]
    public void GetPrincipal_ValidPrincipal_ReturnsPrincipal()
    {
        // Arrange
        var principal = new Principal(50000);
        var duration = new TermInMonths(200);
        var interestRate = new AnnualInterestRate(0.1m);
        var loan = new Loan(principal, duration, interestRate);
        
        // Act
        var principalExpected = loan.Principal.Value;
        
        // Assert
        Assert.Equal(50000, principalExpected);
    }
    
    [Fact]
    public void GetTermInMonths_ValidTerm_ReturnsTerm()
    {
        // Arrange
        var principal = new Principal(50000);
        var duration = new TermInMonths(200);
        var interestRate = new AnnualInterestRate(0.1m);
        var loan = new Loan(principal, duration, interestRate);
        
        // Act
        var term = loan.TermInMonths.Value;
        
        // Assert
        Assert.Equal(200, term);
    }
    
    [Fact]
    public void GetAnnualInterestRate_ValidInterestRate_ReturnsInterestRate()
    {
        // Arrange
        var principal = new Principal(50000);
        var duration = new TermInMonths(200);
        var interestRate = new AnnualInterestRate(0.1m);
        var loan = new Loan(principal, duration, interestRate);
        
        // Act
        var interestRateExpected = loan.AnnualInterestRate.Value;
        
        // Assert
        Assert.Equal(0.1m, interestRateExpected);
    }
}
