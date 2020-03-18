using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exchange
{
    public partial class Cashier : Form
    {
        #region declaration_section
        dbconnection db = new dbconnection();
        bool loadOk1 = false;
        bool loadOk2 = false;
        bool loadGridOk1 = false;
        bool loadGridOk2 = false;
        float blerje1;
        float shitje1;
        float blerje2;
        float shitje2;

        float kursi1 = 0;
        float kursi2 = 0;
        float min_denom;
        float curr_trans;

        int buttonCounter = 0;
        bool firstClicked = false;
        bool secondClicked = false;
        bool isFavouriteMode = true;
        string firstId = "";
        string secondId = "";
        string firstName = "";
        string secondName = "";

        string curr_out = "";
        string curr_in = "";

        bool isShitje = true;
        string blerje_shitje = "";
        bool isCustomRate = false;

        int oldIndex1 = -1;
        int oldIndex2 = -1;
        string oldId1 = "";
        string oldId2 = "";
        string oldName1 = "";
        string oldName2 = "";

        int initialWindowWidth;

        Telerik.WinControls.UI.GridViewTextBoxColumn emertimi1;
        Telerik.WinControls.UI.GridViewDecimalColumn number1;
        Telerik.WinControls.UI.GridViewDecimalColumn existing_number1;

        Telerik.WinControls.UI.GridViewTextBoxColumn emertimi2;
        Telerik.WinControls.UI.GridViewDecimalColumn number2;
        #endregion

        public Cashier(string user_id)
        {
            InitializeComponent();
            initialWindowWidth = this.Width;
            loadNgaNe();
            activateShitje();
            this.shitjeBlerjeLbl.Text = blerje_shitje;
            loadArka(user_id);
            disablePreferencial();
        }

        public void getGjendja(string monedha_id)
        {
            DataTable prerjet = db.selectPrerjet(monedha_id).Copy();
            DataTable gjendja = db.selectGjendjet(monedha_id, this.arkaBox.SelectedValue.ToString()).Copy();
            float sum = 0;
            if (prerjet.Rows.Count > 0)
            {
                if (gjendja.Rows.Count > 0)
                {
                    for (int i = 2; i < prerjet.Columns.Count; i++)
                    {
                        sum += float.Parse(prerjet.Rows[0].ItemArray[i].ToString()) * float.Parse(gjendja.Rows[0].ItemArray[i + 1].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Nuk ka gjendje fillestare te konfiguruar \n\rper monedhen e zgjedhur ne arken e zgjedhur!");
                }
            }
            else
            {
                MessageBox.Show("Nuk ka prerje te konfiguruara per monedhen e zgjedhur!");
            }
            this.gjendjaLbl.Text = sum.ToString("0.00");
        }

        public void fillGjendja()
        {
            loadGridOk1 = false;
            DataTable gjendjet = new DataTable();
            if (isFavouriteMode)
            {
                if (firstClicked)
                {
                    //gjendjet = db.selectPrerjet(firstId).Copy();
                    gjendjet = db.selectGjendjet(firstId, this.arkaBox.SelectedValue.ToString()).Copy();
                }
            }
            else
            {
                if (this.ngaBox.SelectedIndex > -1)
                {
                    gjendjet = db.selectGjendjet(this.ngaBox.SelectedValue.ToString(), this.arkaBox.SelectedValue.ToString()).Copy();
                }
            }
            if (gjendjet.Rows.Count > 0)
            {
                for (int i = 3; i < gjendjet.Columns.Count; i++)
                {
                    if (i - 3 < this.radGridView1.Rows.Count - 1)
                    {
                        this.radGridView1.Rows[i - 3].Cells[2].Value = gjendjet.Rows[0].ItemArray[i].ToString();
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                {
                    this.radGridView1.Rows[i].Cells[2].Value = 0;
                }
            }
            loadGridOk1 = true;
        }

        public void loadFirstGrid()
        {
            loadGridOk1 = false;
            DataTable prerjet = new DataTable();
            DataTable gjendja = new DataTable();
            if (isFavouriteMode)
            {
                if (firstClicked)
                {
                    prerjet = db.selectPrerjet(firstId).Copy();
                    getGjendja(firstId);
                    curr_out = firstId;
                }
            }
            else
            {
                if (this.ngaBox.SelectedIndex > -1)
                {
                    prerjet = db.selectPrerjet(this.ngaBox.SelectedValue.ToString()).Copy();
                    getGjendja(this.ngaBox.SelectedValue.ToString());
                }
            }

            this.radGridView1.Rows.Clear();
            this.radGridView1.Columns.Clear();

            emertimi1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            emertimi1.IsVisible = true;
            emertimi1.HeaderText = (isFavouriteMode ? firstName : this.ngaBox.Text);
            emertimi1.ReadOnly = true;

            number1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            number1.IsVisible = true;
            number1.HeaderText = "Sasia per Shitje";
            number1.ReadOnly = false;

            existing_number1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            existing_number1.IsVisible = true;
            existing_number1.HeaderText = "Sasia Aktuale";
            existing_number1.ReadOnly = true;

            this.radGridView1.Columns.Add(emertimi1);
            this.radGridView1.Columns.Add(number1);
            this.radGridView1.Columns.Add(existing_number1);

            this.radGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            for (int i = 2; i < prerjet.Columns.Count; i++)
            {
                if (int.Parse(prerjet.Rows[0].ItemArray[i].ToString()) != 0)
                {
                    this.radGridView1.Rows.Add(prerjet.Rows[0].ItemArray[i].ToString(), 0);
                }
            }
            this.radGridView1.Rows.Add("Totali", 0);
            this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].ReadOnly = true;
            fillGjendja();
            #region useless
            //else
            //{
            //    DataTable prerjet = new DataTable();
            //    if (isFavouriteMode)
            //    {
            //        if (secondClicked)
            //        {
            //            prerjet = db.selectPrerjet(firstId).Copy();
            //        }
            //    }
            //    else
            //    {
            //        if (this.neBox.SelectedIndex > -1)
            //        {
            //            prerjet = db.selectPrerjet(this.neBox.SelectedValue.ToString()).Copy();
            //        }
            //    }
            //    this.radGridView1.Rows.Clear();
            //    this.radGridView1.Columns.Clear();

            //    emertimi1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            //    emertimi1.IsVisible = true;
            //    emertimi1.HeaderText = (isFavouriteMode ? this.secondName : this.neBox.Text);
            //    emertimi1.ReadOnly = true;

            //    number1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            //    number1.IsVisible = true;
            //    number1.HeaderText = "Sasia per Shitje";
            //    number1.ReadOnly = false;

            //    //this.radGridView1.Columns.Add(id1);
            //    this.radGridView1.Columns.Add(emertimi1);
            //    this.radGridView1.Columns.Add(number1);

            //    this.radGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            //    for (int i = 2; i < prerjet.Columns.Count; i++)
            //    {
            //        if (int.Parse(prerjet.Rows[0].ItemArray[i].ToString()) != 0)
            //        {
            //            this.radGridView1.Rows.Add(prerjet.Rows[0].ItemArray[i].ToString(), 0);
            //        }
            //    }
            //    this.radGridView1.Rows.Add("Totali", 0);
            //}
            #endregion
            loadGridOk1 = true;
        }

        public void loadSecondGrid()
        {
            loadGridOk2 = false;
            DataTable prerjet = new DataTable();
            if (isFavouriteMode)
            {
                if (secondClicked)
                {
                    prerjet = db.selectPrerjet(secondId).Copy();
                    curr_in = secondId;
                }
            }
            else
            {
                if (this.neBox.SelectedIndex > -1)
                {
                    prerjet = db.selectPrerjet(this.neBox.SelectedValue.ToString()).Copy();
                }
            }

            this.radGridView2.Rows.Clear();
            this.radGridView2.Columns.Clear();

            emertimi2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            emertimi2.IsVisible = true;
            emertimi2.HeaderText = (isFavouriteMode ? secondName : this.neBox.Text);
            emertimi2.ReadOnly = true;

            number2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            number2.IsVisible = true;
            number2.HeaderText = "Sasia per Blerje";
            number2.ReadOnly = false;

            this.radGridView2.Columns.Add(emertimi2);
            this.radGridView2.Columns.Add(number2);

            this.radGridView2.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            for (int i = 2; i < prerjet.Columns.Count; i++)
            {
                if (int.Parse(prerjet.Rows[0].ItemArray[i].ToString()) != 0)
                {
                    this.radGridView2.Rows.Add(prerjet.Rows[0].ItemArray[i].ToString(), 0);
                }
            }
            this.radGridView2.Rows.Add("Totali", 0);
            this.radGridView2.Rows[this.radGridView2.Rows.Count - 1].Cells[1].ReadOnly = true;
            #region useless
            //}
            //else
            //{
            //    DataTable prerjet = new DataTable();
            //    if (isFavouriteMode)
            //    {
            //        if (firstClicked)
            //        {
            //            prerjet = db.selectPrerjet(firstId).Copy();
            //        }
            //    }
            //    else
            //    {
            //        if (this.ngaBox.SelectedIndex > -1)
            //        {
            //            prerjet = db.selectPrerjet(this.ngaBox.SelectedValue.ToString()).Copy();
            //        }
            //    }
            //    this.radGridView2.Rows.Clear();
            //    this.radGridView2.Columns.Clear();

            //    emertimi2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            //    emertimi2.IsVisible = true;
            //    emertimi2.HeaderText = (isFavouriteMode ? this.firstName : this.ngaBox.Text);
            //    emertimi2.ReadOnly = true;

            //    number2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            //    number2.IsVisible = true;
            //    number2.HeaderText = "Sasia per Blerje";
            //    number2.ReadOnly = false;

            //    //this.radGridView1.Columns.Add(id1);
            //    this.radGridView2.Columns.Add(emertimi2);
            //    this.radGridView2.Columns.Add(number2);

            //    this.radGridView2.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            //    for (int i = 2; i < prerjet.Columns.Count; i++)
            //    {
            //        if (int.Parse(prerjet.Rows[0].ItemArray[i].ToString()) != 0)
            //        {
            //            this.radGridView2.Rows.Add(prerjet.Rows[0].ItemArray[i].ToString(), 0);
            //        }
            //    }
            //    this.radGridView2.Rows.Add("Totali", 0);
            //}
            #endregion
            loadGridOk2 = true;
        }

        public void loadNgaNe()
        {
            kursi1 = 0;
            kursi2 = 0;
            firstClicked = false;
            secondClicked = false;
            firstId = "";
            secondId = "";
            this.blerjeLbl.Text = "";
            this.shitjeLbl.Text = "";
            this.totaliLbl.Text = "0";
            activateShitje();

            DataTable monedhat1 = db.selectAllRecFromTable("monedhat").Copy();
            loadOk1 = false;
            this.ngaBox.DataSource = monedhat1;
            this.ngaBox.ValueMember = "id";
            this.ngaBox.DisplayMember = "monedha";
            this.ngaBox.SelectedIndex = -1;
            loadOk1 = true;

            DataTable monedhat2 = db.selectAllRecFromTable("monedhat").Copy();
            loadOk2 = false;
            this.neBox.DataSource = monedhat2;
            this.neBox.ValueMember = "id";
            this.neBox.DisplayMember = "monedha";
            this.neBox.SelectedIndex = -1;
            loadOk2 = true;

            if (isFavouriteMode)
            {
                DataTable monedhat3 = db.selectFavoriteCurrencies().Copy();
                this.ngaBox.Visible = false;
                this.neBox.Visible = false;
                for (int i = 0; i < monedhat3.Rows.Count; i++)
                {
                    this.insertButton(monedhat3.Rows[i].ItemArray[0].ToString(), monedhat3.Rows[i].ItemArray[1].ToString());
                }
            }
            else
            {
                this.ngaBox.Visible = true;
                this.neBox.Visible = true;
                removeButtons();
                this.buttonCounter = 0;
            }
        }

        public void loadArka(string user_id)
        {
            DataTable arka = db.selectArkatByUser(user_id).Copy();
            if (arka.Rows.Count > 0)
            {
                this.arkaBox.DataSource = arka;
                this.arkaBox.ValueMember = "id";
                this.arkaBox.DisplayMember = "arka";
                this.arkaBox.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Ju nuk keni asnje arke te caktuar!");
            }
        }

        private void removeButtons()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i].GetType() == typeof(Button))
                {
                    Button a = ((Button)this.Controls[i]);
                    if (a.Tag != null)
                    {
                        if (a.Tag.ToString() == "FirstButton" || a.Tag.ToString() == "SecondButton")
                        {
                            this.Controls.Remove(a);
                        }
                    }
                }
            }
        }

        private void ngaBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loadOk1)
            {
                if (getBlerjeShitje1())
                {
                    oldIndex1 = ngaBox.SelectedIndex;
                    llogaritShumen();
                }
                else
                {
                    ngaBox.SelectedIndex = oldIndex1;
                }
                loadFirstGrid();
                loadSecondGrid();
            }
        }

        //public void getKursi()
        //{
        //    bool in1 = false;
        //    bool in2 = false;
        //    DataTable kursi1 = new DataTable();
        //    if (this.ngaBox.SelectedIndex > -1)
        //    {
        //        kursi1 = db.getBlerjeShitjeMonedhe(this.ngaBox.SelectedValue.ToString()).Copy();
        //        in1 = true;
        //    }
        //    DataTable kursi2 = new DataTable();
        //    if (this.neBox.SelectedIndex > -1)
        //    {
        //        kursi2 = db.getBlerjeShitjeMonedhe(this.neBox.SelectedValue.ToString()).Copy();
        //        in2 = true;
        //    }
        //    switch (this.levizjaBox.Text)
        //    {
        //        case "Shitje":
        //            {
        //                if (in1)
        //                {
        //                    this.kursiLbl1.Text = "Shitje : " + kursi1.Rows[0].ItemArray[1].ToString();
        //                }
        //                if (in2)
        //                {
        //                    this.kursiLbl2.Text = "Blerje : " + kursi2.Rows[0].ItemArray[0].ToString();
        //                }
        //                break;
        //            }
        //        case "Blerje":
        //            {
        //                if (in1)
        //                {
        //                    this.kursiLbl1.Text = "Blerje :" + kursi1.Rows[0].ItemArray[0].ToString();
        //                }
        //                if (in2)
        //                {
        //                    this.kursiLbl2.Text = "Shitje :" + kursi2.Rows[0].ItemArray[1].ToString();
        //                }
        //                break;
        //            }
        //        default:
        //            {

        //                break;
        //            }
        //    }
        //}

        public bool getBlerjeShitje1()
        {
            DataTable current = db.getBlerjeShitjeMonedhe((isFavouriteMode ? (isShitje ? firstId : secondId) : (isShitje ? this.ngaBox.SelectedValue.ToString() : this.neBox.SelectedValue.ToString()))).Copy();
            if (current.Rows.Count > 0)
            {
                if (float.Parse(current.Rows[0].ItemArray[0].ToString()) > 0 && float.Parse(current.Rows[0].ItemArray[1].ToString()) > 0)
                {
                    blerje1 = float.Parse(current.Rows[0].ItemArray[0].ToString());
                    shitje1 = float.Parse(current.Rows[0].ItemArray[1].ToString());
                    llogaritKursin();
                    return true;
                }
                else
                {
                    MessageBox.Show("Monedha e zgjedhur nuk ka kursin te percaktuar!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Monedha e zgjedhur nuk ka kursin te percaktuar!");
                return false;
            }
        }

        public bool getBlerjeShitje2()
        {
            DataTable current = db.getBlerjeShitjeMonedhe((isFavouriteMode ? (isShitje ? secondId : firstId) : (isShitje ? this.neBox.SelectedValue.ToString() : this.ngaBox.SelectedValue.ToString()))).Copy();
            if (current.Rows.Count > 0)
            {
                if (float.Parse(current.Rows[0].ItemArray[0].ToString()) > 0 && float.Parse(current.Rows[0].ItemArray[1].ToString()) > 0)
                {
                    blerje2 = float.Parse(current.Rows[0].ItemArray[0].ToString());
                    shitje2 = float.Parse(current.Rows[0].ItemArray[1].ToString());
                    llogaritKursin();
                    return true;
                }
                else
                {
                    MessageBox.Show("Monedha e zgjedhur nuk ka kursin te percaktuar!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Monedha e zgjedhur nuk ka kursin te percaktuar!");
                return false;
            }
        }

        public void llogaritKursin()
        {
            if (!isFavouriteMode)
            {
                if (this.ngaBox.SelectedIndex > -1 && this.neBox.SelectedIndex > -1)
                {
                    kursi1 = blerje1 / shitje2;
                    kursi2 = shitje1 / blerje2;
                    DataTable denoms = db.getMinDenomByCurrency(this.neBox.SelectedValue.ToString()).Copy();
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
                    kursi1 = 0;
                    kursi2 = 0;
                }
            }
            else
            {
                if (this.firstClicked && this.secondClicked)
                {
                    //kursi1 = blerje1 / shitje2;
                    kursi1 = blerje1 / blerje2;
                    //kursi2 = shitje1 / blerje2;
                    kursi2 = shitje1 / shitje2;
                    DataTable denoms = db.getMinDenomByCurrency(this.secondId).Copy();
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
                    kursi1 = 0;
                    kursi2 = 0;
                }
            }

            this.blerjeLbl.Text = kursi1.ToString("0.0000");
            this.shitjeLbl.Text = kursi2.ToString("0.0000");
            //getKursi();
        }

        private void swap()
        {
            isShitje = !isShitje;
            if (isShitje)
            {
                activateShitje();
            }
            else
            {
                activateBlerje();
            }
            this.shitjeBlerjeLbl.Text = blerje_shitje;
            llogaritShumen();
        }

        private void activateShitje()
        {
            blerje_shitje = "Shitje";
            loadFirstGrid();
            loadSecondGrid();
        }

        private void activateBlerje()
        {
            blerje_shitje = "Blerje";
            loadFirstGrid();
            loadSecondGrid();
        }

        private void neBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loadOk2)
            {
                if (getBlerjeShitje2())
                {
                    llogaritShumen();
                    oldIndex2 = neBox.SelectedIndex;
                }
                else
                {
                    neBox.SelectedIndex = oldIndex2;
                }
                loadFirstGrid();
                loadSecondGrid();
            }
        }

        private void llogaritShumen()
        {
            float z;
            if (float.TryParse(this.sumTxt.Text, out z) && ((this.ngaBox.SelectedIndex > -1 && this.neBox.SelectedIndex > -1) || (firstClicked && secondClicked)))
            {
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
                
                
                curr_trans = (isCustomRate ? float.Parse((this.customRateTxt.Text == "" ? "0" : this.customRateTxt.Text)) : float.Parse((isShitje ? shitjeLbl.Text : blerjeLbl.Text)));
            }
            if (this.sumTxt.Text == "")
            {
                this.totaliLbl.Text = "0.00";
            }
        }

        private void insertButton(string id, string content)
        {
            Button b = new Button()
            {
                Name = id,
                Text = content,
                Width = 70,
                Height = 21,
                Top = 59
            };
            Button b2 = new Button()
            {
                Name = id,
                Text = content,
                Width = 70,
                Height = 21,
                Top = 114
            };
            b.Click += new EventHandler(firstClick);
            b.Tag = "FirstButton";
            b2.Click += new EventHandler(secondClick);
            b2.Tag = "SecondButton";
            b.Left = b2.Left = 86 + buttonCounter * b.Width;
            if (b.Width + b.Left > this.Width)
            {
                this.Width += b.Width;
            }
            this.Controls.Add(b);
            this.Controls.Add(b2);
            buttonCounter++;
        }

        private void decolourFirst()
        {
            for(int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == typeof(Button))
                {
                    if (((Button)this.Controls[i]).Tag == "FirstButton")
                    {
                        ((Button)this.Controls[i]).BackColor = Control.DefaultBackColor;
                    }
                }
            }
        }

        private void decolourSecond()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == typeof(Button))
                {
                    if (((Button)this.Controls[i]).Tag == "SecondButton")
                    {
                        ((Button)this.Controls[i]).BackColor = Control.DefaultBackColor;
                    }
                }
            }
        }

        void secondClick(object sender, EventArgs e)
        {
            secondClicked = true;
            secondId = ((Button)sender).Name;
            if (getBlerjeShitje2())
            {
                secondClicked = true;
                decolourSecond();
                ((Button)sender).BackColor = Color.LightBlue;
                secondName = ((Button)sender).Text;
                llogaritShumen();
                oldId2 = secondId;
                oldName2 = secondName;
            }
            else
            {
                if (oldId2 == "")
                {
                    secondClicked = false;
                }
                secondId = oldId2;
                secondName = oldName2;
            }
            loadFirstGrid();
            loadSecondGrid();
        }

        void firstClick(object sender, EventArgs e)
        {
            firstClicked = true;
            firstId = ((Button)sender).Name;
            if (getBlerjeShitje1())
            {
                decolourFirst();
                ((Button)sender).BackColor = Color.LightBlue;
                firstName = ((Button)sender).Text;
                firstClicked = true;
                llogaritShumen();
                oldId1 = firstId;
                oldName1 = firstName;
            }
            else
            {
                if (oldId1 == "")
                {
                    firstClicked = false;
                }
                firstId = oldId1;
                firstName = oldName1;
            }
            loadFirstGrid();
            loadSecondGrid();
        }

        private void sumTxt_TextChanged(object sender, EventArgs e)
        {
            llogaritShumen();
        }

        private void levizjaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            llogaritShumen();
        }

        public void removePrerjet(string monedha_id)
        {
            string strBuild = "";
            strBuild += "update gjendja set ";
            for (int i = 0; i < this.radGridView1.Rows.Count - 1; i++)
            {
                strBuild += "Sasia" + (i + 1).ToString() + " = " + "Sasia" + (i + 1).ToString() + " - " + this.radGridView1.Rows[i].Cells[1].Value.ToString() + ", ";
            }
            strBuild = strBuild.Substring(0, strBuild.Length - 2);
            strBuild += " where id_ark = " + this.arkaBox.SelectedValue.ToString() + " and id_curr = " + monedha_id;
            db.getQuerySimple(strBuild);
        }

        public void addPrerjet(string monedha_id)
        {
            string strBuild = "";
            strBuild += "update gjendja set ";
            for (int i = 0; i < this.radGridView2.Rows.Count - 1; i++)
            {
                strBuild += "Sasia" + (i + 1).ToString() + " = " + "Sasia" + (i + 1).ToString() + " + " + this.radGridView2.Rows[i].Cells[1].Value.ToString() + ", ";
            }
            strBuild = strBuild.Substring(0, strBuild.Length - 2);
            strBuild += " where id_ark = " + this.arkaBox.SelectedValue.ToString() + " and id_curr = " + monedha_id;
            db.getQuerySimple(strBuild);
        }

        private void konfirmoBtn_Click(object sender, EventArgs e)
        {
            if (((Form1)this.MdiParent).user_id != "0")
            {
                bool okToGo = false;
                float z;
                if (((ngaBox.SelectedIndex > -1 && neBox.SelectedIndex > -1) || (firstClicked && secondClicked)) && float.TryParse(this.sumTxt.Text, out z) && float.TryParse(this.totaliLbl.Text, out z) && this.klientTxt.Text != "" && this.arkaBox.SelectedIndex > -1)
                {
                    if (float.Parse(this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].Value.ToString()) <= float.Parse(gjendjaLbl.Text))
                    {
                        if (!isShitje)
                        {
                            if (float.Parse(this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].Value.ToString()) == float.Parse(this.totaliLbl.Text))
                            {
                                if (float.Parse(this.radGridView2.Rows[this.radGridView2.Rows.Count - 1].Cells[1].Value.ToString()) == float.Parse(this.sumTxt.Text))
                                {
                                    okToGo = true;
                                }
                                else
                                {
                                    MessageBox.Show("Transaksioni nuk mund te kryhet!\n\rPrerjet ne hyrje nuk jane te vendosura sakte!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Transaksioni nuk mund te kryhet!\n\rPrerjet ne dalje nuk jane te vendosura sakte!");
                            }
                        }
                        else
                        {
                            if (float.Parse(this.radGridView2.Rows[this.radGridView2.Rows.Count - 1].Cells[1].Value.ToString()) == float.Parse(this.totaliLbl.Text))
                            {
                                if (float.Parse(this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].Value.ToString()) == float.Parse(this.sumTxt.Text))
                                {
                                    okToGo = true;
                                }
                                else
                                {
                                    MessageBox.Show("Transaksioni nuk mund te kryhet!\n\rPrerjet ne dalje nuk jane te vendosura sakte!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Transaksioni nuk mund te kryhet!\n\rPrerjet ne hyrje nuk jane te vendosura sakte!");
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

                if (okToGo)
                {
                db.insertTransaction(((Form1)(this.MdiParent)).user_id, DateTime.Now.Date, DateTime.Parse(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString()), (isFavouriteMode ? firstName : ngaBox.Text), this.sumTxt.Text, (isFavouriteMode ? secondName : this.neBox.Text), this.totaliLbl.Text, arkaBox.SelectedValue.ToString(), blerje_shitje, this.klientTxt.Text, curr_trans.ToString());
                    removePrerjet(curr_out);
                    addPrerjet(curr_in);
                    MessageBox.Show("Transaksioni u ruajt me sukses!");
                    restartInterface();
                }

            }
            else
            {
                MessageBox.Show("Administratori i sistemit nuk mund te inseroje transaksione!");
            }
        }

        public void restartInterface()
        {
            this.klientTxt.Text = "";
            this.sumTxt.Text = "";
            loadFirstGrid();
            loadSecondGrid();
        }

        private void swapButtons()
        {
            this.decolourFirst();
            this.decolourSecond();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].Tag != null)
                {
                    if (this.Controls[i].Tag.ToString() == "FirstButton")
                    {
                        if (this.Controls[i].Name == secondId)
                        {
                            ((Button)this.Controls[i]).BackColor = Color.LightBlue;
                        }
                    }
                    else if (this.Controls[i].Tag.ToString() == "SecondButton")
                    {
                        if (this.Controls[i].Name == firstId)
                        {
                            ((Button)this.Controls[i]).BackColor = Color.LightBlue;
                        }
                    }
                }
            }

            string tmp;

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
        }

        private void swapDropDowns()
        {
            loadOk1 = false;
            loadOk2 = false;
            int tmp;
            tmp = this.ngaBox.SelectedIndex;
            this.ngaBox.SelectedIndex = this.neBox.SelectedIndex;
            this.neBox.SelectedIndex = tmp;

            tmp = oldIndex1;
            oldIndex1 = oldIndex2;
            oldIndex2 = tmp;

            loadOk1 = true;
            loadOk2 = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(((this.ngaBox.SelectedIndex > -1) && (this.neBox.SelectedIndex > -1) || (this.firstClicked && this.secondClicked)))
            swap();
            if (isFavouriteMode)
            {
                swapButtons();
            }
            else
            {
                swapDropDowns();
            }
            llogaritKursin();
            llogaritShumen();
            loadFirstGrid();
            loadSecondGrid();
        }

        private void favouriteBtn_Click(object sender, EventArgs e)
        {
            if (!isFavouriteMode)
            {
                isFavouriteMode = true;
                loadNgaNe();
                loadFirstGrid();
                loadSecondGrid();
            }
        }

        private void allBtn_Click(object sender, EventArgs e)
        {
            if (isFavouriteMode)
            {
                isFavouriteMode = false;
                loadNgaNe();
                this.Width = this.initialWindowWidth;
                loadFirstGrid();
                loadSecondGrid();
            }
        }

        private void radGridView1_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (loadGridOk1)
            {
                loadGridOk1 = false;
                if (float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) <= float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString()))
                {
                    llogaritShumenEGrides(ref this.radGridView1);
                }
                else
                {
                    MessageBox.Show("Keni kaluar sasine qe eshte aktualisht ne gjendje!");
                    this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = float.Parse(this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString());
                }
                loadGridOk1 = true;
            }
        }

        public void llogaritShumenEGrides(ref Telerik.WinControls.UI.RadGridView grid)
        {
            float s = 0;
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                s += float.Parse(grid.Rows[i].Cells[1].Value.ToString()) * float.Parse(grid.Rows[i].Cells[0].Value.ToString());
            }
            grid.Rows[grid.Rows.Count - 1].Cells[1].Value = s;
        }

        private void radGridView2_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (loadGridOk2)
            {
                loadGridOk2 = false;
                llogaritShumenEGrides(ref this.radGridView2);
                loadGridOk2 = true;
            }
        }

        private void arkaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curr_out != "")
            {
                loadFirstGrid();
                loadSecondGrid();
            }
        }

        private void enablePreferencial()
        {
            isCustomRate = true;

            this.customRateTxt.Enabled = true;
            this.customRateTxt.Text = "1";
            this.shitjeLbl.Visible = false;
            this.blerjeLbl.Visible = false;
        }

        private void disablePreferencial()
        {
            isCustomRate = false;

            this.customRateTxt.Enabled = false;
            this.customRateTxt.Text = "";
            this.shitjeLbl.Visible = true;
            this.blerjeLbl.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                enablePreferencial();
            }
            else
            {
                disablePreferencial();
            }
            llogaritShumen();
        }

        private void customRateTxt_TextChanged(object sender, EventArgs e)
        {
            if (this.customRateTxt.Text != "")
            {
                llogaritShumen();
            }
            else
            {
                this.totaliLbl.Text = "0";
            }
        }
    }
}
