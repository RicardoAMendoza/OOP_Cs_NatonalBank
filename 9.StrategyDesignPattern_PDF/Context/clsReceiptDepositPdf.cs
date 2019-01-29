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
    public class clsReceiptDepositPdf : clsWriteDocumentPdf
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public clsReceiptDepositPdf()
        {
            // ATTRIBUTE DE TYPE INTERFACE -> IntWritePdf
            WritePdf = new clsWriteDepositPdf();
        }
        /// <summary>
        /// clsReceiptDepositPdf : clsWriteDocumentPdf
        /// </summary>
        public override void fncWriteDepositPdf()
        {
            base.fncWriteDepositPdf();
        }
    }
}