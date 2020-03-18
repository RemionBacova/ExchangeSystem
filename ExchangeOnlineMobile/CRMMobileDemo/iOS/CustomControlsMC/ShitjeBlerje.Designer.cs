using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CRMMobileDemo.iOS.CustomControlsMC
{
    partial class ShitjeBlerje
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
            this.monedhaLbl = new Gizmox.WebGUI.Forms.Label();
            this.shitjeTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.blerjeTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.ndryshoBtn = new Gizmox.WebGUI.Forms.Button();
            this.msgLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // monedhaLbl
            // 
            this.monedhaLbl.AutoSize = true;
            this.monedhaLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monedhaLbl.Location = new System.Drawing.Point(13, 10);
            this.monedhaLbl.Name = "monedhaLbl";
            this.monedhaLbl.Size = new System.Drawing.Size(35, 13);
            this.monedhaLbl.TabIndex = 0;
            this.monedhaLbl.Text = "label1";
            // 
            // shitjeTxt
            // 
            this.shitjeTxt.AllowDrag = false;
            this.shitjeTxt.Location = new System.Drawing.Point(66, 38);
            this.shitjeTxt.Name = "shitjeTxt";
            this.shitjeTxt.ReadOnly = true;
            this.shitjeTxt.Size = new System.Drawing.Size(127, 25);
            this.shitjeTxt.TabIndex = 1;
            this.shitjeTxt.TextChanged += new System.EventHandler(this.shitjeTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Shitje";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Blerje";
            // 
            // blerjeTxt
            // 
            this.blerjeTxt.AllowDrag = false;
            this.blerjeTxt.Location = new System.Drawing.Point(66, 68);
            this.blerjeTxt.Name = "blerjeTxt";
            this.blerjeTxt.ReadOnly = true;
            this.blerjeTxt.Size = new System.Drawing.Size(127, 25);
            this.blerjeTxt.TabIndex = 1;
            // 
            // ndryshoBtn
            // 
            this.ndryshoBtn.Location = new System.Drawing.Point(17, 124);
            this.ndryshoBtn.Name = "ndryshoBtn";
            this.ndryshoBtn.Size = new System.Drawing.Size(176, 28);
            this.ndryshoBtn.TabIndex = 3;
            this.ndryshoBtn.Text = "Ndrysho";
            this.ndryshoBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // msgLabel
            // 
            this.msgLabel.Location = new System.Drawing.Point(20, 100);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(173, 24);
            this.msgLabel.TabIndex = 4;
            // 
            // ShitjeBlerje
            // 
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.ndryshoBtn);
            this.Controls.Add(this.blerjeTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shitjeTxt);
            this.Controls.Add(this.monedhaLbl);
            this.Size = new System.Drawing.Size(1091, 839);
            this.Text = "ShitjeBlerje";
            this.ResumeLayout(false);

        }

        #endregion

        private Label monedhaLbl;
        private TextBox shitjeTxt;
        private Label label1;
        private Label label2;
        private TextBox blerjeTxt;
        private Button ndryshoBtn;
        private Label msgLabel;


    }
}