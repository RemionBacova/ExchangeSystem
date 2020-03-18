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
    public partial class Arkat : TranslatePanel
    {
        DetailsListView dt = new DetailsListView();
        public Arkat()
        {
            InitializeComponent();

            //krijohet ListView qe mban te gjitha arkat, ne te cilen mund te zgjidhet nje element
            this.dt.Columns.Add(new ColumnHeader("Arka"));

            //ListView mbushet me arkat qe ndodhen ne DB
            DataTable arkat = Lidhja.Kerkesat1.a.selectAllRecFromTable("Arkat").Copy();

            //shtohen elemente ne ListView sipas vlerave te DataTable te arkave
            for (int i = 0; i < arkat.Rows.Count; i++)
            {
                //emertimi vendoset si tekst i elementit te ListView, ID vendoset si emer
                dt.Items.Add(new ListViewItem(arkat.Rows[i].ItemArray[1].ToString()) { Name = arkat.Rows[i].ItemArray[0].ToString() });
            }

            //shtohet eventi i klikimi
            dt.Click += new EventHandler(dt_Click);

            //shtohet ListView ne nderfaqe
            this.Controls.Add(dt);
            dt.Dock = DockStyle.Fill;
        }

        void dt_Click(object sender, EventArgs e)
        {
            //ne klikim te nje arke, therritet funksioni i kalimit ne nderfaqen e gjendjes se monedhave, duke kaluar si 
                //parameter ID e arkes se zgjedhur, pra emrin e elementit te zgjedhur te ListView
            ((iosForm)((Panel)this.Parent).Parent).goToMonedhatGjendje(((DetailsListView)(sender)).SelectedItem.Name);
        }
    }
}