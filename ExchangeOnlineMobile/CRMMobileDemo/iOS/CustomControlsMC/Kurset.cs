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
    public partial class Kurset : TranslatePanel
    {
        DetailsListView list = new DetailsListView();
        public Kurset()
        {
            InitializeComponent();
            list.Columns.Add(new ColumnHeader("Currency"));

            DataTable monedhat = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();

            //mbushim listen qe do te shfaqet me monedhat, te cilat i marrim nga DB
                //per cdo rresht te monedhave inserojme nje element ne liste me emrin e monedhes si tekst dhe ID si emer te elementit
            for (int i = 0; i < monedhat.Rows.Count; i++)
            {
                list.Items.Add(new ListViewItem(monedhat.Rows[i].ItemArray[1].ToString()) { Name = monedhat.Rows[i].ItemArray[0].ToString() });
            }

            list.Click += new EventHandler(list_Click);

            this.Controls.Add(list);
            list.Dock = DockStyle.Fill;

        }//COMM

        void list_Click(object sender, EventArgs e)
        {
            //ne zgjedhje te elementit therrasim funksionin qe kalon tek editimi i kurseve,
                //duke kaluar si parameter emrin e elementit qe eshte dhe ID e monedhes se zgjedhur
            ((iosForm)((Panel)this.Parent).Parent).goToShitjeBlerje(((DetailsListView)(sender)).SelectedItem.Name);
        }//COMM
    }
}