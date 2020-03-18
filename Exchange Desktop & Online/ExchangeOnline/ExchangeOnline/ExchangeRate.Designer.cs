using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class ExchangeRate
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
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.bankaGrid = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.radButton1 = new Gizmox.WebGUI.Forms.Button();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.ccGrid = new Gizmox.WebGUI.Forms.DataGridView();
            this.tableLayoutPanel1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankaGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bankaGrid);
            this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Banka";
            // 
            // bankaGrid
            // 


            this.bankaGrid.AllowUserToAddRows = false;
            this.bankaGrid.AllowUserToDeleteRows = false;
            this.bankaGrid.AllowUserToResizeColumns = false;
            this.bankaGrid.AllowUserToResizeRows = false;
            this.bankaGrid.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bankaGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.bankaGrid.ItemsPerPage = 100;
            this.bankaGrid.Location = new System.Drawing.Point(3, 17);
            this.bankaGrid.Name = "bankaGrid";
            this.bankaGrid.RowHeadersWidth = 4;
            this.bankaGrid.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.bankaGrid.Size = new System.Drawing.Size(512, 212);
            this.bankaGrid.TabIndex = 0;
            this.bankaGrid.CellValueChanged += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.bankaGrid_CellValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 37);
            this.panel1.TabIndex = 1;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(0, 0);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(259, 37);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Ruaj";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ccGrid);
            this.groupBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(0, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 248);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CC";
            // 
            // ccGrid
            // 
   
            this.ccGrid.AllowUserToAddRows = false;
            this.ccGrid.AllowUserToDeleteRows = false;
            this.ccGrid.AllowUserToResizeColumns = false;
            this.ccGrid.AllowUserToResizeRows = false;
            this.ccGrid.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ccGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ccGrid.Location = new System.Drawing.Point(3, 17);
            this.ccGrid.Name = "ccGrid";
            this.ccGrid.RowHeadersWidth = 4;
            this.ccGrid.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.ccGrid.Size = new System.Drawing.Size(512, 228);
            this.ccGrid.TabIndex = 0;
            this.ccGrid.CellValueChanged += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.ccGrid_CellValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.radButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(518, 37);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(259, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Importo...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExchangeRate
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(518, 517);
            this.Text = "ExchangeRate";
            this.Load += new System.EventHandler(this.ExchangeRate_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bankaGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ccGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView bankaGrid;
        private Panel panel1;
        private Button radButton1;
        private GroupBox groupBox2;
        private DataGridView ccGrid;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;


    }
}