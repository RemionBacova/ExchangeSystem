#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using CRMMobileDemo.Common;
using CustomCRMControls;

#endregion

namespace CRMMobileDemo.iOS.CustomControlsMC
{
    public partial class TransaksionGjendje : TranslatePanel
    {
        string monedha_id = "";
        string arka_id = "";
        string monedha_emertimi = "";

        //lista e user-controls ne te cilat vendosen sasite e daljes ose te hyrjes
        List<LabelBox> rows = new List<LabelBox>();
        public TransaksionGjendje()
        {
            InitializeComponent();
            //inicializim i gjeresive te elementeve
            this.sumTxt.Width = this.panel1.Width - 64;
            this.klientTxt.Width = this.panel1.Width - 64;
        }

        public void insertNewRow(string prerja, string gjendja_zgjedhur, string gjendja)
        {
            //funksion qe shton nje user-control per sasite e daljes ose te hyrjes
            LabelBox lb = new LabelBox(prerja, gjendja_zgjedhur, gjendja, new EventHandler(control_text_changed))
                {
                    Dock = DockStyle.Top,
                    Width = rowsContainer.Width
                };
            //gjithashtu shtohet referenca mbi user-control edhe ne listen e percaktuar ne nivel klase
            rows.Add(lb);
        }//COMM

        void control_text_changed(object sender, EventArgs e)
        {
            //funksion qe kalohet me delegat ne konstruktorin e user-control per vendosjen e prerjeve
                //funksioni therritet ne ndryshim te vleres ne user-control, per ri-llogaritjen e shumes dhe
                //shfaqjes ne nderfaqe
            llogaritShumen();
        }//COMM

        public void llogaritShumen()
        {
            //funksion qe llogarit shumen sipas vlerave te inseruara ne te gjithe user-control LabelBox ku vendoset sasia e prerjeve
                //per hyrje ose dalje
            float s = 0;
            //kerkojme me FOR ne listen e user-controls
            for (int i = 0; i < rows.Count; i++)
            {
                s += float.Parse(rows[i].insideCol1Txt.Text) * float.Parse(rows[i].insideLabel.Text);
            }
            this.totaliLbl.Text = s.ToString();
        }//COMM

        public void fillPrerjet(string monedha_id, string arka_id, string monedha_emertimi)
        {
            //funksioni qe mbush nderfaqen me prerjet dhe sasite e tyre ne DB, per te vendosur perdoruesi sasine qe do te 
                //beje pjese ne transaksion

            this.monedha_id = monedha_id;
            this.arka_id = arka_id;
            this.monedha_emertimi = monedha_emertimi;
            //merret gjendja e monedhes ne arken e zgjedhur
            getGjendja(monedha_id, arka_id);
            //fshihen te gjithe referencat e listes se user-controls
            rows.Clear();
            //fshihen user-controls si elemente vizuale
            this.rowsContainer.Controls.Clear();
            //merren prerjet dhe gjendjet nga DB
            DataTable prerjet = Lidhja.Kerkesat1.a.selectPrerjet(monedha_id).Copy();
            DataTable gjendjet = Lidhja.Kerkesat1.a.selectGjendjet(monedha_id, arka_id).Copy();

            //per cdo rresht te DataTable-ve prerjet dhe gjendjet, vendosim nje user-control me prerjen dhe gjendjen te kaluara si parameter
            float z;
            for (int i = 2; i < prerjet.Columns.Count; i++)
            {
                //index i kolones tek DataTable prerjet korrespondon me te njejtin index ne DataTable gjendjet + 1
                    //pra prerjet[i] ka gjendjen[i+1]
                if (prerjet.Rows[0].ItemArray[i] != null && gjendjet.Rows[0].ItemArray[i+1] != null)
                {
                    if (prerjet.Rows[0].ItemArray[i].ToString() != "" && gjendjet.Rows[0].ItemArray[i+1].ToString() != "")
                    {
                        if(float.TryParse(prerjet.Rows[0].ItemArray[i].ToString(), out z) && float.TryParse(gjendjet.Rows[0].ItemArray[i+1].ToString(), out z))
                        {
                            if (float.Parse(prerjet.Rows[0].ItemArray[i].ToString()) != 0 && float.Parse(gjendjet.Rows[0].ItemArray[i+1].ToString()) != 0)
                            {
                                //user-control shtohet nese kemi vlere jo NULL ose "" te te dy DataTable dhe nese keto vlera jane vlera numerike
                                    //te ndryshme nga 0
                                    //shtimi behet duke thirrur funksionin qe shton user-control
                                insertNewRow(prerjet.Rows[0].ItemArray[i].ToString(), "0", gjendjet.Rows[0].ItemArray[i+1].ToString());
                            }
                        }
                    }
                }
            }

            //pasi i kemi shtuar si elemente vizuale, i shtojme user-control edhe ne listen e deklaruar ne nivel klase
            foreach (LabelBox lb in (from cr in rows orderby float.Parse(cr.insideLabel.Text) descending select cr))
            {
                this.rowsContainer.Controls.Add(lb);
            }
        }//COMM

