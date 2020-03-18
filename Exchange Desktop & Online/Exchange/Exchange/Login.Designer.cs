namespace Exchange
{
    partial class Login
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
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Perdoruesi";
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(12, 27);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(276, 20);
            this.usernameTxt.TabIndex = 1;
            this.usernameTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTxt_KeyDown);
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(12, 72);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(276, 20);
            this.passwordTxt.TabIndex = 3;
            this.passwordTxt.UseSystemPasswordChar = true;
            this.passwordTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTxt_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fjalekalimi";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(12, 101);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(276, 24);
            this.radButton1.TabIndex = 4;
            this.radButton1.Text = "Login";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 137);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}