using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Exchange
{
    public partial class PrintOut
    {
        private Font printFont;
        private Font headerFont;
        private Font footerFont;
        private string streamToPrint;
        private string FontName;

        public string SubjectName;
        public string AppName;
        public string Footer;

        private string template;

        //Load values
        PrintOut(string template_inner, string serial_no, string DateTime, string mag1, string mag2, string perdorues, string data, string total = "")
        {
            PrintInterpret(template_inner, serial_no, DateTime, mag1, mag2, perdorues, data, total);
        }

        //Print
        public void PrintString()
        {
            if (this.template.Length > 0)
            {

                this.FontName = "Bitstream Vera Sans Mono";
                this.streamToPrint = this.template;
                this.Printing();
                printFont = new Font(FontName, 8);

            }
        }

        private void PrintInterpret(string template_inner, string serial_no, string DateTime, string mag1, string mag2, string perdorues, string data, string total = "")
        {
            template_inner = template_inner.Replace("%SN%", serial_no);
            template_inner = template_inner.Replace("%DT%", DateTime);
            template_inner = template_inner.Replace("%MAGAZINA1%", mag1);
            template_inner = template_inner.Replace("%PERDORUES%", perdorues);
            template_inner = template_inner.Replace("%LIST%", data);
            template_inner = template_inner.Replace("%MAGAZINA2%", mag2);
            template_inner = template_inner.Replace("%TOTALI%", total);
            template_inner = template_inner.Replace("\r\n", "\n");

            this.template = template_inner;
        }

        // The PrintPage event is raised for each page to be printed.
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            // int count = 0;
            //            float leftMargin = ev.MarginBounds.Left;
            //            float topMargin = ev.MarginBounds.Top;
            float leftMargin = 0;
            float topMargin = 5.0f;

            //Set the printer font here.
            printFont = new Font(FontName, 8);
            headerFont = new Font(FontName, 14, FontStyle.Bold);
            footerFont = new Font(FontName, 5);

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            //Print header
            ev.Graphics.DrawString(this.SubjectName, new Font("Bitstream Vera Sans Mono", 14, FontStyle.Bold & FontStyle.Underline), Brushes.Black, leftMargin, yPos, new StringFormat());

            //Fix \r\n
            streamToPrint = streamToPrint.Replace("\r", "");

            //String to print
            ev.Graphics.DrawString(streamToPrint, printFont, Brushes.Black, leftMargin, yPos + headerFont.GetHeight(), new StringFormat());

            yPos = headerFont.GetHeight() + topMargin + (printFont.GetHeight() * streamToPrint.Split('\n').Length);
            ev.Graphics.DrawString("\n\n" + this.Footer, footerFont, Brushes.Black, leftMargin, yPos + footerFont.Height * 2, new StringFormat());
            // If more lines exist, print another page.
            ev.HasMorePages = false;
        }

        // Print the file.
        private void Printing()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = this.AppName;
                //pd.PrinterSettings.SupportsColor = false;
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                // Print the document.
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
