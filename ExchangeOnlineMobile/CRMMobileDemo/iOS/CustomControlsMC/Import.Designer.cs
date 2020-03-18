using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CRMMobileDemo.iOS.CustomControlsMC
{
    partial class Import
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.radioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.msgLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.msgLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.sourceItem = new Gizmox.WebGUI.Forms.TextBox();
            this.destinationItem = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.kursiItem = new Gizmox.WebGUI.Forms.TextBox();
            this.tableLayoutPanel2 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.monthBox = new Gizmox.WebGUI.Forms.TextBox();
            this.dayBox = new Gizmox.WebGUI.Forms.TextBox();
            this.yearBox = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 9);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(119, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Nga Kurset e Vjetra";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 99);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(135, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "Nga Burime te Jashtme";
            // 
            // msgLabel1
            // 
            this.msgLabel1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.msgLabel1.Location = new System.Drawing.Point(5, 74);
            this.msgLabel1.Name = "msgLabel1";
            this.msgLabel1.Size = new System.Drawing.Size(1091, 20);
            this.msgLabel1.TabIndex = 3;
            // 
            // msgLabel2
            // 
            this.msgLabel2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.msgLabel2.Location = new System.Drawing.Point(7, 284);
            this.msgLabel2.Name = "msgLabel2";
            this.msgLabel2.Size = new System.Drawing.Size(1091, 16);
            this.msgLabel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Burimi";
            // 
            // sourceItem
            // 
            this.sourceItem.AllowDrag = false;
            this.sourceItem.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.sourceItem.Location = new System.Drawing.Point(4, 141);
            this.sourceItem.Name = "sourceItem";
            this.sourceItem.ReadOnly = true;
            this.sourceItem.Size = new System.Drawing.Size(1091, 27);
            this.sourceItem.TabIndex = 7;
            this.sourceItem.GotFocus += new System.EventHandler(this.sourceItem_GotFocus);
            // 
            // destinationItem
            // 
            this.destinationItem.AllowDrag = false;
            this.destinationItem.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.destinationItem.Location = new System.Drawing.Point(4, 193);
            this.destinationItem.Name = "destinationItem";
            this.destinationItem.ReadOnly = true;
            this.destinationItem.Size = new System.Drawing.Size(1091, 27);
            this.destinationItem.TabIndex = 7;
            this.destinationItem.GotFocus += new System.EventHandler(this.destinationItem_GotFocus);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Destinacioni";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Kursi";
            // 
            // kursiItem
            // 
            this.kursiItem.AllowDrag = false;
            this.kursiItem.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.kursiItem.Location = new System.Drawing.Point(4, 247);
            this.kursiItem.Name = "kursiItem";
            this.kursiItem.ReadOnly = true;
            this.kursiItem.Size = new System.Drawing.Size(1091, 27);
            this.kursiItem.TabIndex = 7;
            this.kursiItem.GotFocus += new System.EventHandler(this.kursiItem_GotFocus);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.Controls.Add(this.monthBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dayBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.yearBox, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1091, 33);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // monthBox
            // 
            this.monthBox.AllowDrag = false;
            this.monthBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.monthBox.Location = new System.Drawing.Point(363, 3);
            this.monthBox.Name = "monthBox";
            this.monthBox.ReadOnly = true;
            this.monthBox.Size = new System.Drawing.Size(354, 27);
            this.monthBox.TabIndex = 0;
            this.monthBox.GotFocus += new System.EventHandler(this.monthBox_GotFocus);
            // 
            // dayBox
            // 
            this.dayBox.AllowDrag = false;
            this.dayBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.dayBox.Location = new System.Drawing.Point(3, 3);
            this.dayBox.Name = "dayBox";
            this.dayBox.ReadOnly = true;
            this.dayBox.Size = new System.Drawing.Size(354, 27);
            this.dayBox.TabIndex = 0;
            this.dayBox.GotFocus += new System.EventHandler(this.dayBox_GotFocus);
            // 
            // yearBox
            // 
            this.yearBox.AllowDrag = false;
            this.yearBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.yearBox.Location = new System.Drawing.Point(723, 3);
            this.yearBox.Name = "yearBox";
            this.yearBox.ReadOnly = true;
            this.yearBox.Size = new System.Drawing.Size(365, 27);
            this.yearBox.TabIndex = 0;
            this.yearBox.GotFocus += new System.EventHandler(this.yearBox_GotFocus);
            // 
            // Import
            // 
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.kursiItem);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.destinationItem);
            this.Controls.Add(this.sourceItem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.msgLabel2);
            this.Controls.Add(this.msgLabel1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Size = new System.Drawing.Size(1091, 839);
            this.Text = "Import";
            this.ResumeLayout(false);

        }

        #endregion

        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label msgLabel1;
        private Label msgLabel2;
        private Label label5;
        private TextBox sourceItem;
        private TextBox destinationItem;
        private Label label6;
        private Label label7;
        private TextBox kursiItem;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox monthBox;
        private TextBox dayBox;
        private TextBox yearBox;


    }
}