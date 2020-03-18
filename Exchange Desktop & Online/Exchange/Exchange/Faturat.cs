using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Exchange
{
    public partial class Faturat : Form
    {
        dbconnection db = new dbconnection();
        Font printFont = new Font(new FontFamily("Segoe UI"), 10);
        string printingString = "";
        public Faturat()
        {
            InitializeComponent();
            initializeVisualElements();
        }

        public void initializeVisualElements()
        {
            this.radCheckBox1.Checked = false;
            this.fromDate.Enabled = false;
            this.toDate.Enabled = false;
            this.levizjaBox.SelectedIndex = 0;
            fillArkat();
            fillUsers();
        }

        public void fillArkat()
        {
            DataTable arkat2 = new DataTable();
            arkat2.Columns.Add("id");
            arkat2.Columns.Add("arka");
            arkat2.Rows.Add("0", "Te Gjitha");
            DataTable arkat = db.selectAllRecFromTable("arkat").Copy();
            for (int i = 0; i < arkat.Rows.Count; i++)
            {
                arkat2.Rows.Add(arkat.Rows[i].ItemArray[0].ToString(), arkat.Rows[i].ItemArray[1].ToString());
            }
            this.arkaBox.DataSource = arkat2;
            this.arkaBox.DisplayMember = "arka";
            this.arkaBox.ValueMember = "id";
            this.arkaBox.SelectedIndex = 0;
        }

        public void fillUsers()
        {
            DataTable users2 = new DataTable();
            users2.Columns.Add("id");
            users2.Columns.Add("emri");
            users2.Rows.Add("0", "Te Gjithe");
            DataTable users = db.selectUsers().Copy();
            for (int i = 0; i < users.Rows.Count; i++)
            {
                users2.Rows.Add(users.Rows[i].ItemArray[0].ToString(), users.Rows[i].ItemArray[1].ToString());
            }
            this.userBox.DataSource = users2;
            this.userBox.DisplayMember = "emri";
            this.userBox.ValueMember = "id";
            this.userBox.SelectedIndex = 0;
        }

        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (radCheckBox1.Checked)
            {
                this.fromDate.Enabled = true;
                this.toDate.Enabled = true;
            }
            else
            {
                this.fromDate.Enabled = false;
                this.toDate.Enabled = false;
            }
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            //sql statement building & excecuting :(
            int expression_counter = 0;
            bool parametersNeeded = false;
            System.Data.OleDb.OleDbParameter[] prm = new System.Data.OleDb.OleDbParameter[]
            {
                new System.Data.OleDb.OleDbParameter("random", 1)
            };
            string sqlBuilder = "";
            sqlBuilder += "select users.emri + ' ' + users.mbiemri as Perdoruesi, arkat.arka as Arka, " +
                "transaksione.Tipi1 as Nga, transaksione.Sasia1 as Sasia1, transaksione.Tipi2 as Ne, transaksione.Sasia2 as Sasia2, " +
                "transaksione.Kursi as Kursi, transaksione.Blerje_shitje as Levizja, transaksione.Ora as Ora " +
                "from (transaksione "+
                "inner join users on transaksione.id_user = users.id) "+
                "inner join arkat on transaksione.id_arka = arkat.id ";
            if (arkaBox.SelectedIndex > 0 || userBox.SelectedIndex > 0 || levizjaBox.SelectedIndex > 0 || this.radCheckBox1.Checked)
            {
                sqlBuilder += " where ";
                if (arkaBox.SelectedIndex > 0)
                {
                    expression_counter++;
                    sqlBuilder += " transaksione.id_arka = " + this.arkaBox.SelectedValue.ToString();
                }
                if (userBox.SelectedIndex > 0)
                {
                    if (expression_counter > 0)
                    {
                        sqlBuilder += " and ";
                    }
                    sqlBuilder += " transaksione.id_user = " + this.userBox.SelectedValue.ToString();
                    expression_counter++;
                }
                if (levizjaBox.SelectedIndex > 0)
                {
                    if (expression_counter > 0)
                    {
                        sqlBuilder += " and ";
                    }
                    sqlBuilder += " transaksione.Blerje_shitje = '" + this.levizjaBox.Text + "'";
                    expression_counter++;
                }
                if (this.radCheckBox1.Checked)
                {
                    prm = new System.Data.OleDb.OleDbParameter[]
                    {
                        new System.Data.OleDb.OleDbParameter("data_fillimit", fromDate.Value),
                        new System.Data.OleDb.OleDbParameter("data_mbarimit", toDate.Value),
                        new System.Data.OleDb.OleDbParameter("Aktiv", true)
                    };
                    parametersNeeded = true;
                    if (expression_counter > 0)
                    {
                        sqlBuilder += " and ";
                    }
                    sqlBuilder += " dita >= @data_fillimit and dita <= @data_mbarimit ";
                }
                if (expression_counter > 0)
                {
                    sqlBuilder += " and ";
                }
                sqlBuilder += " Aktiv = @Aktiv";
            }
            DataTable transactions;
            if (parametersNeeded)
            {
                transactions = db.getQuerySimpleParametric(sqlBuilder, prm).Copy();
            }
            else
            {
                transactions = db.getQuerySimple(sqlBuilder).Copy();
            }
            this.radGridView1.DataSource = transactions;
            this.radGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.Columns["Sasia1"].HeaderText = "Sasia Nga";
            this.radGridView1.Columns["Sasia2"].HeaderText = "Sasia Ne";
        }

        public void copyInformationToClipboard(ref Telerik.WinControls.UI.RadGridView grid)
        {
            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].IsVisible == true)
                {
                    strBuild.Append(grid.Columns[i].HeaderText);
                    strBuild.Append("\t");
                }
            }
            strBuild.Append("\n");
            for (int row = 0; row < grid.Rows.Count; row++)
            {
                for (int cell = 0; cell < grid.Rows[row].Cells.Count; cell++)
                {
                    if (grid.Columns[cell].IsVisible == true)
                    {
                        strBuild.Append((grid.Rows[row].Cells[cell].Value == null ? "" : grid.Rows[row].Cells[cell].Value.ToString()));
                        strBuild.Append("\t");
                    }
                }
                strBuild.Append("\n");
            }
            //Clipboard.SetDataObject(strBuild);
            Clipboard.SetText(strBuild.ToString());
            MessageBox.Show("Informacioni u kopjua dhe mund te ngjitet.");
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            copyInformationToClipboard(ref this.radGridView1);
        }

        private void print(ref Telerik.WinControls.UI.RadGridView grid)
        {
            //string builder with spaces
            //
            
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("Lista e veprimeve, " + DateTime.Now.Date.ToString("dd/MM/yyyy" + "\n"));
            if (arkaBox.SelectedIndex > 0 || userBox.SelectedIndex > 0 || levizjaBox.SelectedIndex > 0 || this.radCheckBox1.Checked)
            {
                strBuild.Append("(");
                if (arkaBox.SelectedIndex > 0)
                {
                    strBuild.Append("Arka " + arkaBox.Text + ", ");
                }
                if (userBox.SelectedIndex > 0)
                {
                    strBuild.Append("Perdoruesi " + userBox.Text + ", ");
                }
                if (levizjaBox.SelectedIndex > 0)
                {
                    strBuild.Append(levizjaBox.Text);
                }
                if (this.radCheckBox1.Checked)
                {
                    strBuild.Append("Nga data " + fromDate.Value.Date.ToString("dd/MM/yyyy") + " deri ne daten " + toDate.Value.Date.ToString("dd/MM/yyyy") + ", ");
                }
                strBuild.Remove(strBuild.Length - 2, 2);
                strBuild.Append(")");
            }
            strBuild.Append("\n\n\n");
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].IsVisible == true)
                {
                    strBuild.Append(grid.Columns[i].HeaderText);
                    strBuild.Append("\t\t\t");
                }
            }
            strBuild.Append("\n\n");
            for (int row = 0; row < grid.Rows.Count; row++)
            {
                for (int cell = 0; cell < grid.Rows[row].Cells.Count; cell++)
                {
                    if (grid.Columns[cell].IsVisible == true)
                    {
                        strBuild.Append((grid.Rows[row].Cells[cell].Value == null ? "" : grid.Rows[row].Cells[cell].Value.ToString()));
                        strBuild.Append("\t\t\t");
                    }
                }
                strBuild.Append("\n");
            }

            printingString = strBuild.ToString();

            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[0];
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            pd.Print();
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = e.MarginBounds.Height /
               printFont.GetHeight(e.Graphics);

            // Print each line of the file. 
            StringFormat format = new StringFormat(StringFormatFlags.LineLimit);
            float[] formatTabs = { 10.0f, 20.0f };
            format.SetTabStops(0.0f, formatTabs);

            yPos = topMargin + (count *
                printFont.GetHeight(e.Graphics));
            e.Graphics.DrawString(printingString, printFont, Brushes.Black,
                leftMargin, yPos, format);
            count++;

            // If more lines exist, print another page. 
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            print(ref this.radGridView1);
        }
    }
}
