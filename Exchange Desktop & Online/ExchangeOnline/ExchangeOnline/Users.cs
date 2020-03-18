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
    public partial class Users : Form
    {
        bool editing = false;
        public Users()
        {
            InitializeComponent();
            //inicializohet nderfaqa
            initialize();
        }

        public void initialize()
        {
            //funksion qe vendos vlerat e elementeve te nderfaqes ne krijim te saj
            this.radioButton1.Checked = true;
            this.radioButton2.Checked = false;
            //shtohen perdoruesit ekzistente nga DB
            loadUsers();
            //elementet vizuale qe mundesojne shtimin ose editimin, ne fillim caktivizohen
            disableElements();
        }//COMM

        public void enableElements()
        {
            //funksion qe aktivizon elementet vizuale qe lejojne perdoruesin te shtoje ose modifikoje perdorues
                //butonat e shtimit, editimit dhe fshirjes caktivizohen, pasi ne kete moment eshte zgjedhur veprimi qe do te behet
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
        }//COMM

        public void disableElements()
        {
            //funksion qe caktivizon elementet vizuale te nderfaqes te cilat lejojne perdoruesin te shtoje ose modifikoje perdorues te tjere
                //butonat e shtimit, editimit dhe fshirjes ri-aktivizohen, pasi ne kete moment eshte mbaruar procesi i shtimit/editimit
                //dhe pritet nje proces tjeter
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
        }//COMM

        public void loadUsers()
        {
            //funksion qe merr perdoruesit ekzistente nga DB dhe i shfaq ne GridView
            this.radGridView1.AutoGenerateColumns = true;
            DataTable users = Lidhja.Kerkesat1.a.selectUsers().Copy();
            this.radGridView1.DataSource = users;

            this.radGridView1.Columns[0].Visible = false;

            this.radGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.AutoGenerateColumns = false;
            this.radGridView1.Update();
        }//COMM

        public void loadData()
        {
            //funksion qe shperndan informacionin e perdoruesit te zgjedhur ne elementet vizuale per editim
            DataTable user_info = Lidhja.Kerkesat1.a.selectUserDataById(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString()).Copy();
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
        }//COMM

        private void shtoBtn_Click(object sender, EventArgs e)
        {
            //ne rastin kur klikohet butoni SHTO, i jepet vlera variablit qe tregon se perdoruesi po editon dhe
                //aktivizohen elementet vizuale per te hedhur informacionin e perdoruesit qe do te shtohet
            editing = false;
            enableElements();
        }//COMM

        private void editoBtn_Click(object sender, EventArgs e)
        {
            //ne rastin kur klikohet butoni EDITO, veprimet kryhen nese eshte nje perdorues i zgjedhur nga GridView
            if (this.radGridView1.SelectedRows.Count > 0)
            {
                //variabli qe tregon se po kryhet editim merr vleren TRUE, aktivizohen elementet vizuale dhe mbushen me te dhenat
                    //e perdoruesit qe po editohet per thjeshtesi ndaj perdoruesit qe po punon me sistemin
                editing = true;
                enableElements();
                loadData();
            }
        }//COMM

        private void fshijBtn_Click(object sender, EventArgs e)
        {
            //ne rastin kur klikohet butoni FSHIJ, perdoruesit i shfaqet nje MessageBox ku ai konfirmon fshirjen e perdoruesit
                //funksioni qe thirret ne konfirmim ndodhet ne EventHandler te kaluar si parameter te MessageBox
            if (this.radGridView1.SelectedRows.Count > 0)
            {
                DialogResult a = MessageBox.Show("Jeni te sigurt qe deshironi te fshini perdoruesin e zgjedhur?", "Kujdes!", MessageBoxButtons.YesNo, new EventHandler(fshijAccepted));
            }
        }//COMM

        private void fshijAccepted(object sender, EventArgs e)
        {
            //funksioni qe therritet kur perdoruesi konfirmon fshirjen pas MessageBox qe i shfaqet
                //ekzekutohet procedura qe fshin rekordin nga DB dhe ri-merren perdoruesit nga DB per tu shfaqur
            if (((Form)(sender)).DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
            {
                Lidhja.Kerkesat1.a.deleteFromTable(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), "users");
                loadUsers();
            }
        }//COMM

        private void anuloBtn_Click(object sender, EventArgs e)
        {
            //ne rastin kur jemi duke shtuar ose edituar dhe duam te anulojme procesin, thjesht caktivizohen elementet ku hidhen
                //informacionet per shtim ose editim
            disableElements();
        }//COMM

        private void ruajBtn_Click(object sender, EventArgs e)
        {
            //ne klikim te butonit RUAJ ne rastin kur jemi duke shtuar ose edituar
            if (editing)
            {
                //nese jemi duke edituar, kontrollojme fillimisht nese jane te hedhura te gjitha informacionet e perdoruesit 
                    //qe po editohet dhe me pas ekzekutojme proceduren qe ben UPDATE
                if (emriTxt.Text != "" && mbiemriTxt.Text != "" && idTxt.Text != "" && usernameTxt.Text != "" && passwordTxt.Text != "" && (this.radioButton1.Checked || this.radioButton2.Checked))
                {
                    Lidhja.Kerkesat1.a.updateUser(this.radGridView1.SelectedRows[0].Cells[0].Value.ToString(), emriTxt.Text, mbiemriTxt.Text, idTxt.Text, usernameTxt.Text, passwordTxt.Text, (this.radioButton1.Checked ? "Admin" : "Kasier"));
                    MessageBox.Show("Perdoruesi u ruajt!");
                    //ri-marrim perdoruesit nga DB
                    loadUsers();
                    disableElements();
                }
                else
                {
                    //perndryshe njoftojme perdoruesin per informacionin jo te plote
                    MessageBox.Show("Te dhenat e inseruara nuk jane te plota! \r\nJepni informacionin e sakte!");
                }
            }
            else
            {
                //nese jemi duke edituar, kontrollojme fillimisht nese jane te hedhura te gjitha informacionet e perdoruesit 
                    //te ri dhe me pas ekzekutojme proceduren qe ben INSERT
                if (emriTxt.Text != "" && mbiemriTxt.Text != "" && idTxt.Text != "" && usernameTxt.Text != "" && passwordTxt.Text != "" && (this.radioButton1.Checked || this.radioButton2.Checked))
                {
                    Lidhja.Kerkesat1.a.insertUser(emriTxt.Text, mbiemriTxt.Text, idTxt.Text, usernameTxt.Text, passwordTxt.Text, (this.radioButton1.Checked ? "Admin" : "Cashier"));
                    MessageBox.Show("Perdoruesi u ruajt!");
                    loadUsers();
                    disableElements();
                }
                else
                {
                    MessageBox.Show("Te dhenat e inseruara nuk jane te plota! \r\nJepni informacionin e sakte!");
                }
            }
        }//COMM
    }
}