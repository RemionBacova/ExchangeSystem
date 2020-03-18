using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRMMobileDemo.Common;

namespace CRMMobileDemo.iOS
{
    public class ScreenManager
    {
        private TranslatePanel[] marrPanels;
        private int mintCurrentIndex;

        public ScreenManager(params TranslatePanel[] arrPanels)
        {
            marrPanels = arrPanels;
        }

        public void ShiftLeft()
        {
            ShiftTo(this.mintCurrentIndex -1);
        }

        public void ShiftRight()
        {
            ShiftTo(this.mintCurrentIndex + 1);
        }

        public TranslatePanel CurrentPanel
        {
            get
            {
                return this.marrPanels[mintCurrentIndex];
            }
        }

        public TranslatePanel PreviousPanel
        {
            get
            {
                return mintCurrentIndex == 0 ? null : this.marrPanels[mintCurrentIndex - 1];
            }
        }

        public TranslatePanel NextPanel
        {
            get
            {
                return mintCurrentIndex == marrPanels.Length - 1 ? null : this.marrPanels[mintCurrentIndex + 1];
            }
        }

        public void ShiftTo(TranslatePanel objPanel)
        {
            for (int i = 0; i < marrPanels.Length; i++)
            {
                if (marrPanels[i] == objPanel)
                {
                    ShiftTo(i);
                    break;
                }
            }
        }

        public void ShiftTo(int intIndex)
        {
            if (this.mintCurrentIndex != intIndex && intIndex >= 0 && intIndex < marrPanels.Length)
            {
                
                TranslatePanel objOutPanelCurrentPanel =marrPanels[mintCurrentIndex];

                // MoveRight
                if (intIndex > this.mintCurrentIndex)
                {
                    marrPanels[intIndex].InRight(false);
                    objOutPanelCurrentPanel.OutLeft(false);
                }
                else // MoveLeft
                {
                    marrPanels[intIndex].InLeft(false);
                    objOutPanelCurrentPanel.OutRight(false);                    
                }

                this.mintCurrentIndex = intIndex;

                Reorder(objOutPanelCurrentPanel);
            }
        }

        private void Reorder(TranslatePanel objOutPanelCurrentPanel)
        {
            for (int i = 0; i < marrPanels.Length; i++)
            {
                if (marrPanels[i] != objOutPanelCurrentPanel && i != mintCurrentIndex)
                {
                    if (i < mintCurrentIndex)
                    {
                        marrPanels[i].Visible = false;

                    }
                    else
                    {
                        marrPanels[i].Visible = false;
                    }
                }
                else
                {
                    marrPanels[i].Visible = true;
                }
            }
        }
    }
}