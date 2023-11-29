using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OH2.Muistipeli.Tuononen
{
    public partial class frmUusiPeli : Form
    {
        public List<Pelaaja> pelaajat;
        public bool uusiPeli = true;
        public bool jatkaPeli = false;
        public bool pelimuotoSolo = false;
        public bool solocheck = false;
        public bool duocheck = false;
        public int korttienmaara = 4;
        public int ValittuRiviP1 = -1;
        public int ValittuRiviP2 = -1;
        public List<String> nimet1 = new List<String>();
        public List<String> nimet2 = new List<String>();
        public Peli peli;
        public bool muuttuikoarvo = false;
        public string tallennusnimi = "";
        public bool ekaonmuuttunut = false;
        public bool tokaonmuuttunut = false;
        public frmUusiPeli()
        {
            InitializeComponent();

            if (File.Exists("c:\\temp\\pelaajat.xml"))
            {
                cmbp1Valitse.Enabled = true;
                cmbp2Valitse.Enabled = true;

                pelaajat = DeserializeXML();

                int i = 0;
                foreach (Pelaaja p in pelaajat)//Tämä hoitaa indeksit kuntoon
                {
                    p.indeksi = i;
                    i++;
                }

                if (pelaajat.Count != 0)
                {
                    foreach (Pelaaja p in pelaajat)
                    {
                        nimet1.Add(p.nimi);
                        nimet2.Add(p.nimi);
                    }
                    cmbp1Valitse.DataSource = nimet1;
                    cmbp2Valitse.DataSource = nimet2;
                }
                else
                {
                    cbUusiSolo.Checked = true;
                    cbUusiDuo.Checked = true;
                    cmbp1Valitse.Enabled = false;
                    cmbp2Valitse.Enabled = false;
                }
            }
            else
                pelaajat = new List<Pelaaja>();
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
        private void cmUusiSolo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (cb == cbUusiSolo)
            {
                if (cb.Checked)
                {
                    tbUusiSoloNimi.Enabled = true;
                    solocheck = true;
                }
                else
                {
                    tbUusiSoloNimi.Enabled = false;
                    solocheck = false;
                    tbUusiSoloNimi.Text = String.Empty;
                }
            }
            else if (cb == cbUusiDuo)
            {
                if (cb.Checked)
                {
                    tbUusiDuoNimi.Enabled = true;
                    duocheck = true;
                }
                else
                {
                    tbUusiDuoNimi.Enabled = false;
                    duocheck = false;
                    tbUusiDuoNimi.Text = String.Empty;
                }
            }
        }

        private void btnAloita_Click(object sender, EventArgs e)
        {
            string msg = String.Empty;
            if (!ValidPelaaja1(ValittuRiviP1, ValittuRiviP2, out msg))
            {
                cmbp2Valitse.Select(0, cmbp1Valitse.SelectionLength);
                this.epUusiPeli.SetError(cmbp1Valitse, msg);
            }
            else
            {
                if (muuttuikoarvo == false)
                    korttienmaara = 8;
                LuoPeli(out peli);

                this.Hide();
                frmMuistipeli muistipeli = new frmMuistipeli(this);
                muistipeli.ShowDialog();
            }
        }

        private void tbUusiSoloNimi_Validated(object sender, EventArgs e)
        {
            epUusiPeli.SetError(tbUusiSoloNimi, String.Empty);
        }

        private void tbUusiSoloNimi_Validating(object sender, CancelEventArgs e)
        {
            string msg = String.Empty;

            if (!ValidNimi(tbUusiSoloNimi.Text, solocheck, out msg))
            {
                e.Cancel = true;
                tbUusiSoloNimi.Select(0, tbUusiSoloNimi.Text.Length);
                this.epUusiPeli.SetError(tbUusiSoloNimi, msg);
            }
        }
        public bool ValidNimi(string sNimi, bool check, out string msg)
        {
            msg = String.Empty;

            if ((sNimi.Trim().Length == 0) && check == true)
            {
                msg = "Nimi puuttuu";
                return false;
            }
            return true;
        }

        private void btnPeruuta_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menu = Application.OpenForms["frmMenu"];
            menu.Show();
        }

        private void cmbPelimuoto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPelimuoto.SelectedIndex == 0)
            {
                pelimuotoSolo = false;
                pnlSolo.Enabled = false;
                pnlDuo.Enabled = false;
            }
            else if (cmbPelimuoto.SelectedIndex == 1)
            {
                pelimuotoSolo = true;
                pnlSolo.Enabled = true;
                pnlDuo.Enabled = false;
            }
            else if (cmbPelimuoto.SelectedIndex == 2)
            {
                pelimuotoSolo = false;
                pnlSolo.Enabled = true;
                pnlDuo.Enabled = true;
            }
        }

        private void tbUusiDuoNimi_Validated(object sender, EventArgs e)
        {
            epUusiPeli.SetError(tbUusiDuoNimi, String.Empty);
        }

        private void tbUusiDuoNimi_Validating(object sender, CancelEventArgs e)
        {
            string msg = String.Empty;

            if (!ValidNimi(tbUusiDuoNimi.Text, duocheck, out msg))
            {
                e.Cancel = true;
                tbUusiDuoNimi.Select(0, tbUusiDuoNimi.Text.Length);
                this.epUusiPeli.SetError(tbUusiDuoNimi, msg);
            }
        }

        private void nudKorttienMaara_ValueChanged(object sender, EventArgs e)
        {
            muuttuikoarvo = true;
            if (nudKorttienMaara.Value < 8)
                nudKorttienMaara.Value = 8;
            if (nudKorttienMaara.Value > 52)
                nudKorttienMaara.Value = 52;
            if ((nudKorttienMaara.Value >= 8 && nudKorttienMaara.Value <= 52) && nudKorttienMaara.Value % 4 == 0)
                korttienmaara = (int)nudKorttienMaara.Value;
            else
            {
                while ((nudKorttienMaara.Value >= 8 && nudKorttienMaara.Value < 52) && nudKorttienMaara.Value % 4 != 0)
                {
                    nudKorttienMaara.Value++;
                }
                korttienmaara = (int)nudKorttienMaara.Value;
            }
        }

        private void cmbp1Valitse_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cmb = (System.Windows.Forms.ComboBox)sender;

            if (cmb == cmbp1Valitse)
            {
                ValittuRiviP1 = cmbp1Valitse.SelectedIndex;
                ekaonmuuttunut = true;
            }
            else if (cmb == cmbp2Valitse)
            {
                ValittuRiviP2 = cmbp2Valitse.SelectedIndex;
                tokaonmuuttunut = true;
            }
        }

        private void cmbp2Valitse_Validated(object sender, EventArgs e)
        {
            epUusiPeli.SetError(cmbp2Valitse, String.Empty);
        }

        private void cmbp2Valitse_Validating(object sender, CancelEventArgs e)
        {
            string msg = String.Empty;

            if (!ValidPelaaja2(ValittuRiviP1, ValittuRiviP2, out msg))
            {
                e.Cancel = true;
                cmbp2Valitse.Select(0, cmbp2Valitse.SelectionLength);
                this.epUusiPeli.SetError(cmbp2Valitse, msg);
            }
        }

        public bool ValidPelaaja2(int pelaaja1, int pelaaja2, out string msg)
        {
            msg = String.Empty;

            if (pelimuotoSolo == false)
            {
                if (cbJatkaTallennusta.Checked == true)
                    return true;
                if (nimet2.Count < 2)
                    return true;
                else
                {
                    if (pelaaja2 == pelaaja1)
                    {
                        msg = "Pelaajat ei voi olla samat";
                        return false;
                    }
                }
            }
            return true;
        }

        public void LuoPeli(out Peli peli)
        {
            peli = new Peli();
            if (pelimuotoSolo == true)
            {
                peli.pelimuotoSolo = true;

                if (cbUusiSolo.Checked)
                {
                    peli.Pelaaja1 = new Pelaaja();
                    peli.Pelaaja1.nimi = tbUusiSoloNimi.Text;
                    peli.Pelaaja1.pelienmaara = 1;
                    peli.Pelaaja1.voitot = 0;
                    peli.Pelaaja1.haviot = 0;
                    peli.Pelaaja1.indeksi = pelaajat.Count;
                    pelaajat.Add(peli.Pelaaja1);
                    SerializeXML(pelaajat);
                }
                else
                {
                    peli.Pelaaja1 = new Pelaaja();
                    peli.Pelaaja1.nimi = pelaajat[ValittuRiviP1].nimi;
                    peli.Pelaaja1.indeksi = pelaajat[ValittuRiviP1].indeksi;
                    pelaajat[ValittuRiviP1].pelienmaara++;
                    if (!cbJatkaTallennusta.Checked)
                        peli.Pelaaja1.pelienmaara = pelaajat[ValittuRiviP1].pelienmaara;
                    peli.Pelaaja1.voitot = pelaajat[ValittuRiviP1].voitot;
                    peli.Pelaaja1.haviot = pelaajat[ValittuRiviP1].haviot;
                    peli.Pelaaja1.voittoprosentti = pelaajat[ValittuRiviP1].LaskeVoittopros(pelaajat[ValittuRiviP1].voitot, pelaajat[ValittuRiviP1].pelienmaara);
                    SerializeXML(pelaajat);
                }
            }
            else
            {
                peli.pelimuotoSolo = false;

                if (cbUusiSolo.Checked)
                {
                    peli.Pelaaja1 = new Pelaaja();
                    peli.Pelaaja1.nimi = tbUusiSoloNimi.Text;
                    peli.Pelaaja1.indeksi = pelaajat.Count;
                    peli.Pelaaja1.pelienmaara = 1;
                    peli.Pelaaja1.voitot = 0;
                    peli.Pelaaja1.haviot = 0;
                    pelaajat.Add(peli.Pelaaja1);
                    SerializeXML(pelaajat);
                }
                else
                {
                    peli.Pelaaja1 = new Pelaaja();
                    peli.Pelaaja1.nimi = pelaajat[ValittuRiviP1].nimi;
                    peli.Pelaaja1.indeksi = pelaajat[ValittuRiviP1].indeksi;
                    pelaajat[ValittuRiviP1].pelienmaara++;
                    if (!cbJatkaTallennusta.Checked)
                        peli.Pelaaja1.pelienmaara = pelaajat[ValittuRiviP1].pelienmaara;
                    peli.Pelaaja1.voitot = pelaajat[ValittuRiviP1].voitot;
                    peli.Pelaaja1.haviot = pelaajat[ValittuRiviP1].haviot;
                    peli.Pelaaja1.voittoprosentti = pelaajat[ValittuRiviP1].LaskeVoittopros(pelaajat[ValittuRiviP1].voitot, pelaajat[ValittuRiviP1].pelienmaara);
                    SerializeXML(pelaajat);
                }

                if (cbUusiDuo.Checked)
                {
                    peli.Pelaaja2 = new Pelaaja();
                    peli.Pelaaja2.nimi = tbUusiDuoNimi.Text;
                    peli.Pelaaja2.indeksi = pelaajat.Count;
                    peli.Pelaaja2.pelienmaara = 1;
                    peli.Pelaaja2.voitot = 0;
                    peli.Pelaaja2.haviot = 0;
                    pelaajat.Add(peli.Pelaaja2);
                    SerializeXML(pelaajat);
                }
                else
                {
                    peli.Pelaaja2 = new Pelaaja();
                    peli.Pelaaja2.nimi = pelaajat[ValittuRiviP2].nimi;
                    peli.Pelaaja2.indeksi = pelaajat[ValittuRiviP2].indeksi;
                    pelaajat[ValittuRiviP2].pelienmaara++;
                    if (!cbJatkaTallennusta.Checked)
                        peli.Pelaaja2.pelienmaara = pelaajat[ValittuRiviP2].pelienmaara;
                    peli.Pelaaja2.voitot = pelaajat[ValittuRiviP2].voitot;
                    peli.Pelaaja2.haviot = pelaajat[ValittuRiviP2].haviot;
                    peli.Pelaaja2.voittoprosentti = pelaajat[ValittuRiviP2].LaskeVoittopros(pelaajat[ValittuRiviP2].voitot, pelaajat[ValittuRiviP2].pelienmaara);
                    SerializeXML(pelaajat);
                }
            }
            peli.korttienmaara = korttienmaara;
            peli.kenenVuoro = peli.Pelaaja1;
            peli.pelinkesto = "00:00:00";
            peli.sek = 0;
            peli.min = 0;
            peli.tun = 0;
        }

        private void cbJatkaTallennusta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbJatkaTallennusta.Checked)
            {
                pnlUusiPeli.Enabled = false;
                btnValistePeli.Enabled = true;
                jatkaPeli = true;
                uusiPeli = false;
            }
            else if (!cbJatkaTallennusta.Checked)
            {
                pnlUusiPeli.Enabled = true;
                btnValistePeli.Enabled = false;
                jatkaPeli = false;
                uusiPeli = true;
                tallennusnimi = String.Empty;
            }
        }

        private void btnValistePeli_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = fbdValitsePeli.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tallennusnimi = fbdValitsePeli.SelectedPath;
            }
        }

        private void cmbp1Valitse_Validated(object sender, EventArgs e)
        {
            epUusiPeli.SetError(tbUusiDuoNimi, String.Empty);
        }

        private void cmbp1Valitse_Validating(object sender, CancelEventArgs e)
        {
            string msg = String.Empty;

            if (!ValidPelaaja1(ValittuRiviP1, ValittuRiviP2, out msg))
            {
                e.Cancel = true;
                cmbp2Valitse.Select(0, cmbp1Valitse.SelectionLength);
                this.epUusiPeli.SetError(cmbp1Valitse, msg);
            }
        }
        public bool ValidPelaaja1(int p1, int p2, out string msg)
        {
            msg = String.Empty;
            if (pelimuotoSolo == false)
            {
                if (cbJatkaTallennusta.Checked == true)
                    return true;
                if(nimet1.Count<2)
                    return true;
                else
                {
                    if (p2 == p1)
                    {
                        msg = "Pelaajat ei voi olla samat";
                        return false;
                    }
                }
            }
            return true;
        }

        private void frmUusiPeli_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form menu = new Form();
            this.Hide();
            menu = Application.OpenForms["frmMenu"];
            menu.Show();
        }
    }
}





