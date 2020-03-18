#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using CustomCRMControls;
using CRMMobileDemo.Common;

#endregion

namespace CRMMobileDemo.iOS.CustomControlsMC
{
    public partial class Login : TranslatePanel
    {
        public Login()
        {
            InitializeComponent();
            //fokusohet te TextBox i username
                //TextBox-et krijohen me madhesi te dhene, per te parandaluar gabime ne UI
            this.usernameTxt.Focus();
            this.usernameTxt.Width = this.Width - 10;
            this.passwordTxt.Width = this.Width - 10;
        }

        public void resetVisualElements()
        {
            //funksioni qe inicializoh tekstet e nderfaqes per perdorim
            this.usernameTxt.Text = "";
            this.passwordTxt.Text = "";
            this.msgLabel.Text = "";
        }
    }
}