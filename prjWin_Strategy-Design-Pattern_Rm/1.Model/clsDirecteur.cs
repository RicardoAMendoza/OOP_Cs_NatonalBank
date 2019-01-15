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
    /// http://www.teccart.qc.ca/
    /// Montréal, Québec
    /// Août 2017
    /// </summary>
    public class clsDirecteur : clsHuman
    {
        private double Salary;
        private int directorIdCounter;
        private static int staticNbcounter;
        /// <summary>
        /// Objet number Admin type 
        /// </summary>
        public static int nbDirector;
        /// <summary>
        /// Constructor that takes 4 arguments we add the photo to the base,  and add salary in the class.
        /// </summary>
        /// <param name="vNumber"></param>
        /// <param name="vName"></param>
        /// <param name="vLastName"></param>
        /// <param name="vSalary"></param>
        /// <param name="vPhoto"></param>
        public clsDirecteur(string vNumber, string vName, string vLastName, double vSalary, string vPhoto) : base(vNumber, vName, vLastName, vPhoto)
        {
            clsDirecteur.staticNbcounter++;
            directorIdCounter = staticNbcounter;
            nbDirector++;
            Salary = vSalary;
        }
        /// <summary>
        /// Constructor that takes 3 arguments from the base and add salary.
        /// </summary>
        /// <param name="vNumber"></param>
        /// <param name="vName"></param>
        /// <param name="vLastName"></param>
        /// <param name="vSalary"></param>
        public clsDirecteur(string vNumber, string vName, string vLastName, double vSalary) : base(vNumber, vName, vLastName)
        {
            clsDirecteur.staticNbcounter++;
            directorIdCounter = staticNbcounter;
            nbDirector++;
            Salary = vSalary;
        }
        /// <summary>
        /// Constructor empty
        /// </summary>
        public clsDirecteur() : base()
        {
            clsDirecteur.staticNbcounter++;
            directorIdCounter = staticNbcounter;
            nbDirector++;
            Salary = 0;
        }
        /// <summary>
        /// Properties.
        /// </summary>
        public int vdirectorIdCounter
        {
            get { return directorIdCounter; }
        }
        public int vnbDirector
        {
            get { return nbDirector; }
        }

        public double vSalary
        {
            get { return Salary; }
            set { Salary = value; }
        }

        public override void fncCreateaHuman(string vName, string vLastName)
        {
            directorIdCounter = vdirectorIdCounter;
            Salary = vSalary;
            base.fncCreateaHuman(vName, vLastName);
        }

        public override string fncDisplayHuman()
        {
            string info = "";
            info += "\n" + directorIdCounter;
            info += base.fncDisplayHuman();
            info += "\nSalary : " + Salary;
            return info;

        }
    }
}
