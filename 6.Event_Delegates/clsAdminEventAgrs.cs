using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWin_NationalBank_Rm
{
    /*
    * This project uses the following licenses:
    *  MIT License
    *  Copyright (c) 2017 Ricardo Mendoza 
    *  Montréal Québec Canada
    *  Institut Teccart
    *  www.teccart.qc.ca
    *  Août 2017
    */
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