        public void getGjendja(string monedha_id, string arka_id)
        {
            //funksion qe merr gjendjen e monedhes se kaluar si parameter ne arken e kaluar si parameter
            //merren prerjet dhe gjendjet nga DB
            DataTable prerjet = Lidhja.Kerkesat1.a.selectPrerjet(monedha_id).Copy();
            DataTable gjendja = Lidhja.Kerkesat1.a.selectGjendjet(monedha_id, arka_id).Copy();
            float sum = 0;
            if (prerjet.Rows.Count > 0)
            {
                if (gjendja.Rows.Count > 0)
                {
                    //nese kemi rekorde ne te dyja DataTable
                    for (int i = 2; i < prerjet.Columns.Count; i++)
                    {
                        //index i kolones tek DataTable prerjet korrespondon me te njejtin index ne DataTable gjendjet + 1
                            //pra prerjet[i] ka gjendjen[i+1]
                        float z;
                        if (float.TryParse(prerjet.Rows[0].ItemArray[i].ToString(), out z) && float.TryParse(gjendja.Rows[0].ItemArray[i + 1].ToString(), out z))
                        {
                            sum += float.Parse(prerjet.Rows[0].ItemArray[i].ToString()) * float.Parse(gjendja.Rows[0].ItemArray[i + 1].ToString());
                        }
                    }
                }
                else
                {
                    //nese nuk kemi rekorde nga gjendja
                    this.msgLbl.Text = "Nuk ka gjendje fillestare per monedhen!";
                }
            }
            else
            {
                //nese nuk kemi rekorde nga prerjet
                this.msgLbl.Text = "Nuk ka prerje per monedhen!";
            }
            //shfaqim shumen e llogaritur
            this.gjendjaLbl.Text = sum.ToString("0.00");
        }//COMM

        public void saveTransaction(string loggedUser)
        {
            //funksioni qe ruan transaksionin e krijuar ne nderfaqe
            float z;
            bool okToGo = false;
            if (this.klientTxt.Text != "" && float.TryParse(this.sumTxt.Text, out z))
            {
                //nese kemi vendosur nje arsye dhe nje shume te caktuar ne UI
                if (float.Parse(this.totaliLbl.Text) <= float.Parse(gjendjaLbl.Text) || this.radioButton2.Checked)
                {
                    //nese totali i llogaritur eshte me i vogel se gjendja e monedhes, ose nese po behet depozitim i monedhes ne arke
                    if (float.Parse(this.totaliLbl.Text) == float.Parse(this.sumTxt.Text))
                    {
                        //nese totali i llogaritur nga vendosja e prerjeve eshte sa shuma e vendosur, 
                            //pra nese prerjet jane vendosur sakte nga perdoruesi
                            //japim vlere tek variabli per te avancuar ne bllokun qe ben inserimin e transaksionit
                        okToGo = true;
                    }
                    else
                    {
                        //nese nuk kemi perputhje te vleres se vendosur si shume dhe te totalit te llogaritur nga vendosja e prerjeve
                        this.msgLbl.Text = "Prerjet nuk jane vendosur sakte!";
                    }
                }
                else
                {
                    //nese nuk kemi gjendje te mjaftueshme pasi po bejme terheqje te monedhes nga arka
                    this.msgLbl.Text = "Nuk ka gjendje te mjaftueshme!";
                }
            }
            else
            {
                //nese kemi lene elemente pa plotesuar, ose i kemi plotesuar gabim (shuma nuk eshte vlere numerike)
                this.sumTxt.Text = "0";
                this.msgLbl.Text = "Kontrolloni plotesimin!";
            }

            if (okToGo)
            {
                //nese eshte arritur te behet TRUE variabli okToGo, bejme inserim te transaksionit

                //Lidhja.Kerkesat1.a.insertTransaction(loggedUser, DateTime.Now.Date, DateTime.Parse(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString()), (isFavouriteMode ? firstName : ngaBox.Text), this.sumTxt.Text, (isFavouriteMode ? secondName : this.neBox.Text), this.totaliLbl.Text, arkaBox.SelectedValue.ToString(), blerje_shitje, (this.checkBox2.Checked ? "Klient i Panjohur" : this.klientTxt.Text), curr_trans.ToString());
                Lidhja.Kerkesat1.a.insertTransaction(loggedUser, DateTime.Now.Date, DateTime.Parse(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString()), this.monedha_emertimi, this.sumTxt.Text, "", "", this.arka_id, (radioButton2.Checked ? "Depozitim" : "Terheqje"), this.klientTxt.Text, "1", "0");
                if (radioButton1.Checked)
                {
                    //nese po bejme terheqje, therrasim funksionin removePrerjet per te hequr sasine e percaktuar te prerjeve nga DB
                    removePrerjet(this.monedha_id);
                }
                else
                {
                    //nese po bejme depozitim, therrasim funksionin addPrerjet per te shtuar sasine e percaktuar te prerjeve nga DB
                    addPrerjet(monedha_id);
                }
                //shfaqim mesazhin ne UI
                msgLbl.Text = "Transaksioni u ruajt me sukses!";
                //ri-inicializojme nderfaqen
                restartInterface();
            }
        }//COMM

