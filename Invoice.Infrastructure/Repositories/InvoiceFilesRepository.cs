using System;
using System.IO;
using System.Threading.Tasks;
using Invoice.Core.Repositories;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Invoice.Infrastructure.Repositories
{
    public class InvoiceFilesRepository : IInvoiceFilesRepository
    {
        public InvoiceFilesRepository(string number, string company)
        {
            var filePath = String.Concat("Faktura_", number, ".pdf");
            
            var stream = new FileStream(filePath, FileMode.Create);

            var document = new Document();

            PdfWriter writer = PdfWriter.GetInstance(document, stream);
            writer.PdfVersion = PdfWriter.VERSION_1_5;
            document.AddAuthor(company); 

            document.Open();
             var tableOfServices = new PdfPTable(9);
            tableOfServices.WidthPercentage = 100.0f;
            tableOfServices.HorizontalAlignment = Element.ALIGN_CENTER;
            //var cellOfService = new PdfPCell();
            for (int i = 0; i < 27; i++)
            {
                string celltitle;
                switch (i)
                {
                    case 0:
                        celltitle = "L.p.";
                        break;
                    case 1:
                        celltitle = "Nazwa";
                        break;
                    default:
                        celltitle = "test";
                        break;
                }
                
                var cellOfService = new PdfPCell(new Phrase(celltitle));
                cellOfService.BorderWidth = 0f;
                if (i > 8){
                    cellOfService.BorderWidthTop = 0.25f;
                }
                cellOfService.FixedHeight = 30.0f;
                cellOfService.HorizontalAlignment = Element.ALIGN_LEFT;
                cellOfService.VerticalAlignment = Element.ALIGN_MIDDLE;
                tableOfServices.AddCell(cellOfService);
            }

            PdfPTable sumTable = new PdfPTable(4);
            sumTable.WidthPercentage = 50.0f;
            // Options: Element.ALIGN_LEFT (or 0), Element.ALIGN_CENTER (1), Element.ALIGN_RIGHT (2).
            sumTable.HorizontalAlignment = Element.ALIGN_RIGHT;


            for (int i = 1; i <= 30; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(String.Format("Cell # {0}", i)));
                cell.BorderWidth = 0f;
                if (i > 4){
                    cell.BorderWidthTop = 0.25f;
                }
                cell.FixedHeight = 30.0f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                sumTable.AddCell(cell);
            }
           document.Add(tableOfServices);
           document.Add(sumTable);

            //  document.Add(new Paragraph("GIF"));
            //  Image logo = Image.GetInstance("logo-is.png");


            //   document.Add(logo);

            /* StyleSheet styleSheet = new StyleSheet();
             styleSheet.LoadTagStyle("h1", "size", "5");
             styleSheet.LoadTagStyle("h2", "size", "3");
             styleSheet.LoadTagStyle("td", "size", ".6");
             styleSheet.LoadTagStyle("th", "size", ".6");
             styleSheet.LoadTagStyle("body", "face", "font");
             styleSheet.LoadTagStyle("body", "encoding", "Identity-H");
             styleSheet.LoadTagStyle("body", "size", "12pt");
             styleSheet.LoadTagStyle("td", "color", "#000000" );

             var htmlWorker = new HtmlWorker(document);
             htmlWorker.Style = styleSheet;

             htmlWorker.StartDocument();

             string htmlFile = File.ReadAllText(filePath);
             var htmlText = new StringReader(htmlFile);
             htmlWorker.Parse(htmlText);

             htmlWorker.EndDocument();
             htmlWorker.Close();*/
            document.Close();
            stream.Dispose();
        }
        public async Task<string> GetUrlAsync(Guid Id)
            => await Task.FromResult("InvoiceUrlTest");

        public async Task UpdateAsync(Guid Id)
        {
            await Task.CompletedTask;
        }
    }
}