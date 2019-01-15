namespace prjWin_NationalBank_Rm
{
    public class clsReceiptDepositPdf : clsWriteDocumentPdf
    {
        public clsReceiptDepositPdf()
        {
            WritePdf = new clsWriteDepositPdf();
        }

        public override void fncWriteDepositPdf()
        {
            base.fncWriteDepositPdf();
        }
    }
}