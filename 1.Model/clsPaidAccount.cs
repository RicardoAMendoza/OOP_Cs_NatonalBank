﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWin_NationalBank_Rm
{
    /// <summary>
    /// Ricardo Mendoza
    /// Strategy Design Patern
    /// Institut Teccart
    /// www.teccart.qc.ca
    /// Montréal, Québec
    /// Août 2017
    /// </summary>
    public class clsPaidAccount : clsAccount
    {

        /// <summary>
        /// Constructor that takes seven arguments -> in the Function protected abstract : Pay interest.
        /// </summary>
        public clsPaidAccount(double vInterestRate, string vNumber, string vType, double vBalance, int vDay, int vMonth, int vYear) : base(vInterestRate, vNumber, vType, vBalance, vDay, vMonth, vYear)
        { }
        /// <summary>
        /// Constructor that takes no arguments.
        /// </summary>
        public clsPaidAccount() : base()
        { }
        /// <summary>
        /// Functions : Open Account
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="Type"></param>
        public override void fncOpenAccount(string Number, string Type)
        {
            base.fncOpenAccount(Number, Type);
        }
        /// <summary>
        /// Functions : Deposit 
        /// </summary>
        /// <param name="deposit"></param>
        /// <returns></returns>
        public override bool fncDeposit(double deposit)
        {
            vInterestPayment = fncPayInterest(deposit);
            fncPaidAccountPayInterest(vInterestPayment);
            MessageBox.Show("an interest of : " + " " + vInterestPayment.ToString() + " $ " + " has been paid ");
            return base.fncDeposit(deposit);
        }
        public override void fncPaidAccountPayInterest(double vInterestPayment)
        {
            base.fncPaidAccountPayInterest(vInterestPayment);
        }
        /// <summary>
        /// Functions : Withdrawal
        /// </summary>
        /// <param name="withdrawal"></param>
        /// <returns></returns>
        public override int fncWithdrawal(int withdrawal)
        {
            return base.fncWithdrawal(withdrawal);
        }
        /// <summary>
        /// Functions : Consultation of the balance 
        /// </summary>
        /// <returns></returns>
        public override string fncPrintBalance()
        {
            return base.fncPrintBalance();
        }
        /// <summary>
        /// Functions : Pay interest
        /// Un CompteRemunéré:
        /// Est un compte d'un genre spécifique, qui rémunère les sommes déposées selon une
        /// formule dépendant d'un taux d'intérêt proposé et modifiable par la banque.Nous
        /// supposerons que la banque est une bonne institution car elle crédite le compte, pour tout
        /// dépôt, d'un intérêt immédiat sur la somme déposée.
        /// </summary>
        protected override double fncPayInterest(double deposit)
        {
            return deposit * vInterestRate;
        }
        protected override double fncChargeComission(int withdrawal)
        {
            throw new NotImplementedException();
        }
    }
}
