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
    public class clsAdminEventAgrs : EventArgs
    {
        // Attributes
        /// <summary>
        /// EventDelegate Message 
        /// </summary>
        public readonly string Message;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vMessage"></param>
        public clsAdminEventAgrs(string vMessage)
        {
            Message = vMessage;
        }
    }
}
