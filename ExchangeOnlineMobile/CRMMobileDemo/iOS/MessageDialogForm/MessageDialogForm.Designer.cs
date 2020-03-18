using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.VisualEffects;
using System.Drawing;

namespace CRMMobileDemo.iOS
{
    partial class MessageDialogForm
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
            this.mobjLabelText = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // mobjLabelText
            // 
            this.mobjLabelText.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabelText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mobjLabelText.Font = new System.Drawing.Font("Arial", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.mobjLabelText.ForeColor = System.Drawing.Color.White;
            this.mobjLabelText.Name = "mobjLabelText";
            this.mobjLabelText.TabIndex = 2;
            this.mobjLabelText.UseMnemonic = false;
            // 
            // MessageDialogForm
            //             
            this.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(233)))), ((int)(((byte)(237))))));
            this.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(2);
            this.Controls.Add(this.mobjLabelText);
            this.DockPadding.All = 10;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxWindow";
            this.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.None;
            this.Size = new System.Drawing.Size(250, 125);
            this.VisualEffect = new Gizmox.WebGUI.Forms.VisualEffects.VisualEffectGroup(new Gizmox.WebGUI.Forms.VisualEffects.VisualEffect[] {
            ((Gizmox.WebGUI.Forms.VisualEffects.VisualEffect)(new Gizmox.WebGUI.Forms.VisualEffects.BorderRadiusVisualEffect(12))),
            ((Gizmox.WebGUI.Forms.VisualEffects.VisualEffect)(new Gizmox.WebGUI.Forms.VisualEffects.GradientBackgroundVisualEffect( Gizmox.WebGUI.Forms.VisualEffects.GradientType.Linear,null, HorizontalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.VerticalDirection.Bottom,new GradientStop[]
            {
                new GradientStop(0,Color.FromArgb(105,114,135), LengthUnits.Percent),
                new GradientStop(6,Color.FromArgb(105,114,135), LengthUnits.Percent),
                new GradientStop(9,Color.FromArgb(99,108,131), LengthUnits.Percent),
                new GradientStop(22,Color.FromArgb( 63,74,101), LengthUnits.Percent),
                new GradientStop(25,Color.FromArgb(56,67,96), LengthUnits.Percent),
                new GradientStop(26,Color.FromArgb(22,35,68), LengthUnits.Percent),
                new GradientStop(100,Color.FromArgb(22,35,68), LengthUnits.Percent)
            },null, LengthUnits.Percent, LengthUnits.Percent,null,null,null)))});
            
            this.ResumeLayout(false);

        }

        private Gizmox.WebGUI.Forms.Label mobjLabelText;
        private Button mobjButton1;
        private Button mobjButton2;
        private Button mobjButton3;
        private Gizmox.WebGUI.Forms.MessageBoxDefaultButton menmDefaultButton;

        #endregion


    }
}