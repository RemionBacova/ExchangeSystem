using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class Raportet
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
            this.menuPanel = new Gizmox.WebGUI.Forms.Panel();
            this.raportiBtn = new Gizmox.WebGUI.Forms.Button();
            this.graphBtn = new Gizmox.WebGUI.Forms.Button();
            this.littleContainer = new Gizmox.WebGUI.Forms.Panel();
            this.kursetBtn = new Gizmox.WebGUI.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.kursetBtn);
            this.menuPanel.Controls.Add(this.raportiBtn);
            this.menuPanel.Controls.Add(this.graphBtn);
            this.menuPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(200, 554);
            this.menuPanel.TabIndex = 0;
            // 
            // raportiBtn
            // 
            this.raportiBtn.Location = new System.Drawing.Point(9, 36);
            this.raportiBtn.Name = "raportiBtn";
            this.raportiBtn.Size = new System.Drawing.Size(176, 27);
            this.raportiBtn.TabIndex = 0;
            this.raportiBtn.Text = "Raporti";
            this.raportiBtn.Click += new System.EventHandler(this.raportiBtn_Click);
            // 
            // graphBtn
            // 
            this.graphBtn.Location = new System.Drawing.Point(9, 9);
            this.graphBtn.Name = "graphBtn";
            this.graphBtn.Size = new System.Drawing.Size(176, 27);
            this.graphBtn.TabIndex = 0;
            this.graphBtn.Text = "Grafiket";
            this.graphBtn.Click += new System.EventHandler(this.graphBtn_Click);
            // 
            // littleContainer
            // 
            this.littleContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.littleContainer.Location = new System.Drawing.Point(200, 0);
            this.littleContainer.Name = "littleContainer";
            this.littleContainer.Size = new System.Drawing.Size(669, 554);
            this.littleContainer.TabIndex = 1;
            // 
            // kursetBtn
            // 
            this.kursetBtn.Location = new System.Drawing.Point(9, 63);
            this.kursetBtn.Name = "kursetBtn";
            this.kursetBtn.Size = new System.Drawing.Size(176, 27);
            this.kursetBtn.TabIndex = 0;
            this.kursetBtn.Text = "Kurset";
            this.kursetBtn.Click += new System.EventHandler(this.kursetBtn_Click);
            // 
            // Raportet
            // 
            this.Controls.Add(this.littleContainer);
            this.Controls.Add(this.menuPanel);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(869, 554);
            this.Text = "Raportet";
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel menuPanel;
        private Panel littleContainer;
        private Button raportiBtn;
        private Button graphBtn;
        private Button kursetBtn;



    }
}