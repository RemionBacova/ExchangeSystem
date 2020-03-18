#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace ExchangeOnline
{
    public partial class UserArka : Form
    {
        public UserArka()
        {
            InitializeComponent();
            loadUsers();
            loadArkat();
        }

        public void loadUsers()
        {
            //funksion qe merr te gjithe perdoruesit dhe i hedh ne GridView
            this.userGrid.AutoGenerateColumns = true;
            DataTable users = Lidhja.Kerkesat1.a.selectUsers().Copy();
            this.userGrid.DataSource = users;
            if (this.userGrid.Columns.Count > 0)
            {
                this.userGrid.Columns[0].Visible = false;
            }
            this.userGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.userGrid.AutoGenerateColumns = false;
            this.userGrid.Update();
        }//COMM

        public void loadNder()
        {
            //funksion qe merr te gjithe arkat e perdoruesit te zgjedhur dhe i hedh ne GridView 
            this.middleGrid.AutoGenerateColumns = true;
            DataTable mid = Lidhja.Kerkesat1.a.selectArkatByUser(this.userGrid.SelectedRows[0].Cells[0].Value.ToString()).Copy();
            this.middleGrid.DataSource = mid;
            if (this.middleGrid.Columns.Count > 0)
            {
                this.middleGrid.Columns[0].Visible = false;
            }
            this.middleGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.middleGrid.AutoGenerateColumns = false;
            this.middleGrid.Update();
        }//COMM

        public void loadArkat()
        {
            //funksion qe merr te gjitha arkat dhe i hedh ne GridView
            this.arkaGrid.AutoGenerateColumns = true;
            DataTable arkat = Lidhja.Kerkesat1.a.selectAllRecFromTable("arkat").Copy();
            this.arkaGrid.DataSource = arkat;
            if (this.arkaGrid.Columns.Count > 0)
            {
                this.arkaGrid.Columns[0].Visible = false;
            }
            this.arkaGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.arkaGrid.AutoGenerateColumns = false;
            this.arkaGrid.Update();
        }//COMM

        private void radButton1_Click(object sender, EventArgs e)
        {
            //funksioni qe ben lidhjen midis perdoruesit te zgjedhur dhe arkes se zgjedhur
                //veprimet kryhen nese kemi nje perdorues te zgjedhur dhe nje arke te zgjedhur
            if (this.userGrid.SelectedRows.Count > 0 && this.arkaGrid.SelectedRows.Count > 0)
            {
                if (int.Parse(Lidhja.Kerkesat1.a.selectRecordByUserArka(this.userGrid.SelectedRows[0].Cells[0].Value.ToString(), this.arkaGrid.SelectedRows[0].Cells[0].Value.ToString()).Copy().Rows[0].ItemArray[0].ToString()) > 0)
                {
                    //nese kemi nje lidhje midis ketij perdoruesi dhe kesaj arke, shfaqim MessageBox qe njofton se lidhja ekziston
                    MessageBox.Show("Lidhja ekziston!");
                }
                else
                {
                    //perndryshe shtojme lidhjen
                    Lidhja.Kerkesat1.a.insertUserArka(this.userGrid.SelectedRows[0].Cells[0].Value.ToString(), this.arkaGrid.SelectedRows[0].Cells[0].Value.ToString());
                    //pas shtimit te lidhjes, marrim dhe njehere te gjitha lidhjet nga DB
                    loadNder();
                }
            }
        }//COMM

        private void radButton2_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit te fshirjes se lidhjes, shfaqet MessageBox qe pret konfirmim per fshirjen nga perdoruesi
                //ne konfirmim, therritet funksioni qe ndodhet ne EventHandler te kaluar si parameter ne MessageBox
            if (this.middleGrid.SelectedRows.Count > 0)
            {
                //nese kemi nje lidhje te zgjedhur
                DialogResult a = MessageBox.Show("Jeni te sigurt qe doni te fshini lidhjen e zgjedhur?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(fshijAccepted));
            }
        }//COMM

        private void fshijAccepted(object sender, EventArgs e)
        {
            //ne rastin kur konfirmohet fshirja
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                //lidhja fshihet nga DB dhe ri-merren te gjitha lidhjet
                Lidhja.Kerkesat1.a.deleteFromTable(this.middleGrid.SelectedRows[0].Cells[0].Value.ToString(), "user_arka");
                loadNder();
            }
        }//COMM

        private void userGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ne zgjedhje te nje perdoruesi tjeter, shfaqim lidhjet me arkat per kete perdorues
            loadNder();
        }//COMM
    }
}