        public void removePrerjet(string monedha_id)
        {
            //funksioni qe heq prerjet e zgjedhura si sasi nga DB
                //kodi ne SQL do te krijohet ne C# dhe do te ekzekutohet ne server

            string strBuild = "";
            strBuild += "update gjendja set ";
            for (int i = 0; i < rows.Count; i++)
            {
                //per cdo prerje vendosim sasite ne baze te informacionit qe ka dhene perdoruesi,
                    //do te krijohet nje script i tipit:
                    //Sasia1 = Sasia1 - sasia_e_vendosur_nga_perdoruesi_ne_usercontrol_1, 
                    //Sasia2 = Sasia2 - sasia_e_vendosur_nga_perdoruesi_ne_usercontrol_2, ...
                strBuild += "Sasia" + (i + 1).ToString() + " = " + "Sasia" + (i + 1).ToString() + " - " + this.rows[i].insideCol1Txt.Text + ", ";
            }
            //heqim presjen e fundit te shtuar ne iteracionin e fundit
            strBuild = strBuild.Substring(0, strBuild.Length - 2);
            //shtojme kushtin, pra modifikimi do te behet ne rekordin ku ndodhet arka dhe monedha e zgjedhur
            strBuild += " where id_ark = " + this.arka_id + " and id_curr = " + monedha_id;
            //ekzekutojme scriptin
            Lidhja.Kerkesat1.a.excecuteInsertScript(strBuild);
        }//COMM

        public void addPrerjet(string monedha_id)
        {
            //funksioni qe shton prerjet e zgjedhura si sasi nga DB
                //kodi ne SQL do te krijohet ne C# dhe do te ekzekutohet ne server
            string strBuild = "";
            strBuild += "update gjendja set ";
            for (int i = 0; i < rows.Count; i++)
            {
                //per cdo prerje vendosim sasite ne baze te informacionit qe ka dhene perdoruesi,
                    //do te krijohet nje script i tipit:
                    //Sasia1 = Sasia1 + sasia_e_vendosur_nga_perdoruesi_ne_usercontrol_1, 
                    //Sasia2 = Sasia2 + sasia_e_vendosur_nga_perdoruesi_ne_usercontrol_2, ...
                strBuild += "Sasia" + (i + 1).ToString() + " = " + "Sasia" + (i + 1).ToString() + " + " + this.rows[i].insideCol1Txt.Text + ", ";
            }
            //heqim presjen e fundit te shtuar ne iteracionin e fundit
            strBuild = strBuild.Substring(0, strBuild.Length - 2);
            //shtojme kushtin, pra modifikimi do te behet ne rekordin ku ndodhet arka dhe monedha e zgjedhur
            strBuild += " where id_ark = " + this.arka_id + " and id_curr = " + monedha_id;
            //ekzekutojme scriptin
            Lidhja.Kerkesat1.a.excecuteInsertScript(strBuild);
        }//COMM

        public void restartInterface()
        {
            //funksioni qe ben ri-inicializimin e nderfaqes, rivendos prerjet e monedhes dhe vendos vlera bosh ne TextBox
            this.klientTxt.Text = "";
            this.sumTxt.Text = "";
            this.fillPrerjet(this.monedha_id, this.arka_id, this.monedha_emertimi);
            this.sumTxt.Focus();
        }//COMM
    }
}