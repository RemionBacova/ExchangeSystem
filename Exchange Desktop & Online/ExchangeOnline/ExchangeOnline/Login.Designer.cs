using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.usernameTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.radButton1 = new Gizmox.WebGUI.Forms.Button();
            this.passwordTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Perdoruesi";
            // 
            // usernameTxt
            // 

            this.usernameTxt.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));

            this.usernameTxt.Location = new System.Drawing.Point(12, 28);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(289, 20);
            this.usernameTxt.TabIndex = 1;
            this.usernameTxt.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.usernameTxt_EnterKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fjalekalimi";
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.radButton1.Location = new System.Drawing.Point(12, 107);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(289, 25);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Login";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // passwordTxt
            // 
            this.passwordTxt.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
   
            this.passwordTxt.Location = new System.Drawing.Point(12, 74);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = 'o';
            this.passwordTxt.Size = new System.Drawing.Size(289, 20);
            this.passwordTxt.TabIndex = 1;
            this.passwordTxt.UseSystemPasswordChar = true;
            this.passwordTxt.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.passwordTxt_EnterKeyDown);
            // 
            // Login
            // 
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(313, 144);
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.Login_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox usernameTxt;
        private Label label2;
        private Button radButton1;
        private TextBox passwordTxt;


    }
}