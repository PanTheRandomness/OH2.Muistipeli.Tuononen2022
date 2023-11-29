namespace OH2.Muistipeli.Tuononen
{
    partial class frmTilastot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTilastot));
            this.dgvPelaajatilastot = new System.Windows.Forms.DataGridView();
            this.btnTakaisin = new System.Windows.Forms.Button();
            this.btnPoista = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelaajatilastot)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPelaajatilastot
            // 
            this.dgvPelaajatilastot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPelaajatilastot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPelaajatilastot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPelaajatilastot.Location = new System.Drawing.Point(0, 0);
            this.dgvPelaajatilastot.Name = "dgvPelaajatilastot";
            this.dgvPelaajatilastot.Size = new System.Drawing.Size(818, 543);
            this.dgvPelaajatilastot.TabIndex = 0;
            this.dgvPelaajatilastot.SelectionChanged += new System.EventHandler(this.dgvPelaajatilastot_SelectionChanged);
            // 
            // btnTakaisin
            // 
            this.btnTakaisin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTakaisin.Location = new System.Drawing.Point(743, 549);
            this.btnTakaisin.Name = "btnTakaisin";
            this.btnTakaisin.Size = new System.Drawing.Size(75, 23);
            this.btnTakaisin.TabIndex = 1;
            this.btnTakaisin.Text = "Takaisin";
            this.btnTakaisin.UseVisualStyleBackColor = true;
            this.btnTakaisin.Click += new System.EventHandler(this.btnTakaisin_Click);
            // 
            // btnPoista
            // 
            this.btnPoista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPoista.Location = new System.Drawing.Point(662, 549);
            this.btnPoista.Name = "btnPoista";
            this.btnPoista.Size = new System.Drawing.Size(75, 23);
            this.btnPoista.TabIndex = 2;
            this.btnPoista.Text = "Poista";
            this.btnPoista.UseVisualStyleBackColor = true;
            this.btnPoista.Click += new System.EventHandler(this.btnPoista_Click);
            // 
            // frmTilastot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 581);
            this.Controls.Add(this.btnPoista);
            this.Controls.Add(this.btnTakaisin);
            this.Controls.Add(this.dgvPelaajatilastot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(822, 125);
            this.Name = "frmTilastot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muistipeli: Tilastot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTilastot_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelaajatilastot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPelaajatilastot;
        private System.Windows.Forms.Button btnTakaisin;
        private System.Windows.Forms.Button btnPoista;
    }
}