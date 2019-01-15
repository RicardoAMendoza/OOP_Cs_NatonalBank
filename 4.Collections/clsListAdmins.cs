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
    public class clsListAdmins
    {
        /// <summary>
        /// Collection : ListAdmins.
        /// </summary>
        private Dictionary<string, clsAdmin> ListAdmins;
        /// <summary>
        /// Constructor
        /// </summary>
        public clsListAdmins()
        {
            ListAdmins = new Dictionary<string, clsAdmin>();
        }
        /// <summary>
        /// Gets the number of the elements in the dictionary.
        /// </summary>
        public int Quantity
        {
            get { return ListAdmins.Values.Count; }
        }
        /// <summary>
        /// Gets the number of the elements in the dictionary.
        /// </summary>
        public Dictionary<string, clsAdmin>.ValueCollection Elements
        {
            get { return ListAdmins.Values; }
        }
        /// <summary>
        /// Function : fncExist(string number ) -> bool true if the Admin exist.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListAdmins.ContainsKey(number);</returns>
        public bool fncExist(string number)
        {
            return ListAdmins.ContainsKey(number);
        }
        /// <summary>
        /// Function : fncFInd(string number) -> returns an Admin by number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public clsAdmin fncFind(string number)
        {
            if (fncExist(number))
            {
                return ListAdmins[number];
            }
            else { return null; }
        }
        /// <summary>
        /// Function : fncAdd(clsAdmin admin) -> adds ab admin in the Admins list
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool fncAdd(clsAdmin admin)
        {
            if (!fncExist(admin.vNumber))
            {
                ListAdmins.Add(admin.vNumber, admin);
                return true;
            }
            else { return false; }
        }
        public bool fncErase(string number)
        {
            return ListAdmins.Remove(number);
        }
        public clsAdmin clsAdmin
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsAdmin clsAdmin1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
