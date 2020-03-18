using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class Prjerjet
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
            this.radButton1 = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.kursiTxt = new Gizmox.WebGUI.Forms.Label();
            this.totaliLbl = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.monedhatBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.arkatBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.radGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.tableLayoutPanel1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.radButton1.Location = new System.Drawing.Point(0, 0);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(259, 37);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Ruaj";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.kursiTxt);
            this.panel1.Controls.Add(this.totaliLbl);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.monedhatBox);
            this.panel1.Controls.Add(this.arkatBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 67);
            this.panel1.TabIndex = 1;
            // 
            // kursiTxt
            // 
            this.kursiTxt.Location = new System.Drawing.Point(313, 9);
            this.kursiTxt.Name = "kursiTxt";
            this.kursiTxt.Size = new System.Drawing.Size(163, 18);
            this.kursiTxt.TabIndex = 2;
            // 
            // totaliLbl
            // 
            this.totaliLbl.Location = new System.Drawing.Point(313, 35);
            this.totaliLbl.Name = "totaliLbl";
            this.totaliLbl.Size = new System.Drawing.Size(128, 18);
            this.totaliLbl.TabIndex = 0;
            this.totaliLbl.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Totali :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kursi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Monedha :";
            // 
            // monedhatBox
            // 
   
            this.monedhatBox.FormattingEnabled = true;
            this.monedhatBox.Location = new System.Drawing.Point(81, 32);
            this.monedhatBox.Name = "monedhatBox";
            this.monedhatBox.Size = new System.Drawing.Size(154, 21);
            this.monedhatBox.TabIndex = 1;
            this.monedhatBox.SelectedValueChanged += new System.EventHandler(this.monedhatBox_SelectedValueChanged);
            // 
            // arkatBox
            // 

            this.arkatBox.FormattingEnabled = true;
            this.arkatBox.Location = new System.Drawing.Point(81, 6);
            this.arkatBox.Name = "arkatBox";
            this.arkatBox.Size = new System.Drawing.Size(154, 21);
            this.arkatBox.TabIndex = 1;
            this.arkatBox.SelectedValueChanged += new System.EventHandler(this.arkatBox_SelectedValueChanged);
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
            // button1
            // 
            this.button1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(259, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Hyrje / Dalje Monedhash";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radGridView1
            // 
    
            this.radGridView1.AllowUserToAddRows = false;
            this.radGridView1.AllowUserToDeleteRows = false;
            this.radGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.radGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RowHeadersWidth = 4;
            this.radGridView1.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.radGridView1.Size = new System.Drawing.Size(518, 418);
            this.radGridView1.TabIndex = 2;
            this.radGridView1.CellEndEdit += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.radGridView1_CellEndEdit);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radButton1, 0, 0);
            this.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 485);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(518, 37);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radGridView1);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 418);
            this.panel2.TabIndex = 3;
            // 
            // Prjerjet
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(518, 522);
            this.Text = "Prjerjet";
            this.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(this.Prjerjet_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button radButton1;
        private Panel panel1;
        private Label totaliLbl;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox monedhatBox;
        private ComboBox arkatBox;
        private Label label1;
        private DataGridView radGridView1;
        private Label kursiTxt;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;


    }
}