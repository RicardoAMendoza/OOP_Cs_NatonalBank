using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class clsListAgencies
    {
        /// <summary>
        /// Collection : ListAgencies.
        /// </summary>
        private Dictionary<string, clsAgency> ListAgencies;
        /// <summary>
        /// Constructor
        /// </summary>
        public clsListAgencies()
        {
            ListAgencies = new Dictionary<string, clsAgency>();
        }
        /// <summary>
        /// Gets the number of the elements in the dictionary.
        /// </summary>
        public int Quantity
        {
            get { return ListAgencies.Values.Count; }
        }
        /// <summary>
        /// Gets the collection of elements in the dictionary
        /// </summary>
        public Dictionary<string, clsAgency>.ValueCollection Elements
        {
            get { return ListAgencies.Values; }
        }
        //  1.Function : Exist
        /// <summary>
        /// Function : fncExist(string agenceNumber) -> bool true if the Agency exist.
        /// </summary>
        /// <param name="agenceNumber"></param>
        /// <returns>ListAgencies.ContainsKey(agenceNumber);</returns>
        public bool fncExist(string agenceNumber)
        {
            return ListAgencies.ContainsKey(agenceNumber);
        }
        //  2.Function : Find
        /// <summary>
        /// Function : fncFind(string agenceNumber) -> returns an Agency by agenceNumber.
        /// </summary>
        /// <param name="agenceNumber"></param>
        /// <returns>ListAgencies[agenceNumber];</returns>
        public clsAgency fncFind(string agenceNumber)
        {
            if (fncExist(agenceNumber))
            {
                return ListAgencies[agenceNumber];
            }
            else
            {
                return null;
            }
        }

        //  3.Function : Add
        /// <summary>
        /// Function : fncAdd(clsAgency agency) -> adds an Agency in the Agency list.
        /// </summary>
        /// <param name="agency"></param>
        /// <returns>ListAgencies.Add(agency.vAgencyNumber, agency) or false</returns>
        public bool fncAdd(clsAgency agency)
        {
            if (!fncExist(agency.vAgencyNumber))
            {
                ListAgencies.Add(agency.vAgencyNumber, agency);
                return true;
            }
            else
            {
                return false;
            }
        }

        //  4.Function : Erase
        /// <summary>
        /// Function : fncErase(string agenceNumber) -> erases an Agency from the list.
        /// </summary>
        /// <param name="agenceNumber"></param>
        /// <returns>ListAgencies.Remove(agenceNumber)</returns>
        public bool fncErase(string agenceNumber)
        {
            return ListAgencies.Remove(agenceNumber);
        }

        //  5.Function : Display
        /// <summary>
        /// Function : fncDisplay() -> display all agencies in ListAgencies.
        /// </summary>
        /// <returns>info;</returns>
        public string fncDisplay()
        {
            string info = "";
            foreach (clsAgency agency in ListAgencies.Values)
            {
                info += agency.fncDisplayAgence();
            }
            return info;
        }

        public clsAgency clsAgency
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsAgency clsAgency1
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
