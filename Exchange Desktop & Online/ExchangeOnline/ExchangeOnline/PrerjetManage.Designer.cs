using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class PrerjetManage
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.monedhatBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.radButton1 = new Gizmox.WebGUI.Forms.Button();
            this.radGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.monedhatBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 32);
            this.panel1.TabIndex = 0;
            // 
            // monedhatBox
            // 

            this.monedhatBox.FormattingEnabled = true;
            this.monedhatBox.Location = new System.Drawing.Point(77, 5);
            this.monedhatBox.Name = "monedhatBox";
            this.monedhatBox.Size = new System.Drawing.Size(141, 21);
            this.monedhatBox.TabIndex = 1;
            this.monedhatBox.SelectedIndexChanged += new System.EventHandler(this.monedhatBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monedha :";
            // 
            // radButton1
            // 
            this.radButton1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.radButton1.Location = new System.Drawing.Point(0, 357);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(372, 39);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "Ruaj";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radGridView1
            // 

            this.radGridView1.AllowUserToAddRows = false;
            this.radGridView1.AllowUserToDeleteRows = false;
            this.radGridView1.AllowUserToResizeColumns = false;
            this.radGridView1.AllowUserToResizeRows = false;
            this.radGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.radGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 32);
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RowHeadersWidth = 4;
            this.radGridView1.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.radGridView1.Size = new System.Drawing.Size(372, 325);
            this.radGridView1.TabIndex = 2;
            this.radGridView1.CellValueChanged += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.radGridView1_CellValueChanged);
            // 
            // PrerjetManage
            // 
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(372, 396);
            this.Text = "PrerjetManage";
            this.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(this.PrerjetManage_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ComboBox monedhatBox;
        private Label label1;
        private Button radButton1;
        private DataGridView radGridView1;


    }
}