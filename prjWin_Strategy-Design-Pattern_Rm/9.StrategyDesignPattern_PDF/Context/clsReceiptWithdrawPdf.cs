namespace prjWin_NationalBank_Rm
{
    public class clsReceiptWithdrawPdf : clsWriteDocumentPdf
    {
        public clsReceiptWithdrawPdf()
        {
            WritePdf = new clsWriteWithdrawPdf();
        }

        public override void fncWriteWithdrawPdf()
        {
            base.fncWriteWithdrawPdf();
        }
    }
}