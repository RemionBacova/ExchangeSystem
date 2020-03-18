/*
' Visual WebGui - http://www.visualwebgui.com
' Copyright (c) 2005
' by Gizmox Inc. ( http://www.gizmox.com )
'
' This program is free software; you can redistribute it and/or modify it 
' under the terms of the GNU General Public License as published by the Free 
' Software Foundation; either version 2 of the License, or (at your option) 
' any later version.
'
' THIS PROGRAM IS DISTRIBUTED IN THE HOPE THAT IT WILL BE USEFUL, 
' BUT WITHOUT ANY WARRANTY; WITHOUT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY 
' OR FITNESS FOR A PARTICULAR PURPOSE. SEE THE GNU GENERAL PUBLIC LICENSE FOR MORE DETAILS.
' YOU SHOULD HAVE RECEIVED A COPY OF THE GNU GENERAL PUBLIC LICENSE ALONG WITH THIS PROGRAM; if not, 
' write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
'
' contact: opensource@visualwebgui.com
*/

#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using CRMMobileDemo.Common;

#endregion Using

namespace CRMMobileDemo.Common
{
    /// <summary>
    /// A Panel control
    /// </summary>
    [Serializable()]
    public class TranslatePanel : UserControl
    {
        public TranslatePanel()
        {
            this.Dock = DockStyle.Fill;
        }

        public void OutRight(bool blnWithDelay)
        {
            if (blnWithDelay)
            {
                this.VisualEffect = new FlyOutToRightVisualEffect(1, 0.1M, Gizmox.WebGUI.Forms.VisualEffects.TransitionTimingFunction.Ease);
            }
            else
            {
                this.VisualEffect = new FlyOutToRightVisualEffect();
            }
        }
        public void OutLeft(bool blnWithDelay)
        {
            if (blnWithDelay)
            {
                this.VisualEffect = new FlyOutToLeftVisualEffect(1, 0.1M, Gizmox.WebGUI.Forms.VisualEffects.TransitionTimingFunction.Ease);
            }
            else
            {
                this.VisualEffect = new FlyOutToLeftVisualEffect();
            }
        }

        public void InRight(bool blnWithDelay)
        {
            if (blnWithDelay)
            {
                this.VisualEffect = new FlyInFromRightVisualEffect(1, 0.1M, Gizmox.WebGUI.Forms.VisualEffects.TransitionTimingFunction.Ease);
            }
            else
            {
                this.VisualEffect = new FlyInFromRightVisualEffect();
            }
        }

        public void InLeft(bool blnWithDelay)
        {
            if (blnWithDelay)
            {
                this.VisualEffect = new FlyInFromLeftVisualEffect(1, 0.1M, Gizmox.WebGUI.Forms.VisualEffects.TransitionTimingFunction.Ease);
            }
            else
            {
                this.VisualEffect = new FlyInFromLeftVisualEffect();
            }
        }
    }
}