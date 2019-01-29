using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    public class clsReceiptConsultPdf : clsWriteDocumentPdf
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public clsReceiptConsultPdf()
        {
            // ATTRIBUTE DE TYPE INTERFACE -> IntWritePdf
            WritePdf = new clsWriteConsultPdf();
        }
        /// <summary>
        /// clsReceiptConsultPdf : clsWriteDocumentPdf
        /// </summary>
        public override void fncWriteConsultPdf()
        {
            base.fncWriteConsultPdf();
        }
    }
}