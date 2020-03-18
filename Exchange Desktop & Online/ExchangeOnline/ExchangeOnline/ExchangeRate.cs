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
    public partial class ExchangeRate : Form
    {

        #region declarative_section

        DataGridViewTextBoxColumn monedha_id;
        DataGridViewTextBoxColumn monedha;
        DataGridViewTextBoxColumn blerje;
        DataGridViewTextBoxColumn shitje;
        DataGridViewTextBoxColumn existent;
        DataGridViewTextBoxColumn value_changed;
        DataGridViewTextBoxColumn current_id;

        DataGridViewTextBoxColumn monedha2_id;
        DataGridViewTextBoxColumn monedha2;
        DataGridViewTextBoxColumn blerje2;
        DataGridViewTextBoxColumn shitje2;
        DataGridViewTextBoxColumn existent2;
        DataGridViewTextBoxColumn value_changed2;
        DataGridViewTextBoxColumn current_id2;

        //DataTable qe mbajne te dhenat ne nivel klase
        DataTable monedhat;
        DataTable vlera_arka;
        DataTable vlera_banka;

        //variabli qe tregon a kemi ndryshime te paruajtura apo jo
            //true  -> kemi ndryshime te paruajtura
            //false -> nuk kemi ndryshime ose jane ruajtur
        bool exchange_rates_changed = false;

        #endregion

        public ExchangeRate()
        {
            InitializeComponent();

            //eventi qe shfaq MessageBox per konfirmim mbyllje ne rastin kur kemi ndryshime te paruajtura
            this.FormClosing += new FormClosingEventHandler(ExchangeRate_FormClosing);
        }

        //variabli qe tregon se perdoruesi e ka konfirmuar mbylljen pa ruajtur te dhenat
        bool close_accepted = false;
        void ExchangeRate_FormClosing(object sender, FormClosingEventArgs e)
        {
            //nese kemi ndryshime dhe perdoruesi nuk ka konfirmuar mbylljen, shfaqet MessageBox per konfirmim
                //funksioni qe therritet ne mbyllje te MessageBox te konfirmimit ndodhet ne EventHandler te kaluar si parameter
            if (exchange_rates_changed)
            {
                if (!close_accepted)
                {
                    DialogResult dr = MessageBox.Show("Jane kryer ndryshime te te dhenave.\n\rJeni te sigurt qe doni te mbyllni dritaren pa ruajtur ndryshimet?",
                        "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(closed));
                    //mbyllja anulohet
                    e.Cancel = true;
                }
            }
        }//COMM

        private void closed(object sender, EventArgs e)
        {
            //nese eshte konfirmuar mbyllja, i japim vleren variablit per te mos u futur ne bllokun e IF ne event te mbylljes
                //dhe e mbyllim formen
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                close_accepted = true;
                this.Close();
            }
        }//COMM

        public void loadData()
        {
            //mbushja e DataTable me te dhena
            #region obsolete_SQL
            //vlera_arka = Lidhja.Kerkesat1.a.selectAllRecFromTable("arka").Copy();
            //vlera_banka = Lidhja.Kerkesat1.a.selectAllRecFromTable("banka").Copy();
            #endregion

            //te gjitha monedhat ne DataTable
            monedhat = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();
            //te gjitha kurset e monedhave te percaktuara diten e sotme
                //nese per nje monedhe nuk ka kurs, nuk do te shfaqet asgje ne rrestin perkates por do te pritet kursi nga perdoruesi
            vlera_arka = Lidhja.Kerkesat1.a.excecuteScript("select * from arka where aktiv = 1 and DataKrijimit = CONVERT(date, '" + DateTime.Now.ToString("dd/MM/yyyy") + "', 103)").Copy();
                //te gjitha kurset e bankes
            vlera_banka = Lidhja.Kerkesat1.a.excecuteScript("select * from banka where aktiv = 1").Copy();

            //pasi mbushen DataTable qe ndodhen ne nivel klase, therriten funksionet e mbushjes se GridView-ve per banken dhe arken
            fillBankaGrid();
            fillCCGrid();
        }//COMM

        private void fillBankaGrid()
        {
            //funksioni qe mbush GridView qe shfaq kurset e bankes

            //fshirje e informacionit ekzistent
            this.bankaGrid.Rows.Clear();
            this.bankaGrid.Columns.Clear();

            //inicializimi i kolonave te percaktuara ne nivel klase qe do te shtohen ne GridView
                //kolona qe mban ID e monedhes
            monedha_id = new DataGridViewTextBoxColumn();
            monedha_id.Visible = false;
                //kolona qe mban emertimin e monedhes
            monedha = new DataGridViewTextBoxColumn();
            monedha.ReadOnly = true;
            monedha.HeaderText = "Monedha";
                //kolona qe mban kursin me te cilin kjo monedhe blihet
            blerje = new DataGridViewTextBoxColumn();
            blerje.HeaderText = "Blerje";
                //kolona qe mban kursin me te cilin kjo monedhe shitet
            shitje = new DataGridViewTextBoxColumn();
            shitje.HeaderText = "Shitje";
                //kolona qe tregon nqs kursi i kembimiteshte ne DB apo jo (vendos a do kryhet INSERT apo UPDATE)
            existent = new DataGridViewTextBoxColumn();
            existent.Visible = false;
                //kolone qe mban nje BOOL qe tregon se kjo monedhe ka nje vlere te ndryshuar nga perdoruesi ne nje nga kurset e kembimit
                //shtuar per arsye performance, nese nuk eshte ndryshuar vlera, nuk behet INSERT/UPDATE
            value_changed = new DataGridViewTextBoxColumn();
            value_changed.Visible = false;
                //kolone qe mban ID e rekordit me informacion mbi kurset e kembimit
            current_id = new DataGridViewTextBoxColumn();
            current_id.Visible = false;

            //shtim i kolonave
            this.bankaGrid.Columns.Add(monedha_id);
            this.bankaGrid.Columns.Add(monedha);
            this.bankaGrid.Columns.Add(blerje);
            this.bankaGrid.Columns.Add(shitje);
            this.bankaGrid.Columns.Add(existent);
            this.bankaGrid.Columns.Add(value_changed);
            this.bankaGrid.Columns.Add(current_id);

            this.bankaGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //variabel qe tregon se kemi gjetur vlera te kursit te shitjes dhe blerjes per monedhen aktuale
            bool foundValue = false;
            for (int i = 0; i < monedhat.Rows.Count; i++)
            {
                foundValue = false;
                for (int j = 0; j < vlera_banka.Rows.Count; j++)
                {
                    //per monedhen aktuale shikojme nese kemi nje vlere te kurseve ne DataTable qe mban kurset
                    if (monedhat.Rows[i].ItemArray[0].ToString() == vlera_banka.Rows[j].ItemArray[1].ToString())
                    {
                        //nese po, e shtojme kete vlere ne GridView duke shperndare informacionin sipas kolonave
                        this.bankaGrid.Rows.Add(monedhat.Rows[i].ItemArray[0].ToString(), monedhat.Rows[i].ItemArray[1].ToString(),
                            vlera_banka.Rows[j].ItemArray[2].ToString(), vlera_banka.Rows[j].ItemArray[3].ToString(), 1, "0", vlera_banka.Rows[j].ItemArray[0].ToString());
                        //u gjend nje vlere, pra nuk eshte e nevojshme te kalohet ne bllokun e meposhtem, i cili kryen veprime
                            //ne rastin kur nuk kemi kurs shitje ose blerje per monedhen
                        foundValue = true;
                        break;
                    }
                }
                if (!foundValue)
                {
                    //nese nuk gjetem nje kurs per monedhen aktuale, shtojme rekordin me informacionin mbi monedhen, por
                        //me kurset bosh per tu hedhur nga perdoruesi
                    this.bankaGrid.Rows.Add(monedhat.Rows[i].ItemArray[0].ToString(), monedhat.Rows[i].ItemArray[1].ToString(), "", "", 0, "0", "");
                }
            }
        }//COMM

        private void fillCCGrid()
        {
            //funksioni qe mbush GridView qe shfaq kurset e arkes

            //fshirje e informacionit ekzistent
            this.ccGrid.Rows.Clear();
            this.ccGrid.Columns.Clear();

            //inicializimi i kolonave te percaktuara ne nivel klase qe do te shtohen ne GridView
                //kolona qe mban ID e monedhes
            monedha2_id = new DataGridViewTextBoxColumn();
            monedha2_id.Visible = false;
                //kolona qe mban emrin e monedhes
            monedha2 = new DataGridViewTextBoxColumn();
            monedha2.ReadOnly = true;
            monedha2.HeaderText = "Monedha";
                //kolona qe mban kursin e blerjes per monedhen
            blerje2 = new DataGridViewTextBoxColumn();
            blerje2.HeaderText = "Blerje";
                //kolona qe mban kursin e shitjes per monedhen
            shitje2 = new DataGridViewTextBoxColumn();
            shitje2.HeaderText = "Shitje";
                //kolona qe tregon nqs kursi i kembimiteshte ne DB apo jo (vendos a do kryhet INSERT apo UPDATE)
            existent2 = new DataGridViewTextBoxColumn();
            existent2.Visible = false;
                //kolone qe mban nje BOOL qe tregon se kjo monedhe ka nje vlere te ndryshuar nga perdoruesi ne nje nga kurset e kembimit
                //shtuar per arsye performance, nese nuk eshte ndryshuar vlera, nuk behet INSERT/UPDATE
            value_changed2 = new DataGridViewTextBoxColumn();
            value_changed2.Visible = false;
                //kolone qe mban ID e rekordit me informacion mbi kurset e kembimit
            current_id2 = new DataGridViewTextBoxColumn();
            current_id2.Visible = false;

            //shtim i kolonave
            this.ccGrid.Columns.Add(monedha2_id);
            this.ccGrid.Columns.Add(monedha2);
            this.ccGrid.Columns.Add(blerje2);
            this.ccGrid.Columns.Add(shitje2);
            this.ccGrid.Columns.Add(existent2);
            this.ccGrid.Columns.Add(value_changed2);
            this.ccGrid.Columns.Add(current_id2);

            this.ccGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //variabel qe tregon se kemi gjetur vlera te kursit te shitjes dhe blerjes per monedhen aktuale
            bool foundValue = false;
            for (int i = 0; i < monedhat.Rows.Count; i++)
            {
                //per monedhen aktuale shikojme nese kemi nje vlere te kurseve ne DataTable qe mban kurset
                foundValue = false;
                for (int j = 0; j < vlera_arka.Rows.Count; j++)
                {
                    if (monedhat.Rows[i].ItemArray[0].ToString() == vlera_arka.Rows[j].ItemArray[1].ToString())
                    {
                        //nese po, e shtojme kete vlere ne GridView duke shperndare informacionin sipas kolonave
                        this.ccGrid.Rows.Add(monedhat.Rows[i].ItemArray[0].ToString(), monedhat.Rows[i].ItemArray[1].ToString(),
                            vlera_arka.Rows[j].ItemArray[2].ToString(), vlera_arka.Rows[j].ItemArray[3].ToString(), 1, "0", this.vlera_arka.Rows[j].ItemArray[0].ToString());
                        //u gjend nje vlere, pra nuk eshte e nevojshme te kalohet ne bllokun e meposhtem, i cili kryen veprime
                            //ne rastin kur nuk kemi kurs shitje ose blerje per monedhen
                        foundValue = true;
                        break;
                    }
                }
                if (!foundValue)
                {
                    //nese nuk gjetem nje kurs per monedhen aktuale, shtojme rekordin me informacionin mbi monedhen, por
                        //me kurset bosh per tu hedhur nga perdoruesi
                    this.ccGrid.Rows.Add(monedhat.Rows[i].ItemArray[0].ToString(), monedhat.Rows[i].ItemArray[1].ToString(), "", "", 0, "0", "");
                }
            }
        }//COMM

        public void saveData()
        {
            //funksion qe ruan informacionin e hedhur nga perdoruesi per banken dhe per arken
            saveBanka();
            saveCC();
            MessageBox.Show("Kurset u ruajten!");
        }//COMM

        public void saveBanka()
        {
            //funksioni qe ben INSERT ose UPDATE per te dhenat e hedhura per banken nga perdoruesi
            for (int i = 0; i < this.bankaGrid.Rows.Count; i++)
            {
                //nqs kemi nje vlere te ndryshuar nga perdoruesi per rreshtin e kapur nga iteracioni
                    //(kolona 5 eshte kolona qe tregon a jane bere ndryshime per monedhen aktuale)
                    //nqs nuk ka vleren 1 nuk kemi pse te bejme INSERT/UPDATE sepse nuk ka ndryshuar gje
                if (int.Parse(this.bankaGrid.Rows[i].Cells[5].Value.ToString()) == 1)
                {
                    //a eshte vlera e kursit te monedhes aktuale ekzistente si rekord ne DB apo jo? 
                        //(kolona 4 tregon a e kemi marre nga DB kete rekord, pra a ekziston ai)
                    if (int.Parse(this.bankaGrid.Rows[i].Cells[4].Value.ToString()) == 1)
                    {
                        //nese ky rekord ekziston, ekzekutojme proceduren UPDATE
                        Lidhja.Kerkesat1.a.updateBanka(this.bankaGrid.Rows[i].Cells[6].Value.ToString(), this.bankaGrid.Rows[i].Cells[3].Value.ToString(), this.bankaGrid.Rows[i].Cells[2].Value.ToString());
                    }
                    else
                    {
                        //perndryshe e inserojme si rekord pra ekzekutojme proceduren INSERT
                        Lidhja.Kerkesat1.a.insertBanka(this.bankaGrid.Rows[i].Cells[0].Value.ToString(), this.bankaGrid.Rows[i].Cells[3].Value.ToString(), this.bankaGrid.Rows[i].Cells[2].Value.ToString());
                    }
                }
            }
        }//COMM

        public void saveCC()
        {
            //funksioni qe ben INSERT ose UPDATE per te dhenat e hedhura per arken nga perdoruesi
            for (int i = 0; i < this.ccGrid.Rows.Count; i++)
            {
                //nqs kemi nje vlere te ndryshuar nga perdoruesi per rreshtin e kapur nga iteracioni
                    //(kolona 5 eshte kolona qe tregon a jane bere ndryshime per monedhen aktuale)
                    //nqs nuk ka vleren 1 nuk kemi pse te bejme INSERT/UPDATE sepse nuk ka ndryshuar gje
                if (int.Parse(this.ccGrid.Rows[i].Cells[5].Value.ToString()) == 1)
                {
                    //a eshte vlera e kursit te monedhes aktuale ekzistente si rekord ne DB apo jo? 
                        //(kolona 4 tregon a e kemi marre nga DB kete rekord, pra a ekziston ai)
                    if (int.Parse(this.ccGrid.Rows[i].Cells[4].Value.ToString()) == 1)
                    {
                        //nese ky rekord ekziston, ekzekutojme proceduren UPDATE
                        Lidhja.Kerkesat1.a.updateArka(this.ccGrid.Rows[i].Cells[6].Value.ToString(), this.ccGrid.Rows[i].Cells[3].Value.ToString(), this.ccGrid.Rows[i].Cells[2].Value.ToString(), DateTime.Now.ToString("dd/MM/yyyy"));
                    }
                    else
                    {
                        //perndryshe e inserojme si rekord pra ekzekutojme proceduren INSERT
                        Lidhja.Kerkesat1.a.insertArka(this.ccGrid.Rows[i].Cells[0].Value.ToString(), this.ccGrid.Rows[i].Cells[3].Value.ToString(), this.ccGrid.Rows[i].Cells[2].Value.ToString(), DateTime.Now.ToString("dd/MM/yyyy"));
                    }
                }
            }
        }//COMM

        private void radButton1_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit RUAJ, do te ruhet informacioni 
            saveData();
            //pas ruajtjes, e marrim dhe njehere informacionin nga DB
            loadData();
            //ne ruajtje, i japim vleren variablit qe tregon a kemi ndryshime te paruajtura, pra FALSE sepse nuk kemi
            exchange_rates_changed = false;
        }//COMM

        private void bankaGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //ne ndryshim te nje qelize te GridView
                //nese ndryshon vlera e nje qelize, kemi ndryshim per monedhen ku ndodhet kjo qelize
                //pra ndryshojme vleren e kolones 5 qe tregon a eshte bere ndryshim apo jo per kete monedhe
                //(per arsye performance, qe te behet INSERT/UPDATE aty ku ka realisht ndryshim)
            this.bankaGrid.Rows[this.bankaGrid.CurrentCell.RowIndex].Cells[5].Value = "1";
            //gjithashtu ne ndryshim te nje vlere, variabli qe tregon ndryshimet e paruajtura merr vleren TRUE
                //pra kemi ndryshime te paruajtura
            exchange_rates_changed = true;
        }//COMM

        private void ccGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //ne ndryshim te nje qelize te GridView
                //nese ndryshon vlera e nje qelize, kemi ndryshim per monedhen ku ndodhet kjo qelize
                //pra ndryshojme vleren e kolones 5 qe tregon a eshte bere ndryshim apo jo per kete monedhe
                //(per arsye performance, qe te behet INSERT/UPDATE aty ku ka realisht ndryshim)
            this.ccGrid.Rows[this.ccGrid.CurrentCell.RowIndex].Cells[5].Value = "1";
            //gjithashtu ne ndryshim te nje vlere, variabli qe tregon ndryshimet e paruajtura merr vleren TRUE
                //pra kemi ndryshime te paruajtura
            exchange_rates_changed = true;
        }//COMM

        private void ExchangeRate_Load(object sender, EventArgs e)
        {
            //funksioni qe thirret ne krijim te formes
                //thjesht therret funksionin qe merr te dhenat nga DB per kurset
            this.bankaGrid.AutoGenerateColumns = true;
            this.ccGrid.AutoGenerateColumns = true;
            loadData();
        }//COMM

        private void button1_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit IMPORTO shfaqet nderfaqja e importit te monedhave nga nje burim ose nga nje dite tjeter
                //ne klikim te butonave te konfirmimit, therrasim funksionin ne EventHandler 
                //i cili ri-mbush GridView me te dhenat e kurseve
            ImportFrom imp = new ImportFrom();
            imp.MdiParent = this.MdiParent;
            imp.Show();
            imp.konfirmoBtn.Click += new EventHandler(ImportedClickedConfirmed);
            imp.konfirmoBtnDate.Click += new EventHandler(ImportedClickedConfirmed);
        }//COMM

        void ImportedClickedConfirmed(object sender, EventArgs e)
        {
            //ri-mbushje e GridView me te dhenat e kurseve pas importit
            this.loadData();
        }//COMM
    }
}