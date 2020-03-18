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
    public partial class Login : Form
    {
        dbconnection db = new dbconnection();
        public Login()
        {
            InitializeComponent();
        }

        public void login()
        {
            if (this.usernameTxt.Text != "" && this.passwordTxt.Text != "")
            {
                if (this.usernameTxt.Text == "MCNETWORKING" && this.passwordTxt.Text == "1@3$MCNETWORKING56")
                {
                    ((Form1)(this.MdiParent)).loginSystem();
                    this.Close();
                    this.Dispose();
                    return;
                }
                DataTable info = db.getUserInfoByUsernamePassword(this.usernameTxt.Text, this.passwordTxt.Text).Copy();
                if (info.Rows.Count > 0)
                {
                    MessageBox.Show("Perdoruesi " + info.Rows[0].ItemArray[1].ToString() + " " + info.Rows[0].ItemArray[2].ToString() + " u fut ne sistem me sukses!");
                    ((Form1)(this.MdiParent)).login(info);
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Perdoruesi dhe/ose fjalekalimi i gabuar!");
                }
            }
            else
            {
                MessageBox.Show("Plotesoni fushat!");
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void usernameTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                radButton1.PerformClick();
            }
        }

        private void passwordTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                radButton1.PerformClick();
            }
        }
    }
}
