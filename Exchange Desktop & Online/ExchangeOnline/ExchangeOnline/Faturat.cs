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
    public partial class Faturat : Form
    {
        //shkrimi i printimit
        Font printFont = new Font(new FontFamily("Segoe UI"), 10);
        //variabli qe tregon nese eshte futur nje kasier apo nje admin
        bool kasier = false;
        //id e perdoruesit te loguar
        string user_id = "";
        //variabli qe tregon nese duhen shfaqur dhe faturat e anuluara apo jo
     bool anuluara = false;

        public Faturat(bool kasier, string user_id)
        {
            this.kasier = kasier;
            this.user_id = user_id;
            //merren fillimisht id e perdoruesit dhe lloji i tij
            InitializeComponent();
            //therritet funksioni qe rregullon gjendjen fillestare te elementeve vizuale
            initializeVisualElements();
            if (kasier)
            {
                //ne rastin kur eshte loguar nje kasier, butoni i anulimit nuk ben anulimin e fatures menjehere,
                    //por ben thjesht caktimin e fatures per anulim
                this.ndryshoBtn.Text = "Cakto Per Anulim";
                //this.checkBox1.Enabled = false;
            }
        }

        public void initializeVisualElements()
        {
            //funksioni qe vendos gjendjen fillestare te elementeve vizuale
            this.radCheckBox1.Checked = false;
            this.fromDate.Enabled = false;
            this.toDate.Enabled = false;
            this.periudhaChk.Checked = false;
            this.periudhaBox.Enabled = false;
            this.periudhaBox.SelectedIndex = -1;
            this.levizjaBox.SelectedIndex = 0;
            //bottom buttons
            this.ndryshoBtn.Enabled = false;
            //end
            fillArkat();
            if (!kasier)
            {
                //ne rastin kur eshte loguar nje ADMIN, lejohet dhe filtrimi i faturave sipas perdoruesit
                fillUsers();
            }
            else
            {
                //ne rastin kur eshte loguar nje KASIER, nuk lejohet filtrimi sipas perdoruesit
                this.userBox.Enabled = false;
            }
        }//COMM

        public void fillArkat()
        {
            //funksioni qe mbush dropdown me arkat per filtrim
            DataTable arkat2 = new DataTable();
            arkat2.Columns.Add("id");
            arkat2.Columns.Add("arka");
            arkat2.Rows.Add("0", "Te Gjitha");
            DataTable arkat;
            if (!kasier)
            {
                //nese eshte loguar nje ADMIN, merren te gjitha arkat ne DB
                arkat = Lidhja.Kerkesat1.a.selectAllRecFromTable("arkat").Copy();
            }
            else
            {
                //nese eshte loguar nje kasier, merren vetem arkat tek te cilat ky kasier ka mundesi te krijoje fatura
                arkat = Lidhja.Kerkesat1.a.selectArkatByUser(this.user_id).Copy();
            }
            for (int i = 0; i < arkat.Rows.Count; i++)
            {
                //mbushim DataTable-in me informacione rresht per rresht dhe me pas e perdorim si DataSource
                    //per dropdownin e arkave
                arkat2.Rows.Add(arkat.Rows[i].ItemArray[0].ToString(), arkat.Rows[i].ItemArray[1].ToString());
            }
            this.arkaBox.DataSource = arkat2;
            this.arkaBox.DisplayMember = "arka";
            this.arkaBox.ValueMember = "id";
            this.arkaBox.SelectedIndex = 0;
        }//COMM

        public void fillUsers()
        {
            //funksioni qe mbledh perdoruesit nga DB
            DataTable users2 = new DataTable();
            users2.Columns.Add("id");
            users2.Columns.Add("emri");
            users2.Rows.Add("0", "Te Gjithe");
            DataTable users = Lidhja.Kerkesat1.a.selectUsers().Copy();
            for (int i = 0; i < users.Rows.Count; i++)
            {
                //mbushim DataTable-in me perdorues dhe me pas e perdorim si DataSource 
                    //per dropdownin e perdoruesve
                users2.Rows.Add(users.Rows[i].ItemArray[0].ToString(), users.Rows[i].ItemArray[1].ToString());
            }
            this.userBox.DataSource = users2;
            this.userBox.DisplayMember = "emri";
            this.userBox.ValueMember = "id";
            this.userBox.SelectedIndex = 0;
        }//COMM

        private void radCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //ne rast se checkBox-i zgjidhet, aktivizohen elementet vizuale qe lejojne filtrimin sipas dates
                //ne rast te kundert elementet caktivizohen
            if (radCheckBox1.Checked)
            {
                this.fromDate.Enabled = true;
                this.toDate.Enabled = true;
                this.periudhaChk.Checked = false;
            }
            else
            {
                this.fromDate.Enabled = false;
                this.toDate.Enabled = false;
            }
        }//COMM

        private void filterBtn_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit, krijohet QUERY qe zgjedh faturat
            //sql statement building & excecuting :(
            int expression_counter = 0;
            string sqlBuilder = "";
            //QUERY krijohet me pjese, ne varesi te kushteve, fillimisht QUERY nuk ka asnje kusht
            sqlBuilder += "select users.emri + ' ' + users.mbiemri as Perdoruesi, arkat.arka as Arka, " +
                "transaksione.Tipi1 as Nga, transaksione.Sasia1 as Sasia1, transaksione.Tipi2 as Ne, transaksione.Sasia2 as Sasia2, " +
                "transaksione.Kursi as Kursi, transaksione.Blerje_shitje as Levizja, transaksione.Dita as Data, transaksione.Ora as Ora, transaksione.id ";
            if (!checkBox1.Checked)
            {
                //ne rast se nuk eshte zgjedhur CheckBox-i per anulim, shtohet stringu tek query qe shfaq kolonen 
                    //qe tregon a eshte per anulim fatura apo jo
                sqlBuilder += ", transaksione.anulim as 'Per Anulim'";
                anuluara = false;
                this.ndryshoBtn.Enabled = false;
            }
            else
            {
                //ne rast se eshte zgjedhur, shfaqet data e anulimit per faturat e anuluara
                    //duke shtuar kolonen ne SELECT
                sqlBuilder += ", transaksione.data_anulimit as 'Data e Anulimit'";
                anuluara = true;
                this.ndryshoBtn.Enabled = true;
            }
            //pjese e QUERY-t
            sqlBuilder += "from (transaksione " +
                "inner join users on transaksione.id_user = users.id) " +
                "inner join arkat on transaksione.id_arka = arkat.id ";
            //nese duam te shfaqim te anuluarat (pra checkBox1 eshte i zgjedhur) kerkojme faturat me aktiv 0
                //perndryshe ato me aktiv 1
            sqlBuilder += " where transaksione.aktiv = " + (checkBox1.Checked ? "0 " : "1 ");
            //nese kemi percaktuar menyra filtrimi, shtohen pjese te tjera ne QUERY, perndryshe ekzekutohet direkt
            if (arkaBox.SelectedIndex > 0 || userBox.SelectedIndex > 0 || levizjaBox.SelectedIndex > 0 || this.radCheckBox1.Checked || this.periudhaChk.Checked || kasier)
            {
                //nese kemi percaktuar menyra filtrimi, shtojme nje 'and' ne string
                sqlBuilder += " and ";
                //shtojme kushtin ne QUERY nese eshte zgjedhur nje vlere nga dropdown per te filtruar sipas arkes
                if (arkaBox.SelectedIndex > 0)
                {
                    //nese plotesohet kushti, vlera e variablit do te inkrementohet per te shtuar 'and' ne kushtin tjeter
                    expression_counter++;
                    sqlBuilder += " transaksione.id_arka = " + this.arkaBox.SelectedValue.ToString();
                }
                //ose filtrojme sipas perdoruesit te zgjedhur, ose filtrojme sipas kasierit te loguar,
                    //pra ose duhet te jete zgjedhur nje vlere tek dropdown i perdoruesit ose duhet te jete loguar nje kasier
                if (userBox.SelectedIndex > 0 || kasier)
                {
                    //nese kemi percaktuar menyra filtrimi te tjera, shtojme 'and' ne string
                    if (expression_counter > 0)
                    {
                        sqlBuilder += " and ";
                    }
                    //ose kontrollojme rekordet e perdoruesit te zgjedhur nga dropdown ne rastin kur eshte loguar nje admin,
                        //ose me id e perdoruesit te loguar ne rastin kur eshte loguar nje kasier
                    sqlBuilder += " transaksione.id_user = " + (kasier ? this.user_id : this.userBox.SelectedValue.ToString());
                    //nese plotesohet kushti, vlera e variablit do te inkrementohet, per te shtuar 'and' ne kushtin tjeter
                    expression_counter++;
                }
                //nese kemi te zgjedhur tipin e levizjes, pra blerje ose shitje, per filtrim
                if (levizjaBox.SelectedIndex > 0)
                {
                    if (expression_counter > 0)
                    {
                        sqlBuilder += " and ";
                    }
                    sqlBuilder += " transaksione.Blerje_shitje = '" + this.levizjaBox.Text + "'";
                    expression_counter++;
                }
                //nese kemi zgjedhur opsionin per te filtruar sipas dates, shtojme kushtin ne QUERY
                if (this.radCheckBox1.Checked)
                {
                    if (expression_counter > 0)
                    {
                        sqlBuilder += " and ";
                    }
                    //shfaqen rekordet ku dita eshte midis vleres se zgjedhur nga data e fillimit dhe asaj te zgjedhur nga data e mbarimit
                    sqlBuilder += " dita >= CONVERT(datetime, '" + this.fromDate.Value.ToString("dd/MM/yyyy") + "', 103) and dita <= CONVERT(datetime, '"+ this.toDate.Value.ToString("dd/MM/yyyy") + "', 103)";
                }
                //nese kemi te zgjedhur opsionin e periudhes, shfaqen faturat e bera nga data e sotme 
                    //deri ne daten e sotme minus periudhen e zgjedhur
                else if (this.periudhaChk.Checked)
                {
                    //nese vlera e kthyer nga funksioni nuk eshte me e madhe se data e sotme
                    if (!(this.getPeriudhaFromComboBox() > DateTime.Now))
                    {
                        if (expression_counter > 0)
                        {
                            sqlBuilder += " and ";
                        }
                        //shfaqen rekordet ku dita eshte midis vleres se kthyer nga funksioni qe llogarit daten e fillimit dhe midis dates se sotme
                        sqlBuilder += " dita >= CONVERT(datetime, '" + this.getPeriudhaFromComboBox().ToString("dd/MM/yyyy") + "', 103) and dita <= CONVERT(datetime, '" + DateTime.Now.ToString("dd/MM/yyyy") + "', 103)";
                    }
                }
            }
            DataTable transactions;
            //QUERY ne forme stringu ekzekutohet ne SQL (ADO standarte) dhe rezultati hidhet ne DataTable per te kaluar ne radGridView1
            transactions = Lidhja.Kerkesat1.a.excecuteScript(sqlBuilder).Copy();
            this.radGridView1.DataSource = transactions;
            this.radGridView1.Columns["id"].Visible = false;
            this.radGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.Columns["Sasia1"].HeaderText = "Sasia Nga";
            this.radGridView1.Columns["Sasia2"].HeaderText = "Sasia Ne";

            //nese kemi nje rresht te zgjedhur pasi mbushim GridView me informacion, aktivizojme butonin e anulimit,
                //perndryshe e caktivizojme
            if (this.radGridView1.SelectedRows.Count == 1)
            {
                this.ndryshoBtn.Enabled = true;
            }
            else
            {
                this.ndryshoBtn.Enabled = false;
            }
        }//COMM

        private void copyBtn_Click(object sender, EventArgs e)
        {
            //thirret funksioni qe kopjon te dhenat e GridView ne Clipboard, faktikisht ky funksion nuk punon 
            this.copyInformationToClipboard(ref this.radGridView1);
        }//COMM

        public void copyInformationToClipboard(ref DataGridView grid)
        {
            //funksioni qe kopjon te dhenat ne GridView per tek Clipboard per tu hedhur ne Excel, etj

            //informacioni do te jete ne forme stringu, duke konkatenuar qelizat e GridView
            StringBuilder strBuild = new StringBuilder();
            //fillimisht hidhen informacionet per Header te GridView
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                //shtohen stringet vetem ne rastin kur kolona eshte e dukshme
                if (grid.Columns[i].Visible == true)
                {
                    strBuild.Append(grid.Columns[i].HeaderText);
                    //qelizat ndahen me tabspace
                    strBuild.Append("\t");
                }
            }
            //rreshtat ndahen me newline
            strBuild.Append("\n");
            for (int row = 0; row < grid.Rows.Count; row++)
            {
                for (int cell = 0; cell < grid.Rows[row].Cells.Count; cell++)
                {
                    //shtohet qeliza vetem ne rastin kur kolona eshte e dukshme
                    if (grid.Columns[cell].Visible == true)
                    {
                        //nese vlera e qelizes aktuale eshte NULL, shtojme stringun ""
                        strBuild.Append((grid.Rows[row].Cells[cell].Value == null ? "" : grid.Rows[row].Cells[cell].Value.ToString()));
                        strBuild.Append("\t");
                    }
                }
                //pas cdo rreshti te shtuar, shtojme newline dhe kalojme ne iteracionin tjeter per te shtuar rreshtin tjeter
                strBuild.Append("\n");
            }

            //per te caktuar tekstin ne Clipboard
            Clipboard.SetText(strBuild.ToString());
            MessageBox.Show("Informacioni u kopjua dhe mund te ngjitet.");
            MessageBox.Show(Clipboard.GetText());
        }//COMM

        //variabli qe percakton nese rekordi i zgjedhur eshte i caktuar per anulim apo jo
            //true    -> mund te caktohet per anulim
            //false   -> eshte caktuar tashme per anulim
        private bool cakto = true;

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //ne rastin kur zgjidhet nje rresht tjeter, funksioni ben ndryshimet e duhura ne nderfaqen grafike
                //ndryshimet do te behen vetem ne rastin kur eshte loguar nje kasier, pasi nese kemi te loguar nje
                //admin, nuk ka nevoje per ndryshime ne nderfaqe

            //ne rastin kur kemi te loguar nje kasier dhe ai ka zgjedhur nje rresht ne GridView
            if (this.radGridView1.SelectedRows.Count == 1 && kasier)
            {
                //nese kolona tregon se fatura e zgjedhur eshte caktuar per anulim, behen ndryshimet perkatese
                if (bool.Parse(this.radGridView1.SelectedRows[0].Cells["Per Anulim"].Value.ToString()))
                {
                    this.ndryshoBtn.Text = "Hiq Caktimin";
                    cakto = false;
                }
                else
                {
                    this.ndryshoBtn.Text = "Cakto Per Anulim";
                    cakto = true;
                }
                //butoni i anulimit aktivizohet gjithsesi, nese zgjidhet nje rresht
                this.ndryshoBtn.Enabled = true;
            }
            else if(this.radGridView1.SelectedRows.Count != 1)
            {
                //perndryshe, nese nuk kemi rresht te zgjedhur, butoni caktivizohet
                this.ndryshoBtn.Enabled = false;
            }
        }//COMM

        private void ndryshoBtn_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit ANULO

            //nese kemi te loguar nje admin, do te nxirret nje MessageBox ku kerkohet konfirmimi per anulimin qe po behet
                //funksioni qe therritet ne konfirmim te MessageBox ndodhet ne EventHandler te kaluar si parameter ne MessageBox
            
            if (!kasier)
            {
                DialogResult a;
                a = MessageBox.Show("Jeni te sigurt qe doni te anuloni transaksionin e zgjedhur?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(anulo_admin));
            }
            //perndryshe, nese kemi te loguar nje kasier, do te nxirret MessageBox qe konfirmon caktimin per anulim te fatures se zgjedhur
                //ose heqjen si fature te caktuar per anulim, pra mos-shenjimin e fatures kur eshte e shenjuar
                //funksioni anulo() qe ndodhet ne EventHandler ben caktimin per anulim ne rastin kur ajo nuk eshte e caktuar
                //funksioni deanulo() qe ndodhet ne EventHandler heq faturen nga ato te caktuarat per anulim
                //ne konfirmim te MessageBox-eve qe nxirren ne te dyja rastet, therriten funksionet perkatese
            else
            {
                if (cakto)
                {
                    DialogResult a;
                    a = MessageBox.Show("Jeni te sigurt qe doni te caktoni transaksionin e zgjedhur per anulim?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(anulo));
                }
                else
                {
                    DialogResult a;
                    a = MessageBox.Show("Jeni te sigurt qe doni te hiqni transaksionin nga te caktuarat per anulim?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(deanulo));
                }
            }
        }//COMM

        private void deanulo(object sender, EventArgs e)
        {
            //ekzekutohet procedura qe heq caktimin per anulim te fatures se zgjedhur dhe kjo gje i tregohet
                //perdoruesit, me pas merren perseri faturat sipas filtrimit te konfiguruar aktualisht
            Lidhja.Kerkesat1.a.decaktoPerAnulim(this.radGridView1.SelectedRows[0].Cells["id"].Value.ToString());
            MessageBox.Show("Transaksioni i zgjedhur eshte hequr nga te caktuarat per anulim.");
            this.filterBtn.PerformClick();
        }//COMM

        private void anulo(object sender, EventArgs e)
        {
            //ekzekutohet procedura qe cakton per anulim faturen e zgjedhur dhe kjo gje i tregohet
                //perdoruesit, me pas merren perseri faturat sipas filtrimit te konfiguruar aktualisht
            Lidhja.Kerkesat1.a.caktoPerAnulim(this.radGridView1.SelectedRows[0].Cells["id"].Value.ToString());
            MessageBox.Show("Transaksioni i zgjedhur u caktua per anulim.\n\rAdministratori i sistemit mund te anuloje transaksionin tuaj.");
            this.filterBtn.PerformClick();
        }//COMM

        private void anulo_admin(object sender, EventArgs e)
        {
            //funksioni qe ben anulimin e fatures nga admini, ekzekuton proceduren ne SQL qe anulon faturen, 
                //me pas nxjerr mesazhin qe tregon se fatura u anulua dhe ne fund ri-merr faturat nga DB sipas 
                //filtrimeve te zgjedhura
            Lidhja.Kerkesat1.a.resetTransaction(this.radGridView1.SelectedRows[0].Cells["id"].Value.ToString());
            MessageBox.Show("Transaksioni i zgjedhur u anulua dhe gjendjet e prerjeve u ricaktuan.");
            this.filterBtn.PerformClick();
        }//COMM

        private void periudhaChk_CheckedChanged(object sender, EventArgs e)
        {
            //nese periudhaChk eshte e selektuar, aktivizohet dropdown qe lejon zgjedhjen e periudhes
                //perndryshe caktivizohet
            if (periudhaChk.Checked)
            {
                this.radCheckBox1.Checked = false;
                this.periudhaBox.Enabled = true;
                this.periudhaBox.SelectedIndex = 0;
            }
            else
            {
                this.periudhaBox.Enabled = false;
                this.periudhaBox.SelectedIndex = -1;
            }
        }//COMM

        private DateTime getPeriudhaFromComboBox()
        {
            //funksion qe kthen daten e llogaritur sipas periudhes se zgjedhur me dropdown,
                //pra daten para aq diteve, muajve ose viteve sa eshte zgjedhur ne dropdown
            switch (this.periudhaBox.SelectedIndex)
            {
                case 0:
                    {
                        //1 Jave
                        return DateTime.Now.AddDays(-7);
                    }
                case 1:
                    {
                        //2 Jave
                        return DateTime.Now.AddDays(-14);
                    }
                case 2:
                    {
                        //1 Muaj
                        return DateTime.Now.AddMonths(-1);
                    }
                case 3:
                    {
                        //3 Muaj
                        return DateTime.Now.AddMonths(-3);
                    }
                case 4:
                    {
                        //6 Muaj
                        return DateTime.Now.AddMonths(-6);
                    }
                case 5:
                    {
                        //1 Vit
                        return DateTime.Now.AddYears(-1);
                    }
                case 6:
                    {
                        //2 Vjet
                        return DateTime.Now.AddYears(-2);
                    }
                case 7:
                    {
                        //Te Gjitha
                        //ne kete rast nuk do te plotesohet kushti ne funksionin qe krijon QUERY-n dhe nuk do te kete filtrim sipas dates
                            //pra do te shfaqen te gjitha faturat
                        return DateTime.Now.AddDays(1);
                    }
                default:
                    {
                        //gabim ne rastin kur kemi periudhe ne dropdown qe nuk ka implementim ne switch/case
                            //kthehet data e sotme nese kjo ndodh, por te gjitha periudhat jane te implementuara
                        MessageBox.Show("Nuk eshte implementuar limiti i fundit per indeksin e zgjedhur!");
                        return DateTime.Now;
                    }
            }
        }//COMM
    }
}