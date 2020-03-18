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

#endregion

namespace ExchangeOnline
{
    public partial class Arkat : Form
    {
        //variabli tregon nese perdoruesi po editon nje arke ose jo
        bool editing = false;
        public Arkat()
        {
            InitializeComponent();
            //ne krijim te formes, disa elemente vizuale duhen caktivizuar
            disableElements();
            //ne krijim te formes, shfaqen arkat ekzistente
            loadArkat();
        }//COMM

        public void loadArkat()
        {
            this.radGridView1.AutoGenerateColumns = true;
            this.radGridView1.DataSource = Lidhja.Kerkesat1.a.selectAllRecFromTable("arkat").Copy();
            //merren te gjitha arkat ekzistente dhe aktive per tu shfaqur
            this.radGridView1.Columns[0].Visible = false;
            this.radGridView1.Columns[1].HeaderText = "Arkat";
            this.radGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.AutoGenerateColumns = false;
            this.radGridView1.Update();
        }//COMM

        public void enableElements()
        {
            //funksioni qe aktivizon elementet vizuale qe sherbejne per te dhene informacionin e arkave qe po shtohen / editohen
                //elementet e meposhtem behen aktive
            this.emertimiTxt.Enabled = true;
            this.ruajBtn.Enabled = true;
            this.anuloBtn.Enabled = true;
                //elementet e meposhtem behen inaktive pasi nuk nevojiten ne shtim / editim te arkave
            this.shtoBtn.Enabled = false;
            this.editoBtn.Enabled = false;
            this.fshijBtn.Enabled = false;
            this.radGridView1.Enabled = false;
        }//COMM

        public void disableElements()
        {
            //funksioni qe caktivizon elementet vizuale, pasi nuk po shtohet / editohet asnje arke
                //elementet e meposhtem behen jo-aktive
            this.emertimiTxt.Enabled = false;
            this.ruajBtn.Enabled = false;
            this.anuloBtn.Enabled = false;
                //elementet e meposhtem behen aktive, pra aktivizohet butoni shto, edito, fshij
            this.shtoBtn.Enabled = true;
            this.editoBtn.Enabled = true;
            this.fshijBtn.Enabled = true;
            this.radGridView1.Enabled = true;
            this.emertimiTxt.Text = "";
        }//COMM

        private void shtoBtn_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit shto, aktivizohen elementet vizuale qe sherbejne per te
                //vendosur perdoruesi informacionin e nevojshem per arken e re
            enableElements();
            //ne rastin kur shtohet arka, variabli i klases tregon qe nuk po editohet nje arke
            editing = false;
        }//COMM

        private void editoBtn_Click(object sender, EventArgs e)
        {
            //veprimet do te behen vetem nese perdoruesi ka zgjedhur nje arke per te edituar
            if (this.radGridView1.SelectedRows.Count > 0)
            {
                //elementet vizuale do te aktivizohen per perdoruesin qe te mund te hedhe informacionin e arkes
                enableElements();
                //elementet vizuale te mepposhtme do te mbushen me informacionin aktual te arkes
                this.emertimiTxt.Text = this.radGridView1.SelectedRows[0].Cells[1].Value.ToString();
                //variabli i klases tregon qe perdoruesi po editon
                editing = true;
            }
        }//COMM

        private void fshijBtn_Click(object sender, EventArgs e)
        {
            //veprimet kryhen ne rastin kur eshte zgjedhur nje element
            if (this.radGridView1.SelectedRows.Count > 0)
            {
                //MessageBox ne te cilin perdoruesi konfirmon fshirjen, 
                    //eventi qe kalohet si parameter therret funksionin fshijAccepted qe ben fshirjen pasi perdoruesi konfirmon
                DialogResult a = MessageBox.Show("Jeni te sigurt qe doni te fshini arken e zgjedhur?", "Kujdes!", 
                    MessageBoxButtons.YesNo, new EventHandler(fshijAccepted));
            }
        }//COMM

        private void fshijAccepted(object sender, EventArgs e)
        {
            //funksioni qe therritet ne rastin kur perdoruesi konfirmon fshirjen,
                //veprimet kryhen nese perdoruesi ka klikuar 'YES'
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                //ne konfirmim therritet procedura ne SQL qe fshin elementin e zgjedhur
                Lidhja.Kerkesat1.a.deleteFromTable(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), "arkat");
                //merren perseri te gjitha arkat aktive pas fshirjes se elementit
                loadArkat();
            }
        }//COMM

        private void ruajBtn_Click(object sender, EventArgs e)
        {
            //butoni qe ben ruajtjen e informacionit ne rastin kur po editohet ose shtohet nje arke
                //editimi ose shtimi tregohen nga variabli i klases
            if (editing)
            {
                //ne rast editimi, therritet procedura qe ben UPDATE
                Lidhja.Kerkesat1.a.updateArkat(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), this.emertimiTxt.Text);
            }
            else
            {
                //ne rast shtimi therritet procedura qe ben INSERT
                Lidhja.Kerkesat1.a.insertArkat(this.emertimiTxt.Text);
            }
            //pasi behet ruajtja, elementet vizuale caktivizohen perseri dhe aktivizohen butonat SHTO, EDITO dhe FSHIJ
            disableElements();
            //pas ruajtjes, merren te gjitha arkat e DB, pra dhe arka qe u shtua, ose arka e edituar ne versionin e ri
            loadArkat();
        }//COMM

        private void anuloBtn_Click(object sender, EventArgs e)
        {
            //ne anulim, thjesht caktivizohen elementet duke mos lene mundesi per ruajtje te informacionit 
            disableElements();
        }//COMM
    }
}