namespace prjWin_NationalBank_Rm
{
    public abstract class clsWriteDocumentPdf
    {
        /// <summary>
        /// Fields : strategy
        /// </summary>
        protected IntWritePdf WritePdf;
        

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public clsWriteDocumentPdf() { }

        /// <summary>
        /// Methods.
        /// </summary>
        public virtual void fncWriteDepositPdf()
        {
            WritePdf.fncWriteDocumentPdf();
        }

        public virtual void fncWriteWithdrawPdf()
        {
            WritePdf.fncWriteDocumentPdf();
        }

        public virtual void fncWriteConsultPdf()
        {
            WritePdf.fncWriteDocumentPdf();
        }
    }
}