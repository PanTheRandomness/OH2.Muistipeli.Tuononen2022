namespace OH2.Muistipeli.Tuononen
{
    partial class frmUusiPeli
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUusiPeli));
            this.epUusiPeli = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblPelimuoto = new System.Windows.Forms.Label();
            this.cmbPelimuoto = new System.Windows.Forms.ComboBox();
            this.pnlSolo = new System.Windows.Forms.Panel();
            this.cmbp1Valitse = new System.Windows.Forms.ComboBox();
            this.lblPelaaja1 = new System.Windows.Forms.Label();
            this.lblUusiSoloNimi = new System.Windows.Forms.Label();
            this.tbUusiSoloNimi = new System.Windows.Forms.TextBox();
            this.cbUusiSolo = new System.Windows.Forms.CheckBox();
            this.lblValitsep1 = new System.Windows.Forms.Label();
            this.pnlDuo = new System.Windows.Forms.Panel();
            this.cmbp2Valitse = new System.Windows.Forms.ComboBox();
            this.lblUusiDuoNimi = new System.Windows.Forms.Label();
            this.tbUusiDuoNimi = new System.Windows.Forms.TextBox();
            this.cbUusiDuo = new System.Windows.Forms.CheckBox();
            this.lblValitsep2 = new System.Windows.Forms.Label();
            this.lblPelaaja2 = new System.Windows.Forms.Label();
            this.btnPeruuta = new System.Windows.Forms.Button();
            this.btnAloita = new System.Windows.Forms.Button();
            this.nudKorttienMaara = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlUusiPeli = new System.Windows.Forms.Panel();
            this.pnlVanhaPeli = new System.Windows.Forms.Panel();
            this.btnValistePeli = new System.Windows.Forms.Button();
            this.cbJatkaTallennusta = new System.Windows.Forms.CheckBox();
            this.fbdValitsePeli = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.epUusiPeli)).BeginInit();
            this.pnlSolo.SuspendLayout();
            this.pnlDuo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKorttienMaara)).BeginInit();
            this.pnlUusiPeli.SuspendLayout();
            this.pnlVanhaPeli.SuspendLayout();
            this.SuspendLayout();
            // 
            // epUusiPeli
            // 
            this.epUusiPeli.ContainerControl = this;
            // 
            // lblPelimuoto
            // 
            this.lblPelimuoto.AutoSize = true;
            this.lblPelimuoto.Font = new System.Drawing.Font("Javanese Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelimuoto.Location = new System.Drawing.Point(2, 8);
            this.lblPelimuoto.Name = "lblPelimuoto";
            this.lblPelimuoto.Size = new System.Drawing.Size(81, 29);
            this.lblPelimuoto.TabIndex = 2;
            this.lblPelimuoto.Text = "Pelimuoto";
            // 
            // cmbPelimuoto
            // 
            this.cmbPelimuoto.FormattingEnabled = true;
            this.cmbPelimuoto.Items.AddRange(new object[] {
            "-",
            "Solo",
            "Duo"});
            this.cmbPelimuoto.Location = new System.Drawing.Point(89, 10);
            this.cmbPelimuoto.Name = "cmbPelimuoto";
            this.cmbPelimuoto.Size = new System.Drawing.Size(121, 21);
            this.cmbPelimuoto.TabIndex = 2;
            this.cmbPelimuoto.Text = "-";
            this.cmbPelimuoto.SelectedIndexChanged += new System.EventHandler(this.cmbPelimuoto_SelectedIndexChanged);
            // 
            // pnlSolo
            // 
            this.pnlSolo.Controls.Add(this.cmbp1Valitse);
            this.pnlSolo.Controls.Add(this.lblPelaaja1);
            this.pnlSolo.Controls.Add(this.lblUusiSoloNimi);
            this.pnlSolo.Controls.Add(this.tbUusiSoloNimi);
            this.pnlSolo.Controls.Add(this.cbUusiSolo);
            this.pnlSolo.Controls.Add(this.lblValitsep1);
            this.pnlSolo.Enabled = false;
            this.pnlSolo.Location = new System.Drawing.Point(7, 40);
            this.pnlSolo.Name = "pnlSolo";
            this.pnlSolo.Size = new System.Drawing.Size(261, 132);
            this.pnlSolo.TabIndex = 3;
            // 
            // cmbp1Valitse
            // 
            this.cmbp1Valitse.Enabled = false;
            this.cmbp1Valitse.FormattingEnabled = true;
            this.cmbp1Valitse.Location = new System.Drawing.Point(79, 40);
            this.cmbp1Valitse.Name = "cmbp1Valitse";
            this.cmbp1Valitse.Size = new System.Drawing.Size(121, 21);
            this.cmbp1Valitse.TabIndex = 3;
            this.cmbp1Valitse.SelectedIndexChanged += new System.EventHandler(this.cmbp1Valitse_SelectedIndexChanged);
            this.cmbp1Valitse.Validating += new System.ComponentModel.CancelEventHandler(this.cmbp1Valitse_Validating);
            this.cmbp1Valitse.Validated += new System.EventHandler(this.cmbp1Valitse_Validated);
            // 
            // lblPelaaja1
            // 
            this.lblPelaaja1.AutoSize = true;
            this.lblPelaaja1.Font = new System.Drawing.Font("Javanese Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelaaja1.Location = new System.Drawing.Point(3, 13);
            this.lblPelaaja1.Name = "lblPelaaja1";
            this.lblPelaaja1.Size = new System.Drawing.Size(65, 27);
            this.lblPelaaja1.TabIndex = 3;
            this.lblPelaaja1.Text = "Pelaaja 1";
            // 
            // lblUusiSoloNimi
            // 
            this.lblUusiSoloNimi.AutoSize = true;
            this.lblUusiSoloNimi.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUusiSoloNimi.Location = new System.Drawing.Point(30, 102);
            this.lblUusiSoloNimi.Name = "lblUusiSoloNimi";
            this.lblUusiSoloNimi.Size = new System.Drawing.Size(39, 25);
            this.lblUusiSoloNimi.TabIndex = 5;
            this.lblUusiSoloNimi.Text = "Nimi";
            // 
            // tbUusiSoloNimi
            // 
            this.tbUusiSoloNimi.Enabled = false;
            this.tbUusiSoloNimi.Location = new System.Drawing.Point(75, 102);
            this.tbUusiSoloNimi.Name = "tbUusiSoloNimi";
            this.tbUusiSoloNimi.Size = new System.Drawing.Size(100, 20);
            this.tbUusiSoloNimi.TabIndex = 5;
            this.tbUusiSoloNimi.Validating += new System.ComponentModel.CancelEventHandler(this.tbUusiSoloNimi_Validating);
            this.tbUusiSoloNimi.Validated += new System.EventHandler(this.tbUusiSoloNimi_Validated);
            // 
            // cbUusiSolo
            // 
            this.cbUusiSolo.AutoSize = true;
            this.cbUusiSolo.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUusiSolo.Location = new System.Drawing.Point(52, 70);
            this.cbUusiSolo.Name = "cbUusiSolo";
            this.cbUusiSolo.Size = new System.Drawing.Size(100, 29);
            this.cbUusiSolo.TabIndex = 4;
            this.cbUusiSolo.Text = "Uusi pelaaja";
            this.cbUusiSolo.UseVisualStyleBackColor = true;
            this.cbUusiSolo.CheckedChanged += new System.EventHandler(this.cmUusiSolo_CheckedChanged);
            // 
            // lblValitsep1
            // 
            this.lblValitsep1.AutoSize = true;
            this.lblValitsep1.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValitsep1.Location = new System.Drawing.Point(3, 40);
            this.lblValitsep1.Name = "lblValitsep1";
            this.lblValitsep1.Size = new System.Drawing.Size(51, 25);
            this.lblValitsep1.TabIndex = 3;
            this.lblValitsep1.Text = "Valitse";
            // 
            // pnlDuo
            // 
            this.pnlDuo.Controls.Add(this.cmbp2Valitse);
            this.pnlDuo.Controls.Add(this.lblUusiDuoNimi);
            this.pnlDuo.Controls.Add(this.tbUusiDuoNimi);
            this.pnlDuo.Controls.Add(this.cbUusiDuo);
            this.pnlDuo.Controls.Add(this.lblValitsep2);
            this.pnlDuo.Controls.Add(this.lblPelaaja2);
            this.pnlDuo.Enabled = false;
            this.pnlDuo.Location = new System.Drawing.Point(7, 178);
            this.pnlDuo.Name = "pnlDuo";
            this.pnlDuo.Size = new System.Drawing.Size(261, 154);
            this.pnlDuo.TabIndex = 6;
            // 
            // cmbp2Valitse
            // 
            this.cmbp2Valitse.Enabled = false;
            this.cmbp2Valitse.FormattingEnabled = true;
            this.cmbp2Valitse.Location = new System.Drawing.Point(80, 41);
            this.cmbp2Valitse.Name = "cmbp2Valitse";
            this.cmbp2Valitse.Size = new System.Drawing.Size(121, 21);
            this.cmbp2Valitse.TabIndex = 6;
            this.cmbp2Valitse.SelectedIndexChanged += new System.EventHandler(this.cmbp1Valitse_SelectedIndexChanged);
            this.cmbp2Valitse.Validating += new System.ComponentModel.CancelEventHandler(this.cmbp2Valitse_Validating);
            this.cmbp2Valitse.Validated += new System.EventHandler(this.cmbp2Valitse_Validated);
            // 
            // lblUusiDuoNimi
            // 
            this.lblUusiDuoNimi.AutoSize = true;
            this.lblUusiDuoNimi.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUusiDuoNimi.Location = new System.Drawing.Point(30, 103);
            this.lblUusiDuoNimi.Name = "lblUusiDuoNimi";
            this.lblUusiDuoNimi.Size = new System.Drawing.Size(39, 25);
            this.lblUusiDuoNimi.TabIndex = 8;
            this.lblUusiDuoNimi.Text = "Nimi";
            // 
            // tbUusiDuoNimi
            // 
            this.tbUusiDuoNimi.Enabled = false;
            this.tbUusiDuoNimi.Location = new System.Drawing.Point(75, 103);
            this.tbUusiDuoNimi.Name = "tbUusiDuoNimi";
            this.tbUusiDuoNimi.Size = new System.Drawing.Size(100, 20);
            this.tbUusiDuoNimi.TabIndex = 8;
            this.tbUusiDuoNimi.Validating += new System.ComponentModel.CancelEventHandler(this.tbUusiDuoNimi_Validating);
            this.tbUusiDuoNimi.Validated += new System.EventHandler(this.tbUusiDuoNimi_Validated);
            // 
            // cbUusiDuo
            // 
            this.cbUusiDuo.AutoSize = true;
            this.cbUusiDuo.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUusiDuo.Location = new System.Drawing.Point(52, 71);
            this.cbUusiDuo.Name = "cbUusiDuo";
            this.cbUusiDuo.Size = new System.Drawing.Size(100, 29);
            this.cbUusiDuo.TabIndex = 7;
            this.cbUusiDuo.Text = "Uusi pelaaja";
            this.cbUusiDuo.UseVisualStyleBackColor = true;
            this.cbUusiDuo.CheckedChanged += new System.EventHandler(this.cmUusiSolo_CheckedChanged);
            // 
            // lblValitsep2
            // 
            this.lblValitsep2.AutoSize = true;
            this.lblValitsep2.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValitsep2.Location = new System.Drawing.Point(3, 41);
            this.lblValitsep2.Name = "lblValitsep2";
            this.lblValitsep2.Size = new System.Drawing.Size(51, 25);
            this.lblValitsep2.TabIndex = 6;
            this.lblValitsep2.Text = "Valitse";
            // 
            // lblPelaaja2
            // 
            this.lblPelaaja2.AutoSize = true;
            this.lblPelaaja2.Font = new System.Drawing.Font("Javanese Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelaaja2.Location = new System.Drawing.Point(3, 14);
            this.lblPelaaja2.Name = "lblPelaaja2";
            this.lblPelaaja2.Size = new System.Drawing.Size(68, 27);
            this.lblPelaaja2.TabIndex = 6;
            this.lblPelaaja2.Text = "Pelaaja 2";
            // 
            // btnPeruuta
            // 
            this.btnPeruuta.Font = new System.Drawing.Font("Javanese Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeruuta.Location = new System.Drawing.Point(125, 457);
            this.btnPeruuta.Name = "btnPeruuta";
            this.btnPeruuta.Size = new System.Drawing.Size(75, 28);
            this.btnPeruuta.TabIndex = 11;
            this.btnPeruuta.Text = "Peruuta";
            this.btnPeruuta.UseVisualStyleBackColor = true;
            this.btnPeruuta.Click += new System.EventHandler(this.btnPeruuta_Click);
            // 
            // btnAloita
            // 
            this.btnAloita.Font = new System.Drawing.Font("Javanese Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAloita.Location = new System.Drawing.Point(263, 457);
            this.btnAloita.Name = "btnAloita";
            this.btnAloita.Size = new System.Drawing.Size(75, 28);
            this.btnAloita.TabIndex = 10;
            this.btnAloita.Text = "Aloita";
            this.btnAloita.UseVisualStyleBackColor = true;
            this.btnAloita.Click += new System.EventHandler(this.btnAloita_Click);
            // 
            // nudKorttienMaara
            // 
            this.nudKorttienMaara.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudKorttienMaara.Location = new System.Drawing.Point(121, 338);
            this.nudKorttienMaara.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.nudKorttienMaara.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudKorttienMaara.Name = "nudKorttienMaara";
            this.nudKorttienMaara.Size = new System.Drawing.Size(90, 20);
            this.nudKorttienMaara.TabIndex = 9;
            this.nudKorttienMaara.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudKorttienMaara.ValueChanged += new System.EventHandler(this.nudKorttienMaara_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Javanese Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Korttien määrä";
            // 
            // pnlUusiPeli
            // 
            this.pnlUusiPeli.Controls.Add(this.nudKorttienMaara);
            this.pnlUusiPeli.Controls.Add(this.pnlDuo);
            this.pnlUusiPeli.Controls.Add(this.label1);
            this.pnlUusiPeli.Controls.Add(this.pnlSolo);
            this.pnlUusiPeli.Controls.Add(this.cmbPelimuoto);
            this.pnlUusiPeli.Controls.Add(this.lblPelimuoto);
            this.pnlUusiPeli.Location = new System.Drawing.Point(85, 79);
            this.pnlUusiPeli.Name = "pnlUusiPeli";
            this.pnlUusiPeli.Size = new System.Drawing.Size(279, 363);
            this.pnlUusiPeli.TabIndex = 2;
            // 
            // pnlVanhaPeli
            // 
            this.pnlVanhaPeli.Controls.Add(this.btnValistePeli);
            this.pnlVanhaPeli.Controls.Add(this.cbJatkaTallennusta);
            this.pnlVanhaPeli.Location = new System.Drawing.Point(85, 12);
            this.pnlVanhaPeli.Name = "pnlVanhaPeli";
            this.pnlVanhaPeli.Size = new System.Drawing.Size(279, 70);
            this.pnlVanhaPeli.TabIndex = 0;
            // 
            // btnValistePeli
            // 
            this.btnValistePeli.Enabled = false;
            this.btnValistePeli.Font = new System.Drawing.Font("Javanese Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValistePeli.Location = new System.Drawing.Point(156, 20);
            this.btnValistePeli.Name = "btnValistePeli";
            this.btnValistePeli.Size = new System.Drawing.Size(112, 29);
            this.btnValistePeli.TabIndex = 1;
            this.btnValistePeli.Text = "Valitse peli";
            this.btnValistePeli.UseVisualStyleBackColor = true;
            this.btnValistePeli.Click += new System.EventHandler(this.btnValistePeli_Click);
            // 
            // cbJatkaTallennusta
            // 
            this.cbJatkaTallennusta.AutoSize = true;
            this.cbJatkaTallennusta.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbJatkaTallennusta.Location = new System.Drawing.Point(7, 21);
            this.cbJatkaTallennusta.Name = "cbJatkaTallennusta";
            this.cbJatkaTallennusta.Size = new System.Drawing.Size(128, 29);
            this.cbJatkaTallennusta.TabIndex = 0;
            this.cbJatkaTallennusta.Text = "Jatka tallennusta";
            this.cbJatkaTallennusta.UseVisualStyleBackColor = true;
            this.cbJatkaTallennusta.CheckedChanged += new System.EventHandler(this.cbJatkaTallennusta_CheckedChanged);
            // 
            // frmUusiPeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 497);
            this.Controls.Add(this.pnlVanhaPeli);
            this.Controls.Add(this.pnlUusiPeli);
            this.Controls.Add(this.btnAloita);
            this.Controls.Add(this.btnPeruuta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(467, 536);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(467, 536);
            this.Name = "frmUusiPeli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muistipeli: Uusi peli";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUusiPeli_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.epUusiPeli)).EndInit();
            this.pnlSolo.ResumeLayout(false);
            this.pnlSolo.PerformLayout();
            this.pnlDuo.ResumeLayout(false);
            this.pnlDuo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKorttienMaara)).EndInit();
            this.pnlUusiPeli.ResumeLayout(false);
            this.pnlUusiPeli.PerformLayout();
            this.pnlVanhaPeli.ResumeLayout(false);
            this.pnlVanhaPeli.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epUusiPeli;
        private System.Windows.Forms.ComboBox cmbPelimuoto;
        private System.Windows.Forms.Label lblPelimuoto;
        private System.Windows.Forms.Panel pnlSolo;
        private System.Windows.Forms.Label lblUusiSoloNimi;
        private System.Windows.Forms.TextBox tbUusiSoloNimi;
        private System.Windows.Forms.CheckBox cbUusiSolo;
        private System.Windows.Forms.Label lblValitsep1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudKorttienMaara;
        private System.Windows.Forms.Button btnAloita;
        private System.Windows.Forms.Button btnPeruuta;
        private System.Windows.Forms.Panel pnlDuo;
        private System.Windows.Forms.Label lblUusiDuoNimi;
        private System.Windows.Forms.TextBox tbUusiDuoNimi;
        private System.Windows.Forms.CheckBox cbUusiDuo;
        private System.Windows.Forms.Label lblValitsep2;
        private System.Windows.Forms.Label lblPelaaja2;
        private System.Windows.Forms.Label lblPelaaja1;
        private System.Windows.Forms.ComboBox cmbp2Valitse;
        private System.Windows.Forms.ComboBox cmbp1Valitse;
        private System.Windows.Forms.Panel pnlUusiPeli;
        private System.Windows.Forms.Panel pnlVanhaPeli;
        private System.Windows.Forms.CheckBox cbJatkaTallennusta;
        private System.Windows.Forms.Button btnValistePeli;
        private System.Windows.Forms.FolderBrowserDialog fbdValitsePeli;
    }
}