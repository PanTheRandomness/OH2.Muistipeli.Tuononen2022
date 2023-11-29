using System;
using System.CodeDom;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OH2.Muistipeli.Tuononen
{
    public partial class frmTilastot : Form
    {
        public List<Pelaaja> pelaajat;
        public int valitturivi = -1;
        public frmTilastot()
        {
            InitializeComponent();

            if (File.Exists("c:\\temp\\pelaajat.xml"))
            {
                using (DataSet ds = new DataSet())
                {
                    ds.ReadXml("c:\\temp\\pelaajat.xml");
                    pelaajat = DeserializeXML();
                    foreach (Pelaaja p in pelaajat)
                        p.voittoprosentti = p.LaskeVoittopros(p.voitot, p.pelienmaara);
                    dgvPelaajatilastot.DataSource = ds.Tables[0];
                }
            }
            else
                pelaajat = new List<Pelaaja>();
            PaivitaTilasto();
        }
        public void PaivitaTilasto()
        {
            foreach (Pelaaja p in pelaajat)
                p.voittoprosentti = p.LaskeVoittopros(p.voitot, p.pelienmaara);
            dgvPelaajatilastot.DataSource = null;
            dgvPelaajatilastot.DataSource = pelaajat;

            dgvPelaajatilastot.Columns[0].HeaderText = "Nimi";
            dgvPelaajatilastot.Columns[1].HeaderText = "Pelien määrä";
            dgvPelaajatilastot.Columns[2].HeaderText = "Voitot";
            dgvPelaajatilastot.Columns[3].HeaderText = "Häviöt";
            dgvPelaajatilastot.Columns[4].HeaderText = "Voittoprosentti";
            dgvPelaajatilastot.Columns[5].Visible = false;
            dgvPelaajatilastot.Columns[6].Visible = false;
            dgvPelaajatilastot.Columns[7].Visible = false;
        }
        public void SerializeXML(List<Pelaaja> input)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(input.GetType());
                var sw = new StreamWriter("c:\\temp\\pelaajat.xml");
                serializer.Serialize(sw, input);
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public List<Pelaaja> DeserializeXML()
        {
            if (File.Exists("c:\\temp\\pelaajat.xml"))
            {
                StreamReader sr = new StreamReader("c:\\temp\\pelaajat.xml");
                XmlSerializer ser = new XmlSerializer(typeof(List<Pelaaja>));
                object obj = ser.Deserialize(sr);
                sr.Close();
                return (List<Pelaaja>)obj;
            }
            else
                return null;
        }
        private void btnTakaisin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menu = Application.OpenForms["frmMenu"];
            menu.Show();
        }

        private void btnPoista_Click(object sender, EventArgs e)
        {
            if (File.Exists("c:\\temp\\pelaajat.xml"))
            {
                valitturivi = dgvPelaajatilastot.CurrentRow.Index;
                try
                {
                    if (valitturivi >= 0)
                    {
                        if (MessageBox.Show("Halutko varmasti poistaa pelaajan ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            pelaajat.RemoveAt(valitturivi);

                            int i = 0;
                            foreach (Pelaaja p in pelaajat)//Tämä hoitaa indeksit kuntoon
                            {
                                p.indeksi = i;
                                i++;
                            }
                            SerializeXML(pelaajat);
                            PaivitaTilasto();
                        }
                    }
                }
                catch (FileNotFoundException ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void dgvPelaajatilastot_SelectionChanged(object sender, EventArgs e)
        {
            valitturivi = dgvPelaajatilastot.CurrentRow.Index;
        }

        private void frmTilastot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form menu = new Form();
            this.Hide();
            menu = Application.OpenForms["frmMenu"];
            menu.Show();
        }
    }
}
