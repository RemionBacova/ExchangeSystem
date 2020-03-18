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
    public partial class Currencies : Form
    {
        //variabli tregon nese perdoruesi po editon nje arke ose jo
        bool editing = false;
        public Currencies()
        {
            InitializeComponent();
        }

        public void loadCurrencies()
        {
            //funksioni qe shfaq te gjitha monedhat ekzistente nga DB
            this.radGridView1.AutoGenerateColumns = true;
            this.radGridView1.DataSource = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();
            this.radGridView1.Columns[0].Visible = false;
            this.radGridView1.Columns[1].HeaderText = "Monedhat";
            this.radGridView1.Columns[2].HeaderText = "E Preferuar";
            this.radGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.AutoGenerateColumns = false;
            this.radGridView1.Update();
        }//COMM

        public void enableElements()
        {
            //funksioni qe aktivizon elementet vizuale qe sherbejne per te dhene informacionin e arkave qe po shtohen / editohen
            this.emertimiTxt.Enabled = true;
            this.ruajBtn.Enabled = true;
            this.shtoBtn.Enabled = false;
            this.editoBtn.Enabled = false;
            this.fshijBtn.Enabled = false;
            this.radGridView1.Enabled = false;
            this.anuloBtn.Enabled = true;
            this.checkBox1.Enabled = true;
        }//COMM

        public void disableElements()
        {
            //funksioni qe caktivizon elementet vizuale qe sherbejne per te dhene informacionin e arkave qe po shtohen / editohen
            this.emertimiTxt.Enabled = false;
            this.ruajBtn.Enabled = false;
            this.shtoBtn.Enabled = true;
            this.editoBtn.Enabled = true;
            this.fshijBtn.Enabled = true;
            this.radGridView1.Enabled = true;
            this.anuloBtn.Enabled = false;
            this.checkBox1.Enabled = false;
            this.checkBox1.Checked = false;
            this.emertimiTxt.Text = "";
        }//COMM

        private void shtoBtn_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit shto, aktivizohen elementet vizuale qe sherbejne per te
                //vendosur perdoruesi informacionin e nevojshem per monedhen e re
            enableElements();
            //ne rastin kur shtohet monedha, variabli i klases tregon qe nuk po editohet nje monedhe
            editing = false;
        }//COMM

        private void editoBtn_Click(object sender, EventArgs e)
        {
            //veprimet do te behen vetem nese perdoruesi ka zgjedhur nje monedhe per te edituar
            if (this.radGridView1.SelectedRows.Count > 0)
            {
                //elementet vizuale do te aktivizohen per perdoruesin qe te mund te hedhe informacionin e monedhes
                enableElements();
                //elementet vizuale te mepposhtme do te mbushen me informacionin aktual te monedhes
                this.emertimiTxt.Text = this.radGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.checkBox1.Checked = bool.Parse(this.radGridView1.SelectedRows[0].Cells[2].Value.ToString());
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
                DialogResult a = MessageBox.Show("Jeni te sigurt qe doni te fshini monedhen e zgjedhur?", "Kujdes!", 
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
                Lidhja.Kerkesat1.a.deleteFromTable(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), "monedhat");
                //merren perseri te gjitha arkat aktive pas fshirjes se elementit
                loadCurrencies();
                //caktivizohen elementet vizuale qe nevojiten per te shtuar / edituar
                disableElements();
                //therritet funksioni i formes kryesore qe shfaq monedhat dhe kurset e tyre ne panelin ne krahun e djathte me kurset
                ((Form1)this.MdiParent).loadGrids();
            }
        }//COMM

        private void ruajBtn_Click(object sender, EventArgs e)
        {
            //butoni qe ben ruajtjen e informacionit ne rastin kur po editohet ose shtohet nje monedhe
                //editimi ose shtimi tregohen nga variabli i klases
            if (editing)
            {
                //ne rast editimi, therritet procedura qe ben UPDATE
                Lidhja.Kerkesat1.a.updateMonedha(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), this.emertimiTxt.Text, this.checkBox1.Checked);
            }
            else
            {
                //ne rast shtimi therritet procedura qe ben INSERT
                Lidhja.Kerkesat1.a.insertMonedha(this.emertimiTxt.Text, this.checkBox1.Checked);
            }
            //pasi behet ruajtja, elementet vizuale caktivizohen perseri dhe aktivizohen butonat SHTO, EDITO dhe FSHIJ
            disableElements();
            //pas ruajtjes, merren te gjitha arkat e DB, pra dhe arka qe u shtua, ose arka e edituar ne versionin e ri
            loadCurrencies();
            //pas ruajtjes, therritet funksioni qe shfaq kurset e monedhave ne dashboard
            ((Form1)this.MdiParent).loadThreaded();

            //funksioni i meposhtem i komentuar ben te njejten gje si ai me siper, por pa THREAD
            //((Form1)this.MdiParent).loadGrids();
        }//COMM

        private void anuloBtn_Click(object sender, EventArgs e)
        {
            //ne anulim, thjesht caktivizohen elementet duke mos lene mundesi per ruajtje te informacionit 
            disableElements();
        }//COMM

        private void Currencies_Load(object sender, EventArgs e)
        {
            this.radGridView1.AutoGenerateColumns = true;
            //ne LOAD te formes, disa elemente vizuale duhen caktivizuar
            disableElements();
            //ne LOAD te formes, shfaqen arkat ekzistente
            loadCurrencies();
        }//COMM
    }
}