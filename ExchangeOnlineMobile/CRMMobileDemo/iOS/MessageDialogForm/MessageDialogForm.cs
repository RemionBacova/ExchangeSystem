#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI;
using CustomCRMControls;

#endregion

namespace CRMMobileDemo.iOS
{
    public partial class MessageDialogForm : Form
    {
        #region Members
        private MessageBoxButtons menmButtons;
        #endregion

        public MessageDialogForm(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, EventHandler objEventHandler)
            : base(objOwner.Context)
        {
            InitializeComponent();

            menmButtons = enmButtons;

            menmDefaultButton = enmDefaultButton;

            int intButtonCount = 0;

            #region Buttons

            #region Button1
            int buttonHeight = 0;
            intButtonCount++;

            // Resetting the AcceptButton and CancelButton properties of the Form.
            this.AcceptButton = this.CancelButton = null;

            // Set the first button.
            this.mobjButton1 = new Button();
            SetButtonStyle(this.mobjButton1);

            switch (menmButtons)
            {
                case MessageBoxButtons.OK:
                    this.mobjButton1.Text = WGLabels.Ok;
                    this.mobjButton1.DialogResult = DialogResult.OK;

                    // Creating a separate button that would respond in server-side if the Esc button is pressed.
                    // This button is not displayed on client UI.
                    Button objButton2 = new Button();
                    objButton2.Text = "OK";
                    objButton2.Dock = DockStyle.Bottom;
                    buttonHeight = 20;objButton2.Size = new Size(20,30);
                    //SetButtonStyle(objButton2);
                    // This is the only situation at which DialogResult is set to None.
                    objButton2.DialogResult = DialogResult.None;
                    this.Controls.Add(objButton2);
                    // Setting the AcceptButton and CancelButton to their relevant buttons.
                    this.AcceptButton = mobjButton1;
                    this.CancelButton = objButton2; // Using the newly created separate 
                    break;
                case MessageBoxButtons.OKCancel:
                    this.mobjButton1.Text = WGLabels.Ok;
                    this.mobjButton1.DialogResult = DialogResult.OK;

                    // Setting the AcceptButton to it's relevant button.
                    this.AcceptButton = mobjButton1;
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    this.mobjButton1.Text = WGLabels.Abort;
                    this.mobjButton1.DialogResult = DialogResult.Abort;
                    break;

                case MessageBoxButtons.RetryCancel:
                    this.mobjButton1.Text = WGLabels.Retry;
                    this.mobjButton1.DialogResult = DialogResult.Retry;
                    break;

                case MessageBoxButtons.YesNo:
                case MessageBoxButtons.YesNoCancel:
                    this.mobjButton1.Text = WGLabels.Yes;
                    this.mobjButton1.DialogResult = DialogResult.Yes;
                    this.mobjButton3 = null;
                    break;
            }

            #endregion

            #endregion

            #region Texts

            // Set description and caption - text values.
            this.mobjLabelText.Text = strText;
            this.Text = strCaption;

            // Measure the description's text size.
            Size objTextsize = CommonUtils.GetStringMeasurements(strText, this.mobjLabelText.Font, objOwner.Width);

            // Calculate the messagebox sizes.
            int intWidth = Math.Min(Math.Max(0, objTextsize.Width) + (this.Padding.All * 2),280);
            int intHeight = buttonHeight + objTextsize.Height + 50;

            // Set the messagebox's calculated size.
            this.SuspendLayout();
            this.Size = new Size(intWidth, intHeight);
            this.ClientSize = new Size(intWidth, intHeight);
            this.ResumeLayout(false);

            #endregion

            if (objEventHandler != null)
            {
                this.Closed += objEventHandler;
            }
        }

        /// <summary>
        /// Adds the table layout column style.
        /// </summary>
        /// <param name="objTableLayoutPanel">The obj table layout panel.</param>
        /// <param name="objColumnStyle">The obj column style.</param>
        private void AddTableLayoutColumnStyle(TableLayoutPanel objTableLayoutPanel, ColumnStyle objColumnStyle)
        {
            if (objTableLayoutPanel != null && objColumnStyle != null)
            {
                objTableLayoutPanel.ColumnStyles.Add(objColumnStyle);
                objTableLayoutPanel.ColumnCount += 1;
            }
        }

        /// <summary>
        /// Adds the table layout row style.
        /// </summary>
        /// <param name="objTableLayoutPanel">The obj table layout panel.</param>
        /// <param name="objRowStyle">The obj row style.</param>
        private void AddTableLayoutRowStyle(TableLayoutPanel objTableLayoutPanel, RowStyle objRowStyle)
        {
            if (objTableLayoutPanel != null && objRowStyle != null)
            {
                objTableLayoutPanel.RowStyles.Add(objRowStyle);
                objTableLayoutPanel.RowCount += 1;
            }
        }

        /// <summary>
        /// setting the button general styles to fit the application style
        /// </summary>
        /// <param name="objButton"></param>
        private void SetButtonStyle(Button objButton)
        {
            objButton.AutoSize = false;
            objButton.Size = new System.Drawing.Size(94, 44);
        }
    }
}