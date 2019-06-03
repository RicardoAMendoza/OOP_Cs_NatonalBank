using Microsoft.VisualStudio.TestTools.UnitTesting;
using prjWin_NationalBank_Rm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWin_NationalBank_Rm.Tests
{
    [TestClass()]
    public class clsAccountTests
    {
        [TestMethod()]
        // public void fncWithdrawalTest()
        public void fncWithdrawalTestUPA_ValidAmount_ChangesBalance()
        {
            // arrange  
            double currentBalance = 2300.0;
            double withdrawal = 100.0;
            double expected = 2200.0;
            // clsUnpaidAccount(double vBalance, string vNumber, string vType)
            var account = new clsUnpaidAccount(currentBalance, "UA1UA1", "UnpaidAccount");
            // act  
            account.fncWithdrawal(withdrawal);
            double actual = account.vBalance;
            // assert  
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Withdraw_AmountMoreThanBalance_Throws()
        {
            // arrange  
            var account = new clsUnpaidAccount(2300.0, "UA1UA1", "UnpaidAccount");
            // act  
            account.fncWithdrawal(400.0);
            // assert is handled by the ExpectedException  
        }


        [TestMethod()]
        // public void fncWithdrawalTest()
        public void fncDepositTestUPA_ValidDeposit_ChangesBalance()
        {
            // arrange  
            double currentBalance = 2300.0;
            double deposit = 100.0;
            double expected = 2400.0;
            // clsUnpaidAccount(double vBalance, string vNumber, string vType)
            var account = new clsUnpaidAccount(currentBalance, "UA1UA1", "UnpaidAccount");
            // act  
            account.fncDeposit(deposit);
            double actual = account.vBalance;
            // assert  
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        // public void fncWithdrawalTest()
        public void fncWithdrawalTestPA_ValidAmount_ChangesBalance()
        {
            // arrange  
            double currentBalance = 2999.0;
            double withdrawal = 100.0;
            double expected = 2899.0;
            // clsUnpaidAccount(double vBalance, string vNumber, string vType)
            var account = new clsPaidAccount(currentBalance, "PA1PA1", "PaidAccount");
            // act  
            account.fncWithdrawal(withdrawal);
            double actual = account.vBalance;
            // assert  
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        // public void fncWithdrawalTest()
        public void fncDepositTestPA_ValidDeposit_ChangesBalance()
        {
            // arrange  
            double currentBalance = 2999.0;
            double deposit = 100.0;
            double expected = 3099.0;
            // clsUnpaidAccount(double vBalance, string vNumber, string vType)
            var account = new clsPaidAccount(currentBalance, "PA1PA1", "PaidAccount");
            // act  
            account.fncDeposit(deposit);
            double actual = account.vBalance;
            // assert  
            Assert.AreEqual(expected, actual);
        }



        
    }
}