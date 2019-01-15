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
    /// /// http://www.teccart.qc.ca/
    /// Montréal, Québec
    /// Août 2017
    /// </summary>
    public class clsAgency
    {
        private string AgencyNumber;
        private string AgencyName;
        private string AgencyAddress;
        private int agencyIdCounter;
        private static int staticNbcounter;
        /// <summary>
        /// Objet number Agency type 
        /// </summary>
        public static int nbAgency;

        /// <summary>
        /// Clients list in the Agence.
        /// </summary>
        private clsListClients ListClients = new clsListClients();
        /// <summary>
        /// Employees list in the agence.
        /// </summary>
        private clsListEmployees ListEmployees = new clsListEmployees();
        /// <summary>
        /// Constructor that takes 3 arguments and two lists.
        /// </summary>
        /// <param name="vAgencyNumber"></param>
        /// <param name="vAgencyName"></param>
        /// <param name="vAgencyAddress"></param>
        /// <param name="vListClients"></param>
        /// <param name="vListEmployees"></param>
        public clsAgency(string vAgencyNumber, string vAgencyName, string vAgencyAddress, clsListClients vListClients, clsListEmployees vListEmployees)
        {
            clsAgency.staticNbcounter++;
            agencyIdCounter = staticNbcounter - 1;
            nbAgency++;
            AgencyNumber = vAgencyNumber;
            AgencyName = vAgencyName;
            AgencyAddress = vAgencyAddress;
            ListClients = vListClients;
            ListEmployees = vListEmployees;
        }
        /// <summary>
        /// Constructor that takes 3 arguments without lists
        /// </summary>
        /// <param name="vAgencyNumber"></param>
        /// <param name="vAgencyName"></param>
        /// <param name="vAgencyAddress"></param>
        public clsAgency(string vAgencyNumber, string vAgencyName, string vAgencyAddress)
        {
            clsAgency.staticNbcounter++;
            agencyIdCounter = staticNbcounter - 1;
            nbAgency++;
            ///  public static clsListAgencies fncGetAgencies()
            AgencyNumber = vAgencyNumber;
            AgencyName = vAgencyName;
            AgencyAddress = vAgencyAddress;
        }
        /// <summary>
        /// Constructor empty
        /// </summary>
        public clsAgency()
        {
            clsAgency.staticNbcounter++;
            agencyIdCounter = staticNbcounter - 1;
            nbAgency++;
            AgencyNumber = clsDataSource.fncEmptyConstructor();
            AgencyName = clsDataSource.fncEmptyConstructor();
            AgencyAddress = clsDataSource.fncEmptyConstructor();
        }
        /// <summary>
        /// Properties.
        /// </summary>
        public int vagencyIdCounter
        {
            get { return agencyIdCounter; }
        }
        public int vnbAgency
        {
            get { return nbAgency; }
        }
        public string vAgencyNumber
        {
            get { return AgencyNumber; }
            set { AgencyNumber = value; }
        }
        public string vAgencyName
        {
            get { return AgencyName; }
            set { AgencyName = value; }
        }
        public string vAgencyAddress
        {
            get { return AgencyAddress; }
            set { AgencyAddress = value; }
        }
        public clsListClients vListClients
        {
            get { return ListClients; }
            set { ListClients = value; }
        }

        public clsListEmployees vListEmployees
        {
            get { return ListEmployees; }
            set { ListEmployees = value; }
        }

        public clsListClients clsListClients
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListEmployees clsListEmployees
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListClients clsListClients1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListEmployees clsListEmployees1
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
        /// fncOpenAgence() -> Open a new agence.
        /// </summary>
        /// <param name="vAgencyNumber"></param>
        /// <param name="vAgencyName"></param>
        /// <param name="vAgencyAddress"></param>
        /// <param name="vListClients"></param>
        /// <param name="vListEmployees"></param>
        public void fncOpenAgence(string vAgencyNumber, string vAgencyName, string vAgencyAddress, clsListClients vListClients, clsListEmployees vListEmployees)
        {
            AgencyNumber = vAgencyNumber;
            AgencyName = vAgencyName;
            AgencyAddress = vAgencyAddress;
            ListClients = vListClients;
            ListEmployees = vListEmployees;
        }

        public string fncDisplayAgence()
        {
            string info = "";
            info += "Agence Number : " + AgencyNumber;
            info += "Agence Name : " + AgencyName;
            info += "Agence Address : " + AgencyAddress;
            info += "Clients : " + ListClients.fncDisplay();
            info += "Employees : " + ListEmployees.fncDisplay();
            return info;
        }
    }
}
