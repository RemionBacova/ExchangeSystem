#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace ExchangeOnline
{
    public partial class MonedhaEcuria : UserControl
    {
        public bool loadedMonedha = false;
        public MonedhaEcuria()
        {
            InitializeComponent();
            loadMonedhat();
            this.htmlBox1.Text = "  ";
        }

        public void loadMonedhat()
        {
            loadedMonedha = false;
            DataTable monedhat = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();
            this.monedhaCombo.DataSource = monedhat;
            this.monedhaCombo.DisplayMember = "monedha";
            this.monedhaCombo.ValueMember = "id";
            this.monedhaCombo.SelectedIndex = -1;
            loadedMonedha = true;
        }

        public void loadMonedhaChart()
        {
            WebClient wc = new WebClient();
            string html_chart = wc.DownloadString(@"http://10.10.1.34/Highcharts-3.0.1/examples/area-basic/index.htm");

            //System.IO.FileStream chart = new System.IO.FileStream(@"index.htm", System.IO.FileMode.Open);

            DataTable monedhat = Lidhja.Kerkesat1.a.getMesataretDitore(this.monedhaCombo.SelectedValue.ToString()).Copy();

            if (monedhat.Rows.Count > 0)
            {
                string shitje = "";
                string blerje = "";
                string monedhat_emra = "";
                for (int i = 0; i < monedhat.Rows.Count; i++)
                {
                    float act_shitje = float.Parse((monedhat.Rows[i].ItemArray[2].ToString() == "" ? "0" : monedhat.Rows[i].ItemArray[2].ToString()));
                    float act_blerje = float.Parse((monedhat.Rows[i].ItemArray[1].ToString() == "" ? "0" : monedhat.Rows[i].ItemArray[1].ToString()));

                    shitje += (act_shitje == 0 ? "null" : act_shitje.ToString()) + ",";
                    blerje += (act_blerje == 0 ? "null" : act_blerje.ToString()) + ",";

                    monedhat_emra += "'" + (DateTime.Parse(monedhat.Rows[i].ItemArray[3].ToString()).Date.ToString("dd/MM/yyyy")) + "',";
                }

                shitje = shitje.Substring(0, shitje.Length - 1);
                blerje = blerje.Substring(0, blerje.Length - 1);
                monedhat_emra = monedhat_emra.Substring(0, monedhat_emra.Length - 1);

                html_chart = html_chart.Replace("%shitje%", shitje);
                html_chart = html_chart.Replace("%blerje%", blerje);
                html_chart = html_chart.Replace("%monedha%", monedhat_emra);
                html_chart = html_chart.Replace("%title%", "Ecuria e monedhes " + this.monedhaCombo.Text);
                this.htmlBox1.Html = html_chart;
            }
            else
            {
                this.htmlBox1.Html = "No Result";
            }
        }

        private void monedhaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadedMonedha)
            {
                if (monedhaCombo.SelectedIndex > -1)
                {
                    loadMonedhaChart();
                }
            }
        }
    }
}