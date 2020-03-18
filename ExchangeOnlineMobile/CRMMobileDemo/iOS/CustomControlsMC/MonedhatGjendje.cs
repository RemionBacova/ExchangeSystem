#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using CRMMobileDemo.Common;
using CustomCRMControls;

#endregion

namespace CRMMobileDemo.iOS.CustomControlsMC
{
    public partial class MonedhatGjendje : TranslatePanel
    {
        string arka_id = "";
        DetailsListView dtl = new DetailsListView();
        public MonedhatGjendje()
        {
            InitializeComponent();
            
        }

        public void fillData(string arka_id)
        {
            //funksion qe mbush te dhenat e gjendjeve nga DB
            this.arka_id = arka_id;
            this.Controls.Clear();
            dtl = new DetailsListView();
            dtl.Columns.Add(new ColumnHeader("Monedha"));
            dtl.Columns.Add(new ColumnHeader("Gjendja"));

            //merren gjendjet per cdo monedhe per arken e kaluar si parameter nga SQL
            DataTable infot = Lidhja.Kerkesat1.a.selectGjendjetByArka(arka_id).Copy();

            for (int i = 0; i < infot.Rows.Count; i++)
            {
                dtl.Items.Add(
                    new ListViewItem(
                        new string[2]
                        {
                            //shtojme emertimin e monedhes dhe gjendjen per monedhen si tekste te elementit te listes
                            infot.Rows[i].ItemArray[1].ToString(),
                            infot.Rows[i].ItemArray[2].ToString()
                        })
                    {
                        //ID e monedhes e vendosim si emer te elementit te listes
                        Name = infot.Rows[i].ItemArray[0].ToString()
                    });
            }

            dtl.Click += new EventHandler(dtl_Click);
            this.Controls.Add(dtl);
            dtl.Dock = DockStyle.Fill;
        }

        void dtl_Click(object sender, EventArgs e)
        {
            if (this.dtl.SelectedItems.Count > 0)
            {
                //ne zgjedhje te nje monedhe kalohet ne nderfaqen ku behen transaksione hyrje/dalje te monedhes se zgjedhur
                ((iosForm)((Panel)this.Parent).Parent).goToTransaksionGjendje(((DetailsListView)(sender)).SelectedItem.Name, this.arka_id, 
                    ((DetailsListView)(sender)).SelectedItem.SubItems[0].Text);
            }
        }
    }
}