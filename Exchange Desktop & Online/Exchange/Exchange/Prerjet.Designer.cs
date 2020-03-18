namespace Exchange
{
    partial class Prerjet
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.arkatBox = new System.Windows.Forms.ComboBox();
            this.monedhatBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kursiTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.totaliLbl = new System.Windows.Forms.Label();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.totaliLbl);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.kursiTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.monedhatBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.arkatBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 66);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 473);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 35);
            this.panel2.TabIndex = 1;
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.SystemColors.Control;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.EnableHotTracking = false;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 66);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnChooser = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AllowColumnResize = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowRowResize = false;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.EnableSorting = false;
            this.radGridView1.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(557, 407);
            this.radGridView1.TabIndex = 2;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellEndEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arka :";
            // 
            // arkatBox
            // 
            this.arkatBox.FormattingEnabled = true;
            this.arkatBox.Location = new System.Drawing.Point(76, 6);
            this.arkatBox.Name = "arkatBox";
            this.arkatBox.Size = new System.Drawing.Size(151, 21);
            this.arkatBox.TabIndex = 1;
            this.arkatBox.SelectedValueChanged += new System.EventHandler(this.arkatBox_SelectedValueChanged);
            // 
            // monedhatBox
            // 
            this.monedhatBox.FormattingEnabled = true;
            this.monedhatBox.Location = new System.Drawing.Point(76, 33);
            this.monedhatBox.Name = "monedhatBox";
            this.monedhatBox.Size = new System.Drawing.Size(151, 21);
            this.monedhatBox.TabIndex = 3;
            this.monedhatBox.SelectedValueChanged += new System.EventHandler(this.monedhatBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monedha :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kursi :";
            // 
            // kursiTxt
            // 
            this.kursiTxt.Location = new System.Drawing.Point(293, 7);
            this.kursiTxt.Name = "kursiTxt";
            this.kursiTxt.Size = new System.Drawing.Size(111, 20);
            this.kursiTxt.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Totali :";
            // 
            // totaliLbl
            // 
            this.totaliLbl.AutoSize = true;
            this.totaliLbl.Location = new System.Drawing.Point(293, 36);
            this.totaliLbl.Name = "totaliLbl";
            this.totaliLbl.Size = new System.Drawing.Size(13, 13);
            this.totaliLbl.TabIndex = 7;
            this.totaliLbl.Text = "0";
            // 
            // radButton1
            // 
            this.radButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radButton1.Location = new System.Drawing.Point(0, 0);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(557, 35);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Ruaj";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // Prerjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 508);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Prerjet";
            this.Text = "Prerjet";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.Label totaliLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox kursiTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox monedhatBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox arkatBox;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}