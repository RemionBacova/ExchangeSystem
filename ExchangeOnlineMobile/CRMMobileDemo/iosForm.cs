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
using CRMMobileDemo.iOS;
using CRMMobileDemo.Common;
using CRMMobileDemo.iOS.CustomControlsMC;
using CustomCRMControls;

#endregion

namespace CRMMobileDemo
{
    public partial class iosForm : Form
    {

        #region elements
        Login log = new Login();
        MainMenuPanel menuPanel = new MainMenuPanel();
        Kurset kurs = new Kurset();
        ShitjeBlerje sb = new ShitjeBlerje();
        Import imp = new Import();
        Arkat ark = new Arkat();
        MonedhatGjendje mgj = new MonedhatGjendje();
        TransaksionGjendje tgj = new TransaksionGjendje();
        
        public string userId = "";

        #endregion

        #region programState
        public int programState;
        //
        //programState per Exhcange

        //1 = Login
        //2 = Main Menu
        //3 = Kurset
        //4 = Shitje & Blerje
        //5 = Import
        //6 = Arkat
        //7 = Monedhat Gjendje
        //8 = Transaksione Gjendje


        //100 = Editing Rate

        #endregion

        public ScreenManager a;
        public NavigationStrip nav;
        public iosForm()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;
            this.NavigationPanel.Width = this.Width;
            this.NavigationPanel.Top = 0;
            this.NavigationPanel.Left = 0;
            this.MainPanel.Top = this.NavigationPanel.Height;
            this.MainPanel.Height = this.Height - this.NavigationPanel.Height - this.ButtonPanel.Height;
            this.ButtonPanel.Top = this.NavigationPanel.Height + this.MainPanel.Height;

            //te gjithe user-controls qe trashegojne nga TranslatePanel shtohen tek ScreenManager
            a = new ScreenManager(new TranslatePanel[] { log, menuPanel, kurs, sb, imp, ark, mgj, tgj});

            //keto user-controls shtohen tek nderfaqja
            this.MainPanel.Controls.Add(log);
            this.MainPanel.Controls.Add(menuPanel);
            this.MainPanel.Controls.Add(kurs);
            this.MainPanel.Controls.Add(sb);
            this.MainPanel.Controls.Add(imp);
            this.MainPanel.Controls.Add(ark);
            this.MainPanel.Controls.Add(mgj);
            this.MainPanel.Controls.Add(tgj);

            //te gjithe nderfaqet behen invisible, pervec asaj te log-in
            for (int i = 0; i < MainPanel.Controls.Count; i++)
            {
                MainPanel.Controls[i].Visible = false;
            }
            log.Visible = true;

            nav = new NavigationStrip() { Dock = DockStyle.Fill, RightButtonVisibility = false, LeftButtonVisibility = false, Text = "" };
            //naviation strip ne pjesen e siperme
            this.NavigationPanel.Controls.Add(nav);

            this.nav.LeftButtonClick += new EventHandler(nav_LeftButtonClick);
            this.nav.RightButtonClick += new EventHandler(nav_RightButtonClick);

            //fillimisht kalojme tek forma e login
            a.ShiftTo(log);

            this.nav.Text = "MyExchange";
            this.postBtn.Visible = true;
            this.postBtn.Text = "Hyrje";
            this.nav.LeftButtonVisibility = false;
            this.nav.RightButtonVisibility = false;
            programState = 1;
        }

        #region eventHandler_assignment

        void nav_RightButtonClick(object sender, EventArgs e)
        {
            //ne klikim te butonit te djathte, ne varesi te nderfaqes ne te cilen ndodhemi (pra ne varesi te variablit programState)
                //kryejme funksione te ndryshme. Nese butoni eshte i padukshem ne nje moment te caktuar, ai nuk do te kryeje
                //asnje funksion
            switch (programState)
            {
                case 1:
                    {
                        //button is invisible
                        break;
                    }
                case 2:
                    {
                        //button is invisible
                        break;
                    }
                case 3:
                    {
                        //import
                        goToImport();
                        break;
                    }
                case 4:
                    {
                        //button is invisible
                        break;
                    }
                case 5:
                    {
                        //button is invisible
                        break;
                    }
                case 6:
                    {
                        //button is invisible
                        break;
                    }
                case 7:
                    {
                        //button is invisible
                        break;
                    }
                case 8:
                    {
                        //button is invisible
                        break;
                    }
                default:
                    {
                        //button is invisible
                        break;
                    }
            }
        }

