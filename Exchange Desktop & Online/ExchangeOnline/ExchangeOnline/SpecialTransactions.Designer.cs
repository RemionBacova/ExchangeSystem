using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class SpecialTransactions
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.ngaBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.klientTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.sumTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.arkaBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.gjendjaLbl = new Gizmox.WebGUI.Forms.Label();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.radGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.konfirmoBtn = new Gizmox.WebGUI.Forms.Button();
            this.radioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.radioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Monedha :";
            // 
            // ngaBox
            // 
          
            this.ngaBox.FormattingEnabled = true;
            this.ngaBox.Location = new System.Drawing.Point(93, 9);
            this.ngaBox.Name = "ngaBox";
            this.ngaBox.Size = new System.Drawing.Size(80, 21);
            this.ngaBox.TabIndex = 2;
            this.ngaBox.SelectedValueChanged += new System.EventHandler(this.ngaBox_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Arsyeja :";
            // 
            // klientTxt
            // 

            this.klientTxt.Location = new System.Drawing.Point(93, 36);
            this.klientTxt.Name = "klientTxt";
            this.klientTxt.Size = new System.Drawing.Size(424, 20);
            this.klientTxt.TabIndex = 7;
            // 
            // sumTxt

            this.sumTxt.Location = new System.Drawing.Point(93, 62);
            this.sumTxt.Name = "sumTxt";
            this.sumTxt.Size = new System.Drawing.Size(424, 20);
            this.sumTxt.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Shuma :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Arka :";
            // 
            // arkaBox
            // 

            this.arkaBox.FormattingEnabled = true;
            this.arkaBox.Location = new System.Drawing.Point(93, 88);
            this.arkaBox.Name = "arkaBox";
            this.arkaBox.Size = new System.Drawing.Size(424, 21);
            this.arkaBox.TabIndex = 8;
            this.arkaBox.SelectedIndexChanged += new System.EventHandler(this.arkaBox_SelectedIndexChanged);
            // 
            // gjendjaLbl
            // 
            this.gjendjaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.gjendjaLbl.Location = new System.Drawing.Point(348, 118);
            this.gjendjaLbl.Name = "gjendjaLbl";
            this.gjendjaLbl.Size = new System.Drawing.Size(165, 20);
            this.gjendjaLbl.TabIndex = 10;
            this.gjendjaLbl.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(256, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Gjendja";
            // 
            // radGridView1
            // 
            this.radGridView1.AllowUserToAddRows = false;
            this.radGridView1.AllowUserToDeleteRows = false;
            this.radGridView1.AllowUserToResizeColumns = false;
            this.radGridView1.AllowUserToResizeRows = false;
            this.radGridView1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.radGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.radGridView1.ItemsPerPage = 100;
            this.radGridView1.Location = new System.Drawing.Point(11, 147);
            this.radGridView1.MultiSelect = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RowHeadersWidth = 4;
            this.radGridView1.RowHeadersWidthSizeMode = Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.radGridView1.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.radGridView1.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.radGridView1.ShowEditingIcon = false;
            this.radGridView1.Size = new System.Drawing.Size(506, 314);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.CellValueChanged += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.radGridView1_CellValueChanged);
            // 
            // konfirmoBtn
            // 
            this.konfirmoBtn.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.konfirmoBtn.Location = new System.Drawing.Point(11, 461);
            this.konfirmoBtn.Name = "konfirmoBtn";
            this.konfirmoBtn.Size = new System.Drawing.Size(506, 33);
            this.konfirmoBtn.TabIndex = 12;
            this.konfirmoBtn.Text = "Konfirmo";
            this.konfirmoBtn.Click += new System.EventHandler(this.konfirmoBtn_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(23, 118);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 17);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.Text = "Terheqje";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(105, 118);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 17);
            this.radioButton2.TabIndex = 16;
            this.radioButton2.Text = "Depozitim";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // SpecialTransactions
            // 
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.konfirmoBtn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.gjendjaLbl);
            this.Controls.Add(this.arkaBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sumTxt);
            this.Controls.Add(this.klientTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ngaBox);
            this.Controls.Add(this.label1);
            this.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Name = "ccc";
            this.Size = new System.Drawing.Size(531, 506);
            this.Text = "Cashier";
            this.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(this.SpecialTransactions_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private ComboBox ngaBox;
        private Label label4;
        private TextBox klientTxt;
        private TextBox sumTxt;
        private Label label6;
        private Label label7;
        private ComboBox arkaBox;
        private Label gjendjaLbl;
        private Label label13;
        private Button konfirmoBtn;
        private DataGridView radGridView1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;


    }
}