using LoanManagementApp;
namespace LoanManagementAppTests;

public class PaymentTest
{
    [Fact]
    public void Test_Payment_GetPaymentNumber()
    {
        // Arrange
        int paymentNumber = 1;
        decimal principalPaid = 500;
        decimal remainingBalance = 1500;
        Payment payment = new Payment(paymentNumber, principalPaid, remainingBalance);

        // Act & Assert
        Assert.Equal(paymentNumber, payment.GetPaymentNumber());
    }

    [Fact]
    public void Test_Payment_GetPrincipalPaid()
    {
        // Arrange
        int paymentNumber = 1;
        decimal principalPaid = 500;
        decimal remainingBalance = 1500;
        Payment payment = new Payment(paymentNumber, principalPaid, remainingBalance);

        // Act & Assert
        Assert.Equal(principalPaid, payment.GetPrincipalPaid());
    }

    [Fact]
    public void Test_Payment_GetRemainingBalance()
    {
        // Arrange
        int paymentNumber = 1;
        decimal principalPaid = 500;
        decimal remainingBalance = 1500;
        Payment payment = new Payment(paymentNumber, principalPaid, remainingBalance);

        // Act & Assert
        Assert.Equal(remainingBalance, payment.GetRemainingBalance());
    }


}
