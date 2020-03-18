#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Net;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using CustomCRMControls;
using CRMMobileDemo.Common;

#endregion

namespace CRMMobileDemo.iOS.CustomControlsMC
{
    public partial class Import : TranslatePanel
    {
        public DateTime selectedDate;

        //vektori me muajt e vitit, sherben per te zgjedhur muajin nga user-control qe do te krijohet ne klikim te TextBox te muajit
        string[] months = new string[] { 
            "Janar", 
            "Shkurt", 
            "Mars", 
            "Prill", 
            "Maj", 
            "Qershor", 
            "Korrik", 
            "Gusht", 
            "Shtator", 
            "Tetor", 
            "Nentor", 
            "Dhjetor" };

        //variabli qe percakton menyren e importimit te zgjedhur nga perdoruesi
            //TRUE  => import sipas nje date tjeter
            //FALSE => import sipas nje burimi
        public bool date = true;

        //ne rast klikimi tek TextBox, do te shfaqet kontrolli ne te cilin perdoruesi mund te zgjedhe diten muajin ose vitin
        DropDownControl drop;

        public Import()
        {
            InitializeComponent();
        }

        public void resetUI()
        {
            //funksion qe ben inicializimin e nderfaqes
            selectedDate = DateTime.Now;
            splitSelectedDateInUI();
            this.radioButton1.Checked = true;
            this.radioButton2.Checked = false;
            enableDate();
        }//COMM

        public void splitSelectedDateInUI()
        {
            //funksion qe ben ndarjen e dates selectedDate ne TextBox per paraqitje vizuale
            this.dayBox.Text = this.selectedDate.Day.ToString();
            this.monthBox.Text = months[this.selectedDate.Month - 1];
            this.monthBox.Tag = this.selectedDate.Month.ToString();
            this.yearBox.Text = this.selectedDate.Year.ToString();
        }//COMM

        public void createSelectedDateFromUI()
        {
            //funksion qe ben krijimin e objektit DateTime nga TextBoxet qe sherbejne per daten
            int max_days;
            switch (int.Parse(this.monthBox.Tag.ToString()))
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        //nese jemi ne muaj me 31 dite, vendosim 31 si numer maksimal ditesh
                        max_days = 31;
                        break;
                    }
                case 2:
                    {
                        //nese jemi ne shkurt, vendosim 29 ne vit te brishte (1 here ne 4 vjet) dhe 28 ne cdo rast tjeter, si dite maksimale
                        max_days = (selectedDate.Year % 4 == 0 ? 29 : 28);
                        break;
                    }
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        //perndryshe vendosim 30 si dite maksimale
                        max_days = 30;
                        break;
                    }
                default:
                    {
                        //wtf
                        max_days = 31;
                        break;
                    }
            }

            //nese numri i diteve te inseruara ne TextBox eshte me i madh se numri maksimal i diteve, i vendosur nga muaji i zgjedhur
                //dhe viti i zgjedhur, atehere si numer te diteve ne TextBox do te vendosim numrin maksimal, qe te kemi nje date te vlefshme
            if (int.Parse(this.dayBox.Text) > max_days)
            {
                this.dayBox.Text = max_days.ToString();
            }
            //data qe krijohet vendoset tek selectedDate, objekt i tipi DateTime i deklaruar ne nivel klase
            selectedDate = DateTime.Parse(this.monthBox.Tag.ToString() + "/" + this.dayBox.Text + "/" + this.yearBox.Text);
        }//COMM

        private void importFromSelectedDate()
        {
            //funksion qe ben importin e kurseve nga data e zgjedhur
                //mesazhet e gabimit ose te suksesit nuk shfaqen me MessageBox por vendosen si Text i Label 
                    //msgLabel1, qe sherben per paraqitje te mesazheve
            if (selectedDate.Date == DateTime.Now.Date)
            {
                //nese data e zgjedhur eshte data e sotme, nuk behet importi, pasi nuk ka kuptim te importojme
                    //kurset e dates se sotme
                msgLabel1.Text = "Jepni nje date te vlefshme!";
            }
            else if (selectedDate.Date > DateTime.Now.Date)
            {
                //nese data e zgjedhur eshte date pas dates se sotme, nuk ka kuptim te importojme kurset e se ardhmes :)
                msgLabel1.Text = "Jepni nje date te vlefshme!";
            }
            else
            {
                //perndryshe marrim kurset e dates se zgjedhur nga DB
                DataTable date_rates = Lidhja.Kerkesat1.a.getRatesFromDate(this.selectedDate.ToString("dd/MM/yyyy")).Copy();
                if (!(date_rates.Rows.Count > 0))
                {
                    //nese nuk kemi rekorde, do te thote se nuk kemi kurs te percaktuar ne daten e kaluar si parameter
                    msgLabel1.Text = "Nuk ka kurse ne kete date!";
                }
                else
                {
                    //perndryshe, kemi kurse per daten e zgjedhur, keshtu qe ekzekutojme proceduren ne SQL per import te kurseve
                    Lidhja.Kerkesat1.a.importRateFromDate(this.selectedDate.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"));
                    msgLabel1.Text = "Kursi u importua me sukses!";
                }
            }
        }//COMM

        public void enableDate()
        {
            //funksioni qe aktivizon importin sipas dates
            date = true;
            selectedDate = DateTime.Now;
            splitSelectedDateInUI();
            this.dayBox.Enabled = true;
            this.monthBox.Enabled = true;
            this.yearBox.Enabled = true;
            this.sourceItem.Enabled = false;
            this.destinationItem.Enabled = false;
            this.kursiItem.Enabled = false;
            this.sourceItem.Text = "";
            this.destinationItem.Text = "";
            this.kursiItem.Text = "";
        }//COMM

        public void enableSource()
        {
            //funksioni qe aktivizon importin sipas burimit (Yahoo)
            date = false;
            selectedDate = DateTime.Now;
            this.dayBox.Enabled = false;
            this.monthBox.Enabled = false;
            this.yearBox.Enabled = false;
            this.dayBox.Text = "";
            this.monthBox.Text = "";
            this.yearBox.Text = "";
            this.sourceItem.Enabled = true;
            this.destinationItem.Enabled = true;
            this.kursiItem.Enabled = true;
            this.sourceItem.Text = "";
            this.destinationItem.Text = "";
            this.kursiItem.Text = "";
        }//COMM

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //ne ndryshim te RadioButton, kur perdoruesi ndryshon menyren e importit
            if (radioButton1.Checked)
            {
                //ne rastin kur importon sipas dates
                enableDate();
            }
            else
            {
                //ne rastin kur importon sipas burimit
                enableSource();
            }
        }//COMM

        private void importFromSelectedSource()
        { 
            //funksioni qe importon kursin nga nje burim i caktuar i zgjedhur nga perdoruesi
            if (this.sourceItem.Text != "" && this.destinationItem.Text != "" && this.kursiItem.Text != "")
            {
                //nese eshte zgjedhur burimi, destinacioni dhe kursi qe do te importohet
                string dest = this.destinationItem.Text;
                string shitjeBlerje = this.kursiItem.Text;
                switch (this.sourceItem.Text)
                {
                    case "Yahoo":
                        {
                            //((Form1)this.MdiParent).importFromYahoo(dest, shitjeBlerje);
                            //nese burimi i zgjedhur eshte Yahoo, therrasim funksionin e importit nga Yahoo
                            importFromYahoo(this.destinationItem.Text, this.kursiItem.Text);
                            break;
                        }
                    default:
                        {
                            //perndryshe kemi burimin por nuk kemi menyre importi
                            MessageBox.Show("Nuk eshte konfiguruar burimi i zgjedhur!");
                            break;
                        }
                }
            }
        }//COMM

        private void importFromYahoo(string destination, string shitje_blerje)
        {
            //funksioni qe ben importin nga Yahoo, merr si parameter destinacionin (arka ose banka) dhe tipin e kursit (shitje ose blerje)

            DataTable radGridView1 = new DataTable();

            radGridView1.Columns.Add("id_monedha");
            radGridView1.Columns.Add("Monedha");
            radGridView1.Columns.Add("Kursi");
            //marrim monedhat nga DB
            DataTable monedhat = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();
            //per cdo monedhe, marrim kursin e kembimit ne faqen e Yahoo, krahasuar me ALL
            for (int i = 0; i < monedhat.Rows.Count; i++)
            {
                string uri = @"http://finance.yahoo.com/d/quotes.txt?e=.csv&f=l1&s=" + monedhat.Rows[i].ItemArray[1].ToString() + "ALL=X";

                WebClient client = new WebClient();

                //marrim vleren qe ka Yahoo me WebClient.DownloadString
                string curr = client.DownloadString(uri);
                //zevendesojme karakteret ENDLINE & NEWROW me "" dhe vendosim ndaresen sic e ka sistemi aktual (NumberDecimalSeparator)
                curr = curr.Replace("\n", "").Replace("\r", "").Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);

                float z;
                string line_read = curr;
                if (float.TryParse(line_read, out z))
                {
                    //nese kemi vlere numerike
                    float rate = float.Parse(line_read);
                    if (rate != 0)
                    {
                        //nese vlera eshte e vlefshme, e inserojme ne DataTable
                            //(radGridView1 eshte DataTable)
                        radGridView1.Rows.Add(monedhat.Rows[i].ItemArray[0].ToString(), monedhat.Rows[i].ItemArray[1].ToString(), rate.ToString());
                    }
                }
                //nese nuk plotesohet kushti, nuk inserojme asnje vlere
            }//COMM

            string selectFirst = "select * from " + destination + " where aktiv = 1 and DataKrijimit = CONVERT(date, '" + DateTime.Now.ToString("dd/MM/yyyy") + "', + 103)";
            DataTable current_values = Lidhja.Kerkesat1.a.excecuteScript(selectFirst).Copy();
            List<string> val = new List<string>();
            for (int i = 0; i < current_values.Rows.Count; i++)
            {
                val.Add(current_values.Rows[i].ItemArray[1].ToString());
            }

            string script = "";
            for (int i = 0; i < radGridView1.Rows.Count; i++)
            {
                bool insert = (from v in val where v == radGridView1.Rows[i].ItemArray[0].ToString() select v).Count<string>() == 0;
                var tmp = (from field
                            in current_values.AsEnumerable()
                           where field.Field<int>("id_curr") == int.Parse(radGridView1.Rows[i].ItemArray[0].ToString()) &&
                           field.Field<bool>("aktiv") == true
                           select field);
                DataTable c = (tmp.Count<DataRow>() == 0 ? new DataTable() : tmp.CopyToDataTable<DataRow>());

                if (!insert)
                {
                    script += @"insert into " + destination + " (id_curr, Blerje, Shitje, Aktiv, DataKrijimit)" +
                        "select id_curr, Blerje, Shitje, 0, DataKrijimit from " + destination + " where id = " + c.Rows[0].ItemArray[0].ToString() + ";";
                    script += "update " + destination + " set " + shitje_blerje + "=" + radGridView1.Rows[i].ItemArray[2].ToString() +
                        ", DataKrijimit = CONVERT(date, '" + DateTime.Now.ToString("dd/MM/yyyy") + "', 103) where id = " + c.Rows[0].ItemArray[0].ToString() + ";";
                }
                else
                {
                    script += @"insert into " + destination + " (id_curr, " + shitje_blerje + ", Aktiv, DataKrijimit)" +
                        "values (" + radGridView1.Rows[i].ItemArray[0].ToString() + ", " + radGridView1.Rows[i].ItemArray[2].ToString() + ", 1, CONVERT(date, '" + DateTime.Now.ToString("dd/MM/yyyy") + "', 103));";
                }
            }
            Lidhja.Kerkesat1.a.excecuteInsertScript(script);
            this.msgLabel2.Text = "Importi i te dhenave u krye me sukses.";
        }//COMM

        public void import()
        {
            //funksioni qe importon ne varesi te zgjedhjes se menyres se importit
            if (this.date)
            {
                importFromSelectedDate();
            }
            else
            {
                importFromSelectedSource();
            }
        }//COMM

        private void sourceItem_GotFocus(object sender, EventArgs e)
        {
            //ne fokus te TextBox te burimit, shfaqim user-control DropDownControl
            DataTable d = new DataTable();
            d.Columns.Add("Value");
            d.Columns.Add("Display");
            
            //burimet e ndryshme shtohen manualisht
            d.Rows.Add("Yahoo", "Yahoo");

            foreach (Control c in this.Controls)
            {
                c.Visible = false;
            }
            //kalohen si parameter ne user-control DataTable, indexet dhe EventHandler me funksionin ne kete instance
            drop = new DropDownControl(d, 0, 1, new EventHandler(sourceSelected))
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(drop);
        }//COMM

        public void sourceSelected(object sender, EventArgs e)
        {
            //funksioni qe therritet ne zgjedhje te burimit per te importuar
                //TextBox ku ndodhen burimet merr vleren qe ka emri i elementit te zgjedhur
            this.sourceItem.Text = ((DetailsListView)(sender)).SelectedItem.Name;
            //hiqet user-control pas zgjedhjes
            this.Controls.Remove(drop);
            foreach (Control c in this.Controls)
            {
                c.Visible = true;
            }
        }//COMM

        public void destinationSelected(object sender, EventArgs e)
        {
            //funksioni qe therritet ne zgjedhje te destinacionit ku do te importohen kurset
                //TextBox ku ndodhen destinacionet merr vleren qe ka emri i elementit te zgjedhur
            this.destinationItem.Text = ((DetailsListView)(sender)).SelectedItem.Name;
            //hiqet user-control pas zgjedhjes
            this.Controls.Remove(drop);
            foreach (Control c in this.Controls)
            {
                c.Visible = true;
            }
        }//COMM

        public void kursiSelected(object sender, EventArgs e)
        {
            //funksioni qe therritet ne zgjedhje te llojit te kursit ku do te behet importi
                //TextBox ku ndodhen llojet e kurseve merr vleren qe ka emri i elementit te zgjedhur
            this.kursiItem.Text = ((DetailsListView)(sender)).SelectedItem.Name;
            //hiqet user-control pas zgjedhjes
            this.Controls.Remove(drop);
            foreach (Control c in this.Controls)
            {
                c.Visible = true;
            }
        }//COMM

        private void destinationItem_GotFocus(object sender, EventArgs e)
        {
            //funksioni qe therritet ne momentin qe perdoruesi klikon mbi TextBox ku ndodhet destinacioni ne te cilin 
                //do te kaloje informacioni i importuar (bankak, arka)
            DataTable d = new DataTable();
            d.Columns.Add("Value");
            d.Columns.Add("Display");

            //vlerat shtohen manualisht ne DataTable qe do te kaloje si parameter
            d.Rows.Add("Arka", "Arka");
            d.Rows.Add("Banka", "Banka");

            foreach (Control c in this.Controls)
            {
                c.Visible = false;
            }
            //shtohet user-control qe merr si parameter DataTable me informacione, indexet dhe EventHandler me funksionin
                //qe do te therritet ne momentin qe do te zjidhet nje element ne user-control, 
                //ky funksion do te jete i percaktuar brenda kesaj instance
            drop = new DropDownControl(d, 0, 1, new EventHandler(destinationSelected))
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(drop);
        }//COMM

        private void kursiItem_GotFocus(object sender, EventArgs e)
        {
            //funksioni qe therritet ne momentin qe perdoruesi klikon mbi TextBox ku ndodhet kursi per te cilin 
                //po behet importimi (shitje, blerje)
            DataTable d = new DataTable();
            d.Columns.Add("Value");
            d.Columns.Add("Display");

            //vlerat shtohen manualisht ne DataTable qe do te kaloje si parameter
            d.Rows.Add("Shitje", "Shitje");
            d.Rows.Add("Blerje", "Blerje");

            foreach (Control c in this.Controls)
            {
                c.Visible = false;
            }
            //shtohet user-control qe merr si parameter DataTable me informacione, indexet dhe EventHandler me funksionin
                //qe do te therritet ne momentin qe do te zjidhet nje element ne user-control, 
                //ky funksion do te jete i percaktuar brenda kesaj instance
            drop = new DropDownControl(d, 0, 1, new EventHandler(kursiSelected))
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(drop);
        }//COMM

        #region dateTime UI Objects

        private void dayBox_GotFocus(object sender, EventArgs e)
        {
            //ne fokusim te TextBox ku ndodhet dita e dates se zgjedhur
            DataTable d = new DataTable();
            d.Columns.Add("Value");
            d.Columns.Add("Display");

            int max_days;
            //fillimisht percaktojme sa dite do te ndodhen ne listen ku zgjidhet dita, ne varesi te muajit dhe vitit
            switch (selectedDate.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        //nese kemi zgjedhur muaj me 31 dite, vendosim 31 si numer maksimal ditesh
                        max_days = 31;
                        break;
                    }
                case 2:
                    {
                        //nese jemi ne shkurt, ne varesi te llojit te vitit (vit i brishte, nje here ne 4 vjet, apo vit normal)
                            //vendosim 28 ose 29 si numer maksimal ditesh
                        max_days = (selectedDate.Year % 4 == 0 ? 29 : 28);
                        break;
                    }
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        //nese jemi ne muaj me 30 dite, vendosim 30 si numer maksimal ditesh
                        max_days = 30;
                        break;
                    }
                default:
                    {
                        //wtf
                        max_days = 31;
                        break;
                    }
            }

            //krijojme nje DataTable me rreshta qe perfaqesojne ditet qe mund te zgjidhen
                //dita me e madhe do te jete dita e fundit, pra ajo qe percaktohet nga numri maksimal i diteve
            for (int i = 1; i <= max_days; i++)
            {
                d.Rows.Add(i.ToString(), i.ToString());
            }

            foreach (Control c in this.Controls)
            {
                c.Visible = false;
            }
            //krijojme user-control qe merr si parameter DataTable me ditet, indexet dhe funksionin qe therritet ne
                //zgjedhje te elementit. funksioni do te jete i percaktuar ne klase dhe do te delegohet me EventHandler
                //te kaluar si parameter
            drop = new DropDownControl(d, 0, 1, new EventHandler(daySelected))
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(drop);
        }//COMM

        public void daySelected(object sender, EventArgs e)
        {
            //ne zgjedhje te elementit te user-control ne rastin kur zgjidhet dita
                //TextBox qe mban diten merr emrin e elementit te zgjedhur
            this.dayBox.Text = ((DetailsListView)(sender)).SelectedItem.Name;

            this.Controls.Remove(drop);
            foreach (Control c in this.Controls)
            {
                c.Visible = true;
            };
            //ri-percaktohet objekti DateTime i zgjedhur ne moment te ndryshimit
            createSelectedDateFromUI();
        }//COMM

        private void monthBox_GotFocus(object sender, EventArgs e)
        {
            //ne fokusim te TextBox ku ndodhet muaji i zgjedhur
            DataTable d = new DataTable();
            d.Columns.Add("Value");
            d.Columns.Add("Display");
            //ne DataTable qe do te kalohet si parameter inserojme rekorde qe perfaqesojne muajt dhe vlerat e tyre
                //psh. 1 - Janar
                //     2 - Shkurt
                //emrat e muajve i kemi ne vektorin e percaktuar ne nivel klase, months[12]
            for (int i = 0; i < months.Length; i++)
            {
                //shtohen ne DataTable per cdo element te vektorit
                    //numri i muajit, emri i muajit
                d.Rows.Add((i + 1).ToString(), months[i]);
            }

            foreach (Control c in this.Controls)
            {
                c.Visible = false;
            }
            //kalohet DataTable si parameter, me index te vleres numrin e muajit (1) dhe me index te emertimit emrin e muajit (2)
                //kalohet dhe EventHandler qe mban funksionin e percaktuar ne kete instance, qe do te therritet ne zgjedhje te
                //elementit te user-control
            drop = new DropDownControl(d, 0, 1, new EventHandler(monthSelected))
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(drop);
        }//COMM

        public void monthSelected(object sender, EventArgs e)
        {
            //ne zgjedhje te muajit nga user-control ku perdoruesi ben zgjedhjen
                //teksti i TextBox do te jete emertimi i muajit te zgjedhur, pra teksti i elementit te zgjedhur ne user-control
            this.monthBox.Text = ((DetailsListView)(sender)).SelectedItem.SubItems[0].Text;
                //numrin e muajit do ta vendosim ne Tag te TextBox si informacion te asociuar dhe kur te duhet per te krijuar
                //daten e zgjedhur, do ta marrim numrin nga Tag i TextBox
            this.monthBox.Tag = ((DetailsListView)(sender)).SelectedItem.Name;
            this.Controls.Remove(drop);
            foreach (Control c in this.Controls)
            {
                c.Visible = true;
            };
            //ri-krijojme daten nga vlerat qe kane TextBox-et
            createSelectedDateFromUI();
        }//COMM

        private void yearBox_GotFocus(object sender, EventArgs e)
        {
            //ne fokusim te TextBox ku vendoset viti i zgjedhur
                //krijohet DataTable me rreshtat qe do te perfaqesojne vitet nga 1900 deri tek viti i sotem
            DataTable d = new DataTable();
            d.Columns.Add("Value");
            d.Columns.Add("Display");

            //vendosen vitet te gjeneruara nga FOR
            for (int i = DateTime.Now.Year; i >= 1900; i--)
            {
                d.Rows.Add(i.ToString(), i.ToString());
            }

            foreach (Control c in this.Controls)
            {
                c.Visible = false;
            }
            //kalohet DataTable me vitet si parameter, indexet dhe EventHandler me funksionin qe do te therritet ne zgjedhje te vitit
                //i cili percaktohet ne kete instance 
            drop = new DropDownControl(d, 0, 1, new EventHandler(yearSelected))
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(drop);
        }//COMM

        private void yearSelected(object sender, EventArgs e)
        {
            //ne zgjedhje te vitit ne user-control qe shfaq vitet
                //teksti i TextBox te viteve merr vleren e emrit te elementit te zgjedhur nga user-control
            this.yearBox.Text = ((DetailsListView)(sender)).SelectedItem.Name;
            this.Controls.Remove(drop);
            foreach (Control c in this.Controls)
            {
                c.Visible = true;
            }
            //ri-krijohet data e zgjedhur nga TextBox-et
            createSelectedDateFromUI();
        }//COMM

        #endregion
    }
}