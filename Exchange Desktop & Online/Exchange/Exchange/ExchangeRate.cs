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
    public partial class ExchangeRate : Form
    {

        #region declarative_section

        Telerik.WinControls.UI.GridViewTextBoxColumn monedha_id;
        Telerik.WinControls.UI.GridViewTextBoxColumn monedha;
        Telerik.WinControls.UI.GridViewTextBoxColumn blerje;
        Telerik.WinControls.UI.GridViewTextBoxColumn shitje;
        Telerik.WinControls.UI.GridViewTextBoxColumn existent;
        Telerik.WinControls.UI.GridViewTextBoxColumn value_changed;
        Telerik.WinControls.UI.GridViewTextBoxColumn current_id;

        Telerik.WinControls.UI.GridViewTextBoxColumn monedha2_id;
        Telerik.WinControls.UI.GridViewTextBoxColumn monedha2;
        Telerik.WinControls.UI.GridViewTextBoxColumn blerje2;
        Telerik.WinControls.UI.GridViewTextBoxColumn shitje2;
        Telerik.WinControls.UI.GridViewTextBoxColumn existent2;
        Telerik.WinControls.UI.GridViewTextBoxColumn value_changed2;
        Telerik.WinControls.UI.GridViewTextBoxColumn current_id2;

        DataTable monedhat;
        DataTable vlera_arka;
        DataTable vlera_banka;

        dbconnection db = new dbconnection();
        #endregion

        public ExchangeRate()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            monedhat = db.selectAllRecFromTable("monedhat");
            vlera_arka = db.selectAllRecFromTable("arka");
            vlera_banka = db.selectAllRecFromTable("banka");

            fillBankaGrid();
            fillCCGrid();
        }

        private void fillBankaGrid()
        {
            this.bankaGrid.Rows.Clear();
            monedha_id = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            monedha_id.IsVisible = false;

            monedha = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            monedha.ReadOnly = true;
            monedha.HeaderText = "Monedha";

            blerje = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            blerje.HeaderText = "Blerje";

            shitje = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            shitje.HeaderText = "Shitje";

            existent = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            existent.IsVisible = false;

            value_changed = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            value_changed.IsVisible = false;

            current_id = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            current_id.IsVisible = false;

            this.bankaGrid.Columns.Add(monedha_id);
            this.bankaGrid.Columns.Add(monedha);
            this.bankaGrid.Columns.Add(blerje);
            this.bankaGrid.Columns.Add(shitje);
            this.bankaGrid.Columns.Add(existent);
            this.bankaGrid.Columns.Add(value_changed);
            this.bankaGrid.Columns.Add(current_id);

            this.bankaGrid.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            bool foundValue = false;
            for (int i = 0; i < monedhat.Rows.Count; i++)
            {
                foundValue = false;
                for (int j = 0; j < vlera_banka.Rows.Count; j++)
                {
                    if (monedhat.Rows[i].ItemArray[0].ToString() == vlera_banka.Rows[j].ItemArray[1].ToString())
                    {
                        this.bankaGrid.Rows.Add(monedhat.Rows[i].ItemArray[0].ToString(), monedhat.Rows[i].ItemArray[1].ToString(),
                            vlera_banka.Rows[j].ItemArray[2].ToString(), vlera_banka.Rows[j].ItemArray[3].ToString(), 1, "0", vlera_banka.Rows[j].ItemArray[0].ToString());
                        foundValue = true;
                        break;
                    }
                }
                if (!foundValue)
                {
                    this.bankaGrid.Rows.Add(monedhat.Rows[i].ItemArray[0].ToString(), monedhat.Rows[i].ItemArray[1].ToString(), "", "", 0, "0", "");
                }
            }
        }

        private void fillCCGrid()
        {
            this.ccGrid.Rows.Clear();
            monedha2_id = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            monedha2_id.IsVisible = false;

            monedha2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            monedha2.ReadOnly = true;
            monedha2.HeaderText = "Monedha";

            blerje2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            blerje2.HeaderText = "Blerje";

            shitje2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            shitje2.HeaderText = "Shitje";

            existent2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            existent2.IsVisible = false;

            value_changed2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            value_changed2.IsVisible = false;

            current_id2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            current_id2.IsVisible = false;

            this.ccGrid.Columns.Add(monedha2_id);
            this.ccGrid.Columns.Add(monedha2);
            this.ccGrid.Columns.Add(blerje2);
            this.ccGrid.Columns.Add(shitje2);
            this.ccGrid.Columns.Add(existent2);
            this.ccGrid.Columns.Add(value_changed2);
            this.ccGrid.Columns.Add(current_id2);

            this.ccGrid.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            bool foundValue = false;
            for (int i = 0; i < monedhat.Rows.Count; i++)
            {
                foundValue = false;
                for (int j = 0; j < vlera_arka.Rows.Count; j++)
                {
                    if (monedhat.Rows[i].ItemArray[0].ToString() == vlera_arka.Rows[j].ItemArray[1].ToString())
                    {
                        this.ccGrid.Rows.Add(monedhat.Rows[i].ItemArray[0].ToString(), monedhat.Rows[i].ItemArray[1].ToString(),
                            vlera_arka.Rows[j].ItemArray[2].ToString(), vlera_arka.Rows[j].ItemArray[3].ToString(), 1, "0", this.vlera_arka.Rows[j].ItemArray[0].ToString());
                        foundValue = true;
                        break;
                    }
                }
                if (!foundValue)
                {
                    this.ccGrid.Rows.Add(monedhat.Rows[i].ItemArray[0].ToString(), monedhat.Rows[i].ItemArray[1].ToString(), "", "", 0, "0", "");
                }
            }
        }

        public void saveData()
        {
            saveBanka();
            saveCC();
        }

        public void saveBanka()
        {
            for (int i = 0; i < this.bankaGrid.Rows.Count; i++)
            {
                if (int.Parse(this.bankaGrid.Rows[i].Cells[5].Value.ToString()) == 1)
                {
                    if (int.Parse(this.bankaGrid.Rows[i].Cells[4].Value.ToString()) == 1)
                    {
                        //update
                        db.updateBanka(this.bankaGrid.Rows[i].Cells[6].Value.ToString(), this.bankaGrid.Rows[i].Cells[3].Value.ToString(), this.bankaGrid.Rows[i].Cells[2].Value.ToString());
                    }
                    else
                    {
                        //insert
                        db.insertBanka(this.bankaGrid.Rows[i].Cells[0].Value.ToString(), this.bankaGrid.Rows[i].Cells[3].Value.ToString(), this.bankaGrid.Rows[i].Cells[2].Value.ToString());
                    }
                }
            }
        }

        public void saveCC()
        {
            for (int i = 0; i < this.ccGrid.Rows.Count; i++)
            {
                if (int.Parse(this.ccGrid.Rows[i].Cells[5].Value.ToString()) == 1)
                {
                    if (int.Parse(this.ccGrid.Rows[i].Cells[4].Value.ToString()) == 1)
                    {
                        //update
                        db.updateArka(this.ccGrid.Rows[i].Cells[6].Value.ToString(), this.ccGrid.Rows[i].Cells[3].Value.ToString(), this.ccGrid.Rows[i].Cells[2].Value.ToString());
                    }
                    else
                    {
                        //insert
                        db.insertArka(this.ccGrid.Rows[i].Cells[0].Value.ToString(), this.ccGrid.Rows[i].Cells[3].Value.ToString(), this.ccGrid.Rows[i].Cells[2].Value.ToString());
                    }
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void bankaGrid_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            this.bankaGrid.Rows[this.bankaGrid.CurrentCell.RowIndex].Cells[5].Value = "1";
        }

        private void ccGrid_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            this.ccGrid.Rows[this.ccGrid.CurrentCell.RowIndex].Cells[5].Value = "1";
        }
    }
}
