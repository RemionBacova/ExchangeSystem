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
    public partial class Users : Form
    {
        dbconnection db = new dbconnection();
        bool editing = false;
        public Users()
        {
            InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            this.radioButton1.Checked = true;
            this.radioButton2.Checked = false;
            loadUsers();
            disableElements();
        }

        public void enableElements()
        {
            this.shtoBtn.Enabled = false;
            this.editoBtn.Enabled = false;
            this.fshijBtn.Enabled = false;
            this.radGridView1.Enabled = false;

            this.emriTxt.Enabled = true;
            this.mbiemriTxt.Enabled = true;
            this.idTxt.Enabled = true;
            this.usernameTxt.Enabled = true;
            this.passwordTxt.Enabled = true;
            this.radioButton1.Enabled = true;
            this.radioButton2.Enabled = true;
            this.ruajBtn.Enabled = true;
            this.anuloBtn.Enabled = true;

            this.radioButton1.Checked = true;
        }

        public void disableElements()
        {
            this.emriTxt.Text = "";
            this.mbiemriTxt.Text = "";
            this.idTxt.Text = "";
            this.usernameTxt.Text = "";
            this.passwordTxt.Text = "";

            this.shtoBtn.Enabled = true;
            this.editoBtn.Enabled = true;
            this.fshijBtn.Enabled = true;
            this.radGridView1.Enabled = true;

            this.emriTxt.Enabled = false;
            this.mbiemriTxt.Enabled = false;
            this.idTxt.Enabled = false;
            this.usernameTxt.Enabled = false;
            this.passwordTxt.Enabled = false;
            this.radioButton1.Enabled = false;
            this.radioButton2.Enabled = false;
            this.anuloBtn.Enabled = false;
            this.ruajBtn.Enabled = false;

            this.radioButton1.Checked = true;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                if (emriTxt.Text != "" && mbiemriTxt.Text != "" && idTxt.Text != "" && usernameTxt.Text != "" && passwordTxt.Text != "" && (this.radioButton1.Checked || this.radioButton2.Checked))
                {
                    //update procedure
                    db.updateUser(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), emriTxt.Text, mbiemriTxt.Text, idTxt.Text, usernameTxt.Text, passwordTxt.Text, (this.radioButton1.Checked ? "Admin" : "Kasier"));
                    MessageBox.Show("Perdoruesi u ruajt!");
                    loadUsers();
                    disableElements();
                }
                else
                {
                    MessageBox.Show("Te dhenat e inseruara nuk jane te plota! \r\nJepni informacionin e sakte!");
                }
            }
            else
            {
                if (emriTxt.Text != "" && mbiemriTxt.Text != "" && idTxt.Text != "" && usernameTxt.Text != "" && passwordTxt.Text != "" && (this.radioButton1.Checked || this.radioButton2.Checked))
                {
                    db.insertUser(emriTxt.Text, mbiemriTxt.Text, idTxt.Text, usernameTxt.Text, passwordTxt.Text, (this.radioButton1.Checked ? "Admin" : "Cashier"));
                    MessageBox.Show("Perdoruesi u ruajt!");
                    loadUsers();
                    disableElements();
                }
                else
                {
                    MessageBox.Show("Te dhenat e inseruara nuk jane te plota! \r\nJepni informacionin e sakte!");
                }
            }
        }

        public void loadUsers()
        {
            DataTable users = db.selectUsers();
            this.radGridView1.DataSource = users;

            this.radGridView1.Columns[0].IsVisible = false;

            this.radGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        public void loadData()
        {
            DataTable user_info = db.selectUserDataById(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString());
            this.emriTxt.Text = user_info.Rows[0].ItemArray[1].ToString();
            this.mbiemriTxt.Text = user_info.Rows[0].ItemArray[2].ToString();
            this.idTxt.Text = user_info.Rows[0].ItemArray[3].ToString();
            this.usernameTxt.Text = user_info.Rows[0].ItemArray[4].ToString();
            this.passwordTxt.Text = user_info.Rows[0].ItemArray[5].ToString();

            if (user_info.Rows[0].ItemArray[6].ToString() == "Admin")
            {
                this.radioButton1.Checked = true;
                this.radioButton2.Checked = false;
            }
            else
            {
                this.radioButton1.Checked = false;
                this.radioButton2.Checked = true;
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            editing = false;
            enableElements();
        }

        private void editoBtn_Click(object sender, EventArgs e)
        {
            if (this.radGridView1.SelectedRows.Count > 0)
            {
                editing = true;
                enableElements();
                loadData();
            }
        }

        private void fshijBtn_Click(object sender, EventArgs e)
        {
            if (this.radGridView1.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Jeni te sigurt qe doni te fshini perdoruesin?", "", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    db.deleteFromTable(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), "users");
                    loadUsers();
                }
            }
        }

        private void anuloBtn_Click(object sender, EventArgs e)
        {
            disableElements();
        }
    }
}
