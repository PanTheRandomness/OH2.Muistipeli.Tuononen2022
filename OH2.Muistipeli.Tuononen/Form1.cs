using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OH2.Muistipeli.Tuononen
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
       
        private void btnUusiPeli_Click(object sender, EventArgs e)
        {
            frmUusiPeli uP= new frmUusiPeli();
            uP.ShowDialog();
        }

        private void btnTilastot_Click(object sender, EventArgs e)
        {
            frmTilastot til=new frmTilastot();
            til.ShowDialog();
        }

        private void btnTietoja_Click(object sender, EventArgs e)
        {
            frmTietoja tie = new frmTietoja();
            tie.ShowDialog();
        }

        private void btnLopeta_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
