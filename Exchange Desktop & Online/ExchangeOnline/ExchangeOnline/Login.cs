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
    public partial class Login : Form
    {

        public string username = "";
        public string password = "";
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
                    //therritet funksioni qe autentifikon perdoruesin si SYSTEM ADMIN
                    this.Close();
                    this.Dispose();
                    return;
                }
                DataTable info = Lidhja.Kerkesat1.a.getUserInfoByUsernamePassword(this.usernameTxt.Text, this.passwordTxt.Text).Copy();
                if (info.Rows.Count > 0)
                {
                    string message = "Perdoruesi " + info.Rows[0].ItemArray[1].ToString() + " " + info.Rows[0].ItemArray[2].ToString() + " u fut ne sistem me sukses!";
                    MessageBox.Show(message, new EventHandler(messageShown));
                    //ne rastin kur perdoruesi njihet ne DB, mbyllet MessageBox dhe therritet funksioni login i klases Form1
                    //funksioni messageShown therritet ne mbyllje te MessageBox per te bere mbylljen e formes se login-it pasi 
                        //perdoruesi klikon OK
                    ((Form1)(this.MdiParent)).login(info);
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
        }//COMM

        private void messageShown(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            //funksion qe therritet ne mbyllje te MessageBox qe tregon se perdoruesi u autentifikua
        }//COMM

        private void radButton1_Click(object sender, EventArgs e)
        {
            //butoni i LOGIN
            login();
        }//COMM

        private void Login_Load(object sender, EventArgs e)
        {
            //ne fillim fokusi ndodhet tek TextBox i username-it
            this.usernameTxt.Focus();
        }//COMM

        private void passwordTxt_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            //ne shtypje te ENTER
            radButton1.PerformClick();
        }//COMM

        private void usernameTxt_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            //ne shtypje te ENTER
            radButton1.PerformClick();
        }//COMM

        private void Login_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            //ne shtypje te ENTER
            if (objArgs.KeyCode == Keys.Return)
            {
                radButton1.PerformClick();
            }
        }//COMM
    }
}