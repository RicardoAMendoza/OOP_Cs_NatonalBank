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
    /// /// http://www.teccart.qc.ca/
    /// Montréal, Québec
    /// Août 2017
    /// </summary>
    public class clsEmployee : clsHuman
    {
        /// <summary>
        /// Fields
        /// </summary>
        clsDate HiringDate;
        /// <summary>
        /// Employee counter
        /// </summary>
        private int employeeIdCounter;
        private static int staticNbcounter;
        /// <summary>
        /// Objet number Admin type 
        /// </summary>
        public static int nbEmployee;
        /// <summary>
        /// Constructor that takes seven arguments we add the photo to the base. without the lists in the class.
        /// </summary>
        public clsEmployee(string vNumber, string vName, string vLastName, string vPhoto, int vDay, int vMonth, int vYear) : base(vNumber, vName, vLastName, vPhoto)
        {
            clsEmployee.staticNbcounter++;
            employeeIdCounter = staticNbcounter;
            nbEmployee++;
            HiringDate = new clsDate(vDay, vMonth, vYear);
        }
        /// <summary>
        /// Constructor that takes six arguments without the lists.
        /// </summary>
        public clsEmployee(string vNumber, string vName, string vLastName, int vDay, int vMonth, int vYear) : base(vNumber, vName, vLastName)
        {
            clsEmployee.staticNbcounter++;
            employeeIdCounter = staticNbcounter;
            nbEmployee++;
            HiringDate = new clsDate(vDay, vMonth, vYear);
        }

        /// <summary>
        /// Constructor that takes no arguments.
        /// </summary>
        public clsEmployee() : base()
        {
            clsEmployee.staticNbcounter++;
            employeeIdCounter = staticNbcounter;
            nbEmployee++;
            HiringDate = new clsDate();
        }
        /// <summary>
        /// Properties.
        /// </summary>
        public int vemployeeIdCounter
        {
            get { return employeeIdCounter; }
        }
        public int vnbEmployee
        {
            get { return nbEmployee; }
        }
        public clsDate vHiringDate
        {
            get { return HiringDate; }
            set { HiringDate = value; }
        }
        /// <summary>
        /// Virtual Methods.
        /// fncCreateaHuman(string vName, string vLastName) -> constructs a human 
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="vLastName"></param>
        public override void fncCreateaHuman(string vName, string vLastName)
        {
            employeeIdCounter = vemployeeIdCounter;
            base.fncCreateaHuman(vName, vLastName);
        }
        /// Override Methods.
        /// fncDisplayHuman() -> info from a human.
        /// </summary>
        /// <returns>info</returns>
        public override string fncDisplayHuman()
        {
            string info = "";
            info += "\nId : " + employeeIdCounter;
            info += base.fncDisplayHuman();
            return info;
        }
        public clsDate clsDate
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsDate clsDate1
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
