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
    public partial class Prerjet : Form
    {
        dbconnection db = new dbconnection();
        bool loadOk1 = false;
        bool loadOk2 = false;
        bool isInserted = false;

        Telerik.WinControls.UI.GridViewTextBoxColumn emertimi;
        Telerik.WinControls.UI.GridViewDecimalColumn numri;

        public Prerjet()
        {
            InitializeComponent();
            fillArkat();
            fillMonedhat();
        }

        public void fillArkat()
        {
            DataTable arkat = db.selectAllRecFromTable("arkat");
            loadOk1 = false;
            this.arkatBox.DataSource = arkat;
            this.arkatBox.DisplayMember = "arka";
            this.arkatBox.ValueMember = "id";
            this.arkatBox.SelectedIndex = -1;
            loadOk1 = true;
        }//ok

        public void fillMonedhat()
        {
            DataTable monedhat = db.selectAllRecFromTable("monedhat");
            loadOk2 = false;
            this.monedhatBox.DataSource = monedhat;
            this.monedhatBox.DisplayMember = "monedha";
            this.monedhatBox.ValueMember = "id";
            this.monedhatBox.SelectedIndex = -1;
            loadOk2 = true;
        }//ok

        public void getKursin()
        {
            DataTable kursi = db.getKursiBankesByMonedha(this.monedhatBox.SelectedValue.ToString()).Copy();
            if (kursi.Rows.Count > 0)
            {
                this.kursiTxt.Text = kursi.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                MessageBox.Show("Nuk eshte caktuar kursi i kembimit per kete monedhe!");
                kursiTxt.Text = "";
            }
        }//ok

        public void insertPrerjet()
        {
            this.radGridView1.Rows.Clear();
            this.radGridView1.Columns.Clear();
            if (monedhatBox.SelectedIndex > -1 && arkatBox.SelectedIndex > -1)
            {
                emertimi = new Telerik.WinControls.UI.GridViewTextBoxColumn();
                emertimi.HeaderText = "Vlera";
                emertimi.ReadOnly = true;

                numri = new Telerik.WinControls.UI.GridViewDecimalColumn();
                numri.HeaderText = "Sasia";
                numri.ReadOnly = false;

                this.radGridView1.Columns.Add(emertimi);
                this.radGridView1.Columns.Add(numri);
                this.radGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                llogarit();
            }
        }//ok

        public void llogarit()
        {
            bool isValue = false;
            DataTable dt = db.selectPrerjet(this.monedhatBox.SelectedValue.ToString()).Copy();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Prerjet nuk jane te konfiguruara per kete monedhe!");
                return;
            }
            DataTable dt2 = db.selectGjendjet(this.monedhatBox.SelectedValue.ToString(), this.arkatBox.SelectedValue.ToString()).Copy();
            if (dt2.Rows.Count > 0)
            {
                isValue = true;
                isInserted = true;
            }
            else
            {
                isValue = false;
                isInserted = false;
            }
            for (int i = 2; i < dt.Columns.Count; i++)
            {
                if (dt.Rows[0].ItemArray[i].ToString() != "0" && dt.Rows[0].ItemArray[i].ToString() != "")
                {
                    this.radGridView1.Rows.Add(dt.Rows[0].ItemArray[i].ToString(), (isValue ? (dt2.Rows[0].ItemArray[i + 1].ToString() == "" ? "0" : dt2.Rows[0].ItemArray[i + 1].ToString()) : "0"));
                }
            }

            float sum = 0;
            for (int i = 0; i < this.radGridView1.Rows.Count; i++)
            {
                sum += float.Parse(this.radGridView1.Rows[i].Cells[0].Value.ToString()) * float.Parse(this.radGridView1.Rows[i].Cells[1].Value.ToString());
            }
            this.totaliLbl.Text = sum.ToString();
        }//ok

        private void arkatBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loadOk1)
            {
                insertPrerjet();
            }
        }//ok

        private void monedhatBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loadOk2)
            {
                insertPrerjet();
                getKursin();
            }
        }//ok

        private void saveConfig()
        {
            if (this.radGridView1.Rows.Count > 0)
            {
                if (!isInserted)
                {
                    //insert procedure
                    string[] tmp = new string[20];
                    for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                    {
                        tmp[i] = this.radGridView1.Rows[i].Cells[1].Value.ToString();
                    }
                    db.insertGjendje(this.monedhatBox.SelectedValue.ToString(), tmp, this.arkatBox.SelectedValue.ToString());
                }
                else
                {
                    //update procedure
                    string[] tmp = new string[20];
                    for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                    {
                        tmp[i] = this.radGridView1.Rows[i].Cells[1].Value.ToString();
                    }
                    db.updateGjendje(this.monedhatBox.SelectedValue.ToString(), tmp, this.arkatBox.SelectedValue.ToString());
                }
                MessageBox.Show("Sasite u ruajten me sukses!");
            }
        }//ok

        private void radButton1_Click(object sender, EventArgs e)
        {
            saveConfig();
        }//ok

        private void radGridView1_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            this.radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (int)(float.Parse(e.Value.ToString()));
            float sum = 0;
            for (int i = 0; i < this.radGridView1.Rows.Count; i++)
            {
                sum += float.Parse(this.radGridView1.Rows[i].Cells[0].Value.ToString()) * float.Parse(this.radGridView1.Rows[i].Cells[1].Value.ToString());
            }
            this.totaliLbl.Text = sum.ToString();
        }//ok
    }
}
