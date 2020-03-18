using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class UserArka
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
            this.radButton2 = new Gizmox.WebGUI.Forms.Button();
            this.radButton1 = new Gizmox.WebGUI.Forms.Button();
            this.tableLayoutPanel1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.middleGrid = new Gizmox.WebGUI.Forms.DataGridView();
            this.arkaGrid = new Gizmox.WebGUI.Forms.DataGridView();
            this.userGrid = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.middleGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arkaGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radButton2);
            this.panel1.Controls.Add(this.radButton1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 31);
            this.panel1.TabIndex = 0;
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(368, 0);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(368, 31);
            this.radButton2.TabIndex = 0;
            this.radButton2.Text = "Fshij Lidhjen";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(0, 0);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(368, 31);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Shto Lidhjen";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.Controls.Add(this.arkaGrid, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.userGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.middleGrid, 1, 0);
            this.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(736, 480);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // middleGrid
            // 


            this.middleGrid.AllowUserToAddRows = false;
            this.middleGrid.AllowUserToDeleteRows = false;
            this.middleGrid.AllowUserToResizeColumns = false;
            this.middleGrid.AllowUserToResizeRows = false;
            this.middleGrid.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.middleGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.middleGrid.ItemsPerPage = 100;
            this.middleGrid.Location = new System.Drawing.Point(242, 0);
            this.middleGrid.Name = "middleGrid";
            this.middleGrid.ReadOnly = true;
            this.middleGrid.RowHeadersWidth = 4;
            this.middleGrid.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.middleGrid.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.middleGrid.Size = new System.Drawing.Size(242, 480);
            this.middleGrid.TabIndex = 4;
            // 
            // arkaGrid
            // 

            this.arkaGrid.AllowUserToAddRows = false;
            this.arkaGrid.AllowUserToDeleteRows = false;
            this.arkaGrid.AllowUserToResizeColumns = false;
            this.arkaGrid.AllowUserToResizeRows = false;
            this.arkaGrid.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.arkaGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.arkaGrid.ItemsPerPage = 100;
            this.arkaGrid.Location = new System.Drawing.Point(484, 0);
            this.arkaGrid.Name = "arkaGrid";
            this.arkaGrid.ReadOnly = true;
            this.arkaGrid.RowHeadersWidth = 4;
            this.arkaGrid.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.arkaGrid.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.arkaGrid.Size = new System.Drawing.Size(242, 480);
            this.arkaGrid.TabIndex = 5;
            // 
            // userGrid
            // 
 
            this.userGrid.AllowUserToAddRows = false;
            this.userGrid.AllowUserToDeleteRows = false;
            this.userGrid.AllowUserToResizeColumns = false;
            this.userGrid.AllowUserToResizeRows = false;
            this.userGrid.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.userGrid.ItemsPerPage = 100;
            this.userGrid.Location = new System.Drawing.Point(0, 0);
            this.userGrid.Name = "userGrid";
            this.userGrid.ReadOnly = true;
            this.userGrid.RowHeadersWidth = 4;
            this.userGrid.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.userGrid.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userGrid.Size = new System.Drawing.Size(242, 480);
            this.userGrid.TabIndex = 6;
            this.userGrid.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.userGrid_CellClick);
            // 
            // UserArka
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(736, 511);
            this.Text = "UserArka";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.middleGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arkaGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button radButton2;
        private Button radButton1;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView middleGrid;
        private DataGridView arkaGrid;
        private DataGridView userGrid;


    }
}