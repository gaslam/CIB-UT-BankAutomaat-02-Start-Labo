using System;

namespace Bank.Lib
{
    public class BankRekening
    {
        public decimal Balance { get; private set; }

        public BankRekening()
        {
            Balance = 500;
        }

        public BankRekening(decimal beginningBalance)
        {
            Balance = beginningBalance;
        }

        public decimal AddMoneyToBankAccount(decimal money)
        {
            Balance += money;
            return Balance;
        }

        public decimal TakeMoneyFromBankAccount(decimal money)
        {
            Balance -= money;
            return Balance;
        }
    }
}
