using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class MonedhaEcuria
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
            this.monedhaCombo = new Gizmox.WebGUI.Forms.ComboBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.htmlBox1 = new Gizmox.WebGUI.Forms.HtmlBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monedhaCombo
            // 

            this.monedhaCombo.FormattingEnabled = true;
            this.monedhaCombo.Location = new System.Drawing.Point(67, 8);
            this.monedhaCombo.Name = "monedhaCombo";
            this.monedhaCombo.Size = new System.Drawing.Size(155, 21);
            this.monedhaCombo.TabIndex = 1;
            this.monedhaCombo.SelectedIndexChanged += new System.EventHandler(this.monedhaCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monedha :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.monedhaCombo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 39);
            this.panel1.TabIndex = 1;
            // 
            // htmlBox1
            // 
            this.htmlBox1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.htmlBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.htmlBox1.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(2);
            this.htmlBox1.ContentType = "text/html";
            this.htmlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.htmlBox1.Expires = -1;
            this.htmlBox1.Html = "<HTML> </HTML>";
            this.htmlBox1.Location = new System.Drawing.Point(0, 39);
            this.htmlBox1.Name = "htmlBox1";
            this.htmlBox1.Size = new System.Drawing.Size(555, 420);
            this.htmlBox1.TabIndex = 0;
            // 
            // MonedhaEcuria
            // 
            this.Controls.Add(this.htmlBox1);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(555, 459);
            this.Text = "MonedhaEcuria";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox monedhaCombo;
        private Label label1;
        private Panel panel1;
        private HtmlBox htmlBox1;


    }
}