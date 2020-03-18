#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using CustomCRMControls;
using CRMMobileDemo.Common;

#endregion

namespace CRMMobileDemo.iOS.CustomControlsMC
{
    public partial class MainMenuPanel : TranslatePanel
    {
        DetailsListView menu = new DetailsListView();
        public MainMenuPanel()
        {
            InitializeComponent();
            menu.Columns.Add(new ColumnHeader("name"));

            //elementet e ListView qe perfaqesojne menute hidhen manualisht, me ID te cilat hidhen si emra te cdo elementi
            menu.Items.Add(new ListViewItem("Kurset") { Name = "1" });
            menu.Items.Add(new ListViewItem("Gjendjet") { Name = "2" });

            menu.Click += new EventHandler(menu_Click);
            this.Controls.Add(menu);
            menu.Dock = DockStyle.Fill;
        }

        void menu_Click(object sender, EventArgs e)
        {
            switch (((DetailsListView)(sender)).SelectedItem.Name)
            {
                case "1":
                    {
                        //nese kemi zgjedhur elementin me ID 1, kalojme ne nderfaqen e kurseve
                        ((iosForm)((Panel)this.Parent).Parent).goToKurset();
                        break;
                    }
                case "2":
                    {
                        //nese kemi zgjedhur elementin me ID 2, kalojme ne nderfaqen e arkave dhe gjendjeve me pas
                        ((iosForm)((Panel)this.Parent).Parent).goToArkat();
                        break;
                    }
                default:
                    {
                        //empty
                        break;
                    }
            }
        }
    }
}