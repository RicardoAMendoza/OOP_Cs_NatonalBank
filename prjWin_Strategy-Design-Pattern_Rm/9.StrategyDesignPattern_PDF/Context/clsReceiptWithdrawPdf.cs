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
    public class clsReceiptWithdrawPdf : clsWriteDocumentPdf
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public clsReceiptWithdrawPdf()
        {
            // ATTRIBUTE DE TYPE INTERFACE -> IntWritePdf
            WritePdf = new clsWriteWithdrawPdf();
        }
        /// <summary>
        /// class clsReceiptWithdrawPdf : clsWriteDocumentPdf
        /// </summary>
        public override void fncWriteWithdrawPdf()
        {
            base.fncWriteWithdrawPdf();
        }
    }
}