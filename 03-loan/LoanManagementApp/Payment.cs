namespace LoanManagementApp
{
    public class Payment
    {
        public int PaymentNumber { get; private set; }
        public decimal PrincipalPaid { get; private set; }
        public decimal RemainingBalance { get; private set; }

        public Payment(int paymentNumber, decimal principalPaid, decimal remainingBalance)
        {
            PaymentNumber = paymentNumber;
            PrincipalPaid = principalPaid;
            RemainingBalance = remainingBalance;
        }
    }
}