        void nav_LeftButtonClick(object sender, EventArgs e)
        {
            //ne klikim te butonit te majte (back), ne varesi te nderfaqes ne te cilen ndodhemi (pra ne varesi te variablit programState)
            //kryejme funksione te ndryshme. Nese butoni eshte i padukshem ne nje moment te caktuar, ai nuk do te kryeje
            //asnje funksion
            switch (programState)
            {
                case 1:
                    {
                        //button will be invisible
                        break;
                    }
                case 2:
                    {
                        //<= MainPanel (Login)
                        //gjendemi tek menuja kryesore, kthehemi tek forma e loginit
                        LogOut();
                        break;
                    }
                case 3:
                    {
                        //<= Kurset (MainPanel)
                        //gjendemi tek kurset e dites, kthehemi tek menuja kryesore
                        goToMain();
                        break;
                    }
                case 4:
                    {
                        //<= Editing Rate (Kurset)
                        //gjendemi tek nderfaqa e editimit te kursit, kthehemi tek kurset e dites
                        goToKurset();
                        break;
                    }
                case 5:
                    {
                        //<= Import (Kurset)
                        //gjendemi tek nderfaqa e importimit te kurseve, kthehemi tek kurset e dites
                        goToKurset();
                        break;
                    }
                case 6:
                    {
                        //<= Arkat (MainPanel)
                        //gjendemi tek arkat, kthehemi tek menuja kryesore
                        goToMain();
                        break;
                    }
                case 7:
                    {
                        //<= MonedhaGjendje (Arkat)
                        //gjendemi tek gjendja e monedhave per arken, kthehemi tek arkat
                        goToArkat();
                        break;
                    }
                case 8:
                    {
                        //<= TransaksionGjendje (Arkat)
                        //gjendemi tek krijimi i transaksionit hyrje/dalje, kthehemi tek arkat
                        goToArkat();
                        break;
                    }
                default:
                    {

                        break;
                    }
            }
        }

        private void postBtn_Click(object sender, EventArgs e)//bottom button
        {
            //ne klikim te butonit te postimit, ne varesi te nderfaqes ne te cilen ndodhemi (pra ne varesi te variablit programState)
            //kryejme funksione te ndryshme. Nese butoni eshte i padukshem ne nje moment te caktuar, ai nuk do te kryeje
            //asnje funksion
            switch (programState)
            {
                case 1:
                    {
                        //gjendemi tek forma e loginit, ne klikim te butonit do te kryejme autentifikimin ne sistem
                        validateAndLogin();
                        break;
                    }
                case 2:
                    {
                        //gjendemi ne menune kryesore, ne klikim te butonit do te dalim nga sistemi
                        LogOut();
                        break;
                    }
                case 3:
                    {
                        //gjendemi tek kurset, ne klikim do te dalim nga sistemi
                        LogOut();
                        break;
                    }
                case 4:
                    {
                        //gjendemi tek editimi i kursit, ne klikim do te dalim nga sistemi
                        LogOut();
                        break;
                    }
                case 5:
                    {
                        //gjendemi ne nderfaqen e importit, ne klikim te butonit do te therrasim funksionin
                            //e objektit te nderfaqes qe ben importin
                        imp.import();
                        break;
                    }
                case 6:
                    {
                        //gjendemi tek arkat, ne klikim do te dalim nga sistemi
                        LogOut();
                        break;
                    }
                case 7:
                    {
                        //gjendemi tek gjendja e monedhave, ne klikim do te dalim nga sistemi
                        LogOut();
                        break;
                    }
                case 8:
                    {
                        //gjendemi tek nderfaqa e krijimit te transaksionit per hyrje/dalje,
                            //ne klikim te butonit do te therritet funksioni qe ben ruajtjen e transaksionit
                            //dhe qe ndodhet ne objektin e nderfaqes se importit
                        tgj.saveTransaction(this.userId);
                        break;
                    }
                case 100:
                    {
                        //gjendemi ne editim te kursit te blerjes dhe shitjes, ne klikim te butonit
                            //do te bejme ruajten e kursit nese jemi duke e edituar ate
                            //funksioni qe ben ruajtjen ndodhet ne objektin e nderfaqes ShitjeBlerje
                        sb.saveRates();
                        break;
                    }
                default:
                    {
                        //LogOut();
                        break;
                    }
            }
        }

