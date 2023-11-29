namespace OH2.Muistipeli.Tuononen
{
    partial class frmMuistipeli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMuistipeli));
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.tslblPelaaja = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblParitYht = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblParitStreak = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblAika = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrPelinAika = new System.Windows.Forms.Timer(this.components);
            this.tmrEiParia = new System.Windows.Forms.Timer(this.components);
            this.tsToiminnot = new System.Windows.Forms.ToolStrip();
            this.tsbtnTallenna = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPausePlay = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLuovuta = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPoistu = new System.Windows.Forms.ToolStripButton();
            this.tmrPoistaParit = new System.Windows.Forms.Timer(this.components);
            this.tmrTallennettuFalse = new System.Windows.Forms.Timer(this.components);
            this.pnlpaneli = new System.Windows.Forms.Panel();
            this.stsStatus.SuspendLayout();
            this.tsToiminnot.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsStatus
            // 
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblPelaaja,
            this.tslblParitYht,
            this.tslblParitStreak,
            this.tslblAika});
            this.stsStatus.Location = new System.Drawing.Point(0, 584);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(869, 22);
            this.stsStatus.TabIndex = 0;
            this.stsStatus.Text = "stsStatus";
            // 
            // tslblPelaaja
            // 
            this.tslblPelaaja.Name = "tslblPelaaja";
            this.tslblPelaaja.Size = new System.Drawing.Size(47, 17);
            this.tslblPelaaja.Text = "Pelaaja:";
            // 
            // tslblParitYht
            // 
            this.tslblParitYht.Name = "tslblParitYht";
            this.tslblParitYht.Size = new System.Drawing.Size(34, 17);
            this.tslblParitYht.Text = "Parit:";
            // 
            // tslblParitStreak
            // 
            this.tslblParitStreak.Name = "tslblParitStreak";
            this.tslblParitStreak.Size = new System.Drawing.Size(42, 17);
            this.tslblParitStreak.Text = "Streak:";
            // 
            // tslblAika
            // 
            this.tslblAika.Name = "tslblAika";
            this.tslblAika.Size = new System.Drawing.Size(49, 17);
            this.tslblAika.Text = "00:00:00";
            // 
            // tmrPelinAika
            // 
            this.tmrPelinAika.Enabled = true;
            this.tmrPelinAika.Interval = 1000;
            this.tmrPelinAika.Tick += new System.EventHandler(this.tmrPelinAika_Tick);
            // 
            // tmrEiParia
            // 
            this.tmrEiParia.Interval = 1200;
            this.tmrEiParia.Tick += new System.EventHandler(this.tmrEiParia_Tick);
            // 
            // tsToiminnot
            // 
            this.tsToiminnot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnTallenna,
            this.tsbtnPausePlay,
            this.tsbtnLuovuta,
            this.tsbtnPoistu});
            this.tsToiminnot.Location = new System.Drawing.Point(0, 0);
            this.tsToiminnot.Name = "tsToiminnot";
            this.tsToiminnot.Size = new System.Drawing.Size(869, 25);
            this.tsToiminnot.TabIndex = 1;
            this.tsToiminnot.Text = "tsToiminnot";
            // 
            // tsbtnTallenna
            // 
            this.tsbtnTallenna.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnTallenna.Image = global::OH2.Muistipeli.Tuononen.Properties.Resources._00save;
            this.tsbtnTallenna.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTallenna.Name = "tsbtnTallenna";
            this.tsbtnTallenna.Size = new System.Drawing.Size(23, 22);
            this.tsbtnTallenna.Text = "Tallenna";
            this.tsbtnTallenna.Click += new System.EventHandler(this.tsbtnTallenna_Click);
            // 
            // tsbtnPausePlay
            // 
            this.tsbtnPausePlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPausePlay.Image = global::OH2.Muistipeli.Tuononen.Properties.Resources._00playpause;
            this.tsbtnPausePlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPausePlay.Name = "tsbtnPausePlay";
            this.tsbtnPausePlay.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPausePlay.Text = "Pause/Play";
            this.tsbtnPausePlay.Click += new System.EventHandler(this.tsbtnPausePlay_Click);
            // 
            // tsbtnLuovuta
            // 
            this.tsbtnLuovuta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLuovuta.Image = global::OH2.Muistipeli.Tuononen.Properties.Resources._00Luovuta;
            this.tsbtnLuovuta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLuovuta.Name = "tsbtnLuovuta";
            this.tsbtnLuovuta.Size = new System.Drawing.Size(23, 22);
            this.tsbtnLuovuta.Text = "Luovuta";
            this.tsbtnLuovuta.Click += new System.EventHandler(this.tslvblLuovuta_Click);
            // 
            // tsbtnPoistu
            // 
            this.tsbtnPoistu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPoistu.Image = global::OH2.Muistipeli.Tuononen.Properties.Resources._00Poistu;
            this.tsbtnPoistu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPoistu.Name = "tsbtnPoistu";
            this.tsbtnPoistu.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPoistu.Text = "Poistu";
            this.tsbtnPoistu.Click += new System.EventHandler(this.tsbtnPoistu_Click);
            // 
            // tmrPoistaParit
            // 
            this.tmrPoistaParit.Interval = 1200;
            this.tmrPoistaParit.Tick += new System.EventHandler(this.tmrPoistaParit_Tick);
            // 
            // tmrTallennettuFalse
            // 
            this.tmrTallennettuFalse.Interval = 500;
            this.tmrTallennettuFalse.Tick += new System.EventHandler(this.tmrTallennettuFalse_Tick);
            // 
            // pnlpaneli
            // 
            this.pnlpaneli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlpaneli.Location = new System.Drawing.Point(0, 26);
            this.pnlpaneli.Name = "pnlpaneli";
            this.pnlpaneli.Size = new System.Drawing.Size(867, 558);
            this.pnlpaneli.TabIndex = 2;
            // 
            // frmMuistipeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(869, 606);
            this.Controls.Add(this.pnlpaneli);
            this.Controls.Add(this.tsToiminnot);
            this.Controls.Add(this.stsStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMuistipeli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muistipeli";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMuistipeli_FormClosing);
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            this.tsToiminnot.ResumeLayout(false);
            this.tsToiminnot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslblPelaaja;
        private System.Windows.Forms.ToolStripStatusLabel tslblParitYht;
        private System.Windows.Forms.ToolStripStatusLabel tslblParitStreak;
        private System.Windows.Forms.ToolStripStatusLabel tslblAika;
        private System.Windows.Forms.Timer tmrPelinAika;
        private System.Windows.Forms.Timer tmrEiParia;
        private System.Windows.Forms.ToolStrip tsToiminnot;
        private System.Windows.Forms.ToolStripButton tsbtnTallenna;
        private System.Windows.Forms.ToolStripButton tsbtnPausePlay;
        private System.Windows.Forms.ToolStripButton tsbtnPoistu;
        private System.Windows.Forms.ToolStripButton tsbtnLuovuta;
        private System.Windows.Forms.Timer tmrPoistaParit;
        private System.Windows.Forms.Timer tmrTallennettuFalse;
        private System.Windows.Forms.Panel pnlpaneli;
    }
}