using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWin_NationalBank_Rm
{
    /*
    * This project uses the following licenses:
    *  MIT License
    *  Copyright (c) 2017 Ricardo Mendoza 
    *  Montréal Québec Canada
    *  Institut Teccart
    *  www.teccart.qc.ca
    *  Août 2017
    */
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
        /// <param name="deposit">double deposit</param>
        /// <returns>base.fncDeposit(deposit)</returns>
        public override bool fncDeposit(double deposit)
        {
            // 2.- Interest payment calcul
            vInterestPayment = fncPayInterest(deposit);
            // 3.- Add interest to the balance
            fncPaidAccountPayInterest(vInterestPayment);
            MessageBox.Show("an interest of : " + "  " + vInterestPayment.ToString() + " $ " + " has been paid ");
            return base.fncDeposit(deposit);
        }
        public override void fncPaidAccountPayInterest(double vInterestPayment)
        {
            base.fncPaidAccountPayInterest(vInterestPayment);
        }
        /// <summary>
        /// Function that returns the total inerest in the deposit
        /// </summary>
        /// <returns>vInterestPayment</returns>
        public double fncInterestComission()
        {
            return vInterestPayment;
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
