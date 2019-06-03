using System;
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
    public class clsUnpaidAccount : clsAccount
    {
        /// <summary>
        /// Constructor that takes eigth arguments -> in the Function protected abstract : Charge  commission.
        /// </summary>
        public clsUnpaidAccount(double vCommission, int vOverdraft, string vNumber, string vType, double vBalance, int vDay, int vMonth, int vYear) : base(vCommission, vOverdraft, vNumber, vType, vBalance, vDay, vMonth, vYear)
        { }

        /// <summary>
        /// Constructor that takes no arguments.
        /// </summary>
        public clsUnpaidAccount() : base()
        { }

        /// <summary>
        /// Constructor TEST.
        /// </summary>
        public clsUnpaidAccount(double vBalance, string vNumber, string vType) : base(vNumber, vType, vBalance)
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
        /// <returns>base.fncDeposit(deposit);</returns>
        public override bool fncDeposit(double deposit)
        {
            return base.fncDeposit(deposit);
        }
        /// <summary>
        /// Functions : Withdrawal
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>base.fncWithdrawl(amount);</returns>
        public override int fncWithdrawal(double amount)
        {
            /// <summary>
            /// Function override : Charge  commission
            /// <summary>
            vCommissionCharge = fncChargeComission(amount);
            if (vCommissionCharge > 0)
            {
                MessageBox.Show("a comission of : " + " " + vCommissionCharge.ToString() + " $ " + " has been charged ");
            }
            fncUnpaidAccountCommission(vCommissionCharge);
            return base.fncWithdrawal(amount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vCommissionCharge"></param>
        public override void fncUnpaidAccountCommission(double vCommissionCharge)
        {
            base.fncUnpaidAccountCommission(vCommissionCharge);
        }
        /// <summary>
        /// Function override : Charge  commission
        /// Un CompteNonRemunéré -> clsUnpaidAccount : clsAccount
        /// Est un compte d'un genre spécifique, qui possède une autorisation de découvert (overdraft)
        /// modifiable à tout moment par la banque, les retraits d'argent sont soumis au seuil défini
        /// par la valeur du découvert autorisé.A chaque fois qu'un retrait dépassant le solde (dans la
        /// limite du découvert autorisé) a lieu la banque prélève sur le compte des frais de gestion
        /// de 12% sur le montant du dépassement
        /// </summary>
        protected override double fncChargeComission(double amount)
        {
            if ((vBalance - amount) < vOverdraft)
            {
                return (vOverdraft + amount - vBalance) * vCommission;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Functions : Consultation of the balance 
        /// </summary>
        /// <returns>base.fncPrintBalance();</returns>
        public override string fncPrintBalance()
        {
            return base.fncPrintBalance();
        }
        protected override double fncPayInterest(double montant)
        {
            throw new NotImplementedException();
        }

        // ATARTS TEXT

        public void Test()
        {
            int r = Add(1, 2);
        }

        // ENDS TEXT
    }
}
