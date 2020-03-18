namespace Exchange
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.filterBtn = new Telerik.WinControls.UI.RadButton();
            this.levizjaBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.arkaBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.fromDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.exportBtn = new Telerik.WinControls.UI.RadButton();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.printBtn = new Telerik.WinControls.UI.RadButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 125);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radCheckBox1);
            this.groupBox1.Controls.Add(this.filterBtn);
            this.groupBox1.Controls.Add(this.levizjaBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.userBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.arkaBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.toDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fromDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Location = new System.Drawing.Point(66, 18);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(106, 18);
            this.radCheckBox1.TabIndex = 11;
            this.radCheckBox1.Text = "Filtro Sipas Dates";
            this.radCheckBox1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
            // 
            // filterBtn
            // 
            this.filterBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filterBtn.Location = new System.Drawing.Point(3, 98);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(526, 24);
            this.filterBtn.TabIndex = 10;
            this.filterBtn.Text = "Shfaq";
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // levizjaBox
            // 
            this.levizjaBox.FormattingEnabled = true;
            this.levizjaBox.Items.AddRange(new object[] {
            "Te Gjitha",
            "Shitje",
            "Blerje"});
            this.levizjaBox.Location = new System.Drawing.Point(300, 70);
            this.levizjaBox.Name = "levizjaBox";
            this.levizjaBox.Size = new System.Drawing.Size(226, 21);
            this.levizjaBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Levizja :";
            // 
            // userBox
            // 
            this.userBox.FormattingEnabled = true;
            this.userBox.Location = new System.Drawing.Point(300, 45);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(226, 21);
            this.userBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Perdoruesi :";
            // 
            // arkaBox
            // 
            this.arkaBox.FormattingEnabled = true;
            this.arkaBox.Location = new System.Drawing.Point(300, 20);
            this.arkaBox.Name = "arkaBox";
            this.arkaBox.Size = new System.Drawing.Size(226, 21);
            this.arkaBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Arka :";
            // 
            // toDate
            // 
            this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.toDate.Location = new System.Drawing.Point(66, 71);
            this.toDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.toDate.MinDate = new System.DateTime(((long)(0)));
            this.toDate.Name = "toDate";
            this.toDate.NullableValue = new System.DateTime(2013, 8, 6, 15, 30, 53, 433);
            this.toDate.NullDate = new System.DateTime(((long)(0)));
            this.toDate.Size = new System.Drawing.Size(150, 20);
            this.toDate.TabIndex = 3;
            this.toDate.TabStop = false;
            this.toDate.Text = "radDateTimePicker2";
            this.toDate.Value = new System.DateTime(2013, 8, 6, 15, 30, 53, 433);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Deri ne :";
            // 
            // fromDate
            // 
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.fromDate.Location = new System.Drawing.Point(66, 44);
            this.fromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.fromDate.MinDate = new System.DateTime(((long)(0)));
            this.fromDate.Name = "fromDate";
            this.fromDate.NullableValue = new System.DateTime(2013, 8, 6, 15, 30, 53, 433);
            this.fromDate.NullDate = new System.DateTime(((long)(0)));
            this.fromDate.Size = new System.Drawing.Size(150, 20);
            this.fromDate.TabIndex = 1;
            this.fromDate.TabStop = false;
            this.fromDate.Text = "radDateTimePicker1";
            this.fromDate.Value = new System.DateTime(2013, 8, 6, 15, 30, 53, 433);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nga :";
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
            this.radGridView1.Location = new System.Drawing.Point(0, 125);
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
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(532, 360);
            this.radGridView1.TabIndex = 1;
            this.radGridView1.Text = "radGridView1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radSplitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 485);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 41);
            this.panel2.TabIndex = 1;
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer1.Size = new System.Drawing.Size(532, 41);
            this.radSplitContainer1.SplitterWidth = 0;
            this.radSplitContainer1.TabIndex = 0;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.Text = "radSplitContainer1";
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.exportBtn);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel1.Size = new System.Drawing.Size(266, 41);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            // 
            // exportBtn
            // 
            this.exportBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportBtn.Location = new System.Drawing.Point(0, 0);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(266, 41);
            this.exportBtn.TabIndex = 0;
            this.exportBtn.Text = "Kopjo";
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.printBtn);
            this.splitPanel2.Location = new System.Drawing.Point(266, 0);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(266, 41);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "cc";
            // 
            // printBtn
            // 
            this.printBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printBtn.Location = new System.Drawing.Point(0, 0);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(266, 41);
            this.printBtn.TabIndex = 1;
            this.printBtn.Text = "Printo";
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // Faturat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 526);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Faturat";
            this.Text = "Faturat";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exportBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton filterBtn;
        private System.Windows.Forms.ComboBox levizjaBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox userBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox arkaBox;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadDateTimePicker toDate;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDateTimePicker fromDate;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.RadButton exportBtn;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadButton printBtn;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
    }
}