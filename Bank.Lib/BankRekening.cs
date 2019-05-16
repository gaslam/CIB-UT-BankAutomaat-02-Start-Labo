using System;
using System.CodeDom;
using System.ComponentModel.Design;

namespace Bank.Lib
{
    public class BankRekening
    {

        public const string MoneyAmountExceedsBalanceMessage = "Er staat niet genoeg geld op je rekening";
        public const string MoneyAmountLessThanZeroMessage = "Het bedrag kan niet kleiner dan 0 zijn.";
        public const string MoneyAmountIsZeroMessage = "Het bedrag kan niet 0 zijn.";
        public const string MoneyAmountGreaterThanMaxMessage = "Het bedrag kan niet groter zijn dan 2000.";

        public const decimal MaxMoney = 2000M;

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
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException("Het bedrag kan niet kleiner zijn dan 0.");
            }

            Balance += money;
            return Balance;
        }

        public decimal TakeMoneyFromBankAccount(decimal money)
        {
            if (money < 0)
            {

                throw new ArgumentOutOfRangeException("Het bedrag kan niet kleiner zijn dan 0.");
            }

            if (money > Balance)
            {
                throw new ArgumentOutOfRangeException("Het bedrag kan niet groter zijn dan de balans.");
            }

            /*throw new ArgumentOutOfRangeException(MoneyAmountLessThanZeroMessage);*/


            if (Balance < money)
            {
                throw new ArgumentOutOfRangeException(MoneyAmountExceedsBalanceMessage);
            }


            Balance -= money;
            return Balance;
        }
    }

}

