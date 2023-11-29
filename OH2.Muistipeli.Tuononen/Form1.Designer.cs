namespace OH2.Muistipeli.Tuononen
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.nfiMenu = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnPelaa = new System.Windows.Forms.Button();
            this.btnTilastot = new System.Windows.Forms.Button();
            this.btnTietoja = new System.Windows.Forms.Button();
            this.btnLopeta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nfiMenu
            // 
            this.nfiMenu.Icon = ((System.Drawing.Icon)(resources.GetObject("nfiMenu.Icon")));
            this.nfiMenu.Text = "Muistipeli";
            this.nfiMenu.Visible = true;
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Javanese Text", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(121, 24);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(99, 62);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Menu";
            // 
            // btnPelaa
            // 
            this.btnPelaa.Font = new System.Drawing.Font("Javanese Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPelaa.Location = new System.Drawing.Point(132, 107);
            this.btnPelaa.Name = "btnPelaa";
            this.btnPelaa.Size = new System.Drawing.Size(75, 30);
            this.btnPelaa.TabIndex = 0;
            this.btnPelaa.Text = "Pelaa";
            this.btnPelaa.UseVisualStyleBackColor = true;
            this.btnPelaa.Click += new System.EventHandler(this.btnUusiPeli_Click);
            // 
            // btnTilastot
            // 
            this.btnTilastot.Font = new System.Drawing.Font("Javanese Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTilastot.Location = new System.Drawing.Point(132, 169);
            this.btnTilastot.Name = "btnTilastot";
            this.btnTilastot.Size = new System.Drawing.Size(75, 32);
            this.btnTilastot.TabIndex = 2;
            this.btnTilastot.Text = "Tilastot";
            this.btnTilastot.UseVisualStyleBackColor = true;
            this.btnTilastot.Click += new System.EventHandler(this.btnTilastot_Click);
            // 
            // btnTietoja
            // 
            this.btnTietoja.Font = new System.Drawing.Font("Javanese Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTietoja.Location = new System.Drawing.Point(132, 236);
            this.btnTietoja.Name = "btnTietoja";
            this.btnTietoja.Size = new System.Drawing.Size(75, 31);
            this.btnTietoja.TabIndex = 3;
            this.btnTietoja.Text = "Tietoja";
            this.btnTietoja.UseVisualStyleBackColor = true;
            this.btnTietoja.Click += new System.EventHandler(this.btnTietoja_Click);
            // 
            // btnLopeta
            // 
            this.btnLopeta.Font = new System.Drawing.Font("Javanese Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopeta.Location = new System.Drawing.Point(132, 308);
            this.btnLopeta.Name = "btnLopeta";
            this.btnLopeta.Size = new System.Drawing.Size(75, 29);
            this.btnLopeta.TabIndex = 4;
            this.btnLopeta.Text = "Lopeta";
            this.btnLopeta.UseVisualStyleBackColor = true;
            this.btnLopeta.Click += new System.EventHandler(this.btnLopeta_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 415);
            this.Controls.Add(this.btnLopeta);
            this.Controls.Add(this.btnTietoja);
            this.Controls.Add(this.btnTilastot);
            this.Controls.Add(this.btnPelaa);
            this.Controls.Add(this.lblMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(372, 454);
            this.MinimumSize = new System.Drawing.Size(372, 454);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muistipeli: Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nfiMenu;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnPelaa;
        private System.Windows.Forms.Button btnTilastot;
        private System.Windows.Forms.Button btnTietoja;
        private System.Windows.Forms.Button btnLopeta;
    }
}

