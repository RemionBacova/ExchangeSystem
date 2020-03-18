#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.IO;

#endregion

namespace ExchangeOnline
{
    public partial class PrintForm : Form
    {
        public PrintForm(string data, string ora, string monedha1, string kursi1, string monedha2, string kursi2,
                string kursi_tot, string shuma, string totali, string klienti, string pika, 
                string[] prerjet1, string[] sasia_prerjet1, string[] prerjet2, string[] sasia_prerjet2)
        {
            //forme qe ben printimin e fatures
            InitializeComponent();
            string body = "";
            System.Net.WebClient wc = new System.Net.WebClient();
            body = wc.DownloadString(@"http://10.10.1.34/Highcharts-3.0.1/examples/area-basic/perfundim.html");


            //<p>DATA: %data%  ORA : %ora%<br/>
            //%monedha1% - %monedha2%<br/>
            //Sasia %monedha1%: %sasia%<br/>
            //Kursi %monedha1%: %kursi_monedha1%<br/>
            //Kursi %monedha2%: %kursi_monedha2%<br/>
            //Kursi: %kursi%<br/>
            //Totali %monedha2%: %totali%<br/>
            //Klienti: %klienti%<br/>
            //Pika: %pika%<br/>
            //Prerjet<br/>
            //%prerjet%
            //</p>

            body = body.Replace("%data%", data);
            body = body.Replace("%ora%", ora);
            body = body.Replace("%monedha1%", monedha1);
            body = body.Replace("%monedha2%", monedha2);
            body = body.Replace("%kursi_monedha1%", kursi1);
            body = body.Replace("%kursi_monedha2%", kursi2);
            body = body.Replace("%kursi%", kursi_tot);
            body = body.Replace("%totali%", totali);
            body = body.Replace("%sasia%", shuma);
            body = body.Replace("%klienti%", klienti);
            body = body.Replace("%pika%", pika);

            string prerjet_builder = "";
            for (int i = 0; i < prerjet1.Length; i++)
            {
                prerjet_builder += prerjet1[i] + " x" + sasia_prerjet1[i] + "<br/>";
            }

            body = body.Replace("%prerjet1%", prerjet_builder);

            prerjet_builder = "";
            for (int i = 0; i < prerjet2.Length; i++)
            {
                prerjet_builder += prerjet2[i] + " x" + sasia_prerjet2[i] + "<br/>";
            }

            body = body.Replace("%prerjet2%", prerjet_builder);

            this.htmlBox1.Html = body;

        }
    }
}