using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class Users
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
            this.ruajBtn = new Gizmox.WebGUI.Forms.Button();
            this.anuloBtn = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.emriTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.mbiemriTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.idTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.usernameTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.passwordTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.radioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.radioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.shtoBtn = new Gizmox.WebGUI.Forms.Button();
            this.editoBtn = new Gizmox.WebGUI.Forms.Button();
            this.fshijBtn = new Gizmox.WebGUI.Forms.Button();
            this.radGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.passwordTxt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.usernameTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.idTxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.mbiemriTxt);
            this.panel1.Controls.Add(this.emriTxt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.anuloBtn);
            this.panel1.Controls.Add(this.ruajBtn);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 212);
            this.panel1.TabIndex = 0;
            // 
            // ruajBtn
            // 
            this.ruajBtn.Location = new System.Drawing.Point(0, 183);
            this.ruajBtn.Name = "ruajBtn";
            this.ruajBtn.Size = new System.Drawing.Size(147, 29);
            this.ruajBtn.TabIndex = 0;
            this.ruajBtn.Text = "Ruaj";
            this.ruajBtn.Click += new System.EventHandler(this.ruajBtn_Click);
            // 
            // anuloBtn
            // 
            this.anuloBtn.Location = new System.Drawing.Point(147, 183);
            this.anuloBtn.Name = "anuloBtn";
            this.anuloBtn.Size = new System.Drawing.Size(147, 29);
            this.anuloBtn.TabIndex = 0;
            this.anuloBtn.Text = "Anulo";
            this.anuloBtn.Click += new System.EventHandler(this.anuloBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Emri :";
            // 
            // emriTxt
            // 

            this.emriTxt.Location = new System.Drawing.Point(75, 7);
            this.emriTxt.Name = "emriTxt";
            this.emriTxt.Size = new System.Drawing.Size(207, 20);
            this.emriTxt.TabIndex = 2;
            // 
            // mbiemriTxt
            // 

            this.mbiemriTxt.Location = new System.Drawing.Point(75, 33);
            this.mbiemriTxt.Name = "mbiemriTxt";
            this.mbiemriTxt.Size = new System.Drawing.Size(207, 20);
            this.mbiemriTxt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mbiemri :";
            // 
            // idTxt
            // 

            this.idTxt.Location = new System.Drawing.Point(75, 59);
            this.idTxt.Name = "idTxt";
            this.idTxt.Size = new System.Drawing.Size(207, 20);
            this.idTxt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID :";
            // 
            // usernameTxt
            // 

            this.usernameTxt.Location = new System.Drawing.Point(75, 85);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(207, 20);
            this.usernameTxt.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Username :";
            // 
            // passwordTxt
            // 

            this.passwordTxt.Location = new System.Drawing.Point(75, 111);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(207, 20);
            this.passwordTxt.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password :";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 136);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "Administrator";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 158);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "Kasier";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fshijBtn);
            this.panel2.Controls.Add(this.editoBtn);
            this.panel2.Controls.Add(this.shtoBtn);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 248);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 31);
            this.panel2.TabIndex = 1;
            // 
            // shtoBtn
            // 
            this.shtoBtn.Location = new System.Drawing.Point(0, 0);
            this.shtoBtn.Name = "shtoBtn";
            this.shtoBtn.Size = new System.Drawing.Size(98, 31);
            this.shtoBtn.TabIndex = 0;
            this.shtoBtn.Text = "Shto";
            this.shtoBtn.Click += new System.EventHandler(this.shtoBtn_Click);
            // 
            // editoBtn
            // 
            this.editoBtn.Location = new System.Drawing.Point(98, 0);
            this.editoBtn.Name = "editoBtn";
            this.editoBtn.Size = new System.Drawing.Size(98, 31);
            this.editoBtn.TabIndex = 0;
            this.editoBtn.Text = "Edito";
            this.editoBtn.Click += new System.EventHandler(this.editoBtn_Click);
            // 
            // fshijBtn
            // 
            this.fshijBtn.Location = new System.Drawing.Point(196, 0);
            this.fshijBtn.Name = "fshijBtn";
            this.fshijBtn.Size = new System.Drawing.Size(98, 31);
            this.fshijBtn.TabIndex = 0;
            this.fshijBtn.Text = "Fshij";
            this.fshijBtn.Click += new System.EventHandler(this.fshijBtn_Click);
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
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RowHeadersWidth = 4;
            this.radGridView1.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("sq-AL");
            this.radGridView1.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.radGridView1.Size = new System.Drawing.Size(294, 248);
            this.radGridView1.TabIndex = 2;
            // 
            // Users
            // 
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(294, 491);
            this.Text = "Users";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label5;
        private TextBox passwordTxt;
        private Label label4;
        private TextBox usernameTxt;
        private Label label3;
        private TextBox idTxt;
        private Label label2;
        private TextBox mbiemriTxt;
        private TextBox emriTxt;
        private Label label1;
        private Button anuloBtn;
        private Button ruajBtn;
        private Panel panel2;
        private Button fshijBtn;
        private Button editoBtn;
        private Button shtoBtn;
        private DataGridView radGridView1;


    }
}