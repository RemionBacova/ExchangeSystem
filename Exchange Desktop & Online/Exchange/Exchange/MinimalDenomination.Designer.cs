namespace Exchange
{
    partial class MinimalDenomination
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.monedhaDrop = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monedha :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vlera minimale e transaksioneve :";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Location = new System.Drawing.Point(12, 79);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(243, 24);
            this.radButton1.TabIndex = 4;
            this.radButton1.Text = "Ruaj";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // monedhaDrop
            // 
            this.monedhaDrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.monedhaDrop.FormattingEnabled = true;
            this.monedhaDrop.Location = new System.Drawing.Point(76, 8);
            this.monedhaDrop.Name = "monedhaDrop";
            this.monedhaDrop.Size = new System.Drawing.Size(179, 21);
            this.monedhaDrop.TabIndex = 5;
            this.monedhaDrop.SelectedIndexChanged += new System.EventHandler(this.monedhaDrop_SelectedValueChanged);
            // 
            // MinimalDenomination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 119);
            this.Controls.Add(this.monedhaDrop);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MinimalDenomination";
            this.Text = "MinimalDenomination";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MinimalDenomination_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.ComboBox monedhaDrop;
    }
}