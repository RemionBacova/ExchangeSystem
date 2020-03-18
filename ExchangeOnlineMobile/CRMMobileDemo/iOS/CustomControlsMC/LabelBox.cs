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

namespace CRMMobileDemo.iOS.CustomControlsMC
{
    public partial class LabelBox : UserControl
    {
        EventHandler e;
        public LabelBox(string col1, string col2, string col3, EventHandler e)
        {
            //user-control qe ka nje Label, dy TextBox dhe sherben per te edituar kurset

            //merren vlerat si parameter
            //si parameter merret dhe funksioni qe ndodhet ne EventHandler per tu therritur ne ndryshim dhe validim te tekstit 
                //te edituar
            this.e = e;
            InitializeComponent();
            this.insideLabel.Text = col1;
            this.insideCol1Txt.Text = col2;
            this.insideCol2Txt.Text = col3;
        }

        private void insideCol1Txt_TextChanged(object sender, EventArgs e)
        {
            //ne ndryshim te tekstit
            float z;
            if (this.insideCol1Txt.Text != "")
            {
                //nese nuk eshte bosh
                if (float.TryParse(this.insideCol1Txt.Text, out z))
                {
                    //nese eshte me presje, e kthejme ne INT
                    this.insideCol1Txt.Text = ((int)(float.Parse(this.insideCol1Txt.Text))).ToString();
                }
                else
                {
                    //perndryshe nese eshte vlere jo e vlefshme, e bejme 0
                    this.insideCol1Txt.Text = "0";
                }
            }
            else
            {
                //dhe nese eshte bosh, e bejme 0
                this.insideCol1Txt.Text = "0";
            }
            //ne fund therrasim funksionin e derguar si parameter ne objekt
            this.e.Invoke(insideCol1Txt, e);
        }
    }
}