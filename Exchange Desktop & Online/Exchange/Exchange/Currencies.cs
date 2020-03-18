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
    public partial class Currencies : Form
    {
        dbconnection db = new dbconnection();
        bool editing = false;
        public Currencies()
        {
            InitializeComponent();
            disableElements();
            loadCurrencies();
        }

        public void loadCurrencies()
        {
            this.radGridView1.DataSource = db.selectAllRecFromTable("monedhat");
            this.radGridView1.Columns[0].IsVisible = false;
            this.radGridView1.Columns[1].HeaderText = "Monedhat";
            this.radGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }//ok

        public void enableElements()
        {
            this.emertimiTxt.Enabled = true;
            this.ruajBtn.Enabled = true;
            this.shtoBtn.Enabled = false;
            this.editoBtn.Enabled = false;
            this.fshijBtn.Enabled = false;
            this.radGridView1.Enabled = false;
            this.anuloBtn.Enabled = true;
            this.checkBox1.Enabled = true;
        }//ok

        public void disableElements()
        {
            this.emertimiTxt.Enabled = false;
            this.ruajBtn.Enabled = false;
            this.shtoBtn.Enabled = true;
            this.editoBtn.Enabled = true;
            this.fshijBtn.Enabled = true;
            this.radGridView1.Enabled = true;
            this.anuloBtn.Enabled = false;
            this.checkBox1.Enabled = false;
            this.checkBox1.Checked = false;
            this.emertimiTxt.Text = "";
        }//ok

        private void shtoBtn_Click(object sender, EventArgs e)
        {
            enableElements();
            editing = false;
        }//ok

        private void editoBtn_Click(object sender, EventArgs e)
        {
            if (this.radGridView1.SelectedRows.Count > 0)
            {
                enableElements();
                this.emertimiTxt.Text = this.radGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.checkBox1.Checked = bool.Parse(this.radGridView1.SelectedRows[0].Cells[2].Value.ToString());
                editing = true;
            }
        }//ok

        private void fshijBtn_Click(object sender, EventArgs e)
        {
            //fshij, messagebox
            DialogResult dr = MessageBox.Show("Jeni te sigurt qe doni te fshini monedhen?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                db.deleteFromTable(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), "monedhat");
                loadCurrencies();
            }
            disableElements();
        }//ok

        private void ruajBtn_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                db.updateMonedha(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), this.emertimiTxt.Text, this.checkBox1.Checked);
            }
            else
            {
                db.insertMonedha(this.emertimiTxt.Text, this.checkBox1.Checked);
            }
            disableElements();
            loadCurrencies();
        }//ok

        private void anuloBtn_Click(object sender, EventArgs e)
        {
            disableElements();
        }//ok
    }
}

