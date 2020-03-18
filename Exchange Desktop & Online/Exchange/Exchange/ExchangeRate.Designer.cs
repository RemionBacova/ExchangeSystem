namespace Exchange
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bankaGrid = new Telerik.WinControls.UI.RadGridView();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ccGrid = new Telerik.WinControls.UI.RadGridView();
            this.splitPanel3 = new Telerik.WinControls.UI.SplitPanel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankaGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankaGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).BeginInit();
            this.splitPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Controls.Add(this.splitPanel3);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer1.Size = new System.Drawing.Size(531, 523);
            this.radSplitContainer1.SplitterWidth = 0;
            this.radSplitContainer1.TabIndex = 0;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.Text = "radSplitContainer1";
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.groupBox1);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel1.Size = new System.Drawing.Size(531, 245);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.1347518F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -135);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bankaGrid);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 245);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bank";
            // 
            // bankaGrid
            // 
            this.bankaGrid.BackColor = System.Drawing.SystemColors.Control;
            this.bankaGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.bankaGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bankaGrid.EnableHotTracking = false;
            this.bankaGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.bankaGrid.ForeColor = System.Drawing.Color.Black;
            this.bankaGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bankaGrid.Location = new System.Drawing.Point(3, 18);
            // 
            // bankaGrid
            // 
            this.bankaGrid.MasterTemplate.AllowAddNewRow = false;
            this.bankaGrid.MasterTemplate.AllowColumnChooser = false;
            this.bankaGrid.MasterTemplate.AllowColumnReorder = false;
            this.bankaGrid.MasterTemplate.AllowColumnResize = false;
            this.bankaGrid.MasterTemplate.AllowDragToGroup = false;
            this.bankaGrid.MasterTemplate.AllowRowResize = false;
            this.bankaGrid.MasterTemplate.EnableGrouping = false;
            this.bankaGrid.MasterTemplate.EnableSorting = false;
            this.bankaGrid.MasterTemplate.ShowRowHeaderColumn = false;
            this.bankaGrid.Name = "bankaGrid";
            this.bankaGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.bankaGrid.RootElement.ForeColor = System.Drawing.Color.Black;
            this.bankaGrid.ShowGroupPanel = false;
            this.bankaGrid.Size = new System.Drawing.Size(525, 224);
            this.bankaGrid.TabIndex = 0;
            this.bankaGrid.Text = "radGridView1";
            this.bankaGrid.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.bankaGrid_CellValueChanged);
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.groupBox2);
            this.splitPanel2.Location = new System.Drawing.Point(0, 245);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(531, 253);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.1502257F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -26);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ccGrid);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 253);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CC";
            // 
            // ccGrid
            // 
            this.ccGrid.BackColor = System.Drawing.SystemColors.Control;
            this.ccGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.ccGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccGrid.EnableHotTracking = false;
            this.ccGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ccGrid.ForeColor = System.Drawing.Color.Black;
            this.ccGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ccGrid.Location = new System.Drawing.Point(3, 18);
            // 
            // ccGrid
            // 
            this.ccGrid.MasterTemplate.AllowAddNewRow = false;
            this.ccGrid.MasterTemplate.AllowColumnChooser = false;
            this.ccGrid.MasterTemplate.AllowColumnReorder = false;
            this.ccGrid.MasterTemplate.AllowColumnResize = false;
            this.ccGrid.MasterTemplate.AllowDragToGroup = false;
            this.ccGrid.MasterTemplate.AllowRowResize = false;
            this.ccGrid.MasterTemplate.EnableGrouping = false;
            this.ccGrid.MasterTemplate.EnableSorting = false;
            this.ccGrid.MasterTemplate.ShowRowHeaderColumn = false;
            this.ccGrid.Name = "ccGrid";
            this.ccGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.ccGrid.RootElement.ForeColor = System.Drawing.Color.Black;
            this.ccGrid.ShowGroupPanel = false;
            this.ccGrid.Size = new System.Drawing.Size(525, 232);
            this.ccGrid.TabIndex = 1;
            this.ccGrid.Text = "radGridView2";
            this.ccGrid.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.ccGrid_CellValueChanged);
            // 
            // splitPanel3
            // 
            this.splitPanel3.Controls.Add(this.radButton1);
            this.splitPanel3.Location = new System.Drawing.Point(0, 498);
            this.splitPanel3.Name = "splitPanel3";
            // 
            // 
            // 
            this.splitPanel3.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel3.Size = new System.Drawing.Size(531, 25);
            this.splitPanel3.SizeInfo.AbsoluteSize = new System.Drawing.Size(200, 25);
            this.splitPanel3.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.2849774F);
            this.splitPanel3.SizeInfo.MaximumSize = new System.Drawing.Size(0, 25);
            this.splitPanel3.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 161);
            this.splitPanel3.TabIndex = 2;
            this.splitPanel3.TabStop = false;
            this.splitPanel3.Text = "j";
            // 
            // radButton1
            // 
            this.radButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radButton1.Location = new System.Drawing.Point(0, 0);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(531, 25);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Ruaj";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // ExchangeRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 523);
            this.Controls.Add(this.radSplitContainer1);
            this.Name = "ExchangeRate";
            this.Text = "ExchangeRate";
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bankaGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankaGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ccGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).EndInit();
            this.splitPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView bankaGrid;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadGridView ccGrid;
        private Telerik.WinControls.UI.SplitPanel splitPanel3;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}