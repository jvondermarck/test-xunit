namespace LoanManagementApp;

public class Payment
{
    private int _paymentNumber;
    private decimal _principalPaid;
    private decimal _remainingBalance;

    public Payment(int paymentNumber, decimal  principalPaid, decimal  remainingBalance)
    {
        _paymentNumber = paymentNumber;
        _principalPaid = principalPaid;
        _remainingBalance = remainingBalance;
    }

    public int GetPaymentNumber()
    {
        return _paymentNumber;
    }

    public decimal GetPrincipalPaid()
    {
        return _principalPaid;
    }

    public decimal GetRemainingBalance()
    {
        return _remainingBalance;
    }
}
