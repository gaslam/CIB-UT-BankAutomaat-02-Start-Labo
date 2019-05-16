using System;
using Bank.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAutomaat.Tests
{
    [TestClass]
    public class BankRekeningTest
    {
        [TestMethod]
        public void TakeMoneyFromBankAccount_WithValidMoney_UpdatesBalance()
        {
            // Arrange
            decimal beginningBalance = 500.95M;
            decimal moneyToTakeFromBankAccount = 100.10M;
            decimal expected = 400.85M;
            BankRekening bankRekening = new BankRekening(beginningBalance);

            // Act
            bankRekening.TakeMoneyFromBankAccount(moneyToTakeFromBankAccount);

            // Assert
            decimal actual = bankRekening.Balance;
            Assert.AreEqual(expected, actual, "Balance is incorrect");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TakeMoneyFromBankAccount_WhenMoneyIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            decimal beginningBalance = 11.99M;
            decimal moneyToTakeFromBankAccount = -20.0M;
            BankRekening bankRekening = new BankRekening(beginningBalance);

            // act  
            bankRekening.TakeMoneyFromBankAccount(moneyToTakeFromBankAccount);

            // assert is handled by ExcpectedException attribute
        }

        [TestMethod]
        public void TakeMoneyFromBankAccount_WhenMoneyIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            decimal beginningBalance = 11.99M;
            decimal moneyToTakeFromBankAccount = 20.0M;
            BankRekening bankRekening = new BankRekening(beginningBalance);

            try
            {
                // act  
                bankRekening.TakeMoneyFromBankAccount(moneyToTakeFromBankAccount);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // assert  
                StringAssert.Contains(ex.Message, BankRekening.MoneyAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown");
        }
    }
}
