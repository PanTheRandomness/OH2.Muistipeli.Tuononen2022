namespace OH2.Muistipeli.Tuononen
{
    partial class frmTietoja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTietoja));
            this.lblOhjelma = new System.Windows.Forms.Label();
            this.lblTyonanto = new System.Windows.Forms.Label();
            this.lblAika = new System.Windows.Forms.Label();
            this.lblTekija = new System.Windows.Forms.Label();
            this.btnTakaisin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOhjelma
            // 
            this.lblOhjelma.AutoSize = true;
            this.lblOhjelma.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOhjelma.Location = new System.Drawing.Point(48, 30);
            this.lblOhjelma.Name = "lblOhjelma";
            this.lblOhjelma.Size = new System.Drawing.Size(90, 25);
            this.lblOhjelma.TabIndex = 0;
            this.lblOhjelma.Text = "Muistipeli 1.0";
            // 
            // lblTyonanto
            // 
            this.lblTyonanto.AutoSize = true;
            this.lblTyonanto.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTyonanto.Location = new System.Drawing.Point(48, 56);
            this.lblTyonanto.Name = "lblTyonanto";
            this.lblTyonanto.Size = new System.Drawing.Size(214, 25);
            this.lblTyonanto.TabIndex = 1;
            this.lblTyonanto.Text = "Savonia, Ohjelmointi 2 harjoitustyö";
            // 
            // lblAika
            // 
            this.lblAika.AutoSize = true;
            this.lblAika.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAika.Location = new System.Drawing.Point(48, 80);
            this.lblAika.Name = "lblAika";
            this.lblAika.Size = new System.Drawing.Size(135, 25);
            this.lblAika.TabIndex = 2;
            this.lblAika.Text = "19.11.2022-15.12.2022";
            // 
            // lblTekija
            // 
            this.lblTekija.AutoSize = true;
            this.lblTekija.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTekija.Location = new System.Drawing.Point(48, 103);
            this.lblTekija.Name = "lblTekija";
            this.lblTekija.Size = new System.Drawing.Size(134, 25);
            this.lblTekija.TabIndex = 3;
            this.lblTekija.Text = "Tekijä: Pan Tuononen";
            // 
            // btnTakaisin
            // 
            this.btnTakaisin.Font = new System.Drawing.Font("Javanese Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakaisin.Location = new System.Drawing.Point(214, 142);
            this.btnTakaisin.Name = "btnTakaisin";
            this.btnTakaisin.Size = new System.Drawing.Size(85, 26);
            this.btnTakaisin.TabIndex = 4;
            this.btnTakaisin.Text = "Takaisin";
            this.btnTakaisin.UseVisualStyleBackColor = true;
            this.btnTakaisin.Click += new System.EventHandler(this.btnTakaisin_Click);
            // 
            // frmTietoja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 180);
            this.Controls.Add(this.btnTakaisin);
            this.Controls.Add(this.lblTekija);
            this.Controls.Add(this.lblAika);
            this.Controls.Add(this.lblTyonanto);
            this.Controls.Add(this.lblOhjelma);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(327, 219);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(327, 219);
            this.Name = "frmTietoja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muistipeli: Tietoja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblOhjelma;
        private System.Windows.Forms.Label lblTyonanto;
        private System.Windows.Forms.Label lblAika;
        private System.Windows.Forms.Label lblTekija;
        private System.Windows.Forms.Button btnTakaisin;
    }
}