using System;
using Bank.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAutomaat.Tests
{
    [TestClass]
    public class BankrekeningTest
    {
        [TestMethod]
        public void TakeMoneyFromBankAccount_withValueMoney_UpdateBalance()
        {

                //Arrange
                decimal beginningBalance = 500.95m;
                decimal moneyToTakeFrombankAccount = 100.10m;
                decimal expected = 400.85m;
                BankRekening bankRekening = new BankRekening(beginningBalance);

                //Act

                bankRekening.TakeMoneyFromBankAccount(moneyToTakeFrombankAccount);

                //Assert
                decimal actual = bankRekening.Balance;
                Assert.AreEqual(expected, actual, "Balance is incorrect");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TakeMoneyFromBankAccount_WhenMoneyIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            decimal beginningBalance = 12.00m;
            decimal moneyToTakeFrombankAccount = -20.00m;
            BankRekening bankRekening = new BankRekening(beginningBalance);
            
            //Act
            bankRekening.TakeMoneyFromBankAccount(moneyToTakeFrombankAccount);

            //Assert
            //is handled by ExpectedException
        }

        [TestMethod]
        public void TakeMoneyFromBankAccount_WhenMoneyIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            decimal beginningBalance = 12.00m;
            decimal moneyToTakeFrombankAccount = 20.00m;
            BankRekening bankRekening = new BankRekening(beginningBalance);
            try
            {
                //Act
                bankRekening.TakeMoneyFromBankAccount(moneyToTakeFrombankAccount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //Assert
                return;
            }

            Assert.Fail("No exception was thrown.");




            //is handled by ExpectedException
        }

        [TestMethod]
        public void AddMoneyToBankAccount_withValueMoney_UpdateBalance()
        {
            //Arrange
            decimal beginningBalance = 500.95m;
            decimal MoneyToAdd = 12.00m;
            decimal expected = 512.95m;

            BankRekening bankRekening = new BankRekening(beginningBalance);

            //Act

            bankRekening.AddMoneyToBankAccount(MoneyToAdd);

            //Assert

            decimal actual = bankRekening.Balance;
            Assert.AreEqual(expected, actual, "Balance is incorrect");
        }

        [TestMethod]
        public void AddMoneyToBankAccount_WhenMoneyIsLessThanZero()
        {
            //Arrange
            try
            {
                decimal beginningBalance = 20.95m;
                decimal MoneyToAdd = -12.00m;

                BankRekening bankRekening = new BankRekening(beginningBalance);

                //Act
                bankRekening.AddMoneyToBankAccount(MoneyToAdd);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, BankRekening.MoneyAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void AddMoneyToBankAccount_WhenMoneyMoreThanMax()
        {
            //Arrange
            try
            {
                decimal beginningBalance = 20.95m;
                decimal MoneyToAdd = 2001.00m;

                BankRekening bankRekening = new BankRekening(beginningBalance);

                //Act
                bankRekening.AddMoneyToBankAccount(MoneyToAdd);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, BankRekening.MoneyAmountGreaterThanMaxMessage);
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void AddMoneyToBankAccount_WhenMoneyIsZero()
        {
            try
            {
                //Arrange
                decimal beginningBalance = 20.95m;
                decimal moneyToAdd = 00.00m;
                decimal expected = 20.95m;

                BankRekening bankRekening = new BankRekening(beginningBalance);

                //Act
                bankRekening.AddMoneyToBankAccount(moneyToAdd);

                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, BankRekening.MoneyAmountIsZeroMessage);
                return;
            }

            Assert.Fail("No exception was thrown.");
        }
    }
}
