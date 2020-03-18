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
    public partial class PrerjetManage : Form
    {
        //variabel qe lejon ekzekutimin e kodit te eventit vetem pasi eshte krijuar DropDown
        public bool loadOk = true;
        //kolonat qe do te shtohen ne GridView ku do te paraqitet informacioni
        DataGridViewTextBoxColumn emertimi;
        DataGridViewTextBoxColumn prerja;

        //variabli qe tregon se prerjet jane te marra nga DB (percakton ne ruajtje proceduren qe do te kryhet, pra INSERT apo UPDATE)
            //TRUE  -> prerjet ekzistojne si rekord ne DB
            //FALSE -> prerjet nuk ekzistojne si rekord ne DB
        bool insertedValue;

        public PrerjetManage()
        {
            InitializeComponent();
            loadMonedhat();
        }

        private void loadMonedhat()
        {
            //merren monedhat nga DB dhe hidhen ne DropDown
            DataTable monedhat = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();
            //ndalohet ekzekutimi i eventit me variablin loadOk
            loadOk = false;
            this.monedhatBox.DataSource = monedhat;
            this.monedhatBox.ValueMember = "id";
            this.monedhatBox.DisplayMember = "Monedha";
            this.monedhatBox.SelectedValue = -1;
            loadOk = true;
        }//COMM

        private void insertPrerjet()
        {
            //funksioni qe mbush GridView me prerjet e monedhes se zgjedhur
            this.radGridView1.Rows.Clear();
            this.radGridView1.Columns.Clear();
                //kolona qe mban prerjen
            emertimi = new DataGridViewTextBoxColumn();
            emertimi.ReadOnly = true;
            emertimi.HeaderText = "Prerja";
                //kolona qe mban sasine e prerjeve
            prerja = new DataGridViewTextBoxColumn();
            prerja.ReadOnly = false;
            prerja.HeaderText = "Vlera";

            this.radGridView1.Columns.Add(emertimi);
            this.radGridView1.Columns.Add(prerja);

            this.radGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //merren prerjet nga DB
            DataTable prerjet = Lidhja.Kerkesat1.a.selectPrerjet(this.monedhatBox.SelectedValue.ToString()).Copy();
            if (prerjet.Rows.Count == 0)
            {
                //nese nuk kemi prerje per monedhen e zgjedhur
                insertedValue = false;
            }
            else
            {
                //nese kemi prerje per monedhen e zgjedhur
                insertedValue = true;
            }
            for (int i = 1; i <= 20; i++)
            {
                float z;
                string addValue = "";
                //per te vendosur prerjet duhet te kemi te pakten nje rekord
                if (insertedValue)
                {
                    //prerjet do te shtohen ne GridView, rekordet duhet te jene te vlefshme, pra prerja duhet te jete nje vlere
                        //numerike, qe do te thote se nuk duhet te jete ""
                    if (float.TryParse(prerjet.Rows[0].ItemArray[i + 1].ToString(), out z))
                    {
                        //nese kemi prerje te vlefshme, e hedhim tek variabli qe do te shtohet ne GridView
                        addValue = z.ToString();
                    }
                    else
                    {
                        //perndryshe kete variabel e bejme ""
                        addValue = "";
                    }
                }
                else
                {
                    addValue = "";
                }
                //hedhim ne GridView 20 prerje dhe nqs nje prerje ka vlere ne DB, do te shtohet ajo vlere
                    //perndryshe vlera do te lihet bosh dhe do te pritet input nga perdoruesi
                this.radGridView1.Rows.Add("Prerja " + i.ToString(), addValue);
            }
        }//COMM

        private void saveConfig()
        {
            //funksioni qe ruan prerjet ne DB
            bool ok = true;
            int index = 0;
            float z;
            for (int i = 0; i < this.radGridView1.Rows.Count; i++)
            {
                if (this.radGridView1.Rows[i].Cells[1].Value != null)
                {
                    if (this.radGridView1.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        if (!float.TryParse(this.radGridView1.Rows[i].Cells[1].Value.ToString(), out z))
                        {
                            //ne rast se nje prerje nuk eshte konfiguruar sic duhet, ruajme index-in e kesaj prerje
                                //dhe variablin ok e bejme FALSE per te mos ekzekutuar kodin e meposhtem
                            ok = false;
                            index = i;
                        }
                    }
                }
            }
            if (ok)
            {
                //nese te gjitha prerjet e vendosura jane te sakta, bejme INSERT ose UPDATE ne DB
                string[] tmp = new string[20];
                for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                {
                    //te gjitha sasite e prerjeve i vendosim ne vektorin tmp[20] per ti vendosur ne DB ne menyre proceduriale
                        //nese vlera ne qelize eshte NULL, ne tmp duhet te jete ""
                    tmp[i] = (this.radGridView1.Rows[i].Cells[1].Value == null ? "" : this.radGridView1.Rows[i].Cells[1].Value.ToString());
                }
                if (!this.insertedValue)
                {
                    //nese nuk ekziston ne DB rekordi i prerjeve per kete monedhe, bejme INSERT
                        //ne funksionin insertPrerje kalojne te gjitha prerjet ne formen e nje vektori qe i mban ato (tmp[])
                    Lidhja.Kerkesat1.a.insertPrerje(this.monedhatBox.SelectedValue.ToString(), tmp);
                }
                else
                {
                    //nese ekziston rekordi, bejme UPDATE me te njejtin vektor (tmp[])
                    Lidhja.Kerkesat1.a.updatePrerje(this.monedhatBox.SelectedValue.ToString(), tmp);
                }
                MessageBox.Show("Prerjet u ruajten me sukses!");
            }
            else
            {
                //perndryshe, nese kemi te pakten nje prerje te vendosur jo-sakte, e shfaqim ate tek perdoruesi
                MessageBox.Show(this.radGridView1.Rows[index].Cells[0].Value.ToString() + " nuk eshte konfiguruar sakte!");
            }
        }//COMM

        private void radButton1_Click(object sender, EventArgs e)
        {
            //butoni RUAJ, therret funksionin e ruajtjes se prerjeve
            saveConfig();
            //variabli isValueChanged merr vleren FALSE pasi nuk ka me ndryshime te paruajtura
            this.isValueChanged = false;
        }//COMM

        //variabli qe tregon a ka apo jo ndryshime te paruajtura, per te ndaluar mbylljen
        public bool isValueChanged = false;
        //monedha e fundit e zgjedhur, per tu perdorur nese perdoruesi anulon kalimin ne nje monedhe tjeter
        public int previousSelectedMonedha = -1;

        private void monedhatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ne ndryshim te monedhes se zgjedhur, nese nuk jane ruajtur ndryshimet e bera ne nderfaqe
                //perdoruesit i shfaqet nje MessageBox ne te cilin konfirmon se do te ndryshoje monedhen pavaresisht
                //ndryshimeve te paruajtura
            if (loadOk)
            {
                //nese eshte krijuar monedha dhe ndryshimi eshte bere nga perdoruesi dhe jo nga kodi
                if (isValueChanged)
                {
                    //funksioni ne EventHandler therritet ne momentin e konfirmimit nga MessageBox
                    DialogResult a = MessageBox.Show("Ndryshimet nuk u ruajten!\n\rJeni te sigurt qe doni te ndryshoni monedhen e zgjedhur?",
                        "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(selectedMonedhaChanged));
                }
                else
                {
                    //nese nuk ka ndryshime te paruajtura, mbushet nderfaqa me monedhen e re
                        //previousSelectedMonedha mban indexin e monedhes per rastin kur duhet kthyer zgjedhja
                    insertPrerjet();
                    previousSelectedMonedha = monedhatBox.SelectedIndex;
                }
            }
        }//COMM

        private void selectedMonedhaChanged(object sender, EventArgs e)
        {
            //funksioni qe therritet kur perdoruesi konfirmon MessageBox ne rastin kur ndryshon monedhen
                //por ka ndryshime te paruajtura
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                //nese perdoruesi konfirmon qe do te ndryshoje monedhen gjithsesi, merren prerjet e monedhes se re
                insertPrerjet();
                this.previousSelectedMonedha = this.monedhatBox.SelectedIndex;
                //variabli merr vleren FALSE sepse nuk ka ndryshime te paruajtura ne momentin qe kalohet ne monedhen tjeter
                isValueChanged = false;
            }
            else
            {
                //perndryshe si index i zgjedhur i ComboBox do te sherbeje indexi i fundit i vlefshem, pra ai i ruajtur
                    //tek previousSelectedMonedha
                loadOk = false;
                this.monedhatBox.SelectedIndex = this.previousSelectedMonedha;
                loadOk = true;
                //kemi ndryshime te paruajtura dhe ne momentin qe perdoruesi do te mundohet te mbylle perseri dritaren
                    //pa ruajtur ndryshimet, atij do ti shfaqet perseri i njejti MessageBox konfirmimi
                isValueChanged = true;
            }
        }//COMM

        private void radGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //ne ndryshim te nje qelize te GridView, kemi ndryshime te paruajtura te cilat i 
                //tregojme me ane te variablit
            this.isValueChanged = true;
        }//COMM

        //variabli qe tregon se nderfaqa mund te mbyllet pasi perdoruesi ka konfirmuar MessageBox qe i shfaqet
            //kur ka ndryshime te paruajtura
        bool okToClose = false;

        private void PrerjetManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!okToClose && isValueChanged)
            {
                //nese ka ndryshime dhe nuk eshte bere nje konfirmim nga perdoruesi per mbyllje pa ruajtje te ndryshimeve, 
                    //atij i shfaqet nje MessageBox te cilin duhet ta konfirmoje
                    //funksioni qe therritet ne konfirmim eshte ne EventHandler te kaluar si parameter
                e.Cancel = true;
                DialogResult dr;
                dr = MessageBox.Show("Jeni te sigurt qe doni te mbyllni dritaren?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(closeOk));
            }
        }//COMM

        private void closeOk(object sender, EventArgs e)
        {
            //funksioni qe therritet ne momentin qe konfirmohet MessageBox qe i shfaqet perdoruesit kur ai do te mbylle dritaren pa ruajtur
                //ndryshimet qe jane bere
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                //nese perdoruesi konfirmon, variabli okToClose merr vleren TRUE dhe nuk ekzekutohet kodi ne eventin e mbylljes se MessageBox
                    //pra mbyllja behet pa problem
                okToClose = true;
                //bejme mbylljen me kod
                this.Close();
                okToClose = false;
            }
            else
            {
                //perndryshe nuk behet asnje veprim por variabli okToClose merr vleren FALSE per te bere ri-shfaqjen e MessageBox qe duhet konfirmuar
                    //ne rast se tentohet te mbyllet forma pa ruajtur ndryshimet perseri
                okToClose = false;
            }
        }//COMM
    }
}