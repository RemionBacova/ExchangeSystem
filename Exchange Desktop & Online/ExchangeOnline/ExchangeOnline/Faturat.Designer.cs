using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class Faturat
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
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.periudhaBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.periudhaChk = new Gizmox.WebGUI.Forms.CheckBox();
            this.checkBox1 = new Gizmox.WebGUI.Forms.CheckBox();
            this.levizjaBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.userBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.arkaBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.toDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.fromDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.radCheckBox1 = new Gizmox.WebGUI.Forms.CheckBox();
            this.filterBtn = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.tableLayoutPanel1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.printBtn = new Gizmox.WebGUI.Forms.Button();
            this.ndryshoBtn = new Gizmox.WebGUI.Forms.Button();
            this.copyBtn = new Gizmox.WebGUI.Forms.Button();
            this.radGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.periudhaBox);
            this.groupBox1.Controls.Add(this.periudhaChk);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.levizjaBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.userBox);
            this.groupBox1.Controls.Add(this.arkaBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.toDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fromDate);
            this.groupBox1.Controls.Add(this.radCheckBox1);
            this.groupBox1.Controls.Add(this.filterBtn);
            this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Periudha :";
            // 
            // periudhaBox
            // 

            this.periudhaBox.FormattingEnabled = true;
            this.periudhaBox.Items.AddRange(new object[] {
            "1 Jave",
            "2 Jave",
            "1 Muaj",
            "3 Muaj",
            "6 Muaj",
            "1 Vit",
            "2 Vjet",
            "Mbi 2 Vjet"});
            this.periudhaBox.Location = new System.Drawing.Point(71, 123);
            this.periudhaBox.Name = "periudhaBox";
            this.periudhaBox.Size = new System.Drawing.Size(179, 21);
            this.periudhaBox.TabIndex = 8;
            // 
            // periudhaChk
            // 
            this.periudhaChk.AutoSize = true;
            this.periudhaChk.Location = new System.Drawing.Point(16, 98);
            this.periudhaChk.Name = "periudhaChk";
            this.periudhaChk.Size = new System.Drawing.Size(135, 17);
            this.periudhaChk.TabIndex = 7;
            this.periudhaChk.Text = "Filtro Sipas Periudhes :";
            this.periudhaChk.CheckedChanged += new System.EventHandler(this.periudhaChk_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(340, 95);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Shfaq te Anuluarat";
            // 
            // levizjaBox
            // 

            this.levizjaBox.FormattingEnabled = true;
            this.levizjaBox.Items.AddRange(new object[] {
            "Te Gjitha",
            "Shitje",
            "Blerje"});
            this.levizjaBox.Location = new System.Drawing.Point(337, 71);
            this.levizjaBox.Name = "levizjaBox";
            this.levizjaBox.Size = new System.Drawing.Size(225, 21);
            this.levizjaBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Levizja :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Perdoruesi :";
            // 
            // userBox
            // 

            this.userBox.FormattingEnabled = true;
            this.userBox.Location = new System.Drawing.Point(337, 45);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(225, 21);
            this.userBox.TabIndex = 5;
            // 
            // arkaBox
            // 

            this.arkaBox.FormattingEnabled = true;
            this.arkaBox.Location = new System.Drawing.Point(337, 19);
            this.arkaBox.Name = "arkaBox";
            this.arkaBox.Size = new System.Drawing.Size(225, 21);
            this.arkaBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Arka :";
            // 
            // toDate
            // 
            this.toDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.toDate.CustomFormat = "";
            this.toDate.Location = new System.Drawing.Point(71, 73);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(179, 21);
            this.toDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Deri ne :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nga :";
            // 
            // fromDate
            // 
            this.fromDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.fromDate.CustomFormat = "";
            this.fromDate.Location = new System.Drawing.Point(71, 44);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(179, 21);
            this.fromDate.TabIndex = 2;
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.AutoSize = true;
            this.radCheckBox1.Location = new System.Drawing.Point(16, 19);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(109, 17);
            this.radCheckBox1.TabIndex = 1;
            this.radCheckBox1.Text = "Filtro Sipas Dates";
            this.radCheckBox1.CheckedChanged += new System.EventHandler(this.radCheckBox1_CheckedChanged);
            // 
            // filterBtn
            // 
            this.filterBtn.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.filterBtn.Location = new System.Drawing.Point(3, 154);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(565, 27);
            this.filterBtn.TabIndex = 0;
            this.filterBtn.Text = "Shfaq";
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 517);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 41);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Controls.Add(this.printBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ndryshoBtn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.copyBtn, 1, 0);
            this.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 41);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // printBtn
            // 
            this.printBtn.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.printBtn.Location = new System.Drawing.Point(0, 0);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(188, 41);
            this.printBtn.TabIndex = 0;
            this.printBtn.Text = "Printo";
            // 
            // ndryshoBtn
            // 
            this.ndryshoBtn.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ndryshoBtn.Location = new System.Drawing.Point(376, 0);
            this.ndryshoBtn.Name = "ndryshoBtn";
            this.ndryshoBtn.Size = new System.Drawing.Size(195, 41);
            this.ndryshoBtn.TabIndex = 0;
            this.ndryshoBtn.Text = "Anulo";
            this.ndryshoBtn.Click += new System.EventHandler(this.ndryshoBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.copyBtn.Location = new System.Drawing.Point(188, 0);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(188, 41);
            this.copyBtn.TabIndex = 0;
            this.copyBtn.Text = "Kopjo";
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // radGridView1
            // 

            this.radGridView1.AllowUserToAddRows = false;
            this.radGridView1.AllowUserToDeleteRows = false;
            this.radGridView1.AllowUserToResizeRows = false;
            this.radGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.radGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 184);
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RowHeadersWidth = 4;
            this.radGridView1.RowHeadersWidthSizeMode = Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.radGridView1.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.radGridView1.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.radGridView1.Size = new System.Drawing.Size(571, 333);
            this.radGridView1.TabIndex = 2;
            this.radGridView1.SelectionChanged += new System.EventHandler(this.radGridView1_SelectionChanged);
            // 
            // Faturat
            // 
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(571, 558);
            this.Text = "Faturat";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox levizjaBox;
        private Label label5;
        private Label label4;
        private ComboBox userBox;
        private ComboBox arkaBox;
        private Label label3;
        private DateTimePicker toDate;
        private Label label2;
        private Label label1;
        private DateTimePicker fromDate;
        private CheckBox radCheckBox1;
        private Button filterBtn;
        private Panel panel1;
        private Button printBtn;
        private DataGridView radGridView1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button copyBtn;
        private Button ndryshoBtn;
        private CheckBox checkBox1;
        private Label label6;
        private ComboBox periudhaBox;
        private CheckBox periudhaChk;


    }
}