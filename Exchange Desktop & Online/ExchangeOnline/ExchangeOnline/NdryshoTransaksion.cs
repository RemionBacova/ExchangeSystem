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

#endregion

namespace ExchangeOnline
{
    public partial class NdryshoTransaksion : Form
    {
        string nrrendor = "";
        public NdryshoTransaksion(string nrrendor)
        {
            this.nrrendor = nrrendor;
            InitializeComponent();
        }
    }
}