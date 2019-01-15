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
    public class clsListClients
    {
        /// <summary>
        /// Collection : ListClients.
        /// </summary>
        private Dictionary<string, clsClient> ListClients;
        /// <summary>
        /// Constructor
        /// </summary>
        public clsListClients()
        {
            ListClients = new Dictionary<string, clsClient>();
        }
        /// <summary>
        /// Gets the number of the elements in the dictionary.
        /// </summary>
        public int Quantity
        {
            get { return ListClients.Values.Count; }
        }
        /// <summary>
        /// Gets the collection of elements in the dictionary
        /// </summary>
        public Dictionary<string, clsClient>.ValueCollection Elements
        {
            get { return ListClients.Values; }
        }

        


        /// <summary>
        /// Function : fncExist(string number ) -> bool true if the Client exist.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>return ListClients.ContainsKey(number); </returns>
        public bool fncExist(string number)
        {
            return ListClients.ContainsKey(number);
        }
        /// <summary>
        /// Function : fncFInd(string number) -> returns a Client by number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListClients[number]; or null</returns>
        public clsClient fncFind(string number)
        {
            if (fncExist(number))
            {
                return ListClients[number];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Function : fncAdd(clsClient client) -> adds a customer in the Clients list
        /// </summary>
        /// <param name="client"></param>
        /// <returns>ListClients.Add(client.vIdClient, client) or false</returns>
        public bool fncAdd(clsClient client)
        {
            if (!fncExist(client.vNumber))
            {
                ListClients.Add(client.vNumber, client);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Function : fncErase(int number) -> erases a Client from the list.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>ListClients.Remove(number)</returns>
        public bool fncErase(string number)
        {
            return ListClients.Remove(number);
        }
        /// <summary>
        /// Function : fncClear() -> removes all keys and values from the dictionary.
        /// </summary>
        public void fncClear()
        {
            ListClients.Clear();
        }
        /// <summary>
        /// Function : fncDisplay() -> display Customers in the client list.
        /// </summary>
        /// <returns>info</returns>
        public string fncDisplay()
        {
            string info = "";
            foreach (clsClient client in ListClients.Values)
            {
                info += client.fncDisplayHuman();
            }
            return info;
        }
        public clsClient clsClient
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public clsClient clsClient1
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
