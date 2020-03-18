#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace ExchangeOnline
{
    public partial class MonedhaHistoriku : UserControl
    {
        bool okToIndexChange = true;
        public MonedhaHistoriku()
        {
            InitializeComponent();
            fillMonedhat();
        }

        public void fillMonedhat()
        {
            this.okToIndexChange = false;
            DataTable monedhat = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();
            this.monedhaBox.DataSource = monedhat;
            this.monedhaBox.DisplayMember = "monedha";
            this.monedhaBox.ValueMember = "id";
            this.monedhaBox.SelectedIndex = -1;
            this.okToIndexChange = true;
        }

        private void monedhaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.okToIndexChange)
            {
                DataTable full_info = Lidhja.Kerkesat1.a.kursetByMonedha(this.monedhaBox.SelectedValue.ToString()).Copy();
                this.dataGridView1.DataSource = full_info;
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}