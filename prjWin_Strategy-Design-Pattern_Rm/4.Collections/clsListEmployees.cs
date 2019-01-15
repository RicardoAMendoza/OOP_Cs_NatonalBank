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
    public class clsListEmployees
    {
        /// <summary>
        /// Collection : ListEmployees.
        /// </summary>
        private Dictionary<string, clsEmployee> ListEmployees;
        /// <summary>
        /// Constructor
        /// </summary>
        public clsListEmployees()
        {
            ListEmployees = new Dictionary<string, clsEmployee>();
        }
        /// <summary>
        /// Gets the number of the elements in the dictionary.
        /// </summary>
        public int Quantity
        {
            get { return ListEmployees.Values.Count; }
        }
        /// <summary>
        /// Gets the collection of elements in the dictionary
        /// </summary>
        public Dictionary<string, clsEmployee>.ValueCollection Elements
        {
            get { return ListEmployees.Values; }
        }

        public clsEmployee clsEmployee
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsEmployee clsEmployee1
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
        /// Function : fncExist(int id ) -> bool true if the Employee exist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return ListEmployees.ContainsKey(id); </returns>
        public bool fncExist(string id)
        {
            return ListEmployees.ContainsKey(id);
        }
        /// <summary>
        /// Function : fncFInd(int id) -> returns an Employee by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ListEmployees[id]; or null</returns>
        public clsEmployee fncFind(string id)
        {
            if (fncExist(id))
            {
                return ListEmployees[id];
            }
            else
            {
                // if there is not object return null
                return null;
            }
        }
        /// <summary>
        /// Function : fncAdd(clsEmployee employee) -> adds an Employee in the Employees list.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>ListEmployees.Add(employee.vIdEmp, employee) or false</returns>
        public bool fncAdd(clsEmployee employee)
        {
            if (!fncExist(employee.vNumber))
            {
                ListEmployees.Add(employee.vNumber, employee);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Function : fncErase(int id) -> erases an Employee from the list.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ListEmployees.Remove(id)</returns>
        public bool fncErase(string id)
        {
            return ListEmployees.Remove(id);
        }
        /// <summary>
        /// Function : fncClear() -> removes all keys and values from the dictionary.
        /// </summary>
        public void fncClear()
        {
            ListEmployees.Clear();
        }
        /// <summary>
        /// Function : fncDisplay() -> display Employees in the client list.
        /// </summary>
        /// <returns>info</returns>
        public string fncDisplay()
        {
            string info = "";
            foreach (clsEmployee employee in ListEmployees.Values)
            {
                info += employee.fncDisplayHuman();
            }
            return info;
        }
    }
}
