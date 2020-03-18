using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ExchangeOnline
{
    partial class ImportFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.sourceBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.destinationBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.konfirmoBtn = new Gizmox.WebGUI.Forms.Button();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.shitjeBlerjeBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.tabPageContainer = new Gizmox.WebGUI.Forms.TabControl();
            this.burimeTeJashtmeTab = new Gizmox.WebGUI.Forms.TabPage();
            this.dataSpecifikeTabPage = new Gizmox.WebGUI.Forms.TabPage();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.dateTimePicker1 = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.konfirmoBtnDate = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageContainer)).BeginInit();
            this.tabPageContainer.SuspendLayout();
            this.burimeTeJashtmeTab.SuspendLayout();
            this.dataSpecifikeTabPage.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Importo te Dhenat Nga :";
            // 
            // sourceBox
            // 

            this.sourceBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.sourceBox.FormattingEnabled = true;
            this.sourceBox.Items.AddRange(new object[] {
            "Yahoo"});
            this.sourceBox.Location = new System.Drawing.Point(2, 24);
            this.sourceBox.Name = "sourceBox";
            this.sourceBox.Size = new System.Drawing.Size(243, 21);
            this.sourceBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destinacioni :";
            // 
            // destinationBox
            // 

            this.destinationBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.destinationBox.FormattingEnabled = true;
            this.destinationBox.Items.AddRange(new object[] {
            "Arka",
            "Banka"});
            this.destinationBox.Location = new System.Drawing.Point(2, 70);
            this.destinationBox.Name = "destinationBox";
            this.destinationBox.Size = new System.Drawing.Size(243, 21);
            this.destinationBox.TabIndex = 2;
            // 
            // konfirmoBtn
            // 
            this.konfirmoBtn.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.konfirmoBtn.Location = new System.Drawing.Point(0, 147);
            this.konfirmoBtn.Name = "konfirmoBtn";
            this.konfirmoBtn.Size = new System.Drawing.Size(240, 29);
            this.konfirmoBtn.TabIndex = 4;
            this.konfirmoBtn.Text = "Ruaj";
            this.konfirmoBtn.Click += new System.EventHandler(this.konfirmoBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kursi :";
            // 
            // shitjeBlerjeBox
            // 

            this.shitjeBlerjeBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.shitjeBlerjeBox.FormattingEnabled = true;
            this.shitjeBlerjeBox.Items.AddRange(new object[] {
            "Shitje",
            "Blerje"});
            this.shitjeBlerjeBox.Location = new System.Drawing.Point(2, 112);
            this.shitjeBlerjeBox.Name = "shitjeBlerjeBox";
            this.shitjeBlerjeBox.Size = new System.Drawing.Size(243, 21);
            this.shitjeBlerjeBox.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.shitjeBlerjeBox);
            this.panel1.Controls.Add(this.sourceBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.konfirmoBtn);
            this.panel1.Controls.Add(this.destinationBox);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 176);
            this.panel1.TabIndex = 5;
            // 
            // tabPageContainer
            // 
            this.tabPageContainer.Controls.Add(this.burimeTeJashtmeTab);
            this.tabPageContainer.Controls.Add(this.dataSpecifikeTabPage);
            this.tabPageContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPageContainer.Location = new System.Drawing.Point(0, 0);
            this.tabPageContainer.Name = "tabPageContainer";
            this.tabPageContainer.SelectedIndex = 0;
            this.tabPageContainer.Size = new System.Drawing.Size(254, 208);
            this.tabPageContainer.TabIndex = 6;

            // 
            // burimeTeJashtmeTab
            // 
            this.burimeTeJashtmeTab.Controls.Add(this.panel1);
            this.burimeTeJashtmeTab.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.burimeTeJashtmeTab.Location = new System.Drawing.Point(4, 22);
            this.burimeTeJashtmeTab.Name = "burimeTeJashtmeTab";
            this.burimeTeJashtmeTab.Size = new System.Drawing.Size(246, 182);
            this.burimeTeJashtmeTab.TabIndex = 1;
            this.burimeTeJashtmeTab.Text = "Burime te Jashtme";
            // 
            // dataSpecifikeTabPage
            // 
            this.dataSpecifikeTabPage.Controls.Add(this.panel3);
            this.dataSpecifikeTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dataSpecifikeTabPage.Location = new System.Drawing.Point(0, 0);
            this.dataSpecifikeTabPage.Name = "dataSpecifikeTabPage";
            this.dataSpecifikeTabPage.Size = new System.Drawing.Size(246, 182);
            this.dataSpecifikeTabPage.TabIndex = 2;
            this.dataSpecifikeTabPage.Text = "Date Specifike";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.konfirmoBtnDate);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 182);
            this.panel3.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Location = new System.Drawing.Point(5, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(236, 21);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Data";
            // 
            // konfirmoBtnDate
            // 
            this.konfirmoBtnDate.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.konfirmoBtnDate.Location = new System.Drawing.Point(0, 153);
            this.konfirmoBtnDate.Name = "konfirmoBtnDate";
            this.konfirmoBtnDate.Size = new System.Drawing.Size(246, 29);
            this.konfirmoBtnDate.TabIndex = 4;
            this.konfirmoBtnDate.Text = "Ruaj";
            this.konfirmoBtnDate.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImportFrom
            // 
            this.Controls.Add(this.tabPageContainer);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedToolWindow;
            this.Size = new System.Drawing.Size(254, 208);
            this.Text = "ImportFrom";
            this.Load += new System.EventHandler(this.ImportFrom_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageContainer)).EndInit();
            this.tabPageContainer.ResumeLayout(false);
            this.burimeTeJashtmeTab.ResumeLayout(false);
            this.dataSpecifikeTabPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private ComboBox sourceBox;
        private Label label2;
        private ComboBox destinationBox;
        private Label label3;
        private ComboBox shitjeBlerjeBox;
        public Button konfirmoBtn;
        private Panel panel1;
        private TabControl tabPageContainer;
        private TabPage burimeTeJashtmeTab;
        private TabPage dataSpecifikeTabPage;
        private Panel panel3;
        public Button konfirmoBtnDate;
        private DateTimePicker dateTimePicker1;
        private Label label4;


    }
}