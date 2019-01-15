using System;
using System.Windows.Forms;

using System.IO; // file stream
using iTextSharp.text; // pdf
using iTextSharp.text.pdf; // pdf

namespace prjWin_NationalBank_Rm
{
    public class clsWriteDepositPdf : IntWritePdf
    {
        public void fncWriteDocumentPdf()
        {
            try
            {
                clsClient actualClient = frmBank.fncActualClient();
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 100, 100, 50, 50);
                PdfWriter writingPdf = PdfWriter.GetInstance(doc, new FileStream("NB_Sdp_DepositReceipt.pdf", FileMode.Create));
                doc.Open(); // Open document to write
                DateTime today = clsDataSource.fncTodayDate();
                Paragraph paregraph = new Paragraph("National Bank of Canada : " + "\n" + "Date : " + today.ToString() + "\n" +"DEPOSIT." +"\n" + actualClient.fncDisplayHuman());
                doc.Add(paregraph);
                doc.Close(); // Close document
                MessageBox.Show("a PDF has been written");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}