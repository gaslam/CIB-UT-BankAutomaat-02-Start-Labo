using System;
<<<<<<< HEAD
using System.ComponentModel.Design;
=======
>>>>>>> 113f1caa99d2b9aaac19443d1a59b6f77aeeb791

namespace Bank.Lib
{
    public class BankRekening
    {
<<<<<<< HEAD
=======
        public const string MoneyAmountExceedsBalanceMessage = "Er staat niet genoeg geld op je rekening";
        public const string MoneyAmountLessThanZeroMessage = "Het bedrag kan niet kleiner dan 0 zijn.";
        public const string MoneyAmountIsZeroMessage = "Het bedrag kan niet 0 zijn.";
        public const string MoneyAmountGreaterThanMaxMessage = "Het bedrag kan niet groter zijn dan 2000.";

        public const decimal MaxMoney = 2000M;

>>>>>>> 113f1caa99d2b9aaac19443d1a59b6f77aeeb791
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
            if (money < 0)
            {
<<<<<<< HEAD
                throw new ArgumentOutOfRangeException("Het bedrag kan niet kleiner zijn dan 0.");
            }

            if (money > Balance)
            {
                throw new ArgumentOutOfRangeException("Het bedrag kan niet groter zijn dan de balans.");
            }
=======
                throw new ArgumentOutOfRangeException(MoneyAmountLessThanZeroMessage);
            }

            if (Balance < money)
            {
                throw new ArgumentOutOfRangeException(MoneyAmountExceedsBalanceMessage);
            }

>>>>>>> 113f1caa99d2b9aaac19443d1a59b6f77aeeb791
            Balance -= money;
            return Balance;
        }
    }
}
