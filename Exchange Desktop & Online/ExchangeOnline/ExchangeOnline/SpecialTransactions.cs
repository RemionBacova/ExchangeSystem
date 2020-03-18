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
    public partial class SpecialTransactions : Form
    {
        #region declaration_section

        //ID e perdoruesit te loguar
        string loggedUser;
        //variablat qe sherbejne per te mos ekzekutuar kodin ne evente pa krijuar objektet vizuale
        bool loadGridOk1 = false;
        bool loadOk1 = false;

        //kolonat qe i shtohen GridView manualisht
        DataGridViewTextBoxColumn emertimi1;
        DataGridViewTextBoxColumn number1;
        DataGridViewTextBoxColumn existing_number1;

        #endregion

        public SpecialTransactions(string user_id)
        {
            //merret perdoruesi i loguar
            loggedUser = user_id;
            InitializeComponent();
            //merren arkat dhe monedhat nga DB si fillim
            loadArkat();
            loadMonedhat();
        }

        public void loadMonedhat()
        {
            //funksioni qe merr monedhat nga DB dhe i vendos ato ne DropDown
            DataTable monedhat = Lidhja.Kerkesat1.a.selectAllRecFromTable("Monedhat").Copy();
            if (monedhat.Rows.Count > 0)
            {
                //loadOk1 behet FALSE per te mos lejuar ekzekutimin e kodit ne event, pa u krijuar objekti vizual
                loadOk1 = false;
                ngaBox.DataSource = monedhat;
                ngaBox.DisplayMember = "Monedha";
                ngaBox.ValueMember = "id";
                ngaBox.SelectedIndex = -1;
                loadOk1 = true;
            }
            else
            {
                //nese nuk ka rekorde monedhash
                MessageBox.Show("Ju nuk keni asnje monedhe te konfiguruar!");
            }
        }//COMM

        public void loadArkat()
        {
            //funksioni qe merr te gjitha arkat nga DB dhe i vendos ne DropDown
            DataTable arkat = Lidhja.Kerkesat1.a.selectAllRecFromTable("Arkat").Copy();
            if (arkat.Rows.Count > 0)
            {
                this.arkaBox.DataSource = arkat;
                this.arkaBox.ValueMember = "id";
                this.arkaBox.DisplayMember = "arka";
                this.arkaBox.SelectedIndex = -1;
            }
            else
            {
                //nese nuk kemi rekorde arkash
                MessageBox.Show("Ju nuk keni asnje arke te konfiguruar!");
            }
        }//COMM

        public void getGjendja(string monedha_id)
        {
            //funksion qe llogarit totalin per monedhen e zgjedhur
            if (this.arkaBox.SelectedIndex >= 0)
            {
                //merren prerjet dhe gjendjet e prerjeve nga tabela te vecanta ne DataTable te vecanta
                DataTable prerjet = Lidhja.Kerkesat1.a.selectPrerjet(monedha_id).Copy();
                DataTable gjendja = Lidhja.Kerkesat1.a.selectGjendjet(monedha_id, this.arkaBox.SelectedValue.ToString()).Copy();
                float sum = 0;
                if (prerjet.Rows.Count > 0)
                {
                    if (gjendja.Rows.Count > 0)
                    {
                        for (int i = 2; i < prerjet.Columns.Count; i++)
                        {
                            float z;
                            if (float.TryParse(prerjet.Rows[0].ItemArray[i].ToString(), out z) && float.TryParse(gjendja.Rows[0].ItemArray[i + 1].ToString(), out z))
                            {
                                //veprimet kryhen nese prerja aktuale dhe gjendja e kesaj prerje eshte vlere numerike,
                                    //shuma llogaritet me vleren e prerjes * sasine e prerjeve ne arke  
                                sum += float.Parse(prerjet.Rows[0].ItemArray[i].ToString()) * float.Parse(gjendja.Rows[0].ItemArray[i + 1].ToString());
                            }
                        }
                    }
                    else
                    {
                        //nese nuk ka rekord nga gjendjet
                        MessageBox.Show("Nuk ka gjendje fillestare te konfiguruar \n\rper monedhen e zgjedhur ne arken e zgjedhur!");
                    }
                }
                else
                {
                    //nese nuk ka rekord nga prerjet
                    MessageBox.Show("Nuk ka prerje te konfiguruara per monedhen e zgjedhur!");
                }
                //ne fund totali qe akumulohet shfaqet ne Label
                this.gjendjaLbl.Text = sum.ToString("0.00");
            }
        }//COMM

        public void loadGrid()
        {
            //funksioni qe mbush GridView me prerjet dhe gjendjet e monedhes
            if (this.arkaBox.SelectedIndex >= 0)
            {
                //GridView mbushet nese kemi nje arke te zgjedhur
                loadGridOk1 = false;
                DataTable prerjet = new DataTable();
                
                //merren prerjet nga DB
                prerjet = Lidhja.Kerkesat1.a.selectPrerjet(this.ngaBox.SelectedValue.ToString()).Copy();
                getGjendja(this.ngaBox.SelectedValue.ToString());

                //ristartohet GridView duke hequr rreshtat dhe kolonat nga lista
                this.radGridView1.Rows.Clear();
                this.radGridView1.Columns.Clear();
                    //kolona qe ka vleren e prerjes
                emertimi1 = new DataGridViewTextBoxColumn();
                emertimi1.Visible = true;
                emertimi1.HeaderText = this.ngaBox.Text;
                emertimi1.ReadOnly = true;
                    //kolona qe ka sasine per dalje te prerjes qe konfigurohet nga perdoruesi
                number1 = new DataGridViewTextBoxColumn();
                number1.Visible = true;
                number1.HeaderText = "Sasia per Shitje";
                number1.ReadOnly = false;
                    //kolona qe ka sasine e prerjes ne kete arke ne DB
                existing_number1 = new DataGridViewTextBoxColumn();
                existing_number1.Visible = true;
                existing_number1.HeaderText = "Sasia Aktuale";
                existing_number1.ReadOnly = true;

                this.radGridView1.AutoGenerateColumns = false;

                this.radGridView1.Columns.Add(emertimi1);
                this.radGridView1.Columns.Add(number1);
                this.radGridView1.Columns.Add(existing_number1);

                this.radGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                float z;
                if (prerjet.Rows.Count > 0)
                {
                    for (int i = 2; i < prerjet.Columns.Count; i++)
                    {
                        if (prerjet.Rows[0].ItemArray[i] != null)
                        {
                            if (prerjet.Rows[0].ItemArray[i].ToString() != "")
                            {
                                if (float.TryParse(prerjet.Rows[0].ItemArray[i].ToString(), out z))
                                {
                                    if (float.Parse(prerjet.Rows[0].ItemArray[i].ToString()) != 0)
                                    {
                                        //mbushet GridView me prerjet dhe me sasi te vendosur nga perdoruesi 0, si default
                                        this.radGridView1.Rows.Add(prerjet.Rows[0].ItemArray[i].ToString(), 0);
                                    }
                                }
                            }
                        }
                    }
                }
                //shtohet rreshti i fundit qe sherben si total dhe ai behet READONLY
                this.radGridView1.Rows.Add("Totali", 0);
                this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].ReadOnly = true;
                //mbushet gjendja e prerjeve nga DB ne GridView
                fillGjendja();
                //variabli loadGridOk1 behet TRUE per te lejuar hyrjen ne kod te eventit
                loadGridOk1 = true;
            }
        }//COMM

        public void fillGjendja()
        {
            //funksioni qe mbush gjendjen e seciles prerje ne GridView 
            loadGridOk1 = false;
            DataTable gjendjet = new DataTable();
            if (this.ngaBox.SelectedIndex > -1)
            {
                //merren gjendjet nga DB per monedhen dhe arken e zgjedhur
                gjendjet = Lidhja.Kerkesat1.a.selectGjendjet(this.ngaBox.SelectedValue.ToString(), this.arkaBox.SelectedValue.ToString()).Copy();
            }
            if (gjendjet.Rows.Count > 0)
            {
                //nese kemi rekord gjendje ne DB
                for (int i = 3; i < gjendjet.Columns.Count; i++)
                {
                    if (i - 3 < this.radGridView1.Rows.Count - 1)
                    {
                        //shtojme gjendjen e seciles prerje ne GridView
                        this.radGridView1.Rows[i - 3].Cells[2].Value = gjendjet.Rows[0].ItemArray[i].ToString();
                    }
                }
            }
            else
            {
                //nese nuk kemi rekord gjendje ne DB
                for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                {
                    //ne GridView shtojme vleren 0
                    this.radGridView1.Rows[i].Cells[2].Value = 0;
                }
            }
            //i japim vleren TRUE variablit per te lejuar ekzekutimin e kodit ne event
            loadGridOk1 = true;
        }//COMM

        private void arkaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ne ndryshim te monedhes se zgjedhur, rimbushim GridView me prerjet dhe gjendjet dhe marrim totalin aktual te arkes
                //per monedhen e zgjedhur
            if (this.ngaBox.SelectedIndex > -1)
            {
                loadGrid();
                getGjendja(this.ngaBox.SelectedValue.ToString());
            }
        }//COMM

        public void llogaritShumenEGrides(ref DataGridView grid)
        {
            //funksioni qe llogarit shumen e rreshtave te GridView per ta hedhur ne rekordin e fundit qe tregon totalin
            float s = 0;
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                s += float.Parse(grid.Rows[i].Cells[1].Value.ToString()) * float.Parse(grid.Rows[i].Cells[0].Value.ToString());
            }
            grid.Rows[grid.Rows.Count - 1].Cells[1].Value = s;
        }//COMM

        private void radGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //ne ndryshim te nje vlere ne GridView
            float z;
            if (loadGridOk1)
            {
                loadGridOk1 = false;
                if (this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    //nese vlera e vene nuk eshte NULL
                    if (this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                    {
                        //dhe nese ajo nuk eshte string ""
                        if (float.TryParse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out z))
                        {
                            //dhe nese eshte vlere numerike e pranueshme
                            if (this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value != null)
                            {
                                //nese dhe vlera e gjendjes ne arke eshte jo NULL
                                if (this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString() != "")
                                {
                                    //dhe ajo eshte jo ""
                                    this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((int)(float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))).ToString();
                                    //fillimisht kthejme vleren numerike te vendosur nga perdoruesi ne nje INT pasi mund te kete vendosur numer me presje
                                    if (float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) <= float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString()) || this.radioButton2.Checked)
                                    {
                                        //nese sasia e vendosur nga perdoruesi nuk kalon gjendjen e prerjeve ne DB
                                            //rillogarisim shumen e grides
                                        llogaritShumenEGrides(ref this.radGridView1);
                                    }
                                    else
                                    {
                                        //nese sasia eshte me e madhe, athere i japim vleres nga perdoruesi sasine qe kem
                                        MessageBox.Show("Keni kaluar sasine qe eshte aktualisht ne gjendje!");
                                        this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString());
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Nuk ka gjendje te konfiguruar per prerjen " + this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() + "" + this.ngaBox.SelectedValue.ToString());
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nuk ka gjendje te konfiguruar per prerjen " + this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() + "" + this.ngaBox.SelectedValue.ToString());
                            }
                        }
                        else
                        {
                            //nese eshte vlere jo numerike, atehere si sasi do te jete 0
                            this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                            llogaritShumenEGrides(ref this.radGridView1);
                        }
                    }
                    else
                    {
                        //nese eshte vlere jo numerike, atehere si sasi do te jete 0
                        this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                        llogaritShumenEGrides(ref this.radGridView1);
                    }
                }
                else
                {
                    //nese eshte vlere jo numerike, atehere si sasi do te jete 0
                    this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    llogaritShumenEGrides(ref this.radGridView1);
                }
                
                loadGridOk1 = true;
            }
        }//COMM

        public void restartInterface()
        {
            //funksioni qe ri-inicializon nderfaqen dhe ri-mbush GridView
            this.klientTxt.Text = "";
            this.sumTxt.Text = "";
            loadGrid();
        }//COMM

        public void removePrerjet(string monedha_id)
        {
            //funksioni qe heq prerjet nga DB, kodi ndertohet gjate ekzekutimit te funksionit
            string strBuild = "";
            strBuild += "update gjendja set ";
            for (int i = 0; i < this.radGridView1.Rows.Count - 1; i++)
            {
                strBuild += "Sasia" + (i + 1).ToString() + " = " + "Sasia" + (i + 1).ToString() + " - " + this.radGridView1.Rows[i].Cells[1].Value.ToString() + ", ";
            }
            strBuild = strBuild.Substring(0, strBuild.Length - 2);
            strBuild += " where id_ark = " + this.arkaBox.SelectedValue.ToString() + " and id_curr = " + monedha_id;
            Lidhja.Kerkesat1.a.excecuteInsertScript(strBuild);
        }//COMM

        public void addPrerjet(string monedha_id)
        {
            //funksioni qe shton prerjet ne DB
            string strBuild = "";
            strBuild += "update gjendja set ";
            for (int i = 0; i < this.radGridView1.Rows.Count - 1; i++)
            {
                strBuild += "Sasia" + (i + 1).ToString() + " = " + "Sasia" + (i + 1).ToString() + " + " + this.radGridView1.Rows[i].Cells[1].Value.ToString() + ", ";
            }
            strBuild = strBuild.Substring(0, strBuild.Length - 2);
            strBuild += " where id_ark = " + this.arkaBox.SelectedValue.ToString() + " and id_curr = " + monedha_id;
            Lidhja.Kerkesat1.a.excecuteInsertScript(strBuild);
        }//COMM

        private void ngaBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //ne rast ndryshimi te monedhes, ri-mbushim GridView me prerjet dhe gjendjet dhe marrim totalin
            if (loadOk1 && this.arkaBox.SelectedIndex > -1)
            {
                loadGrid();
                getGjendja(this.ngaBox.SelectedValue.ToString());
            }
        }//COMM

        private void nullifySelected()
        {
            //funksioni qe ben 0 sasine e cdo prerje
            for (int i = 0; i < this.radGridView1.Rows.Count - 1; i++)
            {
                this.radGridView1.Rows[i].Cells[1].Value = 0;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //ne rast se zgjidhet terheqje ose depozitim, therritet funksioni qe con 0 sasine e cdo prerje (restart i GridView)
            nullifySelected();
        }//COMM

        private void konfirmoBtn_Click(object sender, EventArgs e)
        {
            //butoni qe ben konfirmimin dhe postimin e transaksionit
            if (loggedUser != "0")
            {
                //nese kemi nje perdorues te loguar
                bool okToGo = false;
                if (ngaBox.SelectedIndex > -1 && this.klientTxt.Text != "" && this.arkaBox.SelectedIndex > -1)
                {
                    if (float.Parse(this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].Value.ToString()) <= float.Parse(gjendjaLbl.Text) || this.radioButton2.Checked)
                    {
                        if (float.Parse(this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].Value.ToString()) == float.Parse(this.sumTxt.Text))
                        {
                            //nese totali eshte me i vogel se gjendja dhe nese totali eshte i barabarte me shumen e vendosur ne nderfaqe,
                                //okToGo merr vleren TRUE per tu futur ne bllokun ku postohet transaksioni
                            okToGo = true;
                        }
                        else
                        {
                            MessageBox.Show("Prerjet nuk jane vendosur sakte!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nuk ka gjendje te mjaftueshme per te kryer transaksionin!");
                    }
                }
                else
                {
                    MessageBox.Show("Ruajtja e transaksionit nuk mund te kryhet!\n\rKontrolloni plotesimin!");
                }
                if (okToGo)
                {
                    //Lidhja.Kerkesat1.a.insertTransaction(loggedUser, DateTime.Now.Date, DateTime.Parse(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString()), (isFavouriteMode ? firstName : ngaBox.Text), this.sumTxt.Text, (isFavouriteMode ? secondName : this.neBox.Text), this.totaliLbl.Text, arkaBox.SelectedValue.ToString(), blerje_shitje, (this.checkBox2.Checked ? "Klient i Panjohur" : this.klientTxt.Text), curr_trans.ToString());
                    //nese nuk ka gabime, pra transaksioni mund te postohet, ekzekutojme proceduren me parametrat e kaluara
                    Lidhja.Kerkesat1.a.insertTransaction(loggedUser, DateTime.Now.Date, DateTime.Parse(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString()), ngaBox.Text, this.sumTxt.Text, "", "", this.arkaBox.SelectedValue.ToString(), (radioButton2.Checked ? "Depozitim" : "Terheqje"), this.klientTxt.Text, "1", "0");
                    if (radioButton1.Checked)
                    {
                        //heqim prerjet nga DB ne rast se kemi terheqje
                        removePrerjet(this.ngaBox.SelectedValue.ToString());
                    }
                    else
                    {
                        //ose i shtojme ne rast se kemi depozitim
                        addPrerjet(this.ngaBox.SelectedValue.ToString());
                    }
                    MessageBox.Show("Transaksioni u ruajt me sukses!");
                    //ri-inicializojme nderfaqen
                    restartInterface();
                }
            }
            else
            {
                //ne rast se transaksioni po krijohet nga nje SYSTEM ADMIN
                MessageBox.Show("Administratori i sistemit nuk mund te inseroje transaksione!");
            }
        }//COMM

        //variabli qe tregon se forma mund te mbyllet pasi eshte konfirmuar nga perdoruesi
            //TRUE  -> mund te mbyllet
            //FALSE -> nuk mund te mbyllet dhe do te shfaqet nje MessageBox per konfirmim te mbylljes nga perdoruesi
        bool okToClose = false;
        private void SpecialTransactions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!okToClose)
            {
                //nese nuk eshte konfirmuar mbyllja nga perdoruesi, do te shfaqet nje MessageBox ne te cilin behet konfirmimi
                    //funksioni qe therritet ne konfirmim eshte ai qe ndodhet ne EventHandler qe kalohet si parameter ne MessageBox
                e.Cancel = true;
                DialogResult dr;
                dr = MessageBox.Show("Jeni te sigurt qe doni te mbyllni dritaren?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(closeOk));
            }
        }//COMM

        private void closeOk(object sender, EventArgs e)
        {
            //nese eshte bere konfirmimi i mbylljes nga perdoruesi
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                //nese ka konfirmuar, variablit okToClose i japim vleren TRUE dhe bejme mbyllje manuale
                    //ne kete menyre nuk do te ekzekutohet kodi ne eventin e mbylljes se MessageBox
                okToClose = true;
                this.Close();
                okToClose = false;
            }
            else
            {
                //perndryshe variabli merr vleren FALSE per te rishfaqur MessageBox e konfirmimit ne rast se perseri tentohet mbyllja
                okToClose = false;
            }
        }
    }//COMM
}