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
    public partial class Arkat : Form
    {
        dbconnection db = new dbconnection();
        bool editing = false;
        public Arkat()
        {
            InitializeComponent();
            disableElements();
            loadCurrencies();
        }

        public void loadCurrencies()
        {
            this.radGridView1.DataSource = db.selectAllRecFromTable("arkat");
            this.radGridView1.Columns[0].IsVisible = false;
            this.radGridView1.Columns[1].HeaderText = "Arkat";
            this.radGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        public void enableElements()
        {
            this.emertimiTxt.Enabled = true;
            this.ruajBtn.Enabled = true;
            this.anuloBtn.Enabled = true;
            this.shtoBtn.Enabled = false;
            this.editoBtn.Enabled = false;
            this.fshijBtn.Enabled = false;
            this.radGridView1.Enabled = false;
        }

        public void disableElements()
        {
            this.emertimiTxt.Enabled = false;
            this.ruajBtn.Enabled = false;
            this.anuloBtn.Enabled = false;
            this.shtoBtn.Enabled = true;
            this.editoBtn.Enabled = true;
            this.fshijBtn.Enabled = true;
            this.radGridView1.Enabled = true;
            this.emertimiTxt.Text = "";
        }

        private void shtoBtn_Click(object sender, EventArgs e)
        {
            enableElements();
            editing = false;
        }

        private void editoBtn_Click(object sender, EventArgs e)
        {
            if (this.radGridView1.SelectedRows.Count > 0)
            {
                enableElements();
                this.emertimiTxt.Text = this.radGridView1.SelectedRows[0].Cells[1].Value.ToString();
                editing = true;
            }
        }

        private void fshijBtn_Click(object sender, EventArgs e)
        {
            //fshij, messagebox
            DialogResult dr = MessageBox.Show("Jeni te sigurt qe doni te fshini arken?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                db.deleteFromTable(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), "arkat");
                loadCurrencies();
            }
            disableElements();
        }

        private void ruajBtn_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                db.updateArkat(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), this.emertimiTxt.Text);
            }
            else
            {
                db.insertArkat(this.emertimiTxt.Text);
            }
            disableElements();
            loadCurrencies();
        }

        private void anuloBtn_Click(object sender, EventArgs e)
        {
            disableElements();
        }
    }
}

