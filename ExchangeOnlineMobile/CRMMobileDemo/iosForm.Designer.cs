using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.Drawing;
using CRMMobileDemo.iOS;
using Gizmox.WebGUI.Common.Resources;
using CRMMobileDemo.Common;

namespace CRMMobileDemo
{
    partial class iosForm
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

        private void InitializeComponent()
        {
            this.NavigationPanel = new Gizmox.WebGUI.Forms.Panel();
            this.ButtonPanel = new Gizmox.WebGUI.Forms.Panel();
            this.postBtn = new Gizmox.WebGUI.Forms.Button();
            this.MainPanel = new Gizmox.WebGUI.Forms.Panel();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NavigationPanel
            // 
            this.NavigationPanel.BackColor = System.Drawing.Color.Transparent;
            this.NavigationPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.NavigationPanel.Location = new System.Drawing.Point(0, 0);
            this.NavigationPanel.Name = "NavigationPanel";
            this.NavigationPanel.Size = new System.Drawing.Size(353, 49);
            this.NavigationPanel.TabIndex = 0;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.postBtn);
            this.ButtonPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 612);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(353, 58);
            this.ButtonPanel.TabIndex = 2;
            // 
            // postBtn
            // 
            this.postBtn.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.postBtn.Location = new System.Drawing.Point(0, 0);
            this.postBtn.Name = "postBtn";
            this.postBtn.Size = new System.Drawing.Size(353, 58);
            this.postBtn.TabIndex = 0;
            this.postBtn.Text = "button1";
            this.postBtn.Click += new System.EventHandler(this.postBtn_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 49);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(353, 563);
            this.MainPanel.TabIndex = 1;
            // 
            // iosForm
            // 
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.NavigationPanel);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(353, 670);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        void iosForm_Load(object sender, System.EventArgs e)
        {
            HandleInitControl(this);
        }

        private void HandleInitControl(Control objControl)
        {
            if (objControl is IRequiresInit)
            {
                (objControl as IRequiresInit).InitData();
            }

            foreach (Control objInnerControl in objControl.Controls)
            {
                HandleInitControl(objInnerControl);
            }
        }


        private TabPage mobjSettingsPage;
        private TabPage mobjEmployeesPage;
        private TabPage mobjOrdersPage;
        private TabPage mobjCustomersPage;
        private TabControl mobjTabControl;
        private Panel NavigationPanel;
        private Panel ButtonPanel;
        private Button postBtn;
        private Panel MainPanel;
    }
}