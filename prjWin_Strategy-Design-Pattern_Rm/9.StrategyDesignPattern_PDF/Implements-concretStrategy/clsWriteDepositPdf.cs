using System;
using System.Windows.Forms;

using System.IO; // file stream
using iTextSharp.text; // pdf
using iTextSharp.text.pdf; // pdf

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
    public class clsWriteDepositPdf : IntWritePdf
    {
        /// <summary>
        /// Inherited function
        /// </summary>
        public void fncWriteDocumentPdf()
        {
            try
            {
                clsClient actualClient = frmBank.fncActualClient();
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 100, 100, 50, 50);
                PdfWriter writingPdf = PdfWriter.GetInstance(doc, new FileStream("NB_Sdp_DepositReceipt.pdf", FileMode.Create));
                doc.Open(); // Open document to write
                DateTime today = clsDataSource.fncTodayDate();
                // Written text in to the pdf
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