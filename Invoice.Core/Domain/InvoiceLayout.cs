using System;
using System.Collections;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Invoice.Core.Domain
{
    public class InvoiceLayout
    {
        protected InvoiceLayout()
        {
        }
        public InvoiceLayout(Guid invoiceId)
        {
            //var filePath = invoiceId.ToString();
            var filePath = "test.pdf";
            var stream = new FileStream(filePath, FileMode.Create);

            var document = new Document();

            PdfWriter writer = PdfWriter.GetInstance(document, stream);
            writer.PdfVersion = PdfWriter.VERSION_1_5;
            document.AddAuthor("MM"); 

            document.Open();
            // step 4
          /*  PdfLayer a1 = new PdfLayer("answer 1", writer);
            PdfLayer a2 = new PdfLayer("answer 2", writer);
            PdfLayer a3 = new PdfLayer("answer 3", writer);
            a1.On = false;
            a2.On = false;
            a3.On = false;

            BaseFont bf = BaseFont.CreateFont();
            PdfContentByte cb = writer.DirectContent;
            cb.BeginText();
            cb.SetFontAndSize(bf, 18);
            cb.ShowTextAligned(Element.ALIGN_LEFT,
                "Q1: Who is the director of the movie 'Paths of Glory'?", 50, 766, 0);
            cb.ShowTextAligned(Element.ALIGN_LEFT,
                "Q2: Who directed the movie 'Lawrence of Arabia'?", 50, 718, 0);
            cb.ShowTextAligned(Element.ALIGN_LEFT,
                "Q3: Who is the director of 'House of Flying Daggers'?", 50, 670, 0);
            cb.EndText();
            cb.SaveState();
            cb.SetRgbColorFill(0xFF, 0x00, 0x00);
            cb.BeginText();
            cb.BeginLayer(a1);
            cb.ShowTextAligned(Element.ALIGN_LEFT,
                    "A1: Stanley Kubrick", 50, 742, 0);
            cb.EndLayer();
            cb.BeginLayer(a2);
            cb.ShowTextAligned(Element.ALIGN_LEFT,
                    "A2: David Lean", 50, 694, 0);
            cb.EndLayer();
            cb.BeginLayer(a3);
            cb.ShowTextAligned(Element.ALIGN_LEFT,
                    "A3: Zhang Yimou", 50, 646, 0);
            cb.EndLayer();
            cb.EndText();
            cb.RestoreState();

            var stateOn = new ArrayList {"ON", a1, a2, a3};
            PdfAction actionOn = PdfAction.SetOcGstate(stateOn, true);
            var stateOff = new ArrayList {"OFF", a1, a2, a3};
            PdfAction actionOff = PdfAction.SetOcGstate(stateOff, true);
            var stateToggle = new ArrayList {"Toggle", a1, a2, a3};
            PdfAction actionToggle = PdfAction.SetOcGstate(stateToggle, true);
            Phrase p = new Phrase("Change the state of the answers:");
            Chunk on = new Chunk(" on ").SetAction(actionOn);
            p.Add(on);
            Chunk off = new Chunk("/ off ").SetAction(actionOff);
            p.Add(off);
            Chunk toggle = new Chunk("/ toggle").SetAction(actionToggle);
            p.Add(toggle);
            document.Add(p);*/

            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 50.0f;
            // Options: Element.ALIGN_LEFT (or 0), Element.ALIGN_CENTER (1), Element.ALIGN_RIGHT (2).
            table.HorizontalAlignment = Element.ALIGN_RIGHT;
            //table.DefaultCell.Border = Rectangle.NO_BORDER;
                PdfPCell cell = new PdfPCell(new Phrase(String.Format("Cell # {0}", 1)));
                cell.BorderWidth = 0f;
                cell.FixedHeight = 30.0f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                table.AddCell(cell);
            for (int i = 2; i <= 20; i++) {
                //PdfPCell cell = new PdfPCell(new Phrase(String.Format("Cell # {0}", i)));
                cell.BorderWidth = 0f;
                cell.BorderWidthTop = 0.25f;
                cell.FixedHeight = 30.0f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                table.AddCell(cell);
            }
            document.Add(table);

            document.Close();
            stream.Dispose();
        }
    }
}