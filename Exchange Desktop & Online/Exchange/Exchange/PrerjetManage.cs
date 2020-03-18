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
    public partial class PrerjetManage : Form
    {
        dbconnection db = new dbconnection();
        public bool loadOk = true;
        Telerik.WinControls.UI.GridViewTextBoxColumn emertimi;
        Telerik.WinControls.UI.GridViewTextBoxColumn prerja;

        bool insertedValue;

        public PrerjetManage()
        {
            InitializeComponent();
            loadMonedhat();
        }

        private void loadMonedhat()
        {
            DataTable monedhat = db.selectAllRecFromTable("monedhat").Copy();
            loadOk = false;
            this.monedhatBox.DataSource = monedhat;
            this.monedhatBox.ValueMember = "id";
            this.monedhatBox.DisplayMember = "Monedha";
            this.monedhatBox.SelectedValue = -1;
            loadOk = true;
        }

        private void insertPrerjet()
        {
            this.radGridView1.Rows.Clear();
            this.radGridView1.Columns.Clear();

            emertimi = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            emertimi.ReadOnly = true;
            emertimi.HeaderText = "Prerja";

            prerja = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            prerja.ReadOnly = false;
            prerja.HeaderText = "Vlera";

            this.radGridView1.Columns.Add(emertimi);
            this.radGridView1.Columns.Add(prerja);

            this.radGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            DataTable prerjet = db.selectPrerjet(this.monedhatBox.SelectedValue.ToString()).Copy();
            if(prerjet.Rows.Count == 0)
            {
                insertedValue = false;
            }
            else
            {
                insertedValue = true;
            }
            for (int i = 1; i <= 20; i++)
            {
                this.radGridView1.Rows.Add("Prerja " + i.ToString(), (insertedValue ? (int.Parse(prerjet.Rows[0].ItemArray[i + 1].ToString()) == 0 ? "" : prerjet.Rows[0].ItemArray[i + 1].ToString()) : ""));
            }
        }

        private void saveConfig()
        {
            bool ok = true;
            int index = 0;
            int z;
            for (int i = 0; i < this.radGridView1.Rows.Count; i++)
            {
                if (this.radGridView1.Rows[i].Cells[1].Value.ToString() != "")
                {
                    if (!int.TryParse(this.radGridView1.Rows[i].Cells[1].Value.ToString(), out z))
                    {
                        ok = false;
                        index = i;
                    }
                }
            }
            if (ok)
            {
                string[] tmp = new string[20];
                for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                {
                    tmp[i] = this.radGridView1.Rows[i].Cells[1].Value.ToString();
                }
                if (!this.insertedValue)
                {
                    //insert
                    db.insertPrerje(this.monedhatBox.SelectedValue.ToString(), tmp);
                }
                else
                {
                    //update
                    db.updatePrerje(this.monedhatBox.SelectedValue.ToString(), tmp);
                }
                MessageBox.Show("Prerjet u ruajten me sukses!");
            }
            else
            {
                MessageBox.Show(this.radGridView1.Rows[index].Cells[0].Value.ToString() + " nuk eshte konfiguruar sakte!");
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            saveConfig();
        }

        private void monedhatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadOk)
            {
                insertPrerjet();
            }
        }
    }
}
