﻿using LoadManagementAppDomain;

namespace LoanManagementApp;

public class LoanCalculator
{
    private Loan loan;
    private const int MonthsInYear = 12;

    public LoanCalculator(Loan loan)
    {
        this.loan = loan;
    }

    public decimal CalculateMonthlyPayment()
    {
        decimal monthlyInterestRate = ConvertAnnualInterestRateToMonthlyInterestRate();
        TermInMonths termInMonths = loan.TermInMonths;
        Principal principal = loan.Principal;

        decimal rawMonthlyPayment = principal.Value * (monthlyInterestRate / (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -termInMonths.Value)));

        return Math.Round(rawMonthlyPayment, 2, MidpointRounding.ToZero);
    }

    public List<Payment> GenerateAmortizationSchedule()
    {
        List<Payment> payments = new List<Payment>();
        decimal remainingBalance = loan.Principal.Value;
        decimal monthlyPayment = CalculateMonthlyPayment();
        decimal monthlyInterestRate = ConvertAnnualInterestRateToMonthlyInterestRate();

        for (int i = 1; i <= loan.TermInMonths.Value; i++)
        {
            decimal interestPaid = remainingBalance * monthlyInterestRate;
            decimal principalPaid = monthlyPayment - interestPaid;
            
            if (i == loan.TermInMonths.Value)
            {
                principalPaid = remainingBalance;
                remainingBalance = 0;
            }
            else
            {
                remainingBalance -= principalPaid;
            }

            payments.Add(new Payment(i, principalPaid, remainingBalance));
        }

        return payments;
    }

    private decimal ConvertAnnualInterestRateToMonthlyInterestRate()
    {
        return loan.AnnualInterestRate.Value / 100 / MonthsInYear;
    }

    public decimal  CalculateTotalCreditCost()
    {
        decimal rawTotalCost = CalculateMonthlyPayment() * loan.TermInMonths.Value;
        return Math.Round(rawTotalCost, 2, MidpointRounding.AwayFromZero);
    }
}