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
    public partial class DropDownControl : UserControl
    {
        public DetailsListView l = new DetailsListView();
        
        //ne momentin e klikimit diku ne nderfaqe per te shfaqur kete user-control, automatikisht klikohet dhe elementi i user-control
            //qe gjendet poshte gishtit, pasi aktivizohet eventi i klikimit gabimisht
            //zgjidhja: klikimi i pare qe behet ne user-control eshte klikim bosh dhe do te perdoret EventHandler i pare
                //i cili do te pergatise nderfaqen per klikimin e dyte, qe do te jete ai i sakti
            //EventHandler i dyte eshte ai qe merret si parameter me nje funksion qe ndodhet ne nderfaqen ne te cilen u krijua user-control

        //EventHandler 'bosh'
        EventHandler first;
        //EventHandler qe merret si parameter
        EventHandler outer;

        public DropDownControl(DataTable d, int value_index, int viewing_index, EventHandler e)
        {
            //parametrat: 
                //d             => DataTable qe sherben per te mbushur dropdown me elemente
                //value_index   => index qe tregon kolonen qe do te perdoret si vlere e elementeve (index i kolones ValueMember)
                //viewing_index => index qe tregon kolonen qe do te perdoret si tekst i elementeve (index i kolones DisplayMember)
                //e             => EventHandler qe kalohet si parameter, me funksionin qe therritet ne klikim te nje elementi   
                    //funksioni ndodhet ne objektin i cili krijoi kete instance, veprimet ndodhin aty

            first = new EventHandler(clicked_first);
            outer = e;
            InitializeComponent();
            l.Columns.Add(new ColumnHeader("MainColumn"));
            for (int i = 0; i < d.Rows.Count; i++)
            {
                //shtojme elementet ne ListView sipas rreshtave te DataTable te kaluar si parameter
                    //vlera, pra ID do te kaloje ne emrin e elementit
                    //emertimi do te kaloje te tekstin e elementit
                l.Items.Add(new ListViewItem(d.Rows[i].ItemArray[viewing_index].ToString()) { Name = d.Rows[i].ItemArray[value_index].ToString() });
            }

            l.Click += first;

            this.Controls.Add(l);
            l.Dock = DockStyle.Fill;
        }

        private void clicked_first(object sender, EventArgs e)
        {
            //ne klikim te pare (qe normalisht eshte klikim i gabuar dhe bosh) kalojme si EventHandler te klikimit eventin e marre si parameter
            l.Click -= first;
            l.Click += outer;
        }
    }
}