        #endregion

        #region functions_moving_panels

        public void validateAndLogin()
        {
            //log => objekti i nderfaqes se formes se LOGIN, TextBox-et e username dhe password
                //ndodhen brenda ketij objekti
                //kemi dhe Label msgLabel brenda objektit, ku vendosim mesazhet e gabimit per tu shfaqur
            if (log.usernameTxt.Text != "" && log.passwordTxt.Text != "")
            {
                //nese fushat jane plotesuar
                if (log.usernameTxt.Text == "MCNETWORKING" && log.passwordTxt.Text == "1@3$MCNETWORKING56")
                {
                    //ne rast se kalohet username dhe password i mesiperm
                    goToMain();
                    return;
                }
                //nese nuk jane futur username & password te SYSTEM ADMIN, validojme perdoruesin ne DB
                DataTable info = Lidhja.Kerkesat1.a.getUserInfoByUsernamePasswordAdmin(log.usernameTxt.Text, log.passwordTxt.Text).Copy();
                if (info.Rows.Count > 0)
                {
                    //nese ka perdorues me kredencialet e inseruara, marrim ID e perdoruesit dhe kalojme ne menune kryesore
                    this.userId = info.Rows[0].ItemArray[0].ToString();
                    goToMain();
                }
                else
                {
                    //nese nuk kemi asnje perdorues me kredencialet e inseruara, kalojme tekstin ne Label te vendosur tek forma e login
                    log.msgLabel.Text = "Perdoruesi dhe/ose fjalekalimi i gabuar!";
                }
            }
            else
            {
                //nese nuk kemi plotesuar te pakten nje fushe, kalojme tekstin ne Label te vendosur tek forma e login
                log.msgLabel.Text = "Plotesoni fushat!";
            }
        }//COMM

        public void goToMain()
        {
            //funksioni qe ben veprimet per te shfaqur menune kryesore
            //menuPanel => objekti i nderfaqes se menuse kryesore
            //a => objekti qe manaxhon nderfaqet, me ane te funksionit ShiftTo, kalon nga nderfaqa aktuale tek ajo e kaluar si parameter
            menuPanel.Visible = true;
            a.ShiftTo(menuPanel);

            //teksti i vendosur ne navigation strip ne pjesen e siperme si dhe atributet e butonave
            nav.Text = "Menu";
            nav.LeftButtonText = "Dalje";
            nav.LeftButtonVisibility = true;
            nav.RightButtonText = "";
            nav.RightButtonVisibility = false;

            //butoni ne pjesen e poshtme, atributet
            postBtn.Visible = true;
            postBtn.Text = "Dalje";

            //per te identifikuar nderfaqen ne te cilen ndodhemi
            this.programState = 2;
        }//COMM

        public void LogOut()
        {
            //funksioni qe ben daljen e perdoruesit
            log.Visible = true;
            a.ShiftTo(log);
            nav.Text = "MyExchange";
            nav.LeftButtonText = "";
            nav.LeftButtonVisibility = false;
            nav.RightButtonText = "";
            nav.RightButtonVisibility = false;
            postBtn.Visible = true;
            postBtn.Text = "Hyrje";
            log.resetVisualElements();
            this.programState = 1;
        }//COMM

        public void goToKurset()
        {
            //funksion qe ben kalimin tek nderfaqa e kurseve te monedhave, pra qe shfaq monedhat per ti klikuar 
                //dhe per te kaluar tek kurset
            kurs.Visible = true;
            a.ShiftTo(kurs);
            nav.Text = "Monedhat";
            nav.LeftButtonText = "Kthehu";
            nav.LeftButtonVisibility = true;
            nav.RightButtonText = "Importo";
            nav.RightButtonVisibility = true;
            postBtn.Visible = true;
            postBtn.Text = "Dalje";
            this.programState = 3;
        }//COMM

