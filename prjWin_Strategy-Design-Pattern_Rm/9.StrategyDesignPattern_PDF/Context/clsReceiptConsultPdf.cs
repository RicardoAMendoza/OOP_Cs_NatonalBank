using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWin_NationalBank_Rm
{
    public class clsReceiptConsultPdf : clsWriteDocumentPdf
    {
        public clsReceiptConsultPdf()
        {
            WritePdf = new clsWriteConsultPdf();
        }

        public override void fncWriteConsultPdf()
        {
            base.fncWriteConsultPdf();
        }
    }
}