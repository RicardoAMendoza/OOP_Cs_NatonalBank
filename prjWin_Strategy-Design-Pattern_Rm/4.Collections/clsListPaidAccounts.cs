using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWin_NationalBank_Rm
{
    /// <summary>
    /// Ricardo Mendoza
    /// Institut Teccart
    /// www.teccart.qc.ca
    /// Montréal, Québec
    /// Août 2017
    /// </summary>
    public class clsListPaidAccounts
    {
        /// <summary>
        /// Collection : ListPaidAccounts.
        /// </summary>
        // private Dictionary<string, clsAccount> ListPaidAccounts = new Dictionary<string, clsAccount>();
        private Dictionary<string, clsPaidAccount> ListPaidAccounts;
        /// <summary>
        /// Constructor
        /// </summary>
        public clsListPaidAccounts()
        {
            ListPaidAccounts = new Dictionary<string, clsPaidAccount>();
        }
        /// <summary>
        /// Gets the number of the elements in the dictionary.
        /// </summary>
        public int Quantity
        {
            get { return ListPaidAccounts.Values.Count; }
        }
        /// <summary>
        /// Gets the collection of elements in the dictionary
        /// </summary>
        public Dictionary<string, clsPaidAccount>.ValueCollection Elements
        {
            get { return ListPaidAccounts.Values; }
        }

        public clsPaidAccount clsPaidAccount
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsPaidAccount clsPaidAccount1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// Function : fncExist(string number) -> bool true if the Account exist.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListPaidAccounts.ContainsKey(number);</returns>
        public bool fncExist(string number)
        {
            return ListPaidAccounts.ContainsKey(number);
        }
        /// <summary>
        /// Function : fncFind(string number) -> returns an Account by number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListPaidAccounts[number] if there is not object return null</returns>
        public clsAccount fncFind(string number)
        {
            if (fncExist(number) == true)
            {
                return ListPaidAccounts[number];
            }
            else
            {
                // if there is not object return null
                return null;
            }
        }
        /// <summary>
        /// Function : fncAdd(clsAccount account) -> adds an Account in the Account list.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool fncAdd(clsPaidAccount account)
        {
            if (ListPaidAccounts.ContainsKey(account.vNumber))
            {
                return false;
            }
            else
            {
                ListPaidAccounts.Add(account.vNumber, account);
                return true;
            }
        }
        /// <summary>
        /// Function : fncErase(string number) -> erases an Employee from the list.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListPaidAccounts.Remove(number)</returns>
        public bool fncErase(string number)
        {
            return ListPaidAccounts.Remove(number);
        }
        /// <summary>
        /// Function : fncDisplay() -> display all accounts in ListPaidAccounts
        /// </summary>
        /// <returns>info;</returns>
        public string fncDisplay()
        {
            string info = "";
            foreach (clsAccount account in ListPaidAccounts.Values)
            {
                info += account.fncPrintBalance();
            }
            return info;
        }
    }
}