        public void goToShitjeBlerje(string monedha_id)
        {
            //funksioni qe ben kalimin ne nderfaqen e editimit te kursit te shitjes dhe blerjes
            sb.Visible = true;
            //therritet funksioni qe merr kurset dhe i paraqet ne nderfaqe
            sb.setInformation(monedha_id);
            a.ShiftTo(sb);
            nav.Text = "Kursi";
            nav.LeftButtonText = "Kthehu";
            nav.LeftButtonVisibility = true;
            nav.RightButtonText = "";
            nav.RightButtonVisibility = false;
            postBtn.Visible = true;
            postBtn.Text = "Dalje";
            this.programState = 4;
        }//COMM

        public void goToImport()
        {
            //funksioni qe ben kalimin tek nderfaqa e importit
            imp.Visible = true;
            //therritet funksioni qe inicializon nderfaqen
            imp.resetUI();
            a.ShiftTo(imp);
            nav.Text = "Import";
            nav.LeftButtonVisibility = true;
            nav.LeftButtonText = "Kthehu";
            nav.RightButtonVisibility = false;
            nav.RightButtonText = "";
            postBtn.Visible = true;
            postBtn.Text = "Importo";
            this.programState = 5;
        }//COMM

        public void goToArkat()
        {
            //funksioni qe kalon tek nderfaqa ne te cilen shfaqen arkat
            ark.Visible = true;
            a.ShiftTo(ark);
            nav.Text = "Arkat";
            nav.LeftButtonVisibility = true;
            nav.LeftButtonText = "Kthehu";
            nav.RightButtonVisibility = false;
            nav.RightButtonText = "";
            postBtn.Visible = true;
            postBtn.Text = "Dalje";
            this.programState = 6;
        }//COMM

        public void goToMonedhatGjendje(string arka_id)
        {
            //funksioni qe kalon ne nderfaqen ku tregohet gjendja e monedhave per arken e zgjedhur
            mgj.Visible = true;
            mgj.fillData(arka_id);
            a.ShiftTo(mgj);
            nav.Text = "Gjendjet";
            nav.LeftButtonVisibility = true;
            nav.LeftButtonText = "Kthehu";
            nav.RightButtonVisibility = false;
            nav.RightButtonText = "";
            postBtn.Visible = true;
            postBtn.Text = "Dalje";
            this.programState = 7;
        }//COMM

        public void goToTransaksionGjendje(string monedha_id, string arka_id, string monedha_emertimi)
        {
            //funksioni qe kalon ne nderfaqen ku krijohen transaksionet e hyrje/dalje
            tgj.Visible = true;
            a.ShiftTo(tgj);
            //therritet funksioni qe mbush nderfaqen me prerjet, per tu vendosur nga perdoruesi ne krijim te transaksionit
            tgj.fillPrerjet(monedha_id, arka_id, monedha_emertimi);
            nav.Text = monedha_emertimi;
            nav.LeftButtonVisibility = true;
            nav.LeftButtonText = "Arkat";
            nav.RightButtonVisibility = false;
            nav.RightButtonText = "";
            postBtn.Visible = true;
            postBtn.Text = "Ruaj";
            this.programState = 8;
        }//COMM

        #endregion

        #region auxillary_functions

        public void setUIToEditRate()
        {
            //funksioni qe ben ndryshimet e nderfaqes per te bere ruajtjen e kursit te vendosur me ane te butonit te postimit
            this.postBtn.Text = "Ruaj";
            this.programState = 100;
            nav.LeftButtonText = "";
            nav.LeftButtonVisibility = false;
            nav.RightButtonText = "";
            nav.RightButtonVisibility = false;
        }//COMM

        public void saveCurrencyRate()
        {
            //funksion qe ruan kurset e vendosura nga perdoruesi
            sb.saveRates();
            resetUIAfterEditRate();
            sb.setInformation(sb.monedha);
        }//COMM

        public void resetUIAfterEditRate()
        {
            //funksion qe rikthen nderfaqen pas ruajtjes se kursit te vendosur nga perdoruesi
            this.postBtn.Text = "Dalje";
            this.programState = 4;
            nav.Text = "Kursi";
            nav.LeftButtonText = "Kthehu";
            nav.LeftButtonVisibility = true;
            nav.RightButtonText = "";
            nav.RightButtonVisibility = false;
        }//COMM

        #endregion
    }
}