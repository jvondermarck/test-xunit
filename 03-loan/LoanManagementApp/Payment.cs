namespace LoanManagementApp;

public class Payment
{
    private int _paymentNumber;
    private double _principalPaid;
    private double _remainingBalance;

    public Payment(int paymentNumber, double principalPaid, double remainingBalance)
    {
        _paymentNumber = paymentNumber;
        _principalPaid = principalPaid;
        _remainingBalance = remainingBalance;
    }

    public int GetPaymentNumber()
    {
        return _paymentNumber;
    }

    public double GetPrincipalPaid()
    {
        return _principalPaid;
    }

    public double GetRemainingBalance()
    {
        return _remainingBalance;
    }
}
