#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace ExchangeOnline
{
    public partial class Raportet : Form
    {
        public Raportet()
        {
            InitializeComponent();
        }

        public void loadEcuriaMonedhes()
        {
            this.littleContainer.Controls.Clear();
            this.littleContainer.Controls.Add(new MonedhaEcuria() { Dock = DockStyle.Fill });
        }

        public void loadRaportetPeriudha()
        {
            this.littleContainer.Controls.Clear();
            this.littleContainer.Controls.Add(new RaportetPeriudha() { Dock = DockStyle.Fill });
        }

        public void loadKurset()
        {
            this.littleContainer.Controls.Clear();
            this.littleContainer.Controls.Add(new MonedhaHistoriku() { Dock = DockStyle.Fill });
        }

        private void graphBtn_Click(object sender, EventArgs e)
        {
            loadEcuriaMonedhes();
        }

        private void raportiBtn_Click(object sender, EventArgs e)
        {
            loadRaportetPeriudha();
        }

        private void kursetBtn_Click(object sender, EventArgs e)
        {
            loadKurset();
        }
    }
}