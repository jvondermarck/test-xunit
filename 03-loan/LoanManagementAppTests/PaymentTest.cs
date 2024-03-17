using LoanManagementApp;
namespace LoanManagementAppTests;

public class PaymentTest
{
    [Fact]
    public void Test_Payment()
    {
        // Arrange
        int paymentNumber = 1;
        decimal principalPaid = 500;
        decimal remainingBalance = 1500;
        Payment payment = new Payment(paymentNumber, principalPaid, remainingBalance);

        // Act & Assert
        Assert.Equal(paymentNumber, payment.GetPaymentNumber());
        Assert.Equal(principalPaid, payment.GetPrincipalPaid());
        Assert.Equal(remainingBalance, payment.GetRemainingBalance());
    }
}
