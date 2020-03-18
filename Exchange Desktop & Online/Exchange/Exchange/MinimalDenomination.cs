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
    public partial class MinimalDenomination : Form
    {
        dbconnection db = new dbconnection();
        string current_id;
        bool loadOk = true;
        public int old_index = -1;
        public float old_value = 0;
        bool saved = false;

        public MinimalDenomination()
        {
            InitializeComponent();
            loadMonedhat();
        }

        public void loadMonedhat()
        {
            loadOk = false;
            this.monedhaDrop.DataSource = db.selectAllRecFromTable("monedhat").Copy();
            loadOk = true;
            this.monedhaDrop.ValueMember = "id";
            this.monedhaDrop.DisplayMember = "Monedha";

            this.monedhaDrop.SelectedIndex = 0;
            loadMinDenom();
        }

        public void loadMinDenom()
        {
            if (this.monedhaDrop.SelectedValue != null)
            {
                if (int.Parse(this.monedhaDrop.SelectedValue.ToString()) > -1)
                {
                    using (DataTable min_denom = db.selectDenomValueByCurrency(this.monedhaDrop.SelectedValue.ToString()).Copy())
                    {
                        if (min_denom.Rows.Count > 0)
                        {
                            this.textBox1.Text = min_denom.Rows[0].ItemArray[1].ToString();
                            this.current_id = min_denom.Rows[0].ItemArray[0].ToString();
                        }
                        else
                        {
                            this.textBox1.Text = "0";
                            this.current_id = "-1";
                        }
                    }
                }
            }
        }

        public void saveConfig()
        {
            if (int.Parse(this.current_id) != -1)
            {
                //update procedure
                db.updateMinimalDenomination(this.current_id, this.textBox1.Text);
                MessageBox.Show("Vlera u ruajt!");
            }
            else
            {
                //insert procedure
                db.insertMinimalDenomination(this.monedhaDrop.SelectedValue.ToString(), this.textBox1.Text);
                MessageBox.Show("Vlera u ruajt!");
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            saveConfig();
            saved = true;
        }

        private void monedhaDrop_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loadOk)
            {
                bool positiveSelection = true;
                if (old_index > -1 && monedhaDrop.SelectedIndex != old_index && float.Parse(this.textBox1.Text) != old_value && !saved)
                {
                    DialogResult dr = MessageBox.Show("Jeni te sigurt qe nuk doni te ruani vleren?", "", MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        positiveSelection = true;
                    }
                    else
                    {
                        positiveSelection = false;
                    }
                }
                if (positiveSelection)
                {
                    loadMinDenom();
                    old_index = monedhaDrop.SelectedIndex;
                    old_value = float.Parse(this.textBox1.Text);
                    saved = false;
                }
                else
                {
                    loadOk = false;
                    monedhaDrop.SelectedIndex = old_index;
                    loadOk = true;
                }
            }
        }

        private void MinimalDenomination_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.radButton1.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.radButton1.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Focus();
            }
        }
    }
}
