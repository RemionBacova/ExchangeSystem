#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Threading;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace ExchangeOnline
{
    public partial class Form1 : Form
    {
        public Form klient;
        public string user_id = "-1";
        Thread a;
        Thread b;

        public bool isKasier = true;

        #region temporary_visual_elements
        Label l = new Label()
        {
            Text = "Duke Ngarkuar Te Dhenat...",
            Top = 30,
            Left = 10,
            Font = new System.Drawing.Font(new FontFamily("Tahoma"), 10, FontStyle.Bold),
            Width = 200
        };
        ProgressBar pb = new ProgressBar()
        {
            Dock = DockStyle.Top
        };
        Label l2 = new Label()
        {
            Text = "Duke Ngarkuar Te Dhenat...",
            Top = 30,
            Left = 10,
            Font = new System.Drawing.Font(new FontFamily("Tahoma"), 10, FontStyle.Bold),
            Width = 200
        };
        ProgressBar pb2 = new ProgressBar()
        {
            Dock = DockStyle.Top
        };
        #endregion

        public bool timer_needed = false;
        public bool grid1_loaded = true;
        public bool grid2_loaded = true;

        public Form1()
        {
            InitializeComponent();
            disableAllMenuItems();
            loadLoginForm();
            loadThreaded();
            //loadGrids();
        }

        public void loadGrids()
        {
            getHTMLElementStringArray();
            getFromYahoo();
            //getFromBankaEuropiane();
        }

        public void loadThreaded()
        {
            timer_needed = true;
            if (a != null)
            {
                if (a.IsAlive)
                {
                    a.Abort();
                    resetGridView();
                }
            }
            if (b != null)
            {
                if (b.IsAlive)
                {
                    b.Abort();
                    resetGridView2();
                }
            }
            a = new Thread(new ThreadStart(this.getFromYahoo));
            this.radGridView1.Dock = DockStyle.None;
            this.radGridView1.Visible = false;
            this.tabPage1.Controls.Add(l);
            this.tabPage1.Controls.Add(pb);

            b = new Thread(new ThreadStart(this.getHTMLElementStringArray));
            this.radGridView2.Dock = DockStyle.None;
            this.radGridView2.Visible = false;
            this.tabPage2.Controls.Add(l2);
            this.tabPage2.Controls.Add(pb2);

            grid1_loaded = false;
            grid2_loaded = false;
            //t timer
            //t.Start();
            a.Start();
            b.Start();
        }

        public void enableAllMenuItems()
        {
            monedhatToolStripMenuItem.Enabled = true;
            manaxhoMonedhatToolStripMenuItem.Enabled = true;
            manaxhoKursinToolStripMenuItem.Enabled = true;
            manaxhoPrerjetToolStripMenuItem.Enabled = true;
            gjendjaToolStripMenuItem.Enabled = true;
            //minimalDenominationToolStripMenuItem.Enabled = true;
            perdoruesitToolStripMenuItem.Enabled = true;
            manaxhoPerdoruesitToolStripMenuItem.Enabled = true;
            loginToolStripMenuItem.Enabled = true;
            logoutToolStripMenuItem.Enabled = true;
            arkatToolStripMenuItem.Enabled = true;
            manaxhoArkatToolStripMenuItem.Enabled = true;
            kasaToolStripMenuItem.Enabled = true;
            kasaToolStripMenuItem1.Enabled = true;
            veprimetToolStripMenuItem.Enabled = true;
            paneliIVeprimeveToolStripMenuItem.Enabled = true;
            caktoArkatToolStripMenuItem.Enabled = true;
            raportetToolstripMenuItem.Enabled = true;

            kasaIcon.Enabled = true;
            kasaIcon.BackColor = Color.White;
            kasieriLbl.ForeColor = SystemColors.ControlText;
            transaksionetIcon.Enabled = true;
            transaksionetIcon.BackColor = Color.White;
            transaksioneLbl.ForeColor = SystemColors.ControlText;
            monedhatIcon.Enabled = true;
            monedhatIcon.BackColor = Color.White;
            monedhaLbl.ForeColor = SystemColors.ControlText;
            kursiIcon.Enabled = true;
            kursiIcon.BackColor = Color.White;
            kursiLbl.ForeColor = SystemColors.ControlText;
            prerjetIcon.Enabled = true;
            prerjetIcon.BackColor = Color.White;
            prerjetLbl.ForeColor = SystemColors.ControlText;
            gjendjaIcon.Enabled = true;
            gjendjaIcon.BackColor = Color.White;
            gjendjaLbl.ForeColor = SystemColors.ControlText;
            perdoruesitIcon.Enabled = true;
            perdoruesitIcon.BackColor = Color.White;
            perdoruesitLbl.ForeColor = SystemColors.ControlText;
            shperndarjeIcon.Enabled = true;
            shperndarjeIcon.BackColor = Color.White;
            shperndarjaLbl.ForeColor = SystemColors.ControlText;
            arkaIcon.Enabled = true;
            arkaIcon.BackColor = Color.White;
            arkaLbl.ForeColor = SystemColors.ControlText;
            loginIcon.Enabled = true;
            loginIcon.BackColor = Color.White;
            hyrjeLbl.ForeColor = SystemColors.ControlText;
            logoutIcon.Enabled = true;
            logoutIcon.BackColor = Color.White;
            daljeLbl.ForeColor = SystemColors.ControlText;
            infoIcon.Enabled = true;
            infoIcon.BackColor = Color.White;
            infoLbl.ForeColor = SystemColors.ControlText;
            raportetIcon.Enabled = true;
            raportetIcon.BackColor = Color.White;
            raportetLbl.ForeColor = SystemColors.ControlText;

            this.panel1.Height = 75;
        }

        public void disableAllMenuItems()
        {
            monedhatToolStripMenuItem.Enabled = false;
            manaxhoMonedhatToolStripMenuItem.Enabled = false;
            manaxhoKursinToolStripMenuItem.Enabled = false;
            manaxhoPrerjetToolStripMenuItem.Enabled = false;
            gjendjaToolStripMenuItem.Enabled = false;
            //minimalDenominationToolStripMenuItem.Enabled = false;
            perdoruesitToolStripMenuItem.Enabled = true;
            manaxhoPerdoruesitToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Enabled = true;
            logoutToolStripMenuItem.Enabled = false;
            arkatToolStripMenuItem.Enabled = false;
            manaxhoArkatToolStripMenuItem.Enabled = false;
            kasaToolStripMenuItem.Enabled = false;
            kasaToolStripMenuItem1.Enabled = false;
            veprimetToolStripMenuItem.Enabled = false;
            paneliIVeprimeveToolStripMenuItem.Enabled = false;
            caktoArkatToolStripMenuItem.Enabled = false;
            raportetToolstripMenuItem.Enabled = false;

            kasaIcon.Enabled = false;
            kasaIcon.BackColor = Color.Silver;
            kasieriLbl.ForeColor = SystemColors.ControlDarkDark;
            transaksionetIcon.Enabled = false;
            transaksionetIcon.BackColor = Color.Silver;
            transaksioneLbl.ForeColor = SystemColors.ControlDarkDark;
            monedhatIcon.Enabled = false;
            monedhatIcon.BackColor = Color.Silver;
            monedhaLbl.ForeColor = SystemColors.ControlDarkDark;
            kursiIcon.Enabled = false;
            kursiIcon.BackColor = Color.Silver;
            kursiLbl.ForeColor = SystemColors.ControlDarkDark;
            prerjetIcon.Enabled = false;
            prerjetIcon.BackColor = Color.Silver;
            prerjetLbl.ForeColor = SystemColors.ControlDarkDark;
            gjendjaIcon.Enabled = false;
            gjendjaIcon.BackColor = Color.Silver;
            gjendjaLbl.ForeColor = SystemColors.ControlDarkDark;
            perdoruesitIcon.Enabled = false;
            perdoruesitIcon.BackColor = Color.Silver;
            perdoruesitLbl.ForeColor = SystemColors.ControlDarkDark;
            shperndarjeIcon.Enabled = false;
            shperndarjeIcon.BackColor = Color.Silver;
            shperndarjaLbl.ForeColor = SystemColors.ControlDarkDark;
            arkaIcon.Enabled = false;
            arkaIcon.BackColor = Color.Silver;
            arkaLbl.ForeColor = SystemColors.ControlDarkDark; 
            loginIcon.Enabled = true;
            loginIcon.BackColor = Color.White;
            hyrjeLbl.ForeColor = SystemColors.ControlText;
            logoutIcon.Enabled = false;
            logoutIcon.BackColor = Color.Silver;
            daljeLbl.ForeColor = SystemColors.ControlDarkDark;
            infoIcon.Enabled = true;
            infoIcon.BackColor = Color.White;
            infoLbl.ForeColor = SystemColors.ControlText;
            raportetIcon.Enabled = false;
            raportetIcon.BackColor = Color.Silver;
            raportetLbl.ForeColor = SystemColors.ControlDarkDark;

            this.panel1.Height = 0;
        }

        public void enableCashierMenuItems()
        {
            monedhatToolStripMenuItem.Enabled = false;
            manaxhoMonedhatToolStripMenuItem.Enabled = false;
            manaxhoKursinToolStripMenuItem.Enabled = false;
            manaxhoPrerjetToolStripMenuItem.Enabled = false;
            gjendjaToolStripMenuItem.Enabled = false;
            //minimalDenominationToolStripMenuItem.Enabled = false;
            perdoruesitToolStripMenuItem.Enabled = true;
            manaxhoPerdoruesitToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Enabled = true;
            logoutToolStripMenuItem.Enabled = true;
            arkatToolStripMenuItem.Enabled = false;
            manaxhoArkatToolStripMenuItem.Enabled = false;
            kasaToolStripMenuItem.Enabled = true;
            kasaToolStripMenuItem1.Enabled = true;
            veprimetToolStripMenuItem.Enabled = false;
            paneliIVeprimeveToolStripMenuItem.Enabled = false;
            caktoArkatToolStripMenuItem.Enabled = false;
            raportetToolstripMenuItem.Enabled = false;

            kasaIcon.Enabled = true;
            kasaIcon.BackColor = Color.White;
            kasieriLbl.ForeColor = SystemColors.ControlText;
            transaksionetIcon.Enabled = true;
            transaksionetIcon.BackColor = Color.White;
            transaksioneLbl.ForeColor = SystemColors.ControlText;
            monedhatIcon.Enabled = false;
            monedhatIcon.BackColor = Color.Silver;
            monedhaLbl.ForeColor = SystemColors.ControlDarkDark;
            kursiIcon.Enabled = false;
            kursiIcon.BackColor = Color.Silver;
            kursiLbl.ForeColor = SystemColors.ControlDarkDark;
            prerjetIcon.Enabled = false;
            prerjetIcon.BackColor = Color.Silver;
            prerjetLbl.ForeColor = SystemColors.ControlDarkDark;
            gjendjaIcon.Enabled = false;
            gjendjaIcon.BackColor = Color.Silver;
            gjendjaLbl.ForeColor = SystemColors.ControlDarkDark;
            perdoruesitIcon.Enabled = false;
            perdoruesitIcon.BackColor = Color.Silver;
            perdoruesitLbl.ForeColor = SystemColors.ControlDarkDark;
            shperndarjeIcon.Enabled = false;
            shperndarjeIcon.BackColor = Color.Silver;
            shperndarjaLbl.ForeColor = SystemColors.ControlDarkDark;
            arkaIcon.Enabled = false;
            arkaIcon.BackColor = Color.Silver;
            arkaLbl.ForeColor = SystemColors.ControlDarkDark;
            loginIcon.Enabled = true;
            loginIcon.BackColor = Color.White;
            hyrjeLbl.ForeColor = SystemColors.ControlText;
            logoutIcon.Enabled = true;
            logoutIcon.BackColor = Color.White;
            daljeLbl.ForeColor = SystemColors.ControlText;
            infoIcon.Enabled = true;
            infoIcon.BackColor = Color.White;
            infoLbl.ForeColor = SystemColors.ControlText;
            raportetIcon.Enabled = false;
            raportetIcon.BackColor = Color.Silver;
            raportetLbl.ForeColor = SystemColors.ControlDarkDark;

            this.panel1.Height = 75;
        }

        public void loadExchangeRate()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new ExchangeRate();
            klient.MdiParent = this;
            klient.Show();
        }

        private void loadUserArka()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new UserArka();
            klient.MdiParent = this;
            klient.Show();
        }

        private void loadRaportet()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new Raportet();
            klient.MdiParent = this;
            klient.Show();
        }

        private void loadCurrencyManager()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new Currencies();
            klient.MdiParent = this;
            klient.Show();
        }

        private void loadCCManager()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new Arkat();
            klient.MdiParent = this;
            klient.Show();
        }

        //private void loadMinDenom()
        //{
        //    if (klient != null)
        //    {
        //        if (!klient.IsDisposed)
        //        {
        //            klient.Close();
        //            klient.Dispose();
        //        }
        //    }
        //    klient = new MinimalDenomination();
        //    klient.MdiParent = this;
        //    klient.BringToFront();
        //    klient.Show();
        //}

        private void loadUsers()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new Users();
            klient.MdiParent = this;
            klient.Show();
        }

        private void loadCashiersInterface()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new Cashier(this.user_id);
            klient.MdiParent = this;
            klient.Show();
        }

        private void loadPrerjet()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new Prjerjet();
            klient.MdiParent = this;
            klient.Show();
        }

        private void loadPrerjetManager()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new PrerjetManage();
            klient.MdiParent = this;
            klient.Show();
        }

        private void loadLoginForm()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new Login();
            klient.MdiParent = this;
            klient.StartPosition = FormStartPosition.CenterParent;
            klient.Show();
        }

        private void loadTransaksionet()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new Faturat(this.isKasier, this.user_id);
            klient.MdiParent = this;
            klient.Show();
        }

        private void loadAbout()
        {
            if (klient != null)
            {
                if (!klient.IsDisposed)
                {
                    klient.Close();
                    klient.Dispose();
                }
            }
            klient = new About();
            klient.MdiParent = this;
            klient.Show();
        }

        public void loginSystem()
        {
            this.Text = "MyExchange / SYSTEM ADMIN";
            this.user_id = "0";
            enableAllMenuItems();
        }

        public void login(DataTable user_info)
        {
            
            this.Text = "MyExchange / " + user_info.Rows[0].ItemArray[1].ToString() + " " + user_info.Rows[0].ItemArray[2].ToString();
            this.user_id = user_info.Rows[0].ItemArray[0].ToString();
            switch (user_info.Rows[0].ItemArray[6].ToString())
            {
                case "Kasier":
                    {
                        enableCashierMenuItems();
                        this.isKasier = true;
                        break;
                    }
                case "Admin":
                    {
                        enableAllMenuItems();
                        this.isKasier = false;
                        break;
                    }
                default:
                    {
                        //nuk duhet te kete rekord me tjeter vlere ne DB per kolonen Roli
                        break;
                    }
            }
        }

        private void manaxhoMonedhatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadCurrencyManager();
        }

        private void manaxhoKursinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadExchangeRate();
        }

        private void manaxhoPrerjetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadPrerjetManager();
        }

        private void gjendjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadPrerjet();
        }

        private void manaxhoPerdoruesitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadUsers();
        }

        private void manaxhoArkatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadCCManager();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Jeni te sigurt qe doni te dilni nga sistemi?", "Logout", MessageBoxButtons.YesNo, new EventHandler(logoutAccepted));
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadLoginForm();
        }

        private void kasaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadCashiersInterface();
        }

        private void rrethNeshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadAbout();
        }

        private void paneliIVeprimeveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadTransaksionet();
        }

        private void caktoArkatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadUserArka();
        }

        private void kasaIcon_Click(object sender, EventArgs e)
        {
            loadCashiersInterface();
        }

        private void transaksionetIcon_Click(object sender, EventArgs e)
        {
            loadTransaksionet();
        }

        private void monedhatIcon_Click(object sender, EventArgs e)
        {
            loadCurrencyManager();
        }

        private void kursiIcon_Click(object sender, EventArgs e)
        {
            loadExchangeRate();
        }

        private void prerjetIcon_Click(object sender, EventArgs e)
        {
            loadPrerjetManager();
        }

        private void gjendjaIcon_Click(object sender, EventArgs e)
        {
            loadPrerjet();
        }

        private void perdoruesitIcon_Click(object sender, EventArgs e)
        {
            loadUsers();
        }

        private void shperndarjeIcon_Click(object sender, EventArgs e)
        {
            loadUserArka();
        }

        private void arkaIcon_Click(object sender, EventArgs e)
        {
            loadCCManager();
        }

        private void loginIcon_Click(object sender, EventArgs e)
        {
            loadLoginForm();
        }

        private void logoutIcon_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Jeni te sigurt qe doni te dilni nga sistemi?", "Logout", MessageBoxButtons.YesNo, new EventHandler(logoutAccepted));
        }

        private void logoutAccepted(object sender, EventArgs e)
        {
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                this.user_id = "-1";
                disableAllMenuItems();
                this.Text = "MyExchange";
            }
        }

        private void infoIcon_Click(object sender, EventArgs e)
        {
            loadAbout();
        }

        //DataTable bankaShqiperise;

        private void getHTMLElementStringArray()
        {
            WebClient client = new WebClient();
            string htmlSource = client.DownloadString(@"http://www.bankofalbania.org/web/Kursi_i_Kembimit_2014_1.php");
            htmlSource = htmlSource.ToUpper();
            //int numberOfElements = htmlSource.Where(x => x == '<').Count();

            int firstIndex = htmlSource.IndexOf("<TABLE class=\"tabcontent\"".ToUpper());
            htmlSource = htmlSource.Substring(firstIndex);
            int endIndex = htmlSource.IndexOf("</TABLE>".ToUpper());
            htmlSource = htmlSource.Substring(0, endIndex + "</TABLE>".Length);

            DataTable bankaShqiperise = new DataTable();
            bankaShqiperise.Columns.Add("Monedha");
            bankaShqiperise.Columns.Add("Kursi");

            //find tr, insert tr into datatable, delete tr
            int total = htmlSource.Length;
            while (htmlSource.Contains("<TR>".ToUpper()))
            {
                string curr_row;
                int firstRow = htmlSource.IndexOf("<TR>".ToUpper());
                int lastRow = htmlSource.IndexOf("</TR>".ToUpper());
                curr_row = htmlSource.Substring(firstRow, lastRow).ToUpper();

                if (curr_row.Contains("Përditesimi i fundit".ToUpper()) || curr_row.Contains("Lekë për njësi të monedhës së huaj".ToUpper()))
                {
                    htmlSource = htmlSource.Replace(curr_row, "");
                    continue;
                }
                else
                {
                    string emertimi = "";
                    string monedha = "";
                    string kursi = "";
                    htmlSource = htmlSource.Substring(lastRow + "</TR>".Length);
                    bool same_name = false;
                    for (int i = 0; i < 3; i++)
                    {
                        int firstDef = curr_row.IndexOf("<TD");
                        string curr_def = curr_row.Substring(firstDef);
                        int firstEnd = curr_def.IndexOf(">");
                        string auxillary_string = curr_row.Substring(firstDef, firstEnd + 1);
                        curr_def = curr_def.Substring(firstEnd);
                        int lastDef = curr_def.IndexOf("</TD>");
                        curr_def = curr_def.Substring(1, lastDef - 1);
                        if (curr_row.IndexOf(auxillary_string + curr_def + "</TD>") != curr_row.LastIndexOf(auxillary_string + curr_def + "</TD>"))
                        {
                            same_name = true;
                        }
                        curr_row = curr_row.Replace(auxillary_string + curr_def + "</TD>", "");
                        switch (i)
                        {
                            case 0:
                                {
                                    emertimi = curr_def;
                                    break;
                                }
                            case 1:
                                {
                                    monedha = curr_def;
                                    break;
                                }
                            case 2:
                                {
                                    kursi = curr_def;
                                    break;
                                }
                            default:
                                {

                                    break;
                                }
                        }
                    }
                    if (!same_name)
                    {
                        bankaShqiperise.Rows.Add(emertimi + " (" + monedha + ")", kursi.Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator));
                        this.pb2.Value = 100 - (int)((float)((float)htmlSource.Length / (float)total) * 100);
                    }
                    else
                    {
                        bankaShqiperise.Rows.Add(emertimi, monedha);
                        this.pb2.Value = 100 - (int)((float)((float)htmlSource.Length / (float)total) * 100);
                    }
                }
            }

            this.radGridView2.DataSource = bankaShqiperise;
            this.radGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resetGridView2();
        }

        [Obsolete]
        private void getFromBankaEuropiane()
        {
            //further implementation
            //
            //

            XmlDocument doc = new XmlDocument();
            string xmlEuropeanBank = @"http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml";
            WebClient wc = new WebClient();
            string xmlBuilder = wc.DownloadString(xmlEuropeanBank);

            xmlBuilder = xmlBuilder.Substring(xmlBuilder.IndexOf(@"<Cube>"));

            DataTable testing = new DataTable();
            testing.ReadXml(xmlBuilder);
        }

        public void getFromYahoo()
        {
            try
            {
                DataTable kursi = new DataTable();
                kursi.Columns.Add("id_monedha");
                kursi.Columns.Add("Monedha");
                kursi.Columns.Add("Kursi");
                DataTable monedhat = Lidhja.Kerkesat1.a.selectAllRecFromTable("monedhat").Copy();
                pb.Step = (int)((((float)1) / (float)(monedhat.Rows.Count)) * 100);
                for (int i = 0; i < monedhat.Rows.Count; i++)
                {
                    string uri = @"http://finance.yahoo.com/d/quotes.txt?e=.csv&f=l1&s=" + monedhat.Rows[i].ItemArray[1].ToString() + "ALL=X";

                    WebClient client = new WebClient();
                    string curr = client.DownloadString(uri);
                    curr = curr.Replace("\n", "").Replace("\r", "").Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);

                    float z;
                    string line_read = curr;
                    if (float.TryParse(line_read, out z))
                    {
                        float rate = float.Parse(line_read);
                        if (rate != 0)
                        {
                            //insert into datatable
                            kursi.Rows.Add(monedhat.Rows[i].ItemArray[0].ToString(), monedhat.Rows[i].ItemArray[1].ToString(), rate.ToString());
                            pb.PerformStep();
                        }
                        else
                        {
                            //dont insert into datatable
                        }
                    }
                }
                this.radGridView1.DataSource = kursi;
                this.radGridView1.Columns[0].Visible = false;
                this.radGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                resetGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nuk mund te merren te dhenat ne kete moment!");
            }
        }

        public void resetGridView()
        {
            this.tabPage1.Controls.Remove(l);
            this.tabPage1.Controls.Remove(pb);
            pb.Value = 0;
            this.radGridView1.Visible = true;
            this.radGridView1.Dock = DockStyle.Fill;
            this.panel2.Update();
            this.tabControl1.Update();
            this.radGridView1.Update();
            grid1_loaded = true;
        }

        public void resetGridView2()
        {
            this.tabPage2.Controls.Remove(l2);
            this.tabPage2.Controls.Remove(pb2);
            pb2.Value = 0;
            this.radGridView2.Visible = true;
            this.radGridView2.Dock = DockStyle.Fill;
            this.panel2.Update();
            this.tabControl1.Update();
            this.radGridView2.Update();
            grid2_loaded = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //loadGrids();
        }

        public void importFromYahoo(string destination, string shitje_blerje)
        {
            string selectFirst = "select * from " + destination + " where aktiv = 1 and DataKrijimit = CONVERT(date, '" + DateTime.Now.ToString("dd/MM/yyyy") + "', + 103)";
            DataTable current_values = Lidhja.Kerkesat1.a.excecuteScript(selectFirst).Copy();
            List<string> val = new List<string>();
            for (int i = 0; i < current_values.Rows.Count; i++)
            {
                val.Add(current_values.Rows[i].ItemArray[1].ToString());
            }

            string script = "";
            for (int i = 0; i < this.radGridView1.Rows.Count; i++)
            {
                bool insert = (from v in val where v == this.radGridView1.Rows[i].Cells[0].Value.ToString() select v).Count<string>() == 0;
                var tmp = (from field 
                            in current_values.AsEnumerable() 
                            where field.Field<int>("id_curr") == int.Parse(this.radGridView1.Rows[i].Cells[0].Value.ToString()) &&
                            field.Field<bool>("aktiv") == true
                            select field);
                DataTable c = (tmp.Count<DataRow>() == 0 ? new DataTable() : tmp.CopyToDataTable<DataRow>());
                
                if (!insert)
                {
                    script += @"insert into " + destination + " (id_curr, Blerje, Shitje, Aktiv, DataKrijimit)" +
                        "select id_curr, Blerje, Shitje, 0, DataKrijimit from " + destination + " where id = " + c.Rows[0].ItemArray[0].ToString() + ";";
                    script += "update " + destination + " set " + shitje_blerje + "=" + this.radGridView1.Rows[i].Cells[2].Value.ToString() +
                        ", DataKrijimit = CONVERT(date, '" + DateTime.Now.ToString("dd/MM/yyyy") + "', 103) where id = " + c.Rows[0].ItemArray[0].ToString() + ";";
                }
                else
                {
                    script += @"insert into " + destination + " (id_curr, " + shitje_blerje + ", Aktiv, DataKrijimit)" +
                        "values (" + this.radGridView1.Rows[i].Cells[0].Value.ToString() + ", " + this.radGridView1.Rows[i].Cells[2].Value.ToString() + ", 1, CONVERT(date, '" + DateTime.Now.ToString("dd/MM/yyyy") + "', 103));";
                }
            }
            Lidhja.Kerkesat1.a.excecuteInsertScript(script);
            MessageBox.Show("Importi i te dhenave u krye me sukses.");
        }

        private void raportetToolstripMenuItem_Click(object sender, EventArgs e)
        {
            loadRaportet();
        }

        private void raportetIcon_Click(object sender, EventArgs e)
        {
            loadRaportet();
        }
    }
}