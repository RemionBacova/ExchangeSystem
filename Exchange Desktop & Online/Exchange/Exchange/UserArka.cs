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
    public partial class UserArka : Form
    {
        dbconnection db = new dbconnection();
        public UserArka()
        {
            InitializeComponent();
            loadUsers();
            loadArkat();
        }

        public void loadUsers()
        {
            DataTable users = db.selectUsers().Copy();
            this.userGrid.DataSource = users;
            this.userGrid.Columns[0].IsVisible = false;
            this.userGrid.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        public void loadNder()
        {
            DataTable mid = db.selectArkatByUser(this.userGrid.SelectedRows[0].Cells[0].Value.ToString()).Copy();
            this.middleGrid.DataSource = mid;
            this.middleGrid.Columns[0].IsVisible = false;
            this.middleGrid.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        public void loadArkat()
        {
            DataTable arkat = db.selectAllRecFromTable("arkat").Copy();
            this.arkaGrid.DataSource = arkat;
            this.arkaGrid.Columns[0].IsVisible = false;
            this.arkaGrid.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (this.userGrid.SelectedRows.Count > 0 && this.arkaGrid.SelectedRows.Count > 0)
            {
                if (int.Parse(db.selectRecordByUserArka(this.userGrid.SelectedRows[0].Cells[0].Value.ToString(), this.arkaGrid.SelectedRows[0].Cells[0].Value.ToString()).Copy().Rows[0].ItemArray[0].ToString()) > 0)
                {
                    MessageBox.Show("Lidhja ekziston!");
                }
                else
                {
                    db.insertUserArka(this.userGrid.SelectedRows[0].Cells[0].Value.ToString(), this.arkaGrid.SelectedRows[0].Cells[0].Value.ToString());
                    loadNder();
                }
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (this.middleGrid.SelectedRows.Count > 0)
            {
                db.deleteFromTable(this.middleGrid.SelectedRows[0].Cells[0].Value.ToString(), "user_arka");
                loadNder();
            }
        }

        private void userGrid_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            loadNder();
        }
    }
}
