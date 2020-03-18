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
    public partial class Prjerjet : Form
    {
        //variablat qe nuk lejojne ekzekutimin e funksioneve pa mbaruar disa procedura te mbushjes se dropdowneve
        bool loadOk1 = false;
        bool loadOk2 = false;
        //variabli isInserted tregon a ka gjendje te parapercaktuar per monedhen e zgjedhur, pra a ekziston nje gjendje ne momentin
            //qe po punon perdoruesi
        bool isInserted = false;

        DataGridViewTextBoxColumn emertimi;
        DataGridViewTextBoxColumn numri;

        public Prjerjet()
        {
            InitializeComponent();
            //ne krijim te nderfaqes, mbushim dropdown e arkave dhe te monedhave per inicializim
            fillArkat();
            fillMonedhat();
        }

        public void fillArkat()
        {
            //funksioni qe merr arkat nga DB dhe i shton ato si elemente te dropdown
            DataTable arkat = Lidhja.Kerkesat1.a.selectAllRecFromTable("arkat").Copy();
            //vendosim variablat per te ndaluar ekzekutimin e eventit deri sa te mbushet dropdown
            loadOk1 = false;
            this.arkatBox.DataSource = arkat;
            this.arkatBox.DisplayMember = "arka";
            this.arkatBox.ValueMember = "id";
            this.arkatBox.SelectedIndex = -1;
            loadOk1 = true;
        }//COMM

        public void fillMonedhat()
        {
            //funksioni qe merr monedhat nga DB dhe i shton ato si elemente te dropdown
            DataTable monedhat = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();
            //vendosim variablat per te ndaluar ekzekutimin e eventit deri ne mbushje
            loadOk2 = false;
            this.monedhatBox.DataSource = monedhat;
            this.monedhatBox.DisplayMember = "monedha";
            this.monedhatBox.ValueMember = "id";
            this.monedhatBox.SelectedIndex = -1;
            loadOk2 = true;
        }//COMM

        public void getKursin()
        {
            //funksioni qe merr kursin e monedhes se zgjedhur ne DB dhe e shfaq ate ne nderfaqe
            DataTable kursi = Lidhja.Kerkesat1.a.getKursiBankesByMonedha(this.monedhatBox.SelectedValue.ToString()).Copy();
            if (kursi.Rows.Count > 0)
            {
                //nese ka kurs, e nxjerrim ne nderfaqe
                this.kursiTxt.Text = kursi.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                MessageBox.Show("Nuk eshte caktuar kursi i kembimit per kete monedhe!");
                kursiTxt.Text = "";
            }
        }//COMM

        public void insertPrerjet()
        {
            //funksioni qe pergatit GridView dhe inseron te dhenat per prerjet nga DB
            this.radGridView1.Rows.Clear();
            this.radGridView1.Columns.Clear();
            if (monedhatBox.SelectedIndex > -1 && arkatBox.SelectedIndex > -1)
            {
                emertimi = new DataGridViewTextBoxColumn();
                emertimi.HeaderText = "Vlera";
                emertimi.ReadOnly = true;

                numri = new DataGridViewTextBoxColumn();
                numri.HeaderText = "Sasia";
                numri.ReadOnly = false;

                this.radGridView1.Columns.Add(emertimi);
                this.radGridView1.Columns.Add(numri);
                //shtohen kolonat ne GridView
                this.radGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //therritet funksioni qe inseron informacionin mbi prerjet
                llogarit();
            }
        }//COMM

        public void llogarit()
        {
            //funksioni qe inseron prerjet dhe sasite e tyre si dhe llogarit totalin dhe e shfaq ate ne nderfaqe
            bool isValue = false;
            DataTable dt = Lidhja.Kerkesat1.a.selectPrerjet(this.monedhatBox.SelectedValue.ToString()).Copy();
            if (dt.Rows.Count == 0)
            {
                //nese nuk ka asnje rresht ne DB, kjo ndodh sepse nuk jane percaktuar prerjet e monedhes se zgjedhur
                MessageBox.Show("Prerjet nuk jane te konfiguruara per kete monedhe!");
                this.totaliLbl.Text = "0";
                return;
            }
            DataTable dt2 = Lidhja.Kerkesat1.a.selectGjendjet(this.monedhatBox.SelectedValue.ToString(), this.arkatBox.SelectedValue.ToString()).Copy();
            if (dt2.Rows.Count > 0)
            {
                //nese ka gjendje te para-percaktuar, variablat marrin vleren
                isValue = true;
                isInserted = true;
            }
            else
            {
                isValue = false;
                isInserted = false;
            }

            //shtohen rreshtat sipas kolonave qe vijne si rezultat nga DB, pasi gjendja eshte e vendosur ne kolona
            for (int i = 2; i < dt.Columns.Count; i++)
            {
                if (dt.Rows[0].ItemArray[i].ToString() != "0" && dt.Rows[0].ItemArray[i].ToString() != "")
                {
                    this.radGridView1.Rows.Add(dt.Rows[0].ItemArray[i].ToString(), (isValue ? (dt2.Rows[0].ItemArray[i + 1].ToString() == "" ? "0" : dt2.Rows[0].ItemArray[i + 1].ToString()) : "0"));
                }
            }

            //llogaritet shuma duke mbledhur elementet e GridView, pra sasia e prerjes * vleren e prerjes rresht per rresht
            float sum = 0;
            for (int i = 0; i < this.radGridView1.Rows.Count; i++)
            {
                sum += float.Parse(this.radGridView1.Rows[i].Cells[0].Value.ToString()) * float.Parse(this.radGridView1.Rows[i].Cells[1].Value.ToString());
            }
            this.totaliLbl.Text = ((long)(sum)).ToString();
        }//COMM

        private void saveConfig()
        {
            //funksion qe ben ruajtjen e konfigurimit te sasive te prerjeve ne DB
                //nese ka patur gjendje ne DB, ekzekutohet UPDATE, perndryshe INSERT
            if (this.radGridView1.Rows.Count > 0)
            {
                if (!isInserted)
                {
                    //nuk ka patur gjendje ne DB para se te punonte perdoruesi
                        //gjendjet e prerjeve hidhen ne vektor dhe perdoren ne funksionin e klases lidhese me DB
                        //ekzekutohet procedura INSERT
                    string[] tmp = new string[20];
                    for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                    {
                        tmp[i] = this.radGridView1.Rows[i].Cells[1].Value.ToString();
                    }
                    Lidhja.Kerkesat1.a.insertGjendje(this.monedhatBox.SelectedValue.ToString(), tmp, this.arkatBox.SelectedValue.ToString());
                }
                else
                {
                    //ka patur gjendje ne DB para se te punonte perdoruesi
                        //gjendjet e prerjeve hidhen ne vektor dhe perdoren ne funksionin e klases lidhese me DB
                        //ekzekutohet procedura UPDATE
                    string[] tmp = new string[20];
                    for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                    {
                        tmp[i] = this.radGridView1.Rows[i].Cells[1].Value.ToString();
                    }
                    Lidhja.Kerkesat1.a.updateGjendje(this.monedhatBox.SelectedValue.ToString(), tmp, this.arkatBox.SelectedValue.ToString());
                }
                MessageBox.Show("Sasite u ruajten me sukses!");
            }
        }//COMM

        private void arkatBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //ne ndryshim te arkes se zgjedhur ri-mbushet informacioni i prerjeve dhe gjendjes
                //nese perdoruesi ka ndryshime te cilat nuk i ka ruajtur, njoftohet me MessageBox ku 
                //duhet te konfirmoje ndryshimin e arkes per te ndaluar humbjen e informacionit
                //veprimet kryhen kur loadOk1 eshte TRUE pra kur dropdown i arkes eshte mbushur me te dhena
            if (loadOk1)
            {
                if (valueChanged)
                {
                    //nese perdoruesi ka ndryshime te paruajtura, shfaqet MessageBox me funksionin qe ekzekutohet ne konfirmim
                        //funksioni gjendet ne EventHandler qe kalohet si parameter
                    DialogResult a;
                    a = MessageBox.Show("Ndryshimet nuk u ruajten!\n\rJeni te sigurt qe doni te ndryshoni arken e zgjedhur?", "Kujdes!",
                        MessageBoxButtons.YesNo, new EventHandler(arkaBoxChangedDialog));
                }
                else
                {
                    //nese nuk ka ndryshime te paruajtura, mbushet nderfaqa me te dhenat e prerjeve dhe gjendjes
                    insertPrerjet();
                    //previousArkaIndex eshte index i elementit te zgjedhur nga arka qe perdoret ne momentin kur anulohet zgjedhja e 
                        //arkes tjeter ne rast se perdoruesi ka bere ndryshime te paruajtura
                    this.previousArkaIndex = this.arkatBox.SelectedIndex;
                }
            }
        }//COMM

        private void arkaBoxChangedDialog(object sender, EventArgs e)
        {
            //funksioni qe therritet kur perdoruesi konfirmon ndryshimin e arkes pas MessageBox qe i shfaqet
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                //nese ka konfirmuar, kalohet ne arken e re, pra inserohen prerjet e arkes se zgjedhur
                    //variabli qe tregon se perdoruesi ka bere ndryshime behet FALSE per riperdorim
                insertPrerjet();
                valueChanged = false;
                this.previousArkaIndex = this.arkatBox.SelectedIndex;
            }
            else
            {
                //perndryshe, dropdown do te kete si element te zgjedhur ate qe kishte 
                loadOk1 = false;
                this.arkatBox.SelectedIndex = previousArkaIndex;
                loadOk1 = true;
                valueChanged = true;
            }
        }//COMM

        //variabel qe tregon se perdoruesi ka bere ndryshime ne nderfaqen ku ndodhet, te cilat nuk jane ruajtur
            //true  -> ka ndryshime te paruajtura
            //false -> nuk ka ndryshime te paruajtura, pra jane ruajtur ose nuk jane bere ndryshime
        public bool valueChanged = false;
        //variablat qe ruajne index e fundit te zgjedhur nga perdoruesi per dropdownet e arkes dhe monedhes
            //si vlere fillestare kane -1
        public int previousArkaIndex = -1;
        public int previousMonedhaIndex = -1;

        private void monedhatBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //ne ndryshim te vleres se zgjedhur per monedhen
            if (loadOk2)
            {
                //veprimet kryhen nese dropdown eshte i ndertuar dhe i mbushur
                if (valueChanged)
                {
                    //nese perdoruesi ka bere ndryshime dhe nuk i ka ruajtur, atij i nxirret nje njoftim ku duhet konfirmuar levizja
                        //funksioni qe ekzekutohet ne konfirmim eshte ne EventHandler qe kalohet si parameter
                    DialogResult a;
                    a = MessageBox.Show("Ndryshimet nuk u ruajten!\n\rJeni te sigurt qe doni te ndryshoni monedhen e zgjedhur?", "Kujdes!",
                        MessageBoxButtons.YesNo, new EventHandler(monedhaBoxChangedDialog));
                }
                else
                {
                    //nese nuk ka ndryshime te paruajtura, merren prerjet dhe gjendja e tyre dhe kursi i monedhes se zgjedhur
                    insertPrerjet();
                    getKursin();
                    //ruhet index i aksesuar per perdorim te mevonshem, kur te ndryshoje monedha nese duhet rikthyer vlera e dropdown
                    previousMonedhaIndex = monedhatBox.SelectedIndex;
                }
            }
        }//COMM

        private void monedhaBoxChangedDialog(object sender, EventArgs e)
        {
            //funksioni qe therritet kur konfirmohet ndryshimi i monedhes pa ruajtur ndryshimet
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                //nese konfirmohet, merren prerjet dhe gjendjet e monedhes se re te zgjedhur
                    //variabli valueChanged behet FALSE per tu riperdorur
                insertPrerjet();
                getKursin();
                valueChanged = false;
                previousMonedhaIndex = monedhatBox.SelectedIndex;
            }
            else
            {
                //rikthehet vlera e dropdown te monedhes
                loadOk2 = false;
                this.monedhatBox.SelectedIndex = previousMonedhaIndex;
                loadOk2 = true; 
                valueChanged = true;
            }
        }//COMM

        private void radGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //ne rastin kur ndryshohet vlera e nje qelize te GridView ku shfaqen gjendjet e prerjeve

            float z;
            if (this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                {
                    if (float.TryParse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out z))
                    {
                        //nese futen sasi te vlefshme, jo "" dhe jo NULL kryhen veprimet, perndryshe sasia behet 0
                            //nese futet nje numer me presje, ai kthehet ne INT
                        this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (int)(float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                        //ne ndryshim te sasise, ri-llogaritet totali
                        float sum = 0;
                        for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                        {
                            sum += float.Parse(this.radGridView1.Rows[i].Cells[0].Value.ToString()) * float.Parse(this.radGridView1.Rows[i].Cells[1].Value.ToString());
                        }
                        this.totaliLbl.Text = sum.ToString();
                        //ne ndryshim, variabli qe tregon se kemi vlera te paruajtura behet TRUE per te treguar se nuk jane ruajtur ndryshimet e fundit
                        valueChanged = true;
                    }
                    else
                    {
                        this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    }
                }
                else
                {
                    this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                }
            }
            else
            {
                this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
            }
        }//COMM

        private void radButton1_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit RUAJ
            saveConfig();
            //ne ruajtje te te dhenave, variabli qe tregon ndryshime te paruajtura ri-startohet
            valueChanged = false;
        }//COMM

        private void button1_Click(object sender, EventArgs e)
        {
            //shfaqet forma tjeter ku behet hyrja/dalja e prerjeve nga nje admin
            SpecialTransactions st = new SpecialTransactions(((Form1)(this.MdiParent)).user_id);
            st.ShowDialog();
        }//COMM

        //variabli qe tregon a eshte OK te mbyllim formen apo jo
        bool okToClose = false;
        private void Prjerjet_FormClosing(object sender, FormClosingEventArgs e)
        {
            //nese nuk e kemi konfirmuar mbylljen e formes me ndryshimet e paruajtura, nxjerrim nje MessageBox ne te cilin
                //do te konfirmohet mbyllja
                //funksioni qe therritet ne mbyllje ndodhet ne EventHandler te kaluar si parameter
            if (!okToClose && valueChanged)
            {
                //nese eshte e pakonfirmuar, anulohet mbyllja por shfaqet MessageBox
                e.Cancel = true;
                DialogResult dr;
                dr = MessageBox.Show("Jeni te sigurt qe doni te mbyllni dritaren?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(closeOk));
            }
        }//COMM

        private void closeOk(object sender, EventArgs e)
        {
            //ne rast se eshte konfirmuar mbyllja e formes me gjithe ndryshimet e paruajtura, variabli qe tregon konfirmimin e mbylljes se formes
                //behet TRUE dhe ne event te mbylljes, nuk futemi fare ne bllokun e kushtit IF, pra forma mbyllet normalisht
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                //variabli merr vleren qe nuk lejon futjen ne kod
                okToClose = true;
                this.Close();
                okToClose = false;
            }
            else
            {
                //nese nuk eshte konfirmuar mbyllja e formes, mundesohet futja perseri ne blloun e kushtit IF ne event
                    //pra shfaqet dhe njehere mesazhi ne rast mbyllje me ndryshime te paruajtura
                okToClose = false;
            }
        }//COMM
    }
}