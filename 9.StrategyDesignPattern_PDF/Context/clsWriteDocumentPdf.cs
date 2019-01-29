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
    public abstract class clsWriteDocumentPdf
    {
        /// <summary>
        /// Fields : strategy -> Attribute de type Interface
        /// </summary>
        protected IntWritePdf WritePdf;
        

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public clsWriteDocumentPdf() { }

        /// <summary>
        /// clsReceiptDepositPdf : clsWriteDocumentPdf
        /// </summary>
        public virtual void fncWriteDepositPdf()
        {
            WritePdf.fncWriteDocumentPdf();
        }
        /// <summary>
        /// class clsReceiptWithdrawPdf : clsWriteDocumentPdf
        /// </summary>
        public virtual void fncWriteWithdrawPdf()
        {
            WritePdf.fncWriteDocumentPdf();
        }
        /// <summary>
        /// clsReceiptConsultPdf : clsWriteDocumentPdf
        /// </summary>
        public virtual void fncWriteConsultPdf()
        {
            WritePdf.fncWriteDocumentPdf();
        }
    }
}