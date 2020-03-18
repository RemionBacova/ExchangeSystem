using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CRMMobileDemo.iOS.CustomControlsMC
{
    partial class LabelBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.insideLabel = new Gizmox.WebGUI.Forms.Label();
            this.insideCol1Txt = new Gizmox.WebGUI.Forms.TextBox();
            this.insideCol2Txt = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // insideLabel
            // 
            this.insideLabel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.insideLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insideLabel.Location = new System.Drawing.Point(0, 0);
            this.insideLabel.Name = "insideLabel";
            this.insideLabel.Size = new System.Drawing.Size(167, 36);
            this.insideLabel.TabIndex = 0;
            this.insideLabel.Text = "label1";
            this.insideLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // insideCol1Txt
            // 
            this.insideCol1Txt.AllowDrag = false;
            this.insideCol1Txt.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.insideCol1Txt.Location = new System.Drawing.Point(170, 3);
            this.insideCol1Txt.Name = "insideCol1Txt";
            this.insideCol1Txt.Size = new System.Drawing.Size(80, 30);
            this.insideCol1Txt.TabIndex = 1;
            this.insideCol1Txt.TextChanged += new System.EventHandler(this.insideCol1Txt_TextChanged);
            // 
            // insideCol2Txt
            // 
            this.insideCol2Txt.AllowDrag = false;
            this.insideCol2Txt.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.insideCol2Txt.Location = new System.Drawing.Point(256, 3);
            this.insideCol2Txt.Name = "insideCol2Txt";
            this.insideCol2Txt.ReadOnly = true;
            this.insideCol2Txt.Size = new System.Drawing.Size(80, 30);
            this.insideCol2Txt.TabIndex = 1;
            // 
            // LabelBox
            // 
            this.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.insideCol2Txt);
            this.Controls.Add(this.insideCol1Txt);
            this.Controls.Add(this.insideLabel);
            this.Size = new System.Drawing.Size(343, 36);
            this.Text = "LabelBox";
            this.ResumeLayout(false);

        }

        #endregion

        public Label insideLabel;
        public TextBox insideCol1Txt;
        public TextBox insideCol2Txt;







    }
}