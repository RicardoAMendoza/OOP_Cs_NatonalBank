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
    public class clsNationalBank
    {
        /// <summary>
        /// Fields
        /// </summary>
        private int IdBank;
        private string BankName;
        private string BankAddress;
        private double BankCapital;
        private clsDirecteur Director;
        private clsListDirecteurs ListDirecteurs = new clsListDirecteurs();
        private clsListAgencies ListAgencies = new clsListAgencies();
        private clsListAdmins ListAdmins = new clsListAdmins();
        private static int staticNbBank;
        /// <summary>
        /// Constructor that takes three arguments and the director list, agencies list and the admin list.
        /// </summary>
        public clsNationalBank(string vBankName, string vBankAddress, double vBankCapital, clsListDirecteurs vListDirecteurs, clsListAgencies vListAgencies, clsListAdmins vListAdmins)
        {
            clsNationalBank.staticNbBank++;
            IdBank = staticNbBank;
            BankName = vBankName;
            BankAddress = vBankAddress;
            BankCapital = vBankCapital;
            ListDirecteurs = vListDirecteurs;
            ListAgencies = vListAgencies;
            ListAdmins = vListAdmins;
        }
        /// <summary>
        /// Constructor that takes three arguments, the director as an object and the director list, agencies list and the admin list.
        /// </summary>
        public clsNationalBank(string vNumber, string vName, string vLastName, double vSalary, string vPhoto, string vBankName, string vBankAddress, double vBankCapital, clsListDirecteurs vListDirecteurs, clsListAgencies vListAgencies, clsListAdmins vListAdmins)
        {
            // constructor director -> Constructor that takes 4 arguments we add the photo to the base,  and add salary in the class.
            Director = new clsDirecteur(vNumber, vName, vLastName, vSalary, vPhoto);

            clsNationalBank.staticNbBank++;
            IdBank = staticNbBank;
            BankName = vBankName;
            BankAddress = vBankAddress;
            BankCapital = vBankCapital;
            ListDirecteurs = vListDirecteurs;
            ListAgencies = vListAgencies;
            ListAdmins = vListAdmins;
        }
        /// <summary>
        /// Constructor that takes three arguments, the director as an object and the director list and agencies list.
        /// </summary>
        public clsNationalBank(string vNumber, string vName, string vLastName, double vSalary, string vPhoto, string vBankName, string vBankAddress, double vBankCapital, clsListDirecteurs vListDirecteurs, clsListAgencies vListAgencies)
        {
            // constructor director -> Constructor that takes 4 arguments we add the photo to the base,  and add salary in the class.
            Director = new clsDirecteur(vNumber, vName, vLastName, vSalary, vPhoto);

            clsNationalBank.staticNbBank++;
            IdBank = staticNbBank;
            BankName = vBankName;
            BankAddress = vBankAddress;
            BankCapital = vBankCapital;
            ListDirecteurs = vListDirecteurs;
            ListAgencies = vListAgencies;

        }
        /// <summary>
        /// Constructor that takes the director as an object and three arguments 
        /// </summary>
        public clsNationalBank(string vNumber, string vName, string vLastName, double vSalary, string vPhoto, string vBankName, string vBankAddress, double vBankCapital)
        {
            // constructor director -> Constructor that takes 4 arguments we add the photo to the base,  and add salary in the class.
            Director = new clsDirecteur(vNumber, vName, vLastName, vSalary, vPhoto);

            clsNationalBank.staticNbBank++;
            IdBank = staticNbBank;
            BankName = vBankName;
            BankAddress = vBankAddress;
            BankCapital = vBankCapital;
            ListDirecteurs = vListDirecteurs;
            ListAgencies = vListAgencies;
            ListAdmins = vListAdmins;
        }
        /// <summary>
        /// Constructor that takes three arguments with out the lists.
        /// </summary>
        public clsNationalBank(string vBankName, string vBankAddress, double vBankCapital)
        {
            clsNationalBank.staticNbBank++;
            IdBank = staticNbBank;
            BankName = vBankName;
            BankAddress = vBankAddress;
            BankCapital = vBankCapital;
        }
        /// <summary>
        /// Constructor that takes no arguments.
        /// </summary>
        public clsNationalBank()
        {
            clsNationalBank.staticNbBank++;
            IdBank = 400 + IdBank;
            BankName = clsDataSource.fncEmptyConstructor();
            BankAddress = clsDataSource.fncEmptyConstructor();
            BankCapital = 0;
            ListDirecteurs = null;
            ListAgencies = null;
            ListAdmins = null;
        }
        /// <summary>
        /// Properties.
        /// </summary>
        public clsDirecteur vDirector
        {
            get { return Director; }
            set { Director = value; }
        }
        public int vIdBank
        {
            get { return IdBank; }
            set { IdBank = value; }
        }

        public string vBankName
        {
            get { return BankName; }
            set { BankName = value; }
        }
        public string vBankAddress
        {
            get { return BankAddress; }
            set { BankAddress = value; }
        }
        public double vBankCapital
        {
            get { return BankCapital; }
            set { BankCapital = value; }
        }
        public clsListDirecteurs vListDirecteurs
        {
            get { return ListDirecteurs; }
            set { ListDirecteurs = value; }
        }
        public clsListAgencies vListAgencies
        {
            get { return ListAgencies; }
            set { ListAgencies = value; }
        }

        public clsListAdmins vListAdmins
        {
            get { return ListAdmins; }
            set { ListAdmins = value; }
        }



        public void fncOpenaBank(string BankName, string BankAddress, double BankCapital, clsListDirecteurs ListDirecteurs, clsListAgencies ListAgencies, clsListAdmins ListAdmins)
        {
            BankName = vBankName;
            BankAddress = vBankAddress;
            BankCapital = vBankCapital;
            ListDirecteurs = vListDirecteurs;
            ListAgencies = vListAgencies;
            ListAdmins = vListAdmins;
        }
        public string fncDisplay()
        {
            string info = "";
            info += "\nBank Name : " + BankName;
            info += "\nBank Address : " + BankAddress;
            info += "\nBank Capital : " + BankCapital;
            info += "\nBank Directeur : " + ListDirecteurs.fncDisplay();
            info += "\nBank Agencies : " + ListAgencies.fncDisplay();
            return info;
        }
        public clsListAgencies clsListAgencies
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListAdmins clsListAdmins
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListDirecteurs clsListDirecteurs
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListAgencies clsListAgencies1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListAdmins clsListAdmins1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsListDirecteurs clsListDirecteurs1
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
