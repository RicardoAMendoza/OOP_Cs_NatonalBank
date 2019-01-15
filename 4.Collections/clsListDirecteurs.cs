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
    public class clsListDirecteurs
    {
        /// <summary>
        /// Field : Director list
        /// </summary>
        private Dictionary<string, clsDirecteur> ListDirecteurs;
        /// <summary>
        /// Constructor that takes no arguments.
        /// </summary>
        public clsListDirecteurs()
        {
            ListDirecteurs = new Dictionary<string, clsDirecteur>();
        }
        /// <summary>
        /// Returns the elements number in the list.
        /// </summary>
        public int Quantity
        {
            get { return ListDirecteurs.Values.Count; }
        }
        /// <summary>
        /// Returns the property of each element in the list.
        /// </summary>
        public Dictionary<string, clsDirecteur>.ValueCollection Elements
        {
            get { return ListDirecteurs.Values; }
        }

        public clsDirecteur clsDirecteur
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsDirecteur clsDirecteur1
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
        /// Function : fncExist(string number ) -> bool true if the Directeur exist.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListDirecteurs.ContainsKey(number);</returns>
        public bool fncExist(string number)
        {
            return ListDirecteurs.ContainsKey(number);
        }
        /// <summary>
        /// Function : fncFInd(int number) -> returns a Directeur by number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListDirecteurs[number];</returns>
        public clsDirecteur fncFind(string number)
        {
            if (fncExist(number))
            {
                return ListDirecteurs[number];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Function : fncAdd(clsDirecteur directeur) -> adds a customer in the Directeur list
        /// </summary>
        /// <param name="directeur"></param>
        /// <returns>ListDirecteurs.Add(directeur.vNumber, directeur); or false</returns>
        public bool fncAdd(clsDirecteur directeur)
        {
            if (!fncExist(directeur.vNumber))
            {
                ListDirecteurs.Add(directeur.vNumber, directeur);
                // MessageBox.Show(ListDirecteurs.Count.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Function : fncErase(int number) -> erases a Directeur from the list.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListDirecteurs.Remove(number);  </returns>
        public bool fncErase(string number)
        {
            return ListDirecteurs.Remove(number);
        }
        /// <summary>
        /// Function : fncDisplay() -> display Directeurs in the directeurs list.
        /// </summary>
        /// <returns>Directeurs info</returns>
        public string fncDisplay()
        {
            string info = "";
            foreach (clsDirecteur directeur in ListDirecteurs.Values)
            {
                info += directeur.fncDisplayHuman();
            }
            return info;
        }

    }
}
