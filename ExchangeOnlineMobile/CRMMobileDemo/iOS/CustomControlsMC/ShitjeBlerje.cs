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
    public partial class ShitjeBlerje : TranslatePanel
    {
        //variabel qe tregon se kursi eshte duke u inseruar, pra nuk ekziston nje rekord ne DB per kursin e monedhes se zgjedhur
            //TRUE  => nuk ka rekord, do ekzekutohet nje procedure INSERT
            //FALSE => ka rekord, do ekzekutohet nje procedure UPDATE
        bool inserting = false;

        //variabel qe tregon a eshte perdoruesi duke edituar kursin apo jo
        bool editing = false;

        //id e monedhes se zgjedhur
        public string monedha = "";

        //id e rekordit te kursit te monedhes se zgjedhur
        string rate_id = "";

        public ShitjeBlerje()
        {
            InitializeComponent();
        }

        public void initializeUI()
        {
            //funksion qe inicializon nderafqen
            this.msgLabel.Text = "";
            this.editing = false;
            this.shitjeTxt.ReadOnly = true;
            this.blerjeTxt.ReadOnly = true;
            this.ndryshoBtn.Enabled = true;
        }//COMM

        private void button1_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit qe inicializon nderfaqen per ndryshimin e kursit
            if (editing)
            {
                //nese jemi ne editim, nderfaqa kthehet ne gjendjen normale
                editing = false;
                setInformation(this.monedha);
                initializeUI();
                ((iosForm)((Panel)this.Parent).Parent).resetUIAfterEditRate();
                this.ndryshoBtn.Text = "Ndrysho";
            }
            else
            {
                //nese nuk jemi ne editim, nderfaqa behet gati per editim
                editing = true;
                this.shitjeTxt.ReadOnly = false;
                this.blerjeTxt.ReadOnly = false;
                this.ndryshoBtn.Enabled = true;
                this.ndryshoBtn.Text = "Anulo";
                ((iosForm)((Panel)this.Parent).Parent).setUIToEditRate();
            }
        }//COMM

        public void setInformation(string monedha_id)
        {
            //funksion qe merr kurset e monedhes se zgjedhur dhe i paraqet si informacion duke i shperndare ne TextBox-et perkatese
                //si parameter merret ID e monedhes
            this.monedha = monedha_id;
            //merret emertimi dhe shfaqet ne nderfaqe
            this.monedhaLbl.Text = Lidhja.Kerkesat1.a.excecuteScript("select monedha from monedhat where id = " + monedha_id).Copy().Rows[0].ItemArray[0].ToString();

            //hidhet informacioni i kurseve ne DataTable
            DataTable curr_info = Lidhja.Kerkesat1.a.getBlerjeShitjeMonedheWithId(monedha_id, DateTime.Now.ToString("dd/MM/yyyy")).Copy();

            if (curr_info.Rows.Count > 0)
            {
                //nese kemi rekord, pra nese ekziston kursi, shperndajme informacionin ne TextBox

                //meqenese kemi rekord, do te kryejme UPDATE, variabli behet FALSE
                inserting = false;

                //ID e rekordit ruhet ne variabel per ta kaluar si parameter per UPDATE
                this.rate_id = curr_info.Rows[0].ItemArray[2].ToString();

                float z;
                if (float.TryParse(curr_info.Rows[0].ItemArray[0].ToString(), out z))
                {
                    //nese kursi eshte i vlefshem, e shfaqim ne TextBox
                    this.blerjeTxt.Text = curr_info.Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    //perndryshe e lejme bosh
                    this.blerjeTxt.Text = "";
                }
                if (float.TryParse(curr_info.Rows[0].ItemArray[1].ToString(), out z))
                {
                    //nese kursi eshte i vlefshem, e shfaqim ne TextBox
                    this.shitjeTxt.Text = curr_info.Rows[0].ItemArray[1].ToString();
                }
                else
                {
                    //perndryshe e lejme bosh
                    this.shitjeTxt.Text = "";
                }
            }
            else
            {
                //nese nuk kemi rekord, variabli behet TRUE, gje qe lejon ekzekutimin e INSERT-it ne ruajtje
                inserting = true;
                //TextBox-et jane "" meqenese nuk kemi nje kurs te percaktuar
                this.blerjeTxt.Text = "";
                this.shitjeTxt.Text = "";
            }
            //ri-inicializojme nderfaqen
            initializeUI();
        }//COMM

        public void saveRates()
        {
            //funksioni qe ruan kursin e ri te shitjes dhe blerjes per monedhen e zgjedhur
                //veprimet behen nese kemi vlera te sakta te shitjes dhe blerjes
                //perndryshe shfaqen mesazhet e gabimit
            float z;
            if (float.TryParse(this.shitjeTxt.Text, out z) || float.TryParse(this.blerjeTxt.Text, out z))
            {
                if (float.TryParse(this.shitjeTxt.Text, out z))
                {
                    if (float.TryParse(this.blerjeTxt.Text, out z))
                    {
                        if ((float.Parse(this.shitjeTxt.Text) >= 0) || float.Parse(this.blerjeTxt.Text) >= 0)
                        {
                            if (float.Parse(this.shitjeTxt.Text) >= 0)
                            {
                                if (float.Parse(this.blerjeTxt.Text) >= 0)
                                {
                                    //nese kurset jane vlera numerike te vlefshme (me te medha se 0)
                                    if (inserting)
                                    {
                                        //nese nuk kishim rekord, bejme INSERT-in e kurseve
                                        Lidhja.Kerkesat1.a.insertArka(this.monedha, this.shitjeTxt.Text, this.blerjeTxt.Text, DateTime.Now.ToString("dd/MM/yyyy"));
                                        //ri-merret kursi
                                        this.setInformation(this.monedha);
                                        //ri-inicializohen variablat dhe elementet e nderfaqes
                                        editing = false;
                                        initializeUI();
                                        ((iosForm)((Panel)this.Parent).Parent).resetUIAfterEditRate();
                                        this.ndryshoBtn.Text = "Ndrysho";
                                        //shfaqet mesazhi i suksesit
                                        this.msgLabel.Text = "Kursi u ruajt me sukses!";
                                    }
                                    else
                                    {
                                        //nese kishim rekord, bejme UPDATE te rekordit te kurseve
                                        Lidhja.Kerkesat1.a.updateArka(this.rate_id, this.shitjeTxt.Text, this.blerjeTxt.Text, DateTime.Now.ToString("dd/MM/yyyy"));
                                        //ri-merret kursi
                                        this.setInformation(this.monedha);
                                        //ri-inicializohen variablat dhe elementet e nderfaqes
                                        editing = false;
                                        initializeUI();
                                        ((iosForm)((Panel)this.Parent).Parent).resetUIAfterEditRate();
                                        this.ndryshoBtn.Text = "Ndrysho";
                                        //shfaqet mesazhi i suksesit
                                        this.msgLabel.Text = "Kursi u ruajt me sukses!";
                                    }
                                }
                                else
                                {
                                    this.msgLabel.Text = "Vlera e blerjes jo e sakte!";
                                }
                            }
                            else
                            {
                                this.msgLabel.Text = "Vlera e shitjes jo e sakte!";
                            }
                        }
                        else
                        {
                            this.msgLabel.Text = "Vlerat jo te sakta!";
                        }
                    }
                    else
                    {
                        this.msgLabel.Text = "Vlera e blerjes jo e sakte!";
                    }
                }
                else
                {
                    this.msgLabel.Text = "Vlera e shitjes jo e sakte!";
                }
            }
            else
            {
                this.msgLabel.Text = "Vlerat jo te sakta!";
            }
        }//COMM

        private void shitjeTxt_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}