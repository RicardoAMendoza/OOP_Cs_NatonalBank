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
    public class clsClient : clsHuman
    {
        /// <summary>
        /// Fields
        /// </summary>
        private string Address;
        private string Nip;
        private clsEmployee Employee;
        /// <summary>
        /// clsListUnpaidAccounts ListUnpaidAccounts -> List of unpaids accounts
        /// </summary>
        private clsListUnpaidAccounts ListUnpaidAccounts = new clsListUnpaidAccounts();
        /// <summary>
        /// ListPaidAccounts -> List of paid accounts
        /// </summary>
        private clsListPaidAccounts ListPaidAccounts = new clsListPaidAccounts();
        /// <summary>
        /// Client counter
        /// </summary>
        private int clientIdCounter;
        private static int staticNbcounter;
        /// <summary>
        /// Constructor that takes five arguments, one employee as object without the lists.
        /// </summary>
        public clsClient(string vNumber, string vName, string vLastName, string vNip, string vAddress, string vNumberEmp, string vNameEmp, string vLastNameEmp, string vPhoto, int vDay, int vMonth, int vYear) : base(vNumber, vName, vLastName)
        {
            // constructor employee
            Employee = new clsEmployee(vNumberEmp, vNameEmp, vLastNameEmp, vPhoto, vDay, vMonth, vYear);

            clsClient.staticNbcounter++;
            clientIdCounter = staticNbcounter;
            Address = vAddress;
            Nip = vNip;
        }
        /// <summary>
        /// Constructor that takes five arguments with lists.
        /// </summary>
        public clsClient(string vNumber, string vName, string vLastName, string vNip, string vAddress, clsListUnpaidAccounts vListUnpaidAccounts, clsListPaidAccounts vListPaidAccounts) : base(vNumber, vName, vLastName)
        {
            clsClient.staticNbcounter++;
            clientIdCounter = staticNbcounter;
            Address = vAddress;
            Nip = vNip;
            ListUnpaidAccounts = vListUnpaidAccounts;
            ListPaidAccounts = vListPaidAccounts;
        }
        /// <summary>
        /// Constructor that takes five arguments with out the lists.
        /// </summary>
        public clsClient(string vNumber, string vName, string vLastName, string vNip, string vAddress) : base(vNumber, vName, vLastName)
        {
            clsClient.staticNbcounter++;
            clientIdCounter = staticNbcounter;
            Address = vAddress;
            Nip = vNip;
        }
        /// <summary>
        /// Constructor that takes no arguments.
        /// </summary>
        public clsClient() : base()
        {
            clsClient.staticNbcounter++;
            clientIdCounter = staticNbcounter;
            Address = clsDataSource.fncEmptyConstructor();
            Nip = clsDataSource.fncEmptyConstructor();
            Employee = new clsEmployee();
        }
        /// <summary>
        /// Properties.
        /// </summary>
        public int vclientIdCounter
        {
            get { return clientIdCounter; }
        }
        public string vNip
        {
            get { return Nip; }
            set { Nip = value; }
        }
        public string vAddress
        {
            get { return Address; }
            set { Address = value; }
        }
        public clsEmployee vEmployee
        {
            get { return Employee; }
            set { Employee = value; }
        }


        public clsListUnpaidAccounts vListUnpaidAccounts
        {
            get { return ListUnpaidAccounts; }
            set { ListUnpaidAccounts = value; }
        }

        public clsListPaidAccounts vListPaidAccounts
        {
            get { return ListPaidAccounts; }
            set { ListPaidAccounts = value; }
        }
        /// <summary>
        /// Override Methods.
        /// fncCreateaHuman(string vName, string vLastName) -> constructs a Client
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="vLastName"></param>
        public override void fncCreateaHuman(string vName, string vLastName)
        {
            clientIdCounter = vclientIdCounter;
            Nip = vNip;
            Address = vAddress;
            base.fncCreateaHuman(vName, vLastName);
        }
        /// <summary>
        /// Override Methods.
        /// fncDisplayHuman() -> info from a Client and PDF Creation
        /// </summary>
        /// <returns>info</returns>
        public override string fncDisplayHuman()
        {
            string info = "";
            info += "\n\nClient Id : " + clientIdCounter;
            info += base.fncDisplayHuman();
            info += "\nNip : " + Nip;
            info += "\nAdress : " + Address + "\n";
            info += ListUnpaidAccounts.fncDisplay();
            info += ListPaidAccounts.fncDisplay();
            return info;
        }
        public clsListPaidAccounts clsListPaidAccounts
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListUnpaidAccounts clsListUnpaidAccounts
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListUnpaidAccounts clsListUnpaidAccounts1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListPaidAccounts clsListPaidAccounts1
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
