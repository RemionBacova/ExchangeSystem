using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class Currencies
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
            this.anuloBtn = new Gizmox.WebGUI.Forms.Button();
            this.ruajBtn = new Gizmox.WebGUI.Forms.Button();
            this.checkBox1 = new Gizmox.WebGUI.Forms.CheckBox();
            this.emertimiTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.fshijBtn = new Gizmox.WebGUI.Forms.Button();
            this.editoBtn = new Gizmox.WebGUI.Forms.Button();
            this.shtoBtn = new Gizmox.WebGUI.Forms.Button();
            this.radGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.anuloBtn);
            this.panel1.Controls.Add(this.ruajBtn);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.emertimiTxt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 82);
            this.panel1.TabIndex = 0;
            // 
            // anuloBtn
            // 
            this.anuloBtn.Location = new System.Drawing.Point(162, 52);
            this.anuloBtn.Name = "anuloBtn";
            this.anuloBtn.Size = new System.Drawing.Size(162, 30);
            this.anuloBtn.TabIndex = 3;
            this.anuloBtn.Text = "Anulo";
            this.anuloBtn.Click += new System.EventHandler(this.anuloBtn_Click);
            // 
            // ruajBtn
            // 
            this.ruajBtn.Location = new System.Drawing.Point(0, 52);
            this.ruajBtn.Name = "ruajBtn";
            this.ruajBtn.Size = new System.Drawing.Size(162, 30);
            this.ruajBtn.TabIndex = 3;
            this.ruajBtn.Text = "Ruaj";
            this.ruajBtn.Click += new System.EventHandler(this.ruajBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Kerkim i Shpejte";
            // 
            // emertimiTxt
            // 

            this.emertimiTxt.Location = new System.Drawing.Point(66, 8);
            this.emertimiTxt.Name = "emertimiTxt";
            this.emertimiTxt.Size = new System.Drawing.Size(247, 20);
            this.emertimiTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emertimi :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fshijBtn);
            this.panel2.Controls.Add(this.editoBtn);
            this.panel2.Controls.Add(this.shtoBtn);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 263);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(325, 27);
            this.panel2.TabIndex = 1;
            // 
            // fshijBtn
            // 
            this.fshijBtn.Location = new System.Drawing.Point(216, 0);
            this.fshijBtn.Name = "fshijBtn";
            this.fshijBtn.Size = new System.Drawing.Size(108, 28);
            this.fshijBtn.TabIndex = 0;
            this.fshijBtn.Text = "Fshij";
            this.fshijBtn.Click += new System.EventHandler(this.fshijBtn_Click);
            // 
            // editoBtn
            // 
            this.editoBtn.Location = new System.Drawing.Point(108, 0);
            this.editoBtn.Name = "editoBtn";
            this.editoBtn.Size = new System.Drawing.Size(108, 28);
            this.editoBtn.TabIndex = 0;
            this.editoBtn.Text = "Edito";
            this.editoBtn.Click += new System.EventHandler(this.editoBtn_Click);
            // 
            // shtoBtn
            // 
            this.shtoBtn.Location = new System.Drawing.Point(0, 0);
            this.shtoBtn.Name = "shtoBtn";
            this.shtoBtn.Size = new System.Drawing.Size(108, 28);
            this.shtoBtn.TabIndex = 0;
            this.shtoBtn.Text = "Shto";
            this.shtoBtn.Click += new System.EventHandler(this.shtoBtn_Click);
            // 
            // radGridView1
            // 


            this.radGridView1.AllowUserToAddRows = false;
            this.radGridView1.AllowUserToDeleteRows = false;
            this.radGridView1.AllowUserToResizeColumns = false;
            this.radGridView1.AllowUserToResizeRows = false;
            this.radGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.radGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            this.radGridView1.MultiSelect = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RowHeadersWidth = 4;
            this.radGridView1.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.radGridView1.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.radGridView1.ShowEditingIcon = false;
            this.radGridView1.Size = new System.Drawing.Size(325, 263);
            this.radGridView1.TabIndex = 2;
            // 
            // Currencies
            // 
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(325, 372);
            this.Text = "Currencies";
            this.Load += new System.EventHandler(this.Currencies_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button anuloBtn;
        private Button ruajBtn;
        private CheckBox checkBox1;
        private TextBox emertimiTxt;
        private Label label1;
        private Panel panel2;
        private Button fshijBtn;
        private Button editoBtn;
        private Button shtoBtn;
        private DataGridView radGridView1;


    }
}