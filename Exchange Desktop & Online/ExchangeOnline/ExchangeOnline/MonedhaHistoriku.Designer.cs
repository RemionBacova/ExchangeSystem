using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class MonedhaHistoriku
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
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.monedhaBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.monedhaBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 33);
            this.panel1.TabIndex = 0;
            // 
            // monedhaBox
            // 

            this.monedhaBox.FormattingEnabled = true;
            this.monedhaBox.Location = new System.Drawing.Point(66, 5);
            this.monedhaBox.Name = "monedhaBox";
            this.monedhaBox.Size = new System.Drawing.Size(121, 21);
            this.monedhaBox.TabIndex = 1;
            this.monedhaBox.SelectedIndexChanged += new System.EventHandler(this.monedhaBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monedha :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(512, 439);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dataGridView1.ItemsPerPage = 100;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.dataGridView1.Size = new System.Drawing.Size(512, 439);
            this.dataGridView1.TabIndex = 0;
            // 
            // MonedhaHistoriku
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(512, 472);
            this.Text = "MonedhaHistoriku";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ComboBox monedhaBox;
        private Label label1;
        private Panel panel2;
        private DataGridView dataGridView1;


    }
}