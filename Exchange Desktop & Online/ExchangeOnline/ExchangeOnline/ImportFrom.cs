#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace ExchangeOnline
{
    public partial class ImportFrom : Form
    {
        public ImportFrom()
        {
            InitializeComponent();
            //si vlere fillestare e DateTimePicker jepet data e sotme
            this.dateTimePicker1.Value = DateTime.Now;
        }

        private void konfirmoBtn_Click(object sender, EventArgs e)
        {
            //butoni qe konfirmon importin nga nje burim
            if (this.sourceBox.SelectedIndex > -1 && this.destinationBox.SelectedIndex > -1 && this.shitjeBlerjeBox.SelectedIndex > -1)
            {
                //importi ndodh kur kemi nje burim (psh. Yahoo), nje destinacion (psh. Kurset e Arkes) dhe tipin e kursit (Shitje/Blerje)
                string dest = this.destinationBox.Text;
                string shitjeBlerje = this.shitjeBlerjeBox.Text;
                switch (this.sourceBox.Text)
                {
                    case "Yahoo":
                        {
                            //ne rastin kur importin e bejme nga Yahoo
                            ((Form1)this.MdiParent).importFromYahoo(dest, shitjeBlerje);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Nuk eshte konfiguruar burimi i zgjedhur!");
                            break;
                        }
                }
            }
        }//COMM

        private void ImportFrom_Load(object sender, EventArgs e)
        {
            //ne inicializim te formes se importit, fokusi kalon tek burimi
            this.sourceBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //butoni qe konfirmon importin nga nje date e caktuar (Load)
            if (dateTimePicker1.Value.Date == DateTime.Now.Date)
            {
                //nuk mund te importohet kursi i dates se sotme
                MessageBox.Show("Nuk mund te importoni te dhena nga dita e sotme!");
            }
            else if (dateTimePicker1.Value.Date > DateTime.Now.Date)
            {
                //dhe as i nje date pas dates se sotme pra ne te ardhmen
                    //se na bot si nostradamus
                MessageBox.Show("Nuk mund te importoni te dhena nga dite pas dites se sotme!");
            }
            else
            {
                //procedura kthen kurset e nje date te caktuar te zgjedhur me DateTimePicker e formes
                DataTable date_rates = Lidhja.Kerkesat1.a.getRatesFromDate(this.dateTimePicker1.Value.ToString("dd/MM/yyyy")).Copy();
                if (!(date_rates.Rows.Count > 0))
                {
                    //nese nuk ka rekorde, nuk kemi patur kurs per ate date
                    MessageBox.Show("Nuk ka kurs te percaktuar per daten e zgjedhur!");
                }
                else
                {
                    //nese ka, ekzekutojme proceduren ne SQL qe ben kalimin e kursit te atehershem ne daten e sotme
                    Lidhja.Kerkesat1.a.importRateFromDate(this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"));
                    MessageBox.Show("Kursi u importua me sukses sipas dates " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + ".");
                }
            }
        }//COMM

        private void konfirmoBtnFile_Click(object sender, EventArgs e)
        {
            //supozohet te kete dhe import nga Excel, por thjesht supozohet
            OpenFileDialog d = new OpenFileDialog();
            d.ShowDialog();
        }//COMM

        void d_FileOk(object sender, CancelEventArgs e)
        {
            //FileStream tmp = File.OpenRead(((OpenFileDialog)(sender)).File.FileName);

            ////FileStream tmp = File.Open(@"C:/MyExchange.xls", FileMode.Create);

            //ExcelWriter ew = new ExcelWriter(tmp);
            //ew.BeginWrite();
            
            //ew.

            //ew.EndWrite();
            //tmp.Close();
        }


    }
}