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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ne klikim te linkut, ndiq linkun
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }//COMM

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ne klikim te linkut, ndiq linkun
            System.Diagnostics.Process.Start(linkLabel2.Text);
        }//COMM
    }
}