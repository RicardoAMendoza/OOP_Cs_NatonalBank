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
    public class clsListUnpaidAccounts
    {
        /// <summary>
        /// Collection : ListUnpaidAccounts.
        /// </summary>
        // private Dictionary<string, clsAccount> ListUnpaidAccounts = new Dictionary<string, clsAccount>();
        private Dictionary<string, clsUnpaidAccount> ListUnpaidAccounts;
        /// <summary>
        /// Constructor
        /// </summary>
        public clsListUnpaidAccounts()
        {
            ListUnpaidAccounts = new Dictionary<string, clsUnpaidAccount>();
        }
        /// <summary>
        /// Gets the number of the elements in the dictionary.
        /// </summary>
        public int Quantity
        {
            get { return ListUnpaidAccounts.Values.Count; }
        }
        /// <summary>
        /// Gets the collection of elements in the dictionary
        /// </summary>
        public Dictionary<string, clsUnpaidAccount>.ValueCollection Elements
        {
            get { return ListUnpaidAccounts.Values; }
        }

        public clsUnpaidAccount clsUnpaidAccount
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsUnpaidAccount clsUnpaidAccount1
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
        /// <returns>ListUnpaidAccounts.ContainsKey(number);</returns>
        public bool fncExist(string number)
        {
            return ListUnpaidAccounts.ContainsKey(number);
        }
        /// <summary>
        /// Function : fncFind(string number) -> returns an Account by number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListUnpaidAccounts[number] if there is not object return null</returns>
        public clsAccount fncFind(string number)
        {
            if (fncExist(number) == true)
            {
                return ListUnpaidAccounts[number];
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
        public bool fncAdd(clsUnpaidAccount account)
        {
            if (ListUnpaidAccounts.ContainsKey(account.vNumber))
            {
                return false;
            }
            else
            {
                ListUnpaidAccounts.Add(account.vNumber, account);
                return true;
            }
        }
        /// <summary>
        /// Function : fncErase(string number) -> erases an Employee from the list.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListUnpaidAccounts.Remove(number)</returns>
        public bool fncErase(string number)
        {
            return ListUnpaidAccounts.Remove(number);
        }
        /// <summary>
        /// Function : fncDisplay() -> display all accounts in ListUnpaidAccounts
        /// </summary>
        /// <returns>info;</returns>
        public string fncDisplay()
        {
            string info = "";
            foreach (clsAccount account in ListUnpaidAccounts.Values)
            {
                info += account.fncPrintBalance();
            }
            return info;
        }
    }
}
