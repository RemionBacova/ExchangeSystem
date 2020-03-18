using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml;

namespace Exchange
{
    public partial class Form1 : Form
    {
        Form klient;
        public string user_id = "-1";
        public Form1()
        {
            InitializeComponent();
            this.Text = "MyExchange";
            disableAllMenuItems();
            loadLoginForm();


            getHTMLElementStringArray();
            //getFromBankaEuropiane();
        }

        private void loadExchangeRate()
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
        }//ok

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
        }//ok

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
        }//ok

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
        }//ok

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
        }//ok

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
        }//ok

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
            klient = new Prerjet();
            klient.MdiParent = this;
            klient.Show();
        }//ok

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
        }//ok

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
        }//ok

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
            klient = new Faturat();
            klient.MdiParent = this;
            klient.Show();
        }//ok

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
        }//ok

        private void manaxhoMonedhatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadCurrencyManager();
        }//ok

        private void manaxhoKursinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadExchangeRate();
        }//ok

        private void manaxhoPrerjetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadPrerjetManager();
        }//ok

        private void gjendjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadPrerjet();
        }//ok

        private void manaxhoPerdoruesitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadUsers();
        }//ok

        private void manaxhoArkatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadCCManager();
        }//ok

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Jeni te sigurt qe doni te dilni nga sistemi?", "", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                //logout
                this.user_id = "-1";
                disableAllMenuItems();
                this.Text = "MyExchange";
            }
        }//ok

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

            kasaIcon.Enabled = true;
            kasaIcon.BackColor = Color.White;
            //kasieriLbl.ForeColor = SystemColors.ControlText;
            transaksionetIcon.Enabled = true;
            transaksionetIcon.BackColor = Color.White;
            //transaksioneLbl.ForeColor = SystemColors.ControlText;
            monedhatIcon.Enabled = true;
            monedhatIcon.BackColor = Color.White;
            //monedhaLbl.ForeColor = SystemColors.ControlText;
            kursiIcon.Enabled = true;
            kursiIcon.BackColor = Color.White;
            //kursiLbl.ForeColor = SystemColors.ControlText;
            prerjetIcon.Enabled = true;
            prerjetIcon.BackColor = Color.White;
            //prerjetLbl.ForeColor = SystemColors.ControlText;
            gjendjaIcon.Enabled = true;
            gjendjaIcon.BackColor = Color.White;
            //gjendjaLbl.ForeColor = SystemColors.ControlText;
            perdoruesitIcon.Enabled = true;
            perdoruesitIcon.BackColor = Color.White;
            //perdoruesitLbl.ForeColor = SystemColors.ControlText;
            shperndarjeIcon.Enabled = true;
            shperndarjeIcon.BackColor = Color.White;
            //shperndarjaLbl.ForeColor = SystemColors.ControlText;
            arkaIcon.Enabled = true;
            arkaIcon.BackColor = Color.White;
            //arkaLbl.ForeColor = SystemColors.ControlText;
            loginIcon.Enabled = true;
            loginIcon.BackColor = Color.White;
            //hyrjeLbl.ForeColor = SystemColors.ControlText;
            logoutIcon.Enabled = true;
            logoutIcon.BackColor = Color.White;
            //daljeLbl.ForeColor = SystemColors.ControlText;
            infoIcon.Enabled = true;
            infoIcon.BackColor = Color.White;
            //infoLbl.ForeColor = SystemColors.ControlText;

            this.panel1.Height = 75;
        }//ok

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

            kasaIcon.Enabled = false;
            kasaIcon.BackColor = Color.Silver;
            //kasieriLbl.ForeColor = SystemColors.ControlDarkDark;
            transaksionetIcon.Enabled = false;
            transaksionetIcon.BackColor = Color.Silver;
            //transaksioneLbl.ForeColor = SystemColors.ControlDarkDark;
            monedhatIcon.Enabled = false;
            monedhatIcon.BackColor = Color.Silver;
            //monedhaLbl.ForeColor = SystemColors.ControlDarkDark;
            kursiIcon.Enabled = false;
            kursiIcon.BackColor = Color.Silver;
            //kursiLbl.ForeColor = SystemColors.ControlDarkDark;
            prerjetIcon.Enabled = false;
            prerjetIcon.BackColor = Color.Silver;
            //prerjetLbl.ForeColor = SystemColors.ControlDarkDark;
            gjendjaIcon.Enabled = false;
            gjendjaIcon.BackColor = Color.Silver;
            //gjendjaLbl.ForeColor = SystemColors.ControlDarkDark;
            perdoruesitIcon.Enabled = false;
            perdoruesitIcon.BackColor = Color.Silver;
            //perdoruesitLbl.ForeColor = SystemColors.ControlDarkDark;
            shperndarjeIcon.Enabled = false;
            shperndarjeIcon.BackColor = Color.Silver;
            //shperndarjaLbl.ForeColor = SystemColors.ControlDarkDark;
            arkaIcon.Enabled = false;
            arkaIcon.BackColor = Color.Silver;
            //arkaLbl.ForeColor = SystemColors.ControlDarkDark; 
            loginIcon.Enabled = true;
            loginIcon.BackColor = Color.White;
            //hyrjeLbl.ForeColor = SystemColors.ControlText;
            logoutIcon.Enabled = false;
            logoutIcon.BackColor = Color.Silver;
            //daljeLbl.ForeColor = SystemColors.ControlDarkDark;
            infoIcon.Enabled = true;
            infoIcon.BackColor = Color.White;
            //infoLbl.ForeColor = SystemColors.ControlText;

            this.panel1.Height = 0;
        }//ok

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

            kasaIcon.Enabled = true;
            kasaIcon.BackColor = Color.White;
            //kasieriLbl.ForeColor = SystemColors.ControlText;
            transaksionetIcon.Enabled = false;
            transaksionetIcon.BackColor = Color.Silver;
            //transaksioneLbl.ForeColor = SystemColors.ControlDarkDark;
            monedhatIcon.Enabled = false;
            monedhatIcon.BackColor = Color.Silver;
            //monedhaLbl.ForeColor = SystemColors.ControlDarkDark;
            kursiIcon.Enabled = false;
            kursiIcon.BackColor = Color.Silver;
            //kursiLbl.ForeColor = SystemColors.ControlDarkDark;
            prerjetIcon.Enabled = false;
            prerjetIcon.BackColor = Color.Silver;
            //prerjetLbl.ForeColor = SystemColors.ControlDarkDark;
            gjendjaIcon.Enabled = false;
            gjendjaIcon.BackColor = Color.Silver;
            //gjendjaLbl.ForeColor = SystemColors.ControlDarkDark;
            perdoruesitIcon.Enabled = false;
            perdoruesitIcon.BackColor = Color.Silver;
            //perdoruesitLbl.ForeColor = SystemColors.ControlDarkDark;
            shperndarjeIcon.Enabled = false;
            shperndarjeIcon.BackColor = Color.Silver;
            //shperndarjaLbl.ForeColor = SystemColors.ControlDarkDark;
            arkaIcon.Enabled = false;
            arkaIcon.BackColor = Color.Silver;
            //arkaLbl.ForeColor = SystemColors.ControlDarkDark;
            loginIcon.Enabled = true;
            loginIcon.BackColor = Color.White;
            //hyrjeLbl.ForeColor = SystemColors.ControlText;
            logoutIcon.Enabled = true;
            logoutIcon.BackColor = Color.White;
            //daljeLbl.ForeColor = SystemColors.ControlText;
            infoIcon.Enabled = true;
            infoIcon.BackColor = Color.White;
            //infoLbl.ForeColor = SystemColors.ControlText;

            this.panel1.Height = 75;
        }//ok

        public void login(DataTable user_info)
        {
            this.Text = "MyExchange / " + user_info.Rows[0].ItemArray[1].ToString() + " " + user_info.Rows[0].ItemArray[2].ToString();
            this.user_id = user_info.Rows[0].ItemArray[0].ToString();
            switch (user_info.Rows[0].ItemArray[6].ToString())
            {
                case "Cashier":
                    {
                        enableCashierMenuItems();
                        break;
                    }
                case "Admin":
                    {
                        enableAllMenuItems();
                        break;
                    }
                default:
                    {
                        //nuk duhet te kete rekord me tjeter vlere ne DB per kolonen Roli
                        break;
                    }
            }
        }//ok

        public void loginSystem()
        {
            this.Text = "MyExchange / SYSTEM ADMIN";
            this.user_id = "0";
            enableAllMenuItems();
        }//ok

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadLoginForm();
        }//ok

        private void kasaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadCashiersInterface();
        }//ok

        private void rrethNeshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadAbout();
        }//ok

        private void paneliIVeprimeveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadTransaksionet();
        }//ok

        private void Form1_Load(object sender, EventArgs e)
        {
            staticWindow sw = new staticWindow();
            sw.MdiParent = this;
            sw.Text = "Info";
            sw.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            sw.StartPosition = FormStartPosition.Manual;
            sw.Left = 30;
            sw.Top = this.Height - sw.Height - 75;
            sw.WindowState = FormWindowState.Normal;
            sw.FormClosed += new FormClosedEventHandler(sw_FormClosed);
            sw.Show();
        }

        void sw_FormClosed(object sender, FormClosedEventArgs e)
        {
            staticWindow sw = new staticWindow();
            sw.MdiParent = this;
            sw.Text = "Info";
            sw.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            sw.StartPosition = FormStartPosition.Manual;
            sw.Left = 30;
            sw.Top = this.Height - sw.Height - 75;
            sw.WindowState = FormWindowState.Normal;
            sw.FormClosed += new FormClosedEventHandler(sw_FormClosed);
            sw.Show();
        }

        private void caktoArkatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadUserArka();
        }//ok

        private void kasaIcon_Click(object sender, EventArgs e)
        {
            loadCashiersInterface();
        }//ok

        private void button1_Click(object sender, EventArgs e)
        {
            loadTransaksionet();
        }//ok

        private void button2_Click(object sender, EventArgs e)
        {
            loadCurrencyManager();
        }//ok

        private void kursiIcon_Click(object sender, EventArgs e)
        {
            loadExchangeRate();
        }//ok

        private void prerjetIcon_Click(object sender, EventArgs e)
        {
            loadPrerjetManager();
        }//ok

        private void gjendjaIcon_Click(object sender, EventArgs e)
        {
            loadPrerjet();
        }//ok

        private void perdoruesitIcon_Click(object sender, EventArgs e)
        {
            loadUsers();
        }//ok

        private void shperndarjeIcon_Click(object sender, EventArgs e)
        {
            loadUserArka();
        }//ok

        private void arkaIcon_Click(object sender, EventArgs e)
        {
            loadCCManager();
        }//ok

        private void loginIcon_Click(object sender, EventArgs e)
        {
            loadLoginForm();
        }//ok

        private void logoutIcon_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Jeni te sigurt qe doni te dilni nga sistemi?", "", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                //logout
                this.user_id = "-1";
                disableAllMenuItems();
                this.Text = "MyExchange";
            }
        }//ok

        private void infoIcon_Click(object sender, EventArgs e)
        {
            loadAbout();
        }

        DataTable bankaShqiperise;

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

            bankaShqiperise = new DataTable();
            bankaShqiperise.Columns.Add("Monedha");
            bankaShqiperise.Columns.Add("Kursi");

            //find tr, insert tr into datatable, delete tr
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
                        bankaShqiperise.Rows.Add(emertimi + " (" + monedha + ")", kursi);
                    }
                    else
                    {
                        bankaShqiperise.Rows.Add(emertimi, monedha);
                    }
                }
            }

            this.radGridView1.DataSource = bankaShqiperise;
            this.radGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        private void getFromBankaEuropiane()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            // doc.LoadXml(stringXml);

            DataTable dt = new DataTable();

            if (doc.ChildNodes[1] != null)
                dt.Columns.Add(doc.ChildNodes[1].Name); //Assuming you want the rood node to be the only column of the datatable

            //iterate through all the childnodes of your root i.e. Category
            foreach (XmlNode node in doc.ChildNodes[1].ChildNodes)
            {
                dt.Rows.Add(node.Name);
            }
            MessageBox.Show(dt.Rows[0].ItemArray[0].ToString());
        }
    }
}


/// echange web service http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml