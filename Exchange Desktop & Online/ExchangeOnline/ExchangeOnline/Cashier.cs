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
    public partial class Cashier : Form
    {
        #region declaration_section
        //variablat qe nuk lejojne ekzekutimin e kodit te eventeve ne rast se nuk jane krijuar elementet vizuale perkates
        bool loadOk1 = false;
        bool loadOk2 = false;
        bool loadGridOk1 = false;
        bool loadGridOk2 = false;
        
        bool okToClose = false;

        //variablat qe mbajne ID e rekordeve te kursit te monedhave te zgjedhura
        string id_kursi1 = "";
        string id_kursi2 = "";

        //kurset e monedhave te zgjedhura
        float blerje1;
        float shitje1;
        float blerje2;
        float shitje2;

        //kurset e shitjes dhe blerjes per veprimin qe po kryhet, pra nga njera monedhe e zgjedhur tek tjetra
        float kursi1 = 0;
        float kursi2 = 0;
        float min_denom;
        //variabli qe ruan kursin me te cilin po kryhet veprimi, qofte shitje ose blerje ne varesi te zgjedhjes
        float curr_trans;

        //numri i butonave qe shfaqen ne formen e monedhave
        int buttonCounter = 0;

        //variablat qe tregojne a jane zgjedhur monedhat kur ato shfaqen ne forme butonash
        bool firstClicked = false;
        bool secondClicked = false;

        //variabel qe tregon menyren e paraqitjes se monedhave
            //true  -> ne forme butonash, pra ato te preferuarat
            //false -> ne forme dropdown, pra te gjitha monedhat
        bool isFavouriteMode = true;
        //variablat qe mbajne ID dhe emrin e monedhave te zgjedhura
        string firstId = "";
        string secondId = "";
        string firstName = "";
        string secondName = "";

        string curr_out = "";
        string curr_in = "";

        //variablat qe tregojne se po behet nje shitje ose blerje
        bool isShitje = true;
        string blerje_shitje = "";
        //variabel qe tregon se perdoruesi ka percaktuar nje kurs dhe nuk ka perdorur kurset e DB
        bool isCustomRate = false;

        //variablat qe ruajne indexet e monedhave ne rast se duhet kthyer dropdown tek index i meparshem ne rast mungese kursi
        int oldIndex1 = -1;
        int oldIndex2 = -1;
        //variablat qe kane te njejtin funksion si oldIndex1 & oldIndex2 por qe sherbejne per ngjyrosjen e butonave te meparshem
            //pra ruajne ID dhe emrin e monedhes
        string oldId1 = "";
        string oldId2 = "";
        string oldName1 = "";
        string oldName2 = "";

        //variablat qe nuk lejojne ekzekutimin e kodit ne eventet e TextBox-eve te shumes dhe totalit
            //ne rastin kur kemi bere ndryshim me kod te TextBox-eve por akoma nuk jane marre monedhat
        bool sumTxtEventOk = true;
        bool totaliLblEventOk = true;

        //gjeresia fillestare ne px e dritares
        int initialWindowWidth;

        DataGridViewTextBoxColumn emertimi1;
        DataGridViewTextBoxColumn number1;
        DataGridViewTextBoxColumn existing_number1;
        DataGridViewTextBoxColumn kusuri1;

        DataGridViewTextBoxColumn emertimi2;
        DataGridViewTextBoxColumn number2;
        DataGridViewTextBoxColumn existing_number2;
        DataGridViewTextBoxColumn kusuri2;

        string loggedUser;
        #endregion

        public Cashier(string user_id)
        {
            //merret ID e perdoruesit qe eshte loguar ne sistem si parameter i konstruktorit
            this.loggedUser = user_id;
            InitializeComponent();
            //gjeresia fillestare e dritares ruhet per tu perdorur ne rast se ndryshohet menyra e paraqitjes se monedhave
            initialWindowWidth = this.Width;

            //merren monedhat dhe si default ne fillim kemi Shitje
            loadNgaNe();
            activateShitje();
            //variabli blerje_shitje mban thjesht "Blerje" ose "Shitje" qe te kalohen si STRING ne label-in perkates
            this.shitjeBlerjeLbl.Text = blerje_shitje;
            //merren te gjitha arkat te cilat perdoruesi i loguar eshte i autorizuar t'i perdore
            loadArka(user_id);
            //caktivizohet kursi i percaktuar nga perdoruesi si default
            disablePreferencial();
        }

        private void enablePreferencial()
        {
            //funksioni qe aktivizon kursin preferencial te caktuar nga perdoruesi gjate faturimit
                //variabli qe tregon se kursi eshte preferencial
            isCustomRate = true;

            //aktivizohet TextBox ku shkruhet kursi preferencial
            this.customRateTxt.Enabled = true;
            this.customRateTxt.Text = "1";
            //label-at qe tregojne kurset nga DB caktivizohen pasi nuk jane te nevojshem
            this.shitjeLbl.Visible = false;
            this.blerjeLbl.Visible = false;
        }//COMM

        private void disablePreferencial()
        {
            //funksioni qe caktivizon kursin preferencial te caktuar nga perdoruesi gjate faturimit
                //variabli qe tregon se kursi nuk eshte preferencial
            isCustomRate = false;
            
            //caktivizohet TextBox ku shkruhet kursi preferencial
            this.customRateTxt.Enabled = false;
            this.customRateTxt.Text = "";
            //label-at qe tregojne kurset nga DB aktivizohen
            this.shitjeLbl.Visible = true;
            this.blerjeLbl.Visible = true;
        }//COMM

        public void loadArka(string user_id)
        {
            //funksioni qe merr arkat me te cilat eshte i lidhur ky perdorues dhe i vendos ato ne ComboBox
            DataTable arka = Lidhja.Kerkesat1.a.selectArkatByUser(user_id).Copy();
            if (arka.Rows.Count > 0)
            {
                this.arkaBox.DataSource = arka;
                this.arkaBox.ValueMember = "id";
                this.arkaBox.DisplayMember = "arka";
                this.arkaBox.SelectedIndex = 0;
            }
            else
            {
                //ne rast se nuk ka arka per kete perdorues
                MessageBox.Show("Ju nuk keni asnje arke te caktuar!");
            }
        }//COMM

        public void loadNgaNe()
        {
            //funksioni qe merr monedhat nga DB dhe i shfaq ato

            //per te mos lejuar eventet e sumTxt dhe totaliLbl
            this.sumTxtEventOk = false;
            this.totaliLblEventOk = false;
            kursi1 = 0;
            kursi2 = 0;
            //asnje nga monedhat nuk eshte zgjedhur, pra variablat qe perfaqesojne monedhat marrin vlerat fillestare
            firstClicked = false;
            secondClicked = false;
            firstId = "";
            secondId = "";
            //nuk ka akoma kurse pasi nuk ka monedhe te zgjedhur
            this.blerjeLbl.Text = "";
            this.shitjeLbl.Text = "";
            this.totaliLbl.Text = "0";
            //si default aktivizohet Shitja
            activateShitje();

            //merren te gjitha monedhat nga DB per ComboBox e pare
            DataTable monedhat1 = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();
            //variablat nuk lejojne hyrjen ne eventet e ComboBox nderkohe qe ai konfigurohet
            loadOk1 = false;
            this.ngaBox.DataSource = monedhat1;
            this.ngaBox.ValueMember = "id";
            this.ngaBox.DisplayMember = "monedha";
            this.ngaBox.SelectedIndex = -1;
            loadOk1 = true;

            //merren te gjitha monedhat nga DB per ComboBox e dyte
            DataTable monedhat2 = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();
            //variablat nuk lejojne hyrjen ne eventet e ComboBox nderkohe qe ai konfigurohet
            loadOk2 = false;
            this.neBox.DataSource = monedhat2;
            this.neBox.ValueMember = "id";
            this.neBox.DisplayMember = "monedha";
            this.neBox.SelectedIndex = -1;
            loadOk2 = true;
            //ne kete moment lejohet ekzekutimi i kodit ne ndryshim te vlerave te TextBox-eve
            this.totaliLblEventOk = true;
            this.sumTxtEventOk = true;

            
            if (isFavouriteMode)
            {
                //nese kemi te zgjedhur paraqitjen me butona te monedhave, marrim monedhat e 'preferuara' nga DB
                    //dhe per cdo rresht, therrasim funksionin qe shton butona ne nderfaqe
                DataTable monedhat3 = Lidhja.Kerkesat1.a.selectFavoriteCurrencies().Copy();
                //ComboBox-et nuk jane te dukshme
                this.ngaBox.Visible = false;
                this.neBox.Visible = false;
                for (int i = 0; i < monedhat3.Rows.Count; i++)
                {
                    //per cdo monedhe shfaqim buton nepermjet funksionit, duke kaluar te dhenat e monedhave si parametra
                        //ne funksionin ku ato krijohen
                    this.insertButton(monedhat3.Rows[i].ItemArray[0].ToString(), monedhat3.Rows[i].ItemArray[1].ToString());
                }
            }
            else
            {
                //nese nuk kemi te zgjedhur paraqitjen me butona te monedhave, i heqim ato nga nderfaqa duke thirrur funksionin
                    //dhe shfaqim ComboBox-et
                this.ngaBox.Visible = true;
                this.neBox.Visible = true;
                removeButtons();
                //numri i butonave te shtuar eshte 0
                this.buttonCounter = 0;
            }
        }//COMM

        private void insertButton(string id, string content)
        {
            //krijohen butonat qe do te shtohen ne nderfaqe
                //ID e monedhes vendoset si emri i monedhes
            Button b = new Button()
            {
                Name = id,
                Text = content,
                Width = 70,
                Height = 21,
                Top = 64
            };
            Button b2 = new Button()
            {
                Name = id,
                Text = content,
                Width = 70,
                Height = 21,
                Top = 119
            };
            //caktohen eventet e klikimit per te dy butonat
                //si Tag vendosim "FirstButton" ose "SecondButton" per te identifikuar butonat
            b.Click += new EventHandler(firstClick);
            b.Tag = "FirstButton";
            b2.Click += new EventHandler(secondClick);
            b2.Tag = "SecondButton";
            //zhvendoset butoni i vendosur pas gjithe te tjereve te vendosur para tij
            b.Left = b2.Left = 86 + buttonCounter * b.Width;
            if (b.Width + b.Left > this.Width)
            {
                //zmadhohet nderfaqa per te shfaqur te gjithe butonat
                this.Width += b.Width;
            }
            //shtohen butonat ne nderfaqe
            this.Controls.Add(b);
            this.Controls.Add(b2);
            //inkrementohet numeruesi i butonave te shtuar me 1
            buttonCounter++;
        }//COMM

        private void removeButtons()
        {
            //funksioni qe heq nga nderfaqa butonat qe perfaqesojne monedhat 
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                //nese kontrolli eshte i tipit Button
                if (this.Controls[i].GetType() == typeof(Button))
                {
                    Button a = ((Button)this.Controls[i]);
                    if (a.Tag != null)
                    {
                        //nese ai ka si Tag string-et e meposhtem pra nese eshte nje nga butonat qe perfaqeson monedhat
                        if (a.Tag.ToString() == "FirstButton" || a.Tag.ToString() == "SecondButton")
                        {
                            //atehere e heqim butonin nga nderfaqa
                            this.Controls.Remove(a);
                        }
                    }
                }
            }
        }//COMM

        void secondClick(object sender, EventArgs e)
        {
            //funksioni qe therritet ne zgjedhje te nje monedhe tjeter 
            //nese klikohet nje nga butonat e rreshtit te dyte qe perfaqesojne monedhat
            secondClicked = true;
            //marrim ID e butonit qe ndodhet ne emrin e butonit
            secondId = ((Button)sender).Name;
            //nese funksioni kthen TRUE do te thote qe eshte marre kursi dhe mund te vazhdojme me zgjedhjen e monedhes
            if (getBlerjeShitje2())
            {
                //tregojme nepermjet variablit qe eshte zgjedhur nje nga monedhat e rreshtit te dyte
                secondClicked = true;
                //therrasim funksionin qe cngjyros te gjithe butonat e rreshtit te dyte
                decolourSecond();
                //ngjyrosim butonin e zgjedhur
                ((Button)sender).BackColor = Color.LightBlue;
                //emri i monedhes se dyte te zgjedhur eshte teksi i butonit
                secondName = ((Button)sender).Text;
                //ne zgjedhje te monedhes llogarisim shumen
                llogaritShumen();
                //ruajme ID dhe emrin e monedhes se sapo-zgjedhur per perdorim te mevonshem, ne rast se duhet anuluar zgjedhja
                oldId2 = secondId;
                oldName2 = secondName;
                //shfaqim emrin e monedhes per tu kuptuar me lehte procesi nga perdoruesi
                this.totalCurrencyLbl.Text = secondName;
            }
            else
            {
                //ne rastin kur nuk kemi nje kurs te percaktuar per monedhen e zgjedhur, anulohet zgjedhja dhe 
                    //rivendoset monedha e zgjedhur me pare si ajo e zgjedhur aktualisht
                if (oldId2 == "")
                {
                    secondClicked = false;
                }
                secondId = oldId2;
                secondName = oldName2;
            }
            //ne zgjedhje te monedhes, mbushen GridView qe permbajne prerjet e monedhave dhe sasite e tyre qe do te marrin pjese ne transaksion
            loadFirstGrid();
            loadSecondGrid();
        }//COMM

        void firstClick(object sender, EventArgs e)
        {
            //funksioni qe therritet ne zgjedhje te nje monedhe tjeter 
                //nese klikohet nje nga butonat e rreshtit te pare qe perfaqesojne monedhat
            firstClicked = true;
            //marrim ID e butonit qe ndodhet ne emrin e butonit
            firstId = ((Button)sender).Name;
            //nese funksioni kthen TRUE do te thote qe eshte marre kursi dhe mund te vazhdojme me zgjedhjen e monedhes
            if (getBlerjeShitje1())
            {
                //therrasim funksionin qe cngjyros te gjithe butonat e rreshtit te pare
                decolourFirst();
                //ngjyrosim butonin e zgjedhur
                ((Button)sender).BackColor = Color.LightBlue;
                //emri i monedhes se pare te zgjedhur eshte teksi i butonit
                firstName = ((Button)sender).Text;
                //tregojme nepermjet variablit qe eshte zgjedhur nje nga monedhat e rreshtit te pare
                firstClicked = true;
                //ne zgjedhje te monedhes llogarisim shumen
                llogaritShumen();
                //ruajme ID dhe emrin e monedhes se sapo-zgjedhur per perdorim te mevonshem, ne rast se duhet anuluar zgjedhja
                oldId1 = firstId;
                oldName1 = firstName;
                //shfaqim emrin e monedhes per tu kuptuar me lehte procesi nga perdoruesi
                this.sumCurrencyLbl.Text = firstName;
            }
            else
            {
                //ne rastin kur nuk kemi nje kurs te percaktuar per monedhen e zgjedhur, anulohet zgjedhja dhe 
                    //rivendoset monedha e zgjedhur me pare si ajo e zgjedhur aktualisht
                if (oldId1 == "")
                {
                    firstClicked = false;
                }
                firstId = oldId1;
                firstName = oldName1;
            }
            //ne zgjedhje te monedhes, mbushen GridView qe permbajne prerjet e monedhave dhe sasite e tyre qe do te marrin pjese ne transaksion
            loadFirstGrid();
            loadSecondGrid();
        }//COMM

        private void llogaritShumen()
        {
            //funksioni qe llogarit shumen ne baze te kursit
            //per te mos lejuar ekzekutimin e kodit ne eventin e totaliLbl deri ne fund te ndryshimit te vleres me kod
            this.totaliLblEventOk = false;
            float z;
            //nese kemi nje vlere numerike ne TextBox, dhe nese kemi te zgjedhura te dyja monedhat
                //(kushti perfshin rastin me DropDown ose rastin me butona)
            if (float.TryParse(this.sumTxt.Text, out z) && ((this.ngaBox.SelectedIndex > -1 && this.neBox.SelectedIndex > -1) || (firstClicked && secondClicked)))
            {
                //nese kemi shitje, bejme veprimin me kursin e shitjes, perndryshe me ate te blerjes
                //nese kemi te percaktuar nje kurs preferencial, perdorim ate ne veprim, perndryshe perdorim kursin nga DB
                    //(kushtet jane vendosur ne rreshtin e vleredhenies me '?'
                if (isShitje)
                {
                    //this.totaliLbl.Text = ((float)((((int)((float.Parse(sumTxt.Text) * float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text))) / min_denom)) + 1) * min_denom)).ToString();
                    this.totaliLbl.Text = (float.Parse(sumTxt.Text) * (isCustomRate ? float.Parse((this.customRateTxt.Text == "" ? "0" : this.customRateTxt.Text)) : float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text)))).ToString("0.00");
                }
                else
                {
                    //this.totaliLbl.Text = ((float)((((int)((float.Parse(sumTxt.Text) * float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text))) / min_denom))) * min_denom)).ToString();
                    this.totaliLbl.Text = (float.Parse(sumTxt.Text) * (isCustomRate ? float.Parse((this.customRateTxt.Text == "" ? "0" : this.customRateTxt.Text)) : float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text)))).ToString("0.00");
                }

                //variabli qe ruan kursin aktual merr vleren sipas kushtit
                curr_trans = (isCustomRate ? float.Parse((this.customRateTxt.Text == "" ? "0" : this.customRateTxt.Text)) : float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text)));
                //percaktohen automatikisht si do te vendosen prerjet ne dalje
                fillAutoDalje();
            }
            if (this.sumTxt.Text == "")
            {
                //ne rastin kur TextBox ku vendoset shua nuk ka vlere, TextBox qe nxjerr rezultatin merr vleren 0
                this.totaliLbl.Text = "0.00";
            }
            //ketu lejohet futja ne event prej ndryshimit te tekstit ne TextBox
            this.totaliLblEventOk = true;
            
        }//COMM

        private void llogaritShumenReverse()
        {
            //e kunderta e funksionit llogaritShumen, ben llogaritjen e TextBox-it te shumes nepermjet vleres qe futet
                //ne TextBox te rezultatit

            this.sumTxtEventOk = false;
            float z;
            if (float.TryParse(this.totaliLbl.Text, out z) && ((this.ngaBox.SelectedIndex > -1 && this.neBox.SelectedIndex > -1) || (firstClicked && secondClicked)))
            {
                if (isShitje)
                {
                    //this.totaliLbl.Text = ((float)((((int)((float.Parse(sumTxt.Text) * float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text))) / min_denom)) + 1) * min_denom)).ToString();
                    this.sumTxt.Text = (float.Parse(totaliLbl.Text) / (isCustomRate ? float.Parse((this.customRateTxt.Text == "" ? "0" : this.customRateTxt.Text)) : float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text)))).ToString("0.00");
                }
                else
                {
                    //this.totaliLbl.Text = ((float)((((int)((float.Parse(sumTxt.Text) * float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text))) / min_denom))) * min_denom)).ToString();
                    this.sumTxt.Text = (float.Parse(totaliLbl.Text) / (isCustomRate ? float.Parse((this.customRateTxt.Text == "" ? "0" : this.customRateTxt.Text)) : float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text)))).ToString("0.00");
                }
                fillAutoDalje();
                curr_trans = (isCustomRate ? float.Parse((this.customRateTxt.Text == "" ? "0" : this.customRateTxt.Text)) : float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text)));
            }
            if (this.totaliLbl.Text == "")
            {
                this.sumTxt.Text = "0.00";
            }
            this.sumTxtEventOk = true;
        }//COMM

        private void decolourFirst()
        {
            //funksioni qe cngjyros te gjithe butonat qe perfaqesojne monedhat e rreshtit te pare
            for (int i = 0; i < this.Controls.Count; i++)
            {
                //nese kontrolli eshte i tipit Button
                if (this.Controls[i].GetType() == typeof(Button))
                {
                    //dhe nese ka si tag stringun qe i vendoset butonave te rreshtit te pare
                    if (((Button)this.Controls[i]).Tag.ToString() == "FirstButton")
                    {
                        //merr ngjyren default
                        ((Button)this.Controls[i]).BackColor = SystemColors.Control;
                    }
                }
            }
        }//COMM

        private void decolourSecond()
        {
            //e njejta si decolourFirst, por per butonat e rreshtit te dyte qe perfaqesojne monedhat
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == typeof(Button))
                {
                    if (((Button)this.Controls[i]).Tag.ToString() == "SecondButton")
                    {
                        ((Button)this.Controls[i]).BackColor = SystemColors.Control;
                    }
                }
            }
        }//COMM

        public bool getBlerjeShitje1()
        {
            //funksioni qe merr kursin e blerjes dhe shitjes per monedhen e pare

            bool kasier = ((Form1)(this.MdiParent)).isKasier;
            float z;
            //merren kurset nga variabli qe mban ID e monedhes se pare, nese kemi te zgjedhur paraqitjen me butona 
                //ose nga vlera e zgjedhur e dropdown-it te pare, per daten e sotme
            DataTable current = Lidhja.Kerkesat1.a.getBlerjeShitjeMonedhe(isFavouriteMode ? firstId : this.ngaBox.SelectedValue.ToString(), DateTime.Now.ToString("dd/MM/yyyy")).Copy();
            if (current.Rows.Count > 0)
            {
                //nese kemi kurs per monedhen e zgjedhur per diten e sotme
                //dhe nese vlerat e shitjes dhe blerjes jane vlera numerike te sakta
                //ne rastin kur nuk jane vlerat te sakta, nese eshte loguar nje kasier, i shfaqet njoftimi
                    //ku thuhet se monedhat nuk kane te percaktuar nje nga kurset ose te dyja kurset
                    //nese eshte loguar nje ADMIN, i jepet mundesia per te dhene kurset me ane te nje MessageBox
                    //ku ai konfirmon qe do te konfiguroje kurset
                    //ne varesi te vleres jo te sakte, shfaqet dhe mesazhi i gabimit
                    //funksioni loadExchangeRate shfaq nderfaqen ku ADMINi hedh te dhenat e kursit, nese konfirmohet
                if (float.TryParse(current.Rows[0].ItemArray[0].ToString(), out z))
                {
                    if (float.TryParse(current.Rows[0].ItemArray[1].ToString(), out z))
                    {
                        if (float.Parse(current.Rows[0].ItemArray[0].ToString()) > 0)
                        {
                            if (float.Parse(current.Rows[0].ItemArray[1].ToString()) > 0)
                            {
                                //variablat marrin vleren e blerjes dhe shitjes respektivisht si dhe te ID se rekordit
                                blerje1 = float.Parse(current.Rows[0].ItemArray[0].ToString());
                                shitje1 = float.Parse(current.Rows[0].ItemArray[1].ToString());
                                id_kursi1 = current.Rows[0].ItemArray[2].ToString();
                                //ri-llogaritet kursi dhe kthehet TRUE per te plotesuar kushtin ne te cilin ndodhet funksioni
                                llogaritKursin();
                                return true;
                            }
                            else
                            {
                                if (kasier)
                                {
                                    MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar sakte kursin e shitjes!");
                                    return false;
                                }
                                else
                                {
                                    DialogResult a;
                                    a = MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar sakte kursin e shitjes!\n\rDoni te konfiguroni kurset tani?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(loadExchangeRate));
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            if (kasier)
                            {
                                MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar sakte kursin e blerjes!");
                                return false;
                            }
                            else
                            {
                                DialogResult a;
                                a = MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar sakte kursin e blerjes!\n\rDoni te konfiguroni kurset tani?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(loadExchangeRate));
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (kasier)
                        {
                            MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar kursin e shitjes!");
                            return false;
                        }
                        else
                        {
                            DialogResult a;
                            a = MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar kursin e shitjes!\n\rDoni te konfiguroni kurset tani?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(loadExchangeRate));
                            return false;
                        }
                    }
                }
                else
                {
                    if (kasier)
                    {
                        MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar kursin e blerjes!");
                        return false;
                    }
                    else
                    {
                        DialogResult a;
                        a = MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar kursin e blerjes!\n\rDoni te konfiguroni kurset tani?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(loadExchangeRate));
                        return false;
                    }
                }
            }
            else
            {
                if (kasier)
                {
                    MessageBox.Show("Monedha e zgjedhur nuk ka kursin te percaktuar!");
                    return false;
                }
                else
                {
                    DialogResult a;
                    a = MessageBox.Show("Monedha e zgjedhur nuk ka kurs te percaktuar!\n\rDoni te konfiguroni kurset tani?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(loadExchangeRate));
                    return false;
                }
            }
        }//COMM

        public void loadExchangeRate(object sender, EventArgs e)
        {
            //funksion qe therritet ne konfirmim te MessageBox qe i kerkon perdoruesit te ndryshoje kurset
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                //nese eshte konfirmuar nga perdoruesi, shfaqet nderfaqa e kurseve
                ((Form1)(this.MdiParent)).loadExchangeRate();
            }
        }//COMM

        public bool getBlerjeShitje2()
        {
            //e njeja si funksioni getBlerjeShitje1, por per monedhen e dyte 

            bool kasier = ((Form1)(this.MdiParent)).isKasier;
            float z;
            //DataTable current = Lidhja.Kerkesat1.a.getBlerjeShitjeMonedhe((isFavouriteMode ? (isShitje ? secondId : firstId) : (isShitje ? this.neBox.SelectedValue.ToString() : this.ngaBox.SelectedValue.ToString())), DateTime.Now.ToString("dd/MM/yyyy")).Copy();
            DataTable current = Lidhja.Kerkesat1.a.getBlerjeShitjeMonedhe(isFavouriteMode ? secondId : this.neBox.SelectedValue.ToString(), DateTime.Now.ToString("dd/MM/yyyy")).Copy();
            if (current.Rows.Count > 0)
            {
                if (float.TryParse(current.Rows[0].ItemArray[0].ToString(), out z))
                {
                    if (float.TryParse(current.Rows[0].ItemArray[1].ToString(), out z))
                    {
                        if (float.Parse(current.Rows[0].ItemArray[0].ToString()) > 0)
                        {
                            if (float.Parse(current.Rows[0].ItemArray[1].ToString()) > 0)
                            {
                                blerje2 = float.Parse(current.Rows[0].ItemArray[0].ToString());
                                shitje2 = float.Parse(current.Rows[0].ItemArray[1].ToString());
                                id_kursi2 = current.Rows[0].ItemArray[2].ToString();
                                llogaritKursin();
                                return true;
                            }
                            else
                            {
                                if (kasier)
                                {
                                    MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar sakte kursin e shitjes!");
                                    return false;
                                }
                                else
                                {
                                    DialogResult a;
                                    a = MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar sakte kursin e shitjes!\n\rDoni te konfiguroni kurset tani?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(loadExchangeRate));
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            if (kasier)
                            {
                                MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar sakte kursin e blerjes!");
                                return false;
                            }
                            else
                            {
                                DialogResult a;
                                a = MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar sakte kursin e blerjes!\n\rDoni te konfiguroni kurset tani?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(loadExchangeRate));
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (kasier)
                        {
                            MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar kursin e shitjes!");
                            return false;
                        }
                        else
                        {
                            DialogResult a;
                            a = MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar kursin e shitjes!\n\rDoni te konfiguroni kurset tani?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(loadExchangeRate));
                            return false;
                        }
                    }
                }
                else
                {
                    if (kasier)
                    {
                        MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar kursin e blerjes!");
                        return false;
                    }
                    else
                    {
                        DialogResult a;
                        a = MessageBox.Show("Monedha e zgjedhur nuk ka te percaktuar kursin e blerjes!\n\rDoni te konfiguroni kurset tani?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(loadExchangeRate));
                        return false;
                    }
                }
            }
            else
            {
                if (kasier)
                {
                    MessageBox.Show("Monedha e zgjedhur nuk ka kursin te percaktuar!");
                    return false;
                }
                else
                {
                    DialogResult a;
                    a = MessageBox.Show("Monedha e zgjedhur nuk ka kurs te percaktuar!\n\rDoni te konfiguroni kurset tani?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(loadExchangeRate));
                    return false;
                }
            }
        }//COMM

        private void activateShitje()
        {
            //funksioni qe aktivizon shitjen si veprim dhe mbush GridView me informacion per monedhat
            blerje_shitje = "Shitje";
            loadFirstGrid();
            loadSecondGrid();
        }//COMM

        public void loadFirstGrid()
        {
            //funksion qe mbush GridView e majte me monedhat ne dalje
                //mbushja behet nese kemi nje arke te zgjedhur
            if (this.arkaBox.SelectedIndex >= 0)
            {
                //variabli nuk lejon ekzekutimin e kodit te eventit pa mbaruar mbushja e GridView
                loadGridOk1 = false;
                DataTable prerjet = new DataTable();
                DataTable gjendja = new DataTable();
                if (isFavouriteMode)
                {
                    if (firstClicked)
                    {
                        //nese kemi te aktivizuar paraqitjen me butona dhe kemi te klikuar nje nga butonat
                            //mbushim DataTable me informacionin nga firstId
                        prerjet = Lidhja.Kerkesat1.a.selectPrerjet(firstId).Copy();
                        //llogarisim gjendjen per monedhen e pare
                        getGjendja(firstId);
                        //monedha ne dalje eshte monedha e pare me te cilen po veprohet
                        curr_out = firstId;
                    }
                }
                else
                {
                    if (this.ngaBox.SelectedIndex > -1)
                    {
                        //nese kemi te aktivizuar pamjen me dropdown dhe kemi te zgjedhur nje nga elementet
                            //kryejme te njejtat veprime por me indexin e zgjedhur
                        prerjet = Lidhja.Kerkesat1.a.selectPrerjet(this.ngaBox.SelectedValue.ToString()).Copy();
                        getGjendja(this.ngaBox.SelectedValue.ToString());
                    }
                }

                //pastrimi i GridView dhe konfigurimi i kolonave
                this.radGridView1.Rows.Clear();
                this.radGridView1.Columns.Clear();
                    //kolona qe mban emrin e monedhes
                emertimi1 = new DataGridViewTextBoxColumn();
                emertimi1.Visible = true;
                emertimi1.HeaderText = (isFavouriteMode ? firstName : this.ngaBox.Text);
                emertimi1.ReadOnly = true;
                    //kolona qe mban sasine per shitje
                number1 = new DataGridViewTextBoxColumn();
                number1.Visible = true;
                number1.HeaderText = "Sasia per Shitje";
                number1.ReadOnly = false;
                    //kolona qe mban gjendjen
                existing_number1 = new DataGridViewTextBoxColumn();
                existing_number1.Visible = true;
                existing_number1.HeaderText = "Sasia Aktuale";
                existing_number1.ReadOnly = true;
                    //kolona qe mban kusurin
                kusuri1 = new DataGridViewTextBoxColumn();
                kusuri1.Visible = true;
                kusuri1.HeaderText = "Kthim";
                kusuri1.ReadOnly = false;

                this.radGridView1.AutoGenerateColumns = false;

                this.radGridView1.Columns.Add(emertimi1);
                this.radGridView1.Columns.Add(number1);
                this.radGridView1.Columns.Add(existing_number1);
                this.radGridView1.Columns.Add(kusuri1);

                this.radGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //shtohen prerjet si rreshta te GridView
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
                                        this.radGridView1.Rows.Add(prerjet.Rows[0].ItemArray[i].ToString(), 0, 0, 0);
                                    }
                                }
                            }
                        }
                    }
                }
                //shtohet dhe rreshti i totalit ne fund
                this.radGridView1.Rows.Add("Totali", 0);
                this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].ReadOnly = true;
                //merret gjendja per cdo prerje me ane te funksionit
                fillGjendja();
                //lejohet te ekzekutohet kodi brenda eventit
                loadGridOk1 = true;
            }
        }//COMM

        public void loadSecondGrid()
        {
            //njelloj si funksioni loadFirstGrid por per GridView ne te djathte
            if (this.arkaBox.SelectedIndex >= 0)
            {
                loadGridOk2 = false;
                DataTable prerjet = new DataTable();
                DataTable gjendja = new DataTable();
                if (isFavouriteMode)
                {
                    if (secondClicked)
                    {
                        prerjet = Lidhja.Kerkesat1.a.selectPrerjet(secondId).Copy();
                        getGjendja(secondId);
                        curr_in = secondId;
                    }
                }
                else
                {
                    if (this.neBox.SelectedIndex > -1)
                    {
                        prerjet = Lidhja.Kerkesat1.a.selectPrerjet(this.neBox.SelectedValue.ToString()).Copy();
                        getGjendja(secondId);
                    }
                }

                this.radGridView2.Rows.Clear();
                this.radGridView2.Columns.Clear();

                emertimi2 = new DataGridViewTextBoxColumn();
                emertimi2.Visible = true;
                emertimi2.HeaderText = (isFavouriteMode ? secondName : this.neBox.Text);
                emertimi2.ReadOnly = true;

                number2 = new DataGridViewTextBoxColumn();
                number2.Visible = true;
                number2.HeaderText = "Sasia per Blerje";
                number2.ReadOnly = false;

                existing_number2 = new DataGridViewTextBoxColumn();
                existing_number2.Visible = true;
                existing_number2.HeaderText = "Sasia aktuale";
                existing_number2.ReadOnly = true;

                kusuri2 = new DataGridViewTextBoxColumn();
                kusuri2.Visible = true;
                kusuri2.HeaderText = "Kthim";
                kusuri2.ReadOnly = false;

                this.radGridView2.Columns.Add(emertimi2);
                this.radGridView2.Columns.Add(number2);
                this.radGridView2.Columns.Add(existing_number2);
                this.radGridView2.Columns.Add(kusuri2);

                this.radGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
                                        this.radGridView2.Rows.Add(prerjet.Rows[0].ItemArray[i].ToString(), 0, 0, 0);
                                    }
                                }
                            }
                        }
                    }
                }
                this.radGridView2.Rows.Add("Totali", 0);
                this.radGridView2.Rows[this.radGridView2.Rows.Count - 1].Cells[1].ReadOnly = true;
                fillGjendja2();
                loadGridOk2 = true;
            }
        }//COMM

        public void fillGjendja()
        {
            //funksioni qe merr gjendjen per cdo prerje te GridView ne te majte

            //per te mos lejuar ekzekutimin e kodit ne event te GridView ne te majte
            loadGridOk1 = false;
            DataTable gjendjet = new DataTable();
            if (isFavouriteMode)
            {
                if (firstClicked)
                {
                    //nese jemi ne paraqitjen me butona, marrim gjendjen nga variablat perkates dhe nga arka e zgjedhur
                    gjendjet = Lidhja.Kerkesat1.a.selectGjendjet(firstId, this.arkaBox.SelectedValue.ToString()).Copy();
                }
            }
            else
            {
                if (this.ngaBox.SelectedIndex > -1)
                {
                    //perndryshe nga dropdown dhe nga arka e zgjedhur
                    gjendjet = Lidhja.Kerkesat1.a.selectGjendjet(this.ngaBox.SelectedValue.ToString(), this.arkaBox.SelectedValue.ToString()).Copy();
                }
            }
            if (gjendjet.Rows.Count > 0)
            {
                for (int i = 3; i < gjendjet.Columns.Count; i++)
                {
                    if (i - 3 < this.radGridView1.Rows.Count - 1)
                    {
                        //shtojme gjendjet per cdo prerje te GridView ne te majte
                        this.radGridView1.Rows[i - 3].Cells[2].Value = gjendjet.Rows[0].ItemArray[i].ToString();
                    }
                }
            }
            else
            {
                //nese nuk kemi asnje rekord per gjendjet, atehere shtojme 0 per cdo prerje
                for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                {
                    this.radGridView1.Rows[i].Cells[2].Value = 0;
                }
            }
            //lejojme perseri ekzekutimin e kodit ne event
            loadGridOk1 = true;
        }//COMM

        public void fillGjendja2()
        {
            //e njeja si funksioni fillGjendja, por per GridView ne te djathte
            loadGridOk2 = false;
            DataTable gjendjet = new DataTable();
            if (isFavouriteMode)
            {
                if (secondClicked)
                {
                    //gjendjet = db.selectPrerjet(firstId).Copy();
                    //gjendjet = Lidhja.Kerkesat1.a.selectGjendjet(firstId, this.arkaBox.SelectedValue.ToString()).Copy();
                    gjendjet = Lidhja.Kerkesat1.a.selectGjendjet(secondId, this.arkaBox.SelectedValue.ToString()).Copy();
                }
            }
            else
            {
                if (this.neBox.SelectedIndex > -1)
                {
                    gjendjet = Lidhja.Kerkesat1.a.selectGjendjet(this.neBox.SelectedValue.ToString(), this.arkaBox.SelectedValue.ToString()).Copy();
                }
            }
            if (gjendjet.Rows.Count > 0)
            {
                for (int i = 3; i < gjendjet.Columns.Count; i++)
                {
                    if (i - 3 < this.radGridView2.Rows.Count - 1)
                    {
                        this.radGridView2.Rows[i - 3].Cells[2].Value = gjendjet.Rows[0].ItemArray[i].ToString();
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.radGridView2.Rows.Count; i++)
                {
                    this.radGridView2.Rows[i].Cells[2].Value = 0;
                }
            }
            loadGridOk2 = true;
        }//COMM

        public void getGjendja(string monedha_id)
        {
            //funksioni qe llogarit gjendjen totale te monedhes ne arken e zgjedhur
                //veprimet kryhen nese kemi nje arke te zgjedhur
            if (this.arkaBox.SelectedIndex >= 0)
            {
                //prerjet dhe gjendja e cdo prerje jane tabela te vecanta ne DB
                    //nje kolone e prerjes ka gjendje ne te njejten kolone te gjendjes + 1
                    //pra prerje[0] => gjendje[1]
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
                            //nese kemi nje prerje dhe gjendje te vlefshme, pra vlera numerike
                            if (float.TryParse(prerjet.Rows[0].ItemArray[i].ToString(), out z) && float.TryParse(gjendja.Rows[0].ItemArray[i + 1].ToString(), out z))
                            {
                                //inkrementojme shumen me prerjen * numrin e prerjeve te ketij tipi ne arke
                                sum += float.Parse(prerjet.Rows[0].ItemArray[i].ToString()) * float.Parse(gjendja.Rows[0].ItemArray[i + 1].ToString());
                            }
                        }
                    }
                    else
                    {
                        //nese nuk kemi rekord tek tabela Gjendja
                        MessageBox.Show("Nuk ka gjendje fillestare te konfiguruar \n\rper monedhen e zgjedhur ne arken e zgjedhur!");
                    }
                }
                else
                {
                    //nese nuk kemi asnje prerje te tabela Prerjet
                    MessageBox.Show("Nuk ka prerje te konfiguruara per monedhen e zgjedhur!");
                }
                this.gjendjaLbl.Text = sum.ToString("0.00");
            }
        }//COMM

        public void llogaritKursin()
        {
            //funksion qe llogarit kursin e shitjes dhe te blerjes midis dy monedhave te zgjedhura
                //ndahet ne dy pjese: rasti kur kemi paraqitjen me butona te nderfaqes dhe rastin kur kemi paraqitjen me DropDown
            if (!isFavouriteMode)
            {
                //ne rastin kur kemi paraqitje me DropDown, veprimet kryhen nese kemi te dy monedhat te zgjedhura
                    //pra indexet e zgjedhura te jene > -1
                if (this.ngaBox.SelectedIndex > -1 && this.neBox.SelectedIndex > -1)
                {
                    //ne variablet qe mbajne kursin vendosim llogaritjet
                    kursi1 = blerje1 / shitje2;
                    kursi2 = shitje1 / blerje2;
                    //as ja kom iden ca esht min denom
                    DataTable denoms = Lidhja.Kerkesat1.a.getMinDenomByCurrency(this.neBox.SelectedValue.ToString()).Copy();
                    if (denoms.Rows.Count > 0)
                    {
                        min_denom = float.Parse(denoms.Rows[0].ItemArray[0].ToString());
                    }
                    else
                    {
                        min_denom = 2;
                    }
                }
                else
                {
                    //nese nuk kemi te zgjedhur te pakten nje monedhe, kurset jane 0
                    kursi1 = 0;
                    kursi2 = 0;
                }
            }
            else
            {
                //ne rastin kur kemi paraqitje me butona, veprimet kryhen nese kemi nga nje buton te klikuar per cdo rresht
                //pra variablat qe behen TRUE ne klikim te butonave te jene TRUE
                if (this.firstClicked && this.secondClicked)
                {
                    //??????

                    //kursi1 = blerje1 / shitje2;
                    kursi1 = blerje1 / blerje2;
                    //kursi2 = shitje1 / blerje2;
                    kursi2 = shitje1 / shitje2;
                    DataTable denoms = Lidhja.Kerkesat1.a.getMinDenomByCurrency(this.secondId).Copy();
                    if (denoms.Rows.Count > 0)
                    {
                        min_denom = float.Parse(denoms.Rows[0].ItemArray[0].ToString());
                    }
                    else
                    {
                        min_denom = 2;
                    }
                }
                else
                {
                    //nese nuk kemi te zgjedhur te pakten nje monedhe, kurset jane 0
                    kursi1 = 0;
                    kursi2 = 0;
                }
            }

            //kalojme kursin ne Label qe te shfaqet
            this.blerjeLbl.Text = kursi1.ToString("0.0000");
            this.shitjeLbl.Text = kursi2.ToString("0.0000");
            //getKursi();
        }//COMM

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //ne zgjedhje te CheckBox qe aktivizon ose caktivizon kursin preferencial
                //therritet funksioni perkates ne varesi te gjendjes se CheckBox-it
                //ne fund llogaritet shuma me kursin qe u vendos ose me ate qe ishte i vendosur nga DB
            if (checkBox1.Checked)
            {
                enablePreferencial();
            }
            else
            {
                disablePreferencial();
            }
            llogaritShumen();
        }//COMM

        private void customRateTxt_TextChanged(object sender, EventArgs e)
        {
            //ne ndryshim te vleres se TextBox te kursit preferencial ri-llogarisim shumen
            if (this.customRateTxt.Text != "")
            {
                //nese kemi vendosur nje vlere, llogarisim shumen me funksionin e llogaritjes
                llogaritShumen();
            }
            else
            {
                //nese jo, shuma e llogaritur eshte 0
                this.totaliLbl.Text = "0";
            }
        }//COMM

        private void arkaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ne ndryshim te arkes se zgjedhur, nese kemi nje monedhe ne dalje, rivendosen prerjet dhe gjendjet
                //neper GridView
            if (curr_out != "")
            {
                loadFirstGrid();
                loadSecondGrid();
            }
        }//COMM

        private void radGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //ne ndryshim te vleres se qelizes ne GridView ne te djathte
            float z;
            //veprimet behen nese loadGridOk2 eshte TRUE pra nese GridView eshte krijuar dhe eshte mbushur
                //pra po editohet nga perdoruesi dhe jo nga kodi
            if (loadGridOk2)
            {
                //per te mos lejuar hyrjen perseri ne event ne rast ndryshimi vlere nga kodi per ndonje qelize
                loadGridOk2 = false;
                if (this.radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    //nese kemi vendosur nje vlere NULL ne qelizen e kusurit, kjo vlere behet 0 (qe te kthehet ne vlere numerike)
                    this.radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                }
                else
                {
                    if (this.radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                    {
                        //edhe nese vlera eshte "" (pra string bosh), qeliza merr vleren 0
                        this.radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    }
                    else
                    {
                        if (!float.TryParse(this.radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out z))
                        {
                            //nese nuk eshte vendosur nje vlere numerike e vlefshme me presje, qeliza merr vleren 0
                            this.radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                        }
                        else
                        {
                            if (this.radGridView2.Rows[e.RowIndex].Cells[2].Value == null)
                            {
                                //nese per kete monedhe nuk ka gjendje, pra gjendja eshte NULL dhe nuk kemi monedha te tilla ne arke, shfaqet MessageBox
                                MessageBox.Show("Nuk ka gjendje te konfiguruar per prerjen " + this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString() + "" + curr_in);
                            }
                            else
                            {
                                if (this.radGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                                {
                                    //edhe nese gjendja eshte "" nuk kemi gjendje
                                    MessageBox.Show("Nuk ka gjendje te konfiguruar per prerjen " + this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString() + "" + curr_in);
                                }
                                else
                                {
                                    if (!float.TryParse(this.radGridView2.Rows[e.RowIndex].Cells[2].Value.ToString(), out z))
                                    {
                                        //nese gjendja eshte vlere jo-numerike e inseruar gabimisht (gje qe nuk ndodh, por per siguri)
                                        MessageBox.Show("Nuk ka gjendje te konfiguruar per prerjen " + this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString() + "" + curr_in);
                                    }
                                    else
                                    {
                                        //nese gjendja ne arke eshte me e madhe se kusuri i vendosur nga perdoruesi, ose nese po editohet
                                            //qeliza ku vendoset vlera ne hyrje (qe nuk ka nevoje per kontroll)
                                        if (float.Parse(this.radGridView2.Rows[e.RowIndex].Cells[2].Value.ToString()) >=
                                            float.Parse(this.radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                                            || e.ColumnIndex == 1)
                                        {
                                            //vleren e kthejme ne INT (ne rast se eshte vendosur FLOAT, gje qe nuk ka kuptim)
                                            this.radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((int)(float.Parse(this.radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))).ToString();
                                            if (e.ColumnIndex == 1)
                                            {
                                                //nese po editojme kolonen e sasise ne hyrje, llogarisim kusurin ne dalje
                                                fillKusuri();
                                            }
                                            else
                                            {
                                                //ri-llogarisim totalin ne rastin kur po editohet kusuri
                                                llogaritShumenEGrides(ref radGridView2, 1, 3);
                                            }
                                            //llogaritShumenEGrides(ref this.radGridView2, 1, 3);
                                        }
                                        else
                                        {
                                            //nese kusuri eshte me i madh se sasia ne arke e kesaj prerje, shfaqet MessageBox
                                            MessageBox.Show("Keni kaluar sasine qe eshte aktualisht ne gjendje!");
                                            //sasia per kusur vendoset sa sasia qe gjendet ne arke per kete prerje
                                            this.radGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = float.Parse(this.radGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //ri-lejojme hyrjen ne event
                loadGridOk2 = true;
            }
        }//COMM

        public void llogaritShumenEGrides(ref DataGridView grid, int normInd, int kusurInd)
        {
            //funksion qe merr si reference nje nga GridView-t, bashke me index e sasive per hyrje dhe per dalje
            float s = 0;
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                s += float.Parse(grid.Rows[i].Cells[normInd].Value.ToString()) * float.Parse(grid.Rows[i].Cells[0].Value.ToString());
                s -= float.Parse(grid.Rows[i].Cells[kusurInd].Value.ToString()) * float.Parse(grid.Rows[i].Cells[0].Value.ToString());
            }
            //vendoset totali ne rreshtin e fundit te shtuar
            grid.Rows[grid.Rows.Count - 1].Cells[1].Value = s;
        }//COMM

        private void radGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //e njejta logjike si eventi CellValueChanged per GridView ne te djathte
            float z;
            if (loadGridOk1)
            {
                loadGridOk1 = false;
                //check for invalid values (null, "", characters string)
                if (this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                    {
                        if (float.TryParse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out z))
                        {
                            this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((int)(float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))).ToString();
                            if (this.radGridView1.Rows[e.RowIndex].Cells[2].Value != null)
                            {
                                if (this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() != "")
                                {
                                    if (float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) <= float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString())
                                        || e.ColumnIndex == 3)
                                    {
                                        //ne kete rast, kolona e hyrjes eshte ajo me index 3, ndersa kolona e daljes qe duhet validuar me gjendjen
                                            //ne arke eshte ajo me index 1
                                        llogaritShumenEGrides(ref this.radGridView1, 1, 3);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Keni kaluar sasine qe eshte aktualisht ne gjendje!");
                                        this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Nuk ka gjendje te konfiguruar per prerjen " + this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "" + curr_out);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nuk ka gjendje te konfiguruar per prerjen " + this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "" + curr_out);
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
                }
                else
                {
                    this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                }
                
                loadGridOk1 = true;
            }
        }//COMM

        private void allBtn_Click(object sender, EventArgs e)
        {
            //butoni qe aktivizon paraqitjen me DropDown te nderfaqes
            if (isFavouriteMode)
            {
                //nese ishim ne paraqitjen me butona, ri-startojme nderfaqen duke therritur funksionet e inicializimit
                    //variabli isFavouriteMode behet FALSE dhe ndikon ne funksionet qe do te thirren
                isShitje = true;
                isFavouriteMode = false;
                loadNgaNe();
                this.Width = this.initialWindowWidth;
                loadFirstGrid();
                loadSecondGrid();
                activateShitje();
                this.shitjeBlerjeLbl.Text = this.blerje_shitje;
                llogaritShumen();
            }
        }//COMM

        private void favouriteBtn_Click(object sender, EventArgs e)
        {
            //e njejta si allBtn_Click, ndryshon variabli
            if (!isFavouriteMode)
            {
                isShitje = true;
                isFavouriteMode = true;
                loadNgaNe();
                loadFirstGrid();
                loadSecondGrid();
                activateShitje();
                this.shitjeBlerjeLbl.Text = this.blerje_shitje;
                llogaritShumen();
            }
        }//COMM

        private void button1_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit qe ndryshon veprimin (Shitje/Blerje)
            if (((this.ngaBox.SelectedIndex > -1) && (this.neBox.SelectedIndex > -1) || (this.firstClicked && this.secondClicked)))
            {
                //nese kemi butona te zgjedhur, bejme ndryshimin e veprimit qe po kryhet
                swap();
            }
            if (isFavouriteMode)
            {
                //nese jemi ne paraqitjen me butona, ndryshojme butonat e zgjedhur
                swapButtons();
            }
            else
            {
                //perndryshe ndryshojme elementet e zgjedhur ne DropDown
                swapDropDowns();
            }
            //behen te gjitha llogarite dhe ne fund mbushen GridView-et per te dy monedhat
            llogaritKursin();
            llogaritShumen();
            loadFirstGrid();
            loadSecondGrid();
        }//COMM

        private void swap()
        {
            //funksioni qe aktivizon shitjen ose blerjen
            isShitje = !isShitje;
            if (isShitje)
            {
                //ne rast se eshte aktivizuar shitja, therritet funksioni perkates
                activateShitje();
            }
            else
            {
                //perndryshe therritet funksioni qe aktivizon blerjen
                activateBlerje();
            }
            //shfaqet lloji i veprimit ne Label
            this.shitjeBlerjeLbl.Text = blerje_shitje;
            //llogaritet shuma pas ndryshimeve te bera
            llogaritShumen();
        }//COMM

        private void activateBlerje()
        {
            //funksioni qe aktivizon blerjen vendos stringun "Blerje" per te bere llogarite me vone me kursin e duhur
                //ri-mbush dhe GridView-et 
            blerje_shitje = "Blerje";
            loadFirstGrid();
            loadSecondGrid();
        }//COMM

        private void swapButtons()
        {
            //funksion qe nderron butonat e zgjedhur
                //cngjyros te gjithe butonat fillimisht
            this.decolourFirst();
            this.decolourSecond();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                //kerkon ne gjithe kontrollet
                if (this.Controls[i].Tag != null)
                {
                    //gjen kontrollet qe kane "FirstButton" ose "SecondButton" ne Tag, per te identifikuar butonat
                    if (this.Controls[i].Tag.ToString() == "FirstButton")
                    {
                        if (this.Controls[i].Name == secondId)
                        {
                            //butonin e rreshtit te pare e ngjyros nese ai ka emrin sa ID e monedhes se dyte te zgjedhur
                            ((Button)this.Controls[i]).BackColor = Color.LightBlue;
                        }
                    }
                    else if (this.Controls[i].Tag.ToString() == "SecondButton")
                    {
                        if (this.Controls[i].Name == firstId)
                        {
                            //e njejta logjike per butonin e rreshtit te dyte
                            ((Button)this.Controls[i]).BackColor = Color.LightBlue;
                        }
                    }
                }
            }

            string tmp;

            //procesi i SWAP i emrave dhe ID-ve te butonave dhe ID-ve te perkoheshme ne rast ri-vendosje te butonave (kur nuk ka kurs psh.)
            tmp = firstId;
            firstId = secondId;
            secondId = tmp;

            tmp = firstName;
            firstName = secondName;
            secondName = tmp;

            tmp = oldId1;
            oldId1 = oldId2;
            oldId2 = tmp;

            tmp = oldName1;
            oldName1 = oldName2;
            oldName2 = tmp;
        }//COMM

        private void swapDropDowns()
        {
            //funksion qe ben nderrimin e index-eve te DropDown te monedhave
                //fillimisht nuk lejon hyrjen ne event te DropDown-eve deri ne fund te funksionit
            loadOk1 = false;
            loadOk2 = false;
            int tmp;
            //nderrohen indexet e DropDowneve (SWAP)
            tmp = this.ngaBox.SelectedIndex;
            this.ngaBox.SelectedIndex = this.neBox.SelectedIndex;
            this.neBox.SelectedIndex = tmp;
            //nderrohen dhe indexet e meparshme te DropDown-eve
            tmp = oldIndex1;
            oldIndex1 = oldIndex2;
            oldIndex2 = tmp;
            //ri-lejohet hyrja ne event
            loadOk1 = true;
            loadOk2 = true;
        }//COMM

        public void restartInterface()
        {
            //funksion qe ri-starton nderfaqen, vendos TextBox-et bosh dhe ri-mbush GridView me prerjet dhe gjendjet
            this.klientTxt.Text = "";
            this.sumTxt.Text = "";
            loadFirstGrid();
            loadSecondGrid();
        }//COMM

        //variabel qe tregon a ka konfirmuar perdoruesi vazhdimin e transaksionit ne MessageBox kur prerjet nuk jane vendosur sakte
            //variabli perdoret per te bere konfirmimin e transaksionit nese eshte konfirmuar ose per te nxjerre MessageBox
            //ne rastin kur perdoruesi nuk ka bere konfirmim, duke perdorur te njejtin event (klikim i butonit konfirmoBtn)
        bool userInput = false;
        private void konfirmoBtn_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit KONFIRMO (postim i transaksionit)
            //ne rast se perdoruesi eshte i vlefshem
            if (loggedUser != "0")
            {
                //variabli qe lejon ose nuk lejon avancimin tek kodi i postimit ne rast se dicka nuk eshte percaktuar sic duket
                bool okToGo = false;
                float z;
                //ky bllok ekzekutohet kur perdoruesi nuk ka konfiruar njehere postimin e fatures pavaresisht gabimeve
                if (!userInput)
                {
                    if (((ngaBox.SelectedIndex > -1 && neBox.SelectedIndex > -1) || (firstClicked && secondClicked)) && float.TryParse(this.sumTxt.Text, out z) && float.TryParse(this.totaliLbl.Text, out z) && (this.klientTxt.Text != "" || this.checkBox2.Checked) && this.arkaBox.SelectedIndex > -1)
                    {
                        //nese jane vendosur mire informacionet neper TextBox dhe nese jane zgjedhur monedhat
                        if (float.Parse(this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].Value.ToString()) <= float.Parse(gjendjaLbl.Text))
                        {
                            //nese totali ne dalje eshte me i vogel se gjendja totale ne arke
                            if (!isShitje)
                            {
                                //nese jemi ne shitje
                                if (float.Parse(this.radGridView2.Rows[this.radGridView2.Rows.Count - 1].Cells[1].Value.ToString()) == float.Parse(this.sumTxt.Text))
                                {
                                    //nese totali i prerjeve ne dalje (i vendosur nga perdoruesi) eshte i barabarte me shumen e llogaritur nga sistemi
                                    if (float.Parse(this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].Value.ToString()) == float.Parse(this.totaliLbl.Text))
                                    {
                                        //lejohet avancimi ne bllokun e postimit te kodit
                                        okToGo = true;
                                    }
                                    else
                                    {
                                        //nese nuk jane vendosur prerjet ne menyre te tille qe totali te jete i barabarte me shumen e llogaritur nga sistemi,
                                            //shfaqet MessageBox qe kerkon konfirmimin e perdoruesit ne rast se ai deshiron te vazhdoje postimin e transaksionit
                                            //nese perdoruesi konfirmon, sistemi ri-futet ne event, me variablin userInput me vleren TRUE qe nuk lejon ri-futjen
                                            //ne kete bllok, pra vazhdon postimin e fatures
                                        DialogResult a = new Gizmox.WebGUI.Forms.DialogResult();
                                        a = MessageBox.Show("Prerjet ne dalje nuk jane vendosur sakte!\n\rJeni te sigurt qe doni te vazhdoni kryerjen e transaksionit?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(ResultInput));
                                    }
                                }
                                else
                                {
                                    //ne rast se totali i prerjeve qe do te futen ne arke nuk eshte i barabarte me shumen e vendosur nga perdoruesi
                                        //nuk ekzekutohet blloku qe ben postimin e fatures, pasi variabli okToGo mbetet FALSE
                                    MessageBox.Show("Transaksioni nuk mund te kryhet!\n\rPrerjet ne hyrje nuk jane te vendosura sakte!");
                                }
                            }
                            else
                            {
                                //nese jemi ne blerje, qendron e njejta logjike
                                if (float.Parse(this.radGridView2.Rows[this.radGridView2.Rows.Count - 1].Cells[1].Value.ToString()) == float.Parse(this.totaliLbl.Text))
                                {
                                    if (float.Parse(this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].Value.ToString()) == float.Parse(this.sumTxt.Text))
                                    {
                                        okToGo = true;
                                    }
                                    else
                                    {
                                        DialogResult a = new Gizmox.WebGUI.Forms.DialogResult();
                                        a = MessageBox.Show("Prerjet ne dalje nuk jane vendosur sakte!\n\rJeni te sigurt qe doni te vazhdoni kryerjen e transaksionit?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(ResultInput));
                                    }
                                }
                                else
                                {
                                    DialogResult a = new Gizmox.WebGUI.Forms.DialogResult();
                                    a = MessageBox.Show("Prerjet ne hyrje nuk jane vendosur sakte!\n\rJeni te sigurt qe doni te vazhdoni kryerjen e transaksionit?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(ResultInput));
                                    //MessageBox.Show("Transaksioni nuk mund te kryhet!\n\rPrerjet ne hyrje nuk jane te vendosura sakte!");
                                }
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
                }
                else
                {
                    //ne rastin kur perdoruesi ka konfirmuar MessageBox qe shfaqet kur totali nuk eshte i barabarte me shumen
                        //ne kete menyre futemi menjehere ne kodin qe ben postimin
                    okToGo = true;
                }
                if (okToGo)
                {
                    string transaksion_id;

                    float z1;
                    //listat qe mbushen me rreshtat e GridView
                    List<string> prerjet1 = new List<string>();
                    List<string> sasia1 = new List<string>();
                    List<string> prerjet2 = new List<string>();
                    List<string> sasia2 = new List<string>();
                    for (int i = 0; i < this.radGridView1.Rows.Count - 1; i++)
                    {
                        if (float.TryParse(this.radGridView1.Rows[i].Cells[1].Value.ToString(), out z1))
                        {
                            if (float.Parse(this.radGridView1.Rows[i].Cells[1].Value.ToString()) > 0)
                            {
                                //nese prerja ka sasi me te madhe se 0, shtohet ne List dhe printohet ne formen e printimit
                                    //ne kete menyre nxirren vetem prerjet qe kane sasi ne dalje / hyrje
                                prerjet1.Add(this.radGridView1.Rows[i].Cells[0].Value.ToString());
                                sasia1.Add(this.radGridView1.Rows[i].Cells[1].Value.ToString());
                            }
                        }
                    }

                    for (int i = 0; i < this.radGridView2.Rows.Count - 1; i++)
                    {
                        if (float.TryParse(this.radGridView2.Rows[i].Cells[1].Value.ToString(), out z1))
                        {
                            if (float.Parse(this.radGridView2.Rows[i].Cells[1].Value.ToString()) > 0)
                            {
                                //e njejta gje dhe per GridView tjeter
                                prerjet2.Add(this.radGridView2.Rows[i].Cells[0].Value.ToString());
                                sasia2.Add(this.radGridView2.Rows[i].Cells[1].Value.ToString());
                            }
                        }
                    }

                    //shfaqet forma e printimit te fatures dhe te gjithe informacionet kalohen si parametra
                        //Listat qe mbajne prerjet kalohen si ARRAY
                    PrintForm pf = new PrintForm(DateTime.Now.Date.ToString("dd/MM/yyyy"), DateTime.Now.TimeOfDay.ToString(), (isShitje ? (isFavouriteMode ? firstName : this.ngaBox.Text) : (isFavouriteMode ? secondName : this.neBox.Text)),
                        (isShitje ? shitje1.ToString() : blerje1.ToString()), (isShitje ? (isFavouriteMode ? secondName : this.neBox.Text) : (isFavouriteMode ? firstName : this.ngaBox.Text)), (isShitje ? shitje2.ToString() : blerje2.ToString()),
                        curr_trans.ToString(), this.sumTxt.Text, this.totaliLbl.Text, this.klientTxt.Text, this.arkaBox.Text, prerjet1.ToArray<string>(), sasia1.ToArray<string>(), prerjet2.ToArray<string>(), sasia2.ToArray<string>());
                    pf.ShowDialog();

                    //pasi inserojme transaksionin marrim ID e transaksionit te sapo inseruar
                    DataTable curr_trans_id = Lidhja.Kerkesat1.a.insertTransaction(loggedUser, DateTime.Now.Date, DateTime.Parse(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString()), (isFavouriteMode ? firstName : ngaBox.Text), this.sumTxt.Text, (isFavouriteMode ? secondName : this.neBox.Text), this.totaliLbl.Text, arkaBox.SelectedValue.ToString(), blerje_shitje, (this.checkBox2.Checked ? "Klient i Panjohur" : this.klientTxt.Text), curr_trans.ToString(), "1").Copy();
                    if (curr_trans_id.Rows.Count > 0)
                    {
                        transaksion_id = curr_trans_id.Rows[0].ItemArray[0].ToString();
                    }
                    else
                    {
                        transaksion_id = "";
                    }
                    //bejme shtimin dhe heqjen e prerjeve me procedurat perkatese, duke kaluar dhe ID e transaksionit si parameter
                        //funksionet removePrerjet dhe addPrerjet bejne rivendosjen e prerjeve
                    removePrerjet(curr_out, transaksion_id);
                    addPrerjet(curr_in, transaksion_id);
                    //vendosen kurset si te perdorura ne DB, pra keto kurse jane perdorur per nje ose disa transaksione
                    Lidhja.Kerkesat1.a.perdorKursin(this.id_kursi1);
                    Lidhja.Kerkesat1.a.perdorKursin(this.id_kursi2);
                    MessageBox.Show("Transaksioni u ruajt me sukses!");
                    //re-inicializojme nderfaqen
                    restartInterface();
                }
            }
            else
            {
                //nese lloji i perdoruesit te loguar eshte SYSTEM ADMIN, nuk lejohet kryerja e transaksionit
                MessageBox.Show("Administratori i sistemit nuk mund te inseroje transaksione!");
            }
        }//COMM

        public void ResultInput(Object sender, EventArgs e)
        {
            //funksioni qe therritet ne rast konfirmimi nga perdoruesi kur shfaqet MessageBox qe njofton se 
                //shuma dhe totali ndryshojne
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                //ndryshon variabli userInput per te mos lejuar validimin ne funksion te klikimit
                userInput = true;
                //ri-klikohet butoni
                konfirmoBtn.PerformClick();
                userInput = false;
            }
        }//COMM

        public void removePrerjet(string monedha_id, string transaksion_id)
        {
            //funksioni qe heq prerjet ne DB per monedhen e kaluar si parameter ne fund te postimit te transaksionit
                //krijohet scripti ne kod
            string strBuild = "";
            strBuild += "update gjendja set ";
            for (int i = 0; i < this.radGridView1.Rows.Count - 1; i++)
            {
                //cdo kolone e ka emrin Sasia1, Sasia2, Sasia3 etj.
                    //inkrementojme ose dekrementojme sasine neper kolona me vlerat qe ndodhen ne GridView
                    //formati i stringut te meposhtem eshte: set Sasia1 = Sasia1 - x, Sasia2 = Sasia2 - x, etj.
                strBuild += "Sasia" + (i + 1).ToString() + " = " + "Sasia" + (i + 1).ToString() + " - " + this.radGridView1.Rows[i].Cells[1].Value.ToString() + " + " + this.radGridView1.Rows[i].Cells[3].Value.ToString() + ", ";
            }
            //per te hequr presjen e tepert ne fund te stringut qe shtohet automatikisht
            strBuild = strBuild.Substring(0, strBuild.Length - 2);
            //UPDATE behet sipas kushtit, kur arka dhe monedha jane ato te zgjedhurat nga perdoruesi
            strBuild += " where id_ark = " + this.arkaBox.SelectedValue.ToString() + " and id_curr = " + monedha_id;
            //ekzekutohet scripti ne SQL
            Lidhja.Kerkesat1.a.excecuteInsertScript(strBuild);

            //vendosen prerjet ne tabelen PrerjeHyrjeDalje ne DB
            for (int i = 0; i < this.radGridView1.Rows.Count - 1; i++)
            {
                if (this.radGridView1.Rows[i].Cells[1].Value != null)
                {
                    if (this.radGridView1.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        if (float.Parse(this.radGridView1.Rows[i].Cells[1].Value.ToString()) > 0)
                        {
                            
                            Lidhja.Kerkesat1.a.insertLevizje(monedha_id, this.arkaBox.SelectedValue.ToString(), (i + 1).ToString(),
                                this.radGridView1.Rows[i].Cells[1].Value.ToString(), transaksion_id, "0");
                        }
                    }
                }
            }

            for (int i = 0; i < this.radGridView1.Rows.Count - 1; i++)
            {
                if (this.radGridView1.Rows[i].Cells[3].Value != null)
                {
                    if (this.radGridView1.Rows[i].Cells[3].Value.ToString() != "")
                    {
                        if (float.Parse(this.radGridView1.Rows[i].Cells[3].Value.ToString()) > 0)
                        {
                            Lidhja.Kerkesat1.a.insertLevizje(monedha_id, this.arkaBox.SelectedValue.ToString(), (i + 1).ToString(),
                                this.radGridView1.Rows[i].Cells[3].Value.ToString(), transaksion_id, "1");
                        }
                    }
                }
            }
        }//COMM

        public void addPrerjet(string monedha_id, string transaksion_id)
        {
            //funksioni qe shton prerjet ne DB per monedhen e kaluar si parameter ne fund te postimit te transaksionit
                //krijohet scripti ne kod

            //logjika e krijimit te scriptit eshte e njejte me ate te funksionit removePrerjet
            string strBuild = "";
            strBuild += "update gjendja set ";
            for (int i = 0; i < this.radGridView2.Rows.Count - 1; i++)
            {
                strBuild += "Sasia" + (i + 1).ToString() + " = " + "Sasia" + (i + 1).ToString() + " + " + this.radGridView2.Rows[i].Cells[1].Value.ToString() + " - " + this.radGridView2.Rows[i].Cells[3].Value.ToString() + ", ";
            }
            strBuild = strBuild.Substring(0, strBuild.Length - 2);
            strBuild += " where id_ark = " + this.arkaBox.SelectedValue.ToString() + " and id_curr = " + monedha_id;
            Lidhja.Kerkesat1.a.excecuteInsertScript(strBuild);

            for (int i = 0; i < this.radGridView2.Rows.Count - 1; i++)
            {
                if (this.radGridView2.Rows[i].Cells[1].Value != null)
                {
                    if (this.radGridView2.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        if (float.Parse(this.radGridView2.Rows[i].Cells[1].Value.ToString()) > 0)
                        {
                            Lidhja.Kerkesat1.a.insertLevizje(monedha_id, this.arkaBox.SelectedValue.ToString(), (i + 1).ToString(),
                                this.radGridView2.Rows[i].Cells[1].Value.ToString(), transaksion_id, "1");
                        }
                    }
                }
            }

            for (int i = 0; i < this.radGridView2.Rows.Count - 1; i++)
            {
                if (this.radGridView2.Rows[i].Cells[3].Value != null)
                {
                    if (this.radGridView2.Rows[i].Cells[3].Value.ToString() != "")
                    {
                        if (float.Parse(this.radGridView2.Rows[i].Cells[3].Value.ToString()) > 0)
                        {
                            Lidhja.Kerkesat1.a.insertLevizje(monedha_id, this.arkaBox.SelectedValue.ToString(), (i + 1).ToString(),
                                this.radGridView2.Rows[i].Cells[3].Value.ToString(), transaksion_id, "0");
                        }
                    }
                }
            }
        }//COMM

        private void sumTxt_TextChanged(object sender, EventArgs e)
        {
            //ne ndryshim shumes, ri-llogaritet rezultati
            if (this.sumTxtEventOk)
            {
                llogaritShumen();
            }
        }//COMM

        private void neBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //ne ndryshim te vleres se zgjedhur per ComboBox e dyte
            if (loadOk2)
            {
                //nese ComboBox eshte krijuar
                if (getBlerjeShitje2())
                {
                    //dhe nese ka kurs blerje & shitje, qe tregohet nga funksioni getBlerjeShitje2()
                        //ri-llogarisim shumen dhe lejojme ndryshimin e monedhes se zgjedhur
                        //monedhen e re te zgjedhur e ruajme ne nje variabel per me vone, kur te na duhet te rikthejme monedhen
                        //e fundit te zgjedhur
                    llogaritShumen();
                    oldIndex2 = neBox.SelectedIndex;
                    this.totalCurrencyLbl.Text = neBox.Text;
                }
                else
                {
                    //ne rastin kur monedha qe sapo zgjodhem nuk ka kurs blerje & shitje, rizgjedhim monedhen e fundit te vlefshme
                        //pra ate te ruajturen ne variablat e perkohshem (index i fundit i zgjedhur => oldIndex2)
                    loadOk2 = false;
                    neBox.SelectedIndex = oldIndex2;
                    loadOk2 = true;
                }
                //rimbushim GridView me prerjet dhe gjendjet
                loadFirstGrid();
                loadSecondGrid();
            }
        }//COMM

        private void ngaBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //e njejta logjike me neBox_SelectedValueChanged, per monedhen e pare
            if (loadOk1)
            {
                if (getBlerjeShitje1())
                {
                    oldIndex1 = ngaBox.SelectedIndex;
                    llogaritShumen();
                    this.sumCurrencyLbl.Text = ngaBox.Text;
                }
                else
                {
                    loadOk1 = false;
                    ngaBox.SelectedIndex = oldIndex1;
                    loadOk1 = true;
                }
                loadFirstGrid();
                loadSecondGrid();
            }
        }//COMM

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //nese vendosim nje klient anonim dhe nuk duam te perdorim emrin e klientit per faturen
            if (((CheckBox)(sender)).Checked)
            {
                //thjesht aktivizojme TextBox me emrin e klientit
                this.klientTxt.Enabled = false;
            }
            else
            {
                //ose e riaktivizojme ate
                this.klientTxt.Enabled = true;
            }
        }//COMM

        private void totaliLbl_TextChanged(object sender, EventArgs e)
        {
            //ne ndryshim te totalit, duhet llogaritur shuma (pra veprimi i kundert i atij qe behet normalisht)
            if (this.totaliLblEventOk)
            {
                llogaritShumenReverse();
            }
        }//COMM

        private void Cashier_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ne mbyllje te formes, nese kemi fature te pa-postuar, shfaqim nje MessageBox ku perdoruesi duhet te konfirmoje mbylljen 
                //me fature te pa-postuar
            if (!okToClose)
            {
                e.Cancel = true;
                DialogResult dr;
                dr = MessageBox.Show("Jeni te sigurt qe doni te mbyllni dritaren?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(closeOk));
            }
        }//COMM

        private void closeOk(object sender, EventArgs e)
        {
            //nese konfirmohet mbyllja e formes pa postuar faturen, ri-mbyllet forma por kesaj rradhe variabli okToClose
                //merr vlere qe mos te lejoje ri-ekzekutimin e bllokut ne event te mbylljes
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                okToClose = true;
                this.Close();
                okToClose = false;
            }
            else
            {
                //nese nuk eshte konfirmuar, nuk ndodh gje, pra heren tjeter qe perdoruesi do te mbylle formen pa ruajtur faturen
                    //do te rishfaqet MessageBox per konfirmimin e mbylljes
                okToClose = false;
            }
        }//COMM

        private void fillAutoDalje()
        {
            foreach (DataGridViewRow r in this.radGridView1.Rows)
            {
                if (r.Index != this.radGridView1.Rows.Count - 1)
                {
                    r.Cells[1].Value = 0;
                    r.Cells[3].Value = 0;
                }
            }
            List<string[]> s = new List<string[]>();
            for (int i = 0; i < this.radGridView1.Rows.Count - 1; i++)
            {
                s.Add(new string[] 
                {
                    this.radGridView1.Rows[i].Cells[0].Value.ToString(),
                    this.radGridView1.Rows[i].Cells[1].Value.ToString(),
                    this.radGridView1.Rows[i].Cells[2].Value.ToString()
                });
            }

            float curr_sum = 0;

            while (curr_sum < float.Parse(isShitje ? sumTxt.Text : totaliLbl.Text))
            {
                s = s.Where(s_curr => float.Parse(s_curr[0]) + curr_sum <= float.Parse(isShitje ? sumTxt.Text : totaliLbl.Text))
                      .Where(s_curr => float.Parse(s_curr[1]) < float.Parse(s_curr[2]) / 2)
                      .OrderByDescending(s_curr => float.Parse(s_curr[0])).ToList<string[]>();

                if (s.Count == 0)
                {
                    break;
                }

                curr_sum += float.Parse(s[0][0]);
                s[0][1] = (float.Parse(s[0][1]) + 1).ToString();

                foreach (DataGridViewRow r in this.radGridView1.Rows)
                {
                    if (r.Cells[0].Value.ToString() == s[0][0])
                    {
                        r.Cells[1].Value = float.Parse(s[0][1]);
                        break;
                    }
                }
            }

            s.Clear();
            for (int i = 0; i < this.radGridView1.Rows.Count - 1; i++)
            {
                s.Add(new string[] 
                {
                    this.radGridView1.Rows[i].Cells[0].Value.ToString(),
                    this.radGridView1.Rows[i].Cells[1].Value.ToString(),
                    this.radGridView1.Rows[i].Cells[2].Value.ToString()
                });
            }


            while (curr_sum < float.Parse(isShitje ? sumTxt.Text : totaliLbl.Text))
            {
                s = s.Where(s_curr => float.Parse(s_curr[0]) + curr_sum <= float.Parse(isShitje ? sumTxt.Text : totaliLbl.Text))
                      .Where(s_curr => float.Parse(s_curr[1]) <= float.Parse(s_curr[2]) - 1)
                      .OrderByDescending(s_curr => float.Parse(s_curr[0])).ToList<string[]>();

                if (s.Count == 0)
                {
                    break;
                }

                curr_sum += float.Parse(s[0][0]);
                s[0][1] = (float.Parse(s[0][1]) + 1).ToString();

                foreach (DataGridViewRow r in this.radGridView1.Rows)
                {
                    if (r.Cells[0].Value.ToString() == s[0][0])
                    {
                        r.Cells[1].Value = float.Parse(s[0][1]);
                        break;
                    }
                }
            }
        }

        private void fillKusuri()
        {
            foreach (DataGridViewRow r in this.radGridView2.Rows)
            {
                if (r.Index != this.radGridView2.Rows.Count - 1)
                {
                    r.Cells[3].Value = 0;
                }
            }
            llogaritShumenEGrides(ref radGridView2, 1, 3);
            float big_diff = float.Parse(this.radGridView2.Rows[this.radGridView2.RowCount - 1].Cells[1].Value.ToString()) - float.Parse(isShitje ? this.totaliLbl.Text : this.sumTxt.Text);
            List<string[]> s = new List<string[]>();
            for (int i = 0; i < this.radGridView2.Rows.Count - 1; i++)
            {
                s.Add(new string[] 
                {
                    this.radGridView2.Rows[i].Cells[0].Value.ToString(),
                    this.radGridView2.Rows[i].Cells[3].Value.ToString(),
                    this.radGridView2.Rows[i].Cells[2].Value.ToString()
                });
            }

            float curr_sum = 0;

            while (curr_sum < big_diff)
            {
                s = s.Where(s_curr => float.Parse(s_curr[0]) + curr_sum <= big_diff)
                      .Where(s_curr => float.Parse(s_curr[1]) < float.Parse(s_curr[2]) / 2)
                      .OrderByDescending(s_curr => float.Parse(s_curr[0])).ToList<string[]>();

                if (s.Count == 0)
                {
                    break;
                }

                curr_sum += float.Parse(s[0][0]);
                s[0][1] = (float.Parse(s[0][1]) + 1).ToString();

                foreach (DataGridViewRow r in this.radGridView2.Rows)
                {
                    if (r.Cells[0].Value.ToString() == s[0][0])
                    {
                        r.Cells[3].Value = float.Parse(s[0][1]);
                        break;
                    }
                }
            }

            s.Clear();
            for (int i = 0; i < this.radGridView2.Rows.Count - 1; i++)
            {
                s.Add(new string[] 
                {
                    this.radGridView2.Rows[i].Cells[0].Value.ToString(),
                    this.radGridView2.Rows[i].Cells[3].Value.ToString(),
                    this.radGridView2.Rows[i].Cells[2].Value.ToString()
                });
            }


            while (curr_sum < big_diff)
            {
                s = s.Where(s_curr => float.Parse(s_curr[0]) + curr_sum <= big_diff)
                      .Where(s_curr => float.Parse(s_curr[1]) <= float.Parse(s_curr[2]) - 1)
                      .OrderByDescending(s_curr => float.Parse(s_curr[0])).ToList<string[]>();

                if (s.Count == 0)
                {
                    break;
                }

                curr_sum += float.Parse(s[0][0]);
                s[0][1] = (float.Parse(s[0][1]) + 1).ToString();

                foreach (DataGridViewRow r in this.radGridView2.Rows)
                {
                    if (r.Cells[0].Value.ToString() == s[0][0])
                    {
                        r.Cells[3].Value = float.Parse(s[0][1]);
                        break;
                    }
                }
            }
            llogaritShumenEGrides(ref radGridView2, 1, 3);
        }
    }
}