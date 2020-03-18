#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace ExchangeOnline
{
    public partial class RaportetPeriudha : UserControl
    {
        public RaportetPeriudha()
        {
            InitializeComponent();
            this.dateTimePicker1.Value = DateTime.Now;
        }

        public void loadGridShitje()
        {
            System.Data.DataTable shitje = Lidhja.Kerkesat1.a.selectSumByPeriudha(this.dateTimePicker1.Value.ToString("dd/MM/yyyy")).Copy();
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = shitje;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void loadGridBlerje()
        {
            System.Data.DataTable blerje = Lidhja.Kerkesat1.a.selectSumByPeriudhaBlerje(this.dateTimePicker1.Value.ToString("dd/MM/yyyy")).Copy();
            this.dataGridView2.AutoGenerateColumns = true;
            this.dataGridView2.DataSource = blerje;
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadGridShitje();
            loadGridBlerje();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:/MyExchange.xls"))
            {
                File.Delete(@"C:/MyExchange.xls");
            }
            
            FileStream tmp = File.Open(@"C:/MyExchange.xls", FileMode.Create);

            ExcelWriter ew = new ExcelWriter(tmp);
            ew.BeginWrite();
            ew.WriteCell(0, 0, "Shitjet:");
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                ew.WriteCell(1, i, this.dataGridView1.Columns[i].HeaderText);
            }
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    ew.WriteCell(i + 2, j, this.dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }

            int second_part = this.dataGridView1.Rows.Count + 3;

            ew.WriteCell(second_part, 0, "Blerjet:");

            for (int i = 0; i < this.dataGridView2.Columns.Count; i++)
            {
                ew.WriteCell(second_part + 1, i, this.dataGridView1.Columns[i].HeaderText);
            }
            for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < this.dataGridView2.Columns.Count; j++)
                {
                    ew.WriteCell(i + second_part + 2, j, this.dataGridView2.Rows[i].Cells[j].Value.ToString());
                }
            }
            ew.EndWrite();
            tmp.Close();
            MessageBox.Show(@"Skedari u ruajt nen emrin 'C:/MyExchange.xls'!");
        }
    }
}