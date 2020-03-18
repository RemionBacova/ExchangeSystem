using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CRMMobileDemo.iOS.CustomControlsMC
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.usernameTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.passwordTxt = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.msgLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Perdoruesi :";
            // 
            // usernameTxt
            // 
            this.usernameTxt.AllowDrag = false;
            this.usernameTxt.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.usernameTxt.Location = new System.Drawing.Point(3, 30);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(763, 27);
            this.usernameTxt.TabIndex = 1;
            // 
            // passwordTxt
            // 
            this.passwordTxt.AllowDrag = false;
            this.passwordTxt.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.passwordTxt.Location = new System.Drawing.Point(3, 83);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(763, 27);
            this.passwordTxt.TabIndex = 1;
            this.passwordTxt.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fjalekalimi :";
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Location = new System.Drawing.Point(7, 122);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(35, 13);
            this.msgLabel.TabIndex = 2;
            // 
            // Login
            // 
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.label1);
            this.Size = new System.Drawing.Size(0, 0);
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        public TextBox usernameTxt;
        public TextBox passwordTxt;
        public Label msgLabel;


    }
}