using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Forms;
using CRMMobileDemo.iOS;
using CustomCRMControls;

namespace CRMMobileDemo.Common
{
    public class ListedPanel : UserControl
    {
        public ListedPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            objList = new StaticDetailsView2ListView();
            //
            // objList
            //
            objList.Dock = DockStyle.Fill;

            this.Dock = DockStyle.Top;
            this.DockPadding.Top = 15;
            this.Controls.Add(objList);
        }

        private StaticDetailsView2ListView objList;

        internal void AddItems(params ListViewItem[] items)
        {
            this.objList.Items.Clear();

            for (int i = 0; i < items.Length; i++)
            {
                this.objList.Columns.Add(new ColumnHeader(" "));
            }

            foreach (var item in items)
            {
                this.objList.Items.Add(item);
            }

            this.Height = items.Length * (46) + 15;
        }
    }
}