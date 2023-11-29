using OH2.Muistipeli.Tuononen.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OH2.Muistipeli.Tuononen
{
    public partial class frmMuistipeli : Form
    {
        public List<Pelaaja> pelaajat;
        public const string STREAK = "Streak: ";
        public const string PARIT = "Parit: ";
        public bool uusipeli = false;
        public bool jatkapeli = false;

        public int valittuP1;
        public int valittuP2;

        public int ekaArvo = 0;
        public int tokaArvo = 0;
        public string ekaMaa = "";
        public string tokaMaa = "";

        public bool tallennettu = false;
        public bool ekaPainettu = false;
        public bool poistupainettu = false;
        public bool luovutapainettu = false;
        public int sekunnit;
        public int minuutit;
        public int tunnit;
        public string sSek;
        public string sMin;
        public string sTun;

        public string tallennusnimi;
        public DateTime pvm = DateTime.Now;

        public Peli peli = new Peli();
        public Pelaaja voittaja = new Pelaaja();
        public Pelaaja haviaja = new Pelaaja();
        public frmUusiPeli pt;

        public TableLayoutPanel tlp = new TableLayoutPanel();
        public List<Peli> pelitiedot = new List<Peli>();
        public List<Kortti> pakka = new List<Kortti>();
        public List<PictureBox> kuvapaikat = new List<PictureBox>();
        public List<Kuvaboksi> kuvaBoksit = new List<Kuvaboksi>();
        public List<Image> korttikuvat = new List<Image>();
        SoundPlayer pari = new SoundPlayer(Properties.Resources.PariCut);
        SoundPlayer eiParia = new SoundPlayer(Properties.Resources.EiPariaCut);

        public frmMuistipeli(frmUusiPeli pt)
        {
            InitializeComponent();
            this.pt = pt;
            uusipeli = pt.uusiPeli;
            jatkapeli = pt.jatkaPeli;
            pelaajat = DeserializeXMLPelaajat();
            KorttiKuvatTalteen();//Nämä kaksi funktiota mahdollistavat kuvan lataamisen formille, kun jatketaan vanhaa peliä
            KortteihinTunniste();
            if (uusipeli == true && jatkapeli == false)//Määrittää luodaanko vai tuodaanko peli
            {
                peli = pt.peli;
                sekunnit = pt.peli.sek;
                minuutit = pt.peli.min;
                tunnit = pt.peli.tun;
                peli.pelimuotoSolo = pt.peli.pelimuotoSolo;
                peli.kenenVuoro = pt.peli.Pelaaja1;
                peli.korttienmaara = pt.peli.korttienmaara;
                peli.pelinkesto = pt.peli.pelinkesto;
                peli.Pelaaja1 = pt.peli.Pelaaja1;
                peli.Pelaaja2 = pt.peli.Pelaaja2;
                peli.paattynyt = false;

                tslblAika.Text = peli.pelinkesto;
                tslblPelaaja.Text = peli.kenenVuoro.nimi;
                tslblParitYht.Text = PARIT + "0";
                tslblParitStreak.Text = STREAK + "0";

                if (peli.pelimuotoSolo == true)
                {
                    tallennusnimi = "c:\\temp\\PanMuistipeliTallennukset\\" + peli.Pelaaja1.nimi + pvm.Day.ToString() + pvm.Month.ToString() + pvm.Year.ToString() + pvm.Hour.ToString() + pvm.Minute.ToString();
                }
                else
                {
                    tallennusnimi = "c:\\temp\\PanMuistipeliTallennukset\\" + peli.Pelaaja1.nimi + ".VS." + peli.Pelaaja2.nimi + pvm.Day.ToString() + pvm.Month.ToString() + pvm.Year.ToString() + pvm.Hour.ToString() + pvm.Minute.ToString();
                }
                JaaKortit(peli.korttienmaara);
                IkkunaKoko(peli.korttienmaara);
                LuoTaulukko(peli.korttienmaara);
            }
            else if (jatkapeli == true && uusipeli == false)
            {
                KorttiKuvatTalteen();
                KortteihinTunniste();
                tallennusnimi = pt.tallennusnimi;
                ekaPainettu = false;
                ekaArvo = 0;
                ekaMaa = "";
                tokaArvo = 0;
                tokaMaa = "";
                tsbtnLuovuta.Enabled = true;
                tsbtnPausePlay.Enabled = true;
                tsbtnTallenna.Enabled = true;
                tsbtnPoistu.Enabled = true;
                tmrPelinAika.Enabled = true;
                tmrPelinAika.Interval = 1000;
                tmrPelinAika.Tick += new EventHandler(tmrPelinAika_Tick);
                tmrEiParia.Enabled = false;
                tmrEiParia.Interval = 1200;
                tmrEiParia.Tick += new EventHandler(tmrEiParia_Tick);
                tmrPoistaParit.Enabled = false;
                tmrPoistaParit.Interval = 1200;
                tmrPoistaParit.Tick += new EventHandler(tmrPoistaParit_Tick);
                tmrTallennettuFalse.Enabled = false;
                tmrTallennettuFalse.Interval = 500;
                tmrTallennettuFalse.Tick += new EventHandler(tmrTallennettuFalse_Tick);

                TuoVanhaPeli();
            }
        }

        public void KorttiKuvatTalteen()
        {
            korttikuvat.Add(Properties.Resources.Hertta1);
            korttikuvat.Add(Properties.Resources.Hertta2);
            korttikuvat.Add(Properties.Resources.Hertta3);
            korttikuvat.Add(Properties.Resources.Hertta4);
            korttikuvat.Add(Properties.Resources.Hertta5);
            korttikuvat.Add(Properties.Resources.Hertta6);
            korttikuvat.Add(Properties.Resources.Hertta7);
            korttikuvat.Add(Properties.Resources.Hertta8);
            korttikuvat.Add(Properties.Resources.Hertta9);
            korttikuvat.Add(Properties.Resources.Hertta10);
            korttikuvat.Add(Properties.Resources.Hertta11);
            korttikuvat.Add(Properties.Resources.Hertta12);
            korttikuvat.Add(Properties.Resources.Hertta13);
            korttikuvat.Add(Properties.Resources.Pata1);
            korttikuvat.Add(Properties.Resources.Pata2);
            korttikuvat.Add(Properties.Resources.Pata3);
            korttikuvat.Add(Properties.Resources.Pata4);
            korttikuvat.Add(Properties.Resources.Pata5);
            korttikuvat.Add(Properties.Resources.Pata6);
            korttikuvat.Add(Properties.Resources.Pata7);
            korttikuvat.Add(Properties.Resources.Pata8);
            korttikuvat.Add(Properties.Resources.Pata9);
            korttikuvat.Add(Properties.Resources.Pata10);
            korttikuvat.Add(Properties.Resources.Pata11);
            korttikuvat.Add(Properties.Resources.Pata12);
            korttikuvat.Add(Properties.Resources.Pata13);
            korttikuvat.Add(Properties.Resources.Risti1);
            korttikuvat.Add(Properties.Resources.Risti2);
            korttikuvat.Add(Properties.Resources.Risti3);
            korttikuvat.Add(Properties.Resources.Risti4);
            korttikuvat.Add(Properties.Resources.Risti5);
            korttikuvat.Add(Properties.Resources.Risti6);
            korttikuvat.Add(Properties.Resources.Risti7);
            korttikuvat.Add(Properties.Resources.Risti8);
            korttikuvat.Add(Properties.Resources.Risti9);
            korttikuvat.Add(Properties.Resources.Risti10);
            korttikuvat.Add(Properties.Resources.Risti11);
            korttikuvat.Add(Properties.Resources.Risti12);
            korttikuvat.Add(Properties.Resources.Risti13);
            korttikuvat.Add(Properties.Resources.Ruutu1);
            korttikuvat.Add(Properties.Resources.Ruutu2);
            korttikuvat.Add(Properties.Resources.Ruutu3);
            korttikuvat.Add(Properties.Resources.Ruutu4);
            korttikuvat.Add(Properties.Resources.Ruutu5);
            korttikuvat.Add(Properties.Resources.Ruutu6);
            korttikuvat.Add(Properties.Resources.Ruutu7);
            korttikuvat.Add(Properties.Resources.Ruutu8);
            korttikuvat.Add(Properties.Resources.Ruutu9);
            korttikuvat.Add(Properties.Resources.Ruutu10);
            korttikuvat.Add(Properties.Resources.Ruutu11);
            korttikuvat.Add(Properties.Resources.Ruutu12);
            korttikuvat.Add(Properties.Resources.Ruutu13);
        }
        public void KortteihinTunniste()
        {
            int i = 1;
            foreach (Image im in korttikuvat)
            {
                im.Tag = i;
                i++;
            }
        }
        public void IkkunaKoko(int maara)
        {
            if (maara <= 8)
            {
                this.Size = new Size(492, 438);
                this.MinimumSize = new Size(492, 438);
            }
            else if (maara > 8 && maara <= 12)
            {
                this.Size = new Size(492, 651);
                this.MinimumSize = new Size(429, 651);
            }
            else if (maara > 12 && maara <= 16)
            {
                this.Size = new Size(492, 861);
                this.MinimumSize = new Size(492, 861);
            }
            else if (maara > 16 && maara <= 20)
            {
                this.Size = new Size(609, 861);
                this.MinimumSize = new Size(609, 861);
            }
            else if (maara > 20 && maara <= 24)
            {
                this.Size = new Size(723, 861);
                this.MinimumSize = new Size(723, 861);
            }
            else if (maara > 24 && maara <= 28)
            {
                this.Size = new Size(836, 861);
                this.MinimumSize = new Size(836, 861);
            }
            else if (maara > 28 && maara <= 32)
            {
                this.Size = new Size(957, 861);
                this.MinimumSize = new Size(957, 861);
            }
            else if (maara > 32 && maara <= 36)
            {
                this.Size = new Size(1070, 861);
                this.MinimumSize = new Size(1070, 861);
            }
            else if (maara > 36 && maara <= 40)
            {
                this.Size = new Size(1190, 861);
                this.MinimumSize = new Size(1190, 861);
            }
            else if (maara > 40 && maara <= 44)
            {
                this.Size = new Size(1301, 861);
                this.MinimumSize = new Size(1301, 861);
            }
            else if (maara > 44 && maara <= 48)
            {
                this.Size = new Size(1416, 861);
                this.MinimumSize = new Size(1416, 861);
            }
            else if (maara > 48 && (maara <= 52 || maara > 52))
            {
                this.Size = new Size(1532, 861);
                this.MinimumSize = new Size(1532, 861);
            }
            peli.ikkunanKoko = this.Size;
        }
        public void LuoTaulukko(int maara)
        {
            tlp.Name = "tlpKorttitaulu";
            tlp.Dock = DockStyle.Fill;
            tlp.Visible = true;
            tlp.Enabled = true;
            int rivit, sarakkeet;
            LuoSolut(maara, out rivit, out sarakkeet);
            tlp.RowCount = rivit;
            tlp.ColumnCount = sarakkeet;
            peli.riviPros = 100F / tlp.RowCount;
            peli.sarakePros = 100F / tlp.ColumnCount;

            for (int i = 1; i <= tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, peli.riviPros));
            }
            for (int j = 1; j <= tlp.ColumnCount; j++)
            {
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, peli.sarakePros));
            }
            Controls.Add(tlp);
            tlp.BringToFront();
            pnlpaneli.SendToBack();
        }
        public void LuoSolut(int maara, out int rivit, out int sarakkeet)
        {
            rivit = 1;
            sarakkeet = 1;

            if (maara <= 8)
            {
                rivit = 2;
                sarakkeet = 4;
            }
            else if (maara > 8 && maara <= 12)
            {
                rivit = 3;
                sarakkeet = 4;
            }
            else if (maara > 12 && maara <= 16)
            {
                rivit = 4;
                sarakkeet = 4;
            }
            else if (maara > 16 && maara <= 20)
            {
                rivit = 4;
                sarakkeet = 5;
            }
            else if (maara > 20 && maara <= 24)
            {
                rivit = 4;
                sarakkeet = 6;
            }
            else if (maara > 24 && maara <= 28)
            {
                rivit = 4;
                sarakkeet = 7;
            }
            else if (maara > 28 && maara <= 32)
            {
                rivit = 4;
                sarakkeet = 8;
            }
            else if (maara > 32 && maara <= 36)
            {
                rivit = 4;
                sarakkeet = 9;
            }
            else if (maara > 36 && maara <= 40)
            {
                rivit = 4;
                sarakkeet = 10;
            }
            else if (maara > 40 && maara <= 44)
            {
                rivit = 4;
                sarakkeet = 11;
            }
            else if (maara > 44 && maara <= 48)
            {
                rivit = 4;
                sarakkeet = 12;
            }
            else if (maara > 48 && (maara <= 52 || maara > 52))
            {
                rivit = 4;
                sarakkeet = 13;
            }
        }
        public void TuoVanhaPeli()
        {
            pelitiedot = DeserializeXMLPeli();
            TuoPelitiedot();
            kuvaBoksit = DeserializeXMLKortit();
            TuoKortit();
            LisaaKuvaBoksiin();
        }
        public void TuoPelitiedot()
        {
            peli.pelimuotoSolo = pelitiedot[0].pelimuotoSolo;
            peli.Pelaaja1 = pelitiedot[0].Pelaaja1;

            if (peli.pelimuotoSolo == false)
                peli.Pelaaja2 = pelitiedot[0].Pelaaja2;

            peli.kenenVuoro = pelitiedot[0].kenenVuoro;
            if (peli.pelimuotoSolo == false)
            {
                if (peli.kenenVuoro.nimi == peli.Pelaaja1.nimi)
                {
                    tslblPelaaja.Text = peli.Pelaaja1.nimi;
                    tslblParitStreak.Text = STREAK + peli.Pelaaja1.paritStreak.ToString();
                    tslblParitYht.Text = PARIT + peli.Pelaaja1.paritYht.ToString();
                }
                else if (peli.kenenVuoro.nimi == peli.Pelaaja2.nimi)
                {
                    tslblPelaaja.Text = peli.Pelaaja2.nimi;
                    tslblParitStreak.Text = STREAK + peli.Pelaaja2.paritStreak.ToString();
                    tslblParitYht.Text = PARIT + peli.Pelaaja2.paritYht.ToString();
                }
            }
            else
            {
                tslblPelaaja.Text = peli.Pelaaja1.nimi;
                tslblParitStreak.Text = STREAK + peli.Pelaaja1.paritStreak.ToString();
                tslblParitYht.Text = PARIT + peli.Pelaaja1.paritYht.ToString();
            }
            peli.korttienmaara = pelitiedot[0].korttienmaara;
            peli.pelinkesto = pelitiedot[0].pelinkesto;
            peli.paattynyt = pelitiedot[0].paattynyt;

            peli.sarakePros = pelitiedot[0].sarakePros;
            peli.riviPros = pelitiedot[0].riviPros;
            peli.ikkunanKoko = pelitiedot[0].ikkunanKoko;

            peli.sek = pelitiedot[0].sek;
            peli.min = pelitiedot[0].min;
            peli.tun = pelitiedot[0].tun;
            sekunnit = peli.sek;
            minuutit = peli.min;
            tunnit = peli.tun;
            if (sekunnit <= 9)
                sSek = "0" + sekunnit.ToString();
            else
                sSek = sekunnit.ToString();
            if (minuutit <= 9)
                sMin = "0" + minuutit.ToString() + ":";
            else
                sMin = minuutit.ToString() + ":";

            if (tunnit <= 9)
                sTun = "0" + tunnit.ToString() + ":";
            else
                sTun = tunnit.ToString() + ":";

            tslblAika.Text = sTun + sMin + sSek;

            this.Size = new Size(peli.ikkunanKoko.Width, peli.ikkunanKoko.Height);
            this.MinimumSize = new Size(peli.ikkunanKoko.Width, peli.ikkunanKoko.Height);

            TuoTaulukko(peli.korttienmaara, peli.riviPros, peli.sarakePros);
        }
        public void TuoTaulukko(int maara, float rivipros, float sarakepros)
        {
            tlp.Name = "tlpKorttitaulu";
            tlp.Dock = DockStyle.Fill;
            tlp.Visible = true;
            tlp.Enabled = true;
            int rivit, sarakkeet;
            LuoSolut(maara, out rivit, out sarakkeet);
            tlp.RowCount = rivit;
            tlp.ColumnCount = sarakkeet;

            for (int i = 1; i <= tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, peli.riviPros));
            }
            for (int j = 1; j <= tlp.ColumnCount; j++)
            {
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, peli.sarakePros));
            }
            Controls.Add(tlp);
        }
        public void TuoKortit()
        {
            foreach (Kuvaboksi kb in kuvaBoksit)
            {
                TuoBoksi(kb.Name, kb.Size, kb.TabIndex, kb.Enabled, kb.KorttiMaa, kb.KorttiArvo, kb.KorttiKaannetty, kb.KorttiPoistettu, kb.tunniste, kb.Location);
            }
            LisaaTaulukkoon();

            tlp.BringToFront();
            pnlpaneli.SendToBack();
        }

        public void TuoBoksi(string nimi, Size koko, int indeksi, bool enabled, string maa, int arvo, bool kaannetty, bool poistettu, int tunniste, Point paikka)
        {
            PictureBox pb = new PictureBox();
            pb.Name = nimi;
            pb.Size = koko;
            if (!poistettu)
                pb.Image = (Image)Properties.Resources.tausta;
            else
                pb.Image = null;
            pb.TabIndex = indeksi;
            pb.Enabled = true;
            pb.Visible = true;
            pb.Location = new Point(paikka.X, paikka.Y);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Anchor = AnchorStyles.None;
            pb.Dock = DockStyle.Fill;
            pb.Tag = (Kortti)TuoKortti(maa, arvo, kaannetty, poistettu, tunniste);

            Controls.Add(pb);
            kuvapaikat.Add(pb);
            pb.Click += new System.EventHandler(pbKortti_Click);
        }
        public Kortti TuoKortti(string maa, int arvo, bool kaannetty, bool poistettu, int tunniste)
        {
            Kortti k = new Kortti();
            k.maa = maa;
            k.arvo = arvo;
            k.kaannetty = kaannetty;
            k.poistettu = poistettu;
            k.tunniste = tunniste;

            if (!poistettu)
            {
                Image kuva = EtsiKuva(tunniste);
                k.kuvalista = new List<Image> { kuva, Properties.Resources.tausta };
            }
            else
            {
                Image kuva = null;
                k.kuvalista = new List<Image> { kuva, kuva };
            }
            return k;
        }
        public Image EtsiKuva(int tunniste)
        {
            Image palautettavakuva = new Bitmap(Properties.Resources.tausta);
            foreach (Image im in korttikuvat)
            {
                if ((int)im.Tag == tunniste)
                {
                    palautettavakuva = im;
                    return palautettavakuva;
                }
            }
            return palautettavakuva;
        }
        public void JaaKortit(int maara)
        {
            LuoPakka(maara);
            LuoPaikat(maara);
            Arvo();
            LisaaTaulukkoon();
            LisaaKuvaBoksiin();
            pelitiedot.Add(peli);
        }
        public void LisaaTaulukkoon()
        {
            int pysty = 0, vaaka = 0;
            foreach (PictureBox pb in kuvapaikat)
            {
                tlp.Controls.Add(pb, vaaka, pysty);
                vaaka++;

                if (pysty > tlp.ColumnCount)
                {
                    vaaka = 0;
                    pysty++;
                }
            }
        }
        public void LuoKortti(int arvo, Image kuva, string maa, int tunniste)
        {
            Kortti k = new Kortti();
            k.kaannetty = false;
            k.poistettu = false;
            k.arvo = arvo;
            k.maa = maa;
            k.tunniste = tunniste;
            k.kuvalista = new List<Image> { kuva, Properties.Resources.tausta };
            pakka.Add(k);
        }
        public void LuoPakka(int maara)
        {//Korttien määrä määrää jaettavat kortit-> Saman kokoisissa peleissä jaossa aina samat kortit
            if (maara >= 8)
            {
                LuoKortti(1, Properties.Resources.Hertta1, "Hertta", 1);
                LuoKortti(1, Properties.Resources.Pata1, "Pata", 14);
                LuoKortti(2, Properties.Resources.Hertta2, "Hertta", 2);
                LuoKortti(2, Properties.Resources.Pata2, "Pata", 15);
                LuoKortti(3, Properties.Resources.Hertta3, "Hertta", 3);
                LuoKortti(3, Properties.Resources.Pata3, "Pata", 16);
                LuoKortti(4, Properties.Resources.Hertta4, "Hertta", 4);
                LuoKortti(4, Properties.Resources.Pata4, "Pata", 17);

                if (maara >= 12)
                {
                    LuoKortti(5, Properties.Resources.Hertta5, "Hertta", 5);
                    LuoKortti(5, Properties.Resources.Pata5, "Pata", 18);
                    LuoKortti(6, Properties.Resources.Hertta6, "Hertta", 6);
                    LuoKortti(6, Properties.Resources.Pata6, "Pata", 19);

                    if (maara >= 16)
                    {
                        LuoKortti(7, Properties.Resources.Hertta7, "Hertta", 7);
                        LuoKortti(7, Properties.Resources.Pata7, "Pata", 20);
                        LuoKortti(8, Properties.Resources.Hertta8, "Hertta", 8);
                        LuoKortti(8, Properties.Resources.Pata8, "Pata", 21);

                        if (maara >= 20)
                        {
                            LuoKortti(9, Properties.Resources.Hertta9, "Hertta", 9);
                            LuoKortti(9, Properties.Resources.Pata9, "Pata", 22);
                            LuoKortti(10, Properties.Resources.Hertta10, "Hertta", 10);
                            LuoKortti(10, Properties.Resources.Pata10, "Pata", 23);

                            if (maara >= 24)
                            {
                                LuoKortti(11, Properties.Resources.Hertta11, "Hertta", 11);
                                LuoKortti(11, Properties.Resources.Pata11, "Pata", 24);
                                LuoKortti(12, Properties.Resources.Hertta12, "Hertta", 12);
                                LuoKortti(12, Properties.Resources.Pata12, "Pata", 25);

                                if (maara >= 28)
                                {
                                    LuoKortti(13, Properties.Resources.Hertta13, "Hertta", 13);
                                    LuoKortti(13, Properties.Resources.Pata13, "Pata", 26);
                                    LuoKortti(1, Properties.Resources.Risti1, "Risti", 27);
                                    LuoKortti(1, Properties.Resources.Ruutu1, "Ruutu", 40);

                                    if (maara >= 32)
                                    {
                                        LuoKortti(2, Properties.Resources.Risti2, "Risti", 28);
                                        LuoKortti(2, Properties.Resources.Ruutu2, "Ruutu", 41);
                                        LuoKortti(3, Properties.Resources.Risti3, "Risti", 29);
                                        LuoKortti(3, Properties.Resources.Ruutu3, "Ruutu", 42);

                                        if (maara >= 36)
                                        {
                                            LuoKortti(4, Properties.Resources.Risti4, "Risti", 30);
                                            LuoKortti(4, Properties.Resources.Ruutu4, "Ruutu", 43);
                                            LuoKortti(5, Properties.Resources.Risti5, "Risti", 31);
                                            LuoKortti(5, Properties.Resources.Ruutu5, "Ruutu", 44);

                                            if (maara >= 40)
                                            {
                                                LuoKortti(6, Properties.Resources.Risti6, "Risti", 32);
                                                LuoKortti(6, Properties.Resources.Ruutu6, "Ruutu", 45);
                                                LuoKortti(7, Properties.Resources.Risti7, "Risti", 33);
                                                LuoKortti(7, Properties.Resources.Ruutu7, "Ruutu", 46);

                                                if (maara >= 44)
                                                {
                                                    LuoKortti(8, Properties.Resources.Risti8, "Risti", 34);
                                                    LuoKortti(8, Properties.Resources.Ruutu8, "Ruutu", 47);
                                                    LuoKortti(9, Properties.Resources.Risti9, "Risti", 35);
                                                    LuoKortti(9, Properties.Resources.Ruutu9, "Ruutu", 48);

                                                    if (maara >= 48)
                                                    {
                                                        LuoKortti(10, Properties.Resources.Risti10, "Risti", 36);
                                                        LuoKortti(10, Properties.Resources.Ruutu10, "Ruutu", 49);
                                                        LuoKortti(11, Properties.Resources.Risti11, "Risti", 37);
                                                        LuoKortti(11, Properties.Resources.Ruutu11, "Ruutu", 50);

                                                        if (maara >= 52)
                                                        {
                                                            LuoKortti(12, Properties.Resources.Risti12, "Risti", 38);
                                                            LuoKortti(12, Properties.Resources.Ruutu12, "Ruutu", 51);
                                                            LuoKortti(13, Properties.Resources.Risti13, "Risti", 39);
                                                            LuoKortti(13, Properties.Resources.Ruutu13, "Ruutu", 52);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void LuoBoksi(string nimi, int tabIndex)
        {
            PictureBox pb = new PictureBox();
            pb.Name = nimi;
            pb.Image = (Image)Properties.Resources.tausta;
            pb.Size = new System.Drawing.Size(109, 151);
            pb.TabIndex = tabIndex;
            pb.Enabled = true;
            pb.Visible = true;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Anchor = AnchorStyles.None;
            pb.Dock = DockStyle.Fill;
            Controls.Add(pb);
            kuvapaikat.Add(pb);
            pb.Click += new System.EventHandler(pbKortti_Click);
        }
        public void LuoPaikat(int maara)
        {
            if (maara >= 8)
            {
                LuoBoksi("pbKortti1", 0);
                LuoBoksi("pbKortti2", 1);
                LuoBoksi("pbKortti3", 2);
                LuoBoksi("pbKortti4", 3);
                LuoBoksi("pbKortti5", 4);
                LuoBoksi("pbKortti6", 5);
                LuoBoksi("pbKortti7", 6);
                LuoBoksi("pbKortti8", 7);
                if (maara >= 12)
                {
                    LuoBoksi("pbKortti9", 8);
                    LuoBoksi("pbKortti10", 9);
                    LuoBoksi("pbKortti11", 10);
                    LuoBoksi("pbKortti12", 11);
                    if (maara >= 16)
                    {
                        LuoBoksi("pbKortti13", 12);
                        LuoBoksi("pbKortti14", 13);
                        LuoBoksi("pbKortti15", 14);
                        LuoBoksi("pbKortti16", 15);
                        if (maara >= 20)
                        {
                            LuoBoksi("pbKortti17", 16);
                            LuoBoksi("pbKortti18", 17);
                            LuoBoksi("pbKortti19", 18);
                            LuoBoksi("pbKortti20", 19);
                            if (maara >= 24)
                            {
                                LuoBoksi("pbKortti25", 20);
                                LuoBoksi("pbKortti22", 21);
                                LuoBoksi("pbKortti23", 22);
                                LuoBoksi("pbKortti24", 23);
                                if (maara >= 28)
                                {
                                    LuoBoksi("pbKortti25", 24);
                                    LuoBoksi("pbKortti26", 25);
                                    LuoBoksi("pbKortti27", 26);
                                    LuoBoksi("pbKortti28", 27);
                                    if (maara >= 32)
                                    {
                                        LuoBoksi("pbKortti29", 28);
                                        LuoBoksi("pbKortti30", 29);
                                        LuoBoksi("pbKortti31", 30);
                                        LuoBoksi("pbKortti32", 31);
                                        if (maara >= 36)
                                        {
                                            LuoBoksi("pbKortti33", 32);
                                            LuoBoksi("pbKortti34", 33);
                                            LuoBoksi("pbKortti35", 34);
                                            LuoBoksi("pbKortti36", 35);
                                            if (maara >= 40)
                                            {
                                                LuoBoksi("pbKortti41", 36);
                                                LuoBoksi("pbKortti38", 37);
                                                LuoBoksi("pbKortti39", 38);
                                                LuoBoksi("pbKortti40", 39);
                                                if (maara >= 44)
                                                {
                                                    LuoBoksi("pbKortti41", 40);
                                                    LuoBoksi("pbKortti42", 41);
                                                    LuoBoksi("pbKortti43", 42);
                                                    LuoBoksi("pbKortti44", 43);
                                                    if (maara >= 48)
                                                    {
                                                        LuoBoksi("pbKortti45", 44);
                                                        LuoBoksi("pbKortti46", 45);
                                                        LuoBoksi("pbKortti47", 46);
                                                        LuoBoksi("pbKortti48", 47);
                                                        if (maara == 52)
                                                        {
                                                            LuoBoksi("pbKortti49", 48);
                                                            LuoBoksi("pbKortti50", 49);
                                                            LuoBoksi("pbKortti51", 50);
                                                            LuoBoksi("pbKortti12", 51);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Arvo()
        {
            Random rnd = new Random();
            int index;

            foreach (PictureBox pb in kuvapaikat)
            {
                index = rnd.Next(pakka.Count);
                pb.Tag = pakka[index];
                Kortti valittukortti = pakka[index];
                pb.Image = valittukortti.kuvalista[1];
                pakka.RemoveAt(index);
            }
        }
        public void LisaaKuvaBoksiin()
        {
            foreach (PictureBox pb in kuvapaikat)
            {
                Kortti k = (Kortti)pb.Tag;
                Kuvaboksi kb = new Kuvaboksi();
                kb.Name = pb.Name;
                kb.Enabled = pb.Enabled;
                kb.TabIndex = pb.TabIndex;
                kb.Size = pb.Size;
                kb.Location = pb.Location;
                kb.KorttiArvo = k.arvo;
                kb.KorttiMaa = k.maa;
                kb.KorttiKaannetty = k.kaannetty;
                kb.KorttiPoistettu = k.poistettu;
                kb.tunniste = k.tunniste;
                kuvaBoksit.Add(kb);
            }
        }
        public void pbKortti_Click(object sender, System.EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Kortti kortti = (Kortti)pb.Tag;

            if (tmrEiParia.Enabled == false)
            {
                if (ekaPainettu == false)
                {
                    if (kortti.kaannetty == false)
                    {
                        if (kortti.poistettu == false)
                        {
                            tsbtnPausePlay.Enabled = false;
                            tsbtnTallenna.Enabled = false;
                            tsbtnPoistu.Enabled = false;
                            tallennettu = false;
                            pelitiedot.Clear();
                            pelitiedot.Add(peli);
                            kortti.kaannetty = true;
                            ekaArvo = kortti.arvo;
                            ekaMaa = kortti.maa;
                            ekaPainettu = true;
                            pb.Image = kortti.kuvalista[0];
                            pb.Enabled = false;
                        }
                    }
                }
                else
                {
                    if (kortti.kaannetty == false)
                    {
                        if (kortti.poistettu == false)
                        {
                            tsbtnPausePlay.Enabled = true;
                            tsbtnTallenna.Enabled = true;
                            tsbtnPoistu.Enabled = true;
                            pelitiedot.Clear();
                            pelitiedot.Add(peli);
                            kortti.kaannetty = true;
                            tokaArvo = kortti.arvo;
                            tokaMaa = kortti.maa;
                            pb.Image = kortti.kuvalista[0];
                            pb.Enabled = false;

                            if (peli.pelimuotoSolo == true)
                            {
                                if (tokaArvo == ekaArvo)
                                {
                                    peli.Pelaaja1.paritStreak++;
                                    peli.Pelaaja1.paritYht++;
                                    tslblParitStreak.Text = STREAK + peli.Pelaaja1.paritStreak.ToString();
                                    tslblParitYht.Text = PARIT + peli.Pelaaja1.paritYht.ToString();
                                    pari.Play();
                                    tmrPoistaParit.Enabled = true;
                                }
                                else
                                {
                                    peli.Pelaaja1.paritStreak = 0;
                                    tslblParitStreak.Text = STREAK + peli.Pelaaja1.paritStreak.ToString();
                                    eiParia.Play();
                                    tmrEiParia.Enabled = true;
                                }
                            }
                            else
                            {
                                if (peli.kenenVuoro.nimi == peli.Pelaaja1.nimi)
                                {
                                    if (tokaArvo == ekaArvo)
                                    {
                                        peli.Pelaaja1.paritStreak++;
                                        peli.Pelaaja1.paritYht++;
                                        tslblParitStreak.Text = STREAK + peli.Pelaaja1.paritStreak.ToString();
                                        tslblParitYht.Text = PARIT + peli.Pelaaja1.paritYht.ToString();
                                        pari.Play();
                                        tmrPoistaParit.Enabled = true;
                                    }
                                    else
                                    {
                                        peli.Pelaaja1.paritStreak = 0;
                                        tslblParitStreak.Text = STREAK + peli.Pelaaja1.paritStreak.ToString();
                                        eiParia.Play();
                                        tmrEiParia.Enabled = true;
                                        VuoronVaihto();
                                    }
                                }
                                else if (peli.kenenVuoro.nimi == peli.Pelaaja2.nimi)
                                {
                                    if (tokaArvo == ekaArvo)
                                    {
                                        peli.Pelaaja2.paritStreak++;
                                        peli.Pelaaja2.paritYht++;
                                        tslblParitStreak.Text = STREAK + peli.Pelaaja2.paritStreak.ToString();
                                        tslblParitYht.Text = PARIT + peli.Pelaaja2.paritYht.ToString();
                                        pari.Play();
                                        tmrPoistaParit.Enabled = true;
                                    }
                                    else
                                    {
                                        peli.Pelaaja2.paritStreak = 0;
                                        tslblParitStreak.Text = STREAK + peli.Pelaaja2.paritStreak.ToString();
                                        eiParia.Play();
                                        tmrEiParia.Enabled = true;
                                        VuoronVaihto();
                                    }
                                }
                            }
                            ekaPainettu = false;
                        }
                    }
                }
            }
        }
        public void PoistaParit()
        {
            foreach (PictureBox pb in kuvapaikat)
            {
                pb.Enabled = true;
                Kortti k = (Kortti)pb.Tag;

                if ((k.arvo == ekaArvo) && (k.maa == ekaMaa))
                {
                    pb.Enabled = false;
                    pb.Image = null;
                    k.kuvalista = new List<Image> { pb.Image, pb.Image };
                    k.poistettu = true;
                    ekaArvo = 0;
                    ekaMaa = "";
                }
                else if ((k.arvo == tokaArvo) && (k.maa == tokaMaa))
                {
                    pb.Enabled = false;
                    pb.Image = null;
                    k.kuvalista = new List<Image> { pb.Image, pb.Image };
                    k.poistettu = true;
                    tokaArvo = 0;
                    tokaMaa = "";
                }
                for (int i = 0; i < kuvaBoksit.Count; i++)
                {
                    if (kuvaBoksit[i].Name == pb.Name)
                    {
                        kuvaBoksit[i].Size = pb.Size;
                        kuvaBoksit[i].TabIndex = pb.TabIndex;
                        kuvaBoksit[i].Enabled = pb.Enabled;
                        kuvaBoksit[i].KorttiArvo = k.arvo;
                        kuvaBoksit[i].KorttiMaa = k.maa;
                        kuvaBoksit[i].KorttiKaannetty = k.kaannetty;
                        kuvaBoksit[i].KorttiPoistettu = k.poistettu;
                    }
                }
            }
            tmrPoistaParit.Enabled = false;
            int eipoistetut;
            eipoistetut = TarkistaPoistetut();
            if (eipoistetut == 0)
            {
                peli.paattynyt = true;
                PaataPeli();
            }
        }
        public int TarkistaPoistetut()
        {
            int eipoistettu = 0;

            foreach (PictureBox pb in kuvapaikat)
            {
                Kortti k = new Kortti();
                k = (Kortti)pb.Tag;
                if (k.poistettu == false)
                    eipoistettu++;
            }
            return eipoistettu;
        }
        private void tsbtnTallenna_Click(object sender, EventArgs e)
        {
            tallennettu = true;
            try
            {
                Tallenna();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tmrTallennettuFalse.Enabled = true;
        }

        public void Tallenna()
        {
            peli.ikkunanKoko = this.Size;
            if (!Directory.Exists(tallennusnimi))
                Directory.CreateDirectory(tallennusnimi);
            SerializeXMLPeli(pelitiedot);
            SerializeXMLKortit(kuvaBoksit);
        }
        private void tsbtnPausePlay_Click(object sender, EventArgs e)
        {
            if (tmrPelinAika.Enabled == true)
            {
                tmrPelinAika.Enabled = false;
                tsbtnTallenna.Enabled = false;
                tsbtnPoistu.Enabled = false;
                foreach (PictureBox pb in kuvapaikat)
                {
                    pb.Enabled = false;
                }
            }
            else if (tmrPelinAika.Enabled == false)
            {
                foreach (PictureBox pb in kuvapaikat)
                {
                    pb.Enabled = true;
                }
                tmrPelinAika.Enabled = true;
                tsbtnPoistu.Enabled = true;
                tsbtnTallenna.Enabled = true;
            }
        }
        public void VuoronVaihto()
        {
            if (peli.pelimuotoSolo == false)
            {
                if (peli.kenenVuoro.nimi == peli.Pelaaja1.nimi)
                {
                    tslblPelaaja.Text = peli.Pelaaja2.nimi;
                    tslblParitYht.Text = PARIT + peli.Pelaaja2.paritYht.ToString();
                    tslblParitStreak.Text = STREAK + peli.Pelaaja2.paritStreak.ToString();
                    peli.kenenVuoro = peli.Pelaaja2;
                }
                else if (peli.kenenVuoro.nimi == peli.Pelaaja2.nimi)
                {
                    tslblPelaaja.Text = peli.Pelaaja1.nimi;
                    tslblParitYht.Text = PARIT + peli.Pelaaja1.paritYht.ToString();
                    tslblParitStreak.Text = STREAK + peli.Pelaaja1.paritStreak.ToString();
                    peli.kenenVuoro = peli.Pelaaja1;
                }
            }
        }

        private void tsbtnPoistu_Click(object sender, EventArgs e)
        {
            poistupainettu = true;
            Form menu = new Form();
            tmrPelinAika.Enabled = false;
            if (tallennettu == false)
            {
                if (DialogResult.Yes == MessageBox.Show("Tallennetaanko peli?", "Peliä ei ole tallennettu", MessageBoxButtons.YesNo))
                {
                    Tallenna();
                    this.Hide();
                    menu = Application.OpenForms["frmMenu"];
                    menu.Show();
                }
                else
                {
                    this.Hide();
                    menu = Application.OpenForms["frmMenu"];
                    menu.Show();
                }
            }
            this.Hide();
            menu = Application.OpenForms["frmMenu"];
            menu.Show();
        }

        private void tmrPelinAika_Tick(object sender, EventArgs e)
        {
            if (sekunnit < 59)
                sekunnit++;
            else
            {
                if (minuutit < 59)
                {
                    minuutit++;
                    sekunnit = 0;
                }
                else
                {
                    tunnit++;
                    minuutit = 0;
                    sekunnit = 0;
                }
            }
            if (sekunnit <= 9)
                sSek = "0" + sekunnit.ToString();
            else
                sSek = sekunnit.ToString();
            if (minuutit <= 9)
                sMin = "0" + minuutit.ToString() + ":";
            else
                sMin = minuutit.ToString() + ":";

            if (tunnit <= 9)
                sTun = "0" + tunnit.ToString() + ":";
            else
                sTun = tunnit.ToString() + ":";
            peli.sek = sekunnit;
            peli.min = minuutit;
            peli.tun = tunnit;
            tslblAika.Text = sTun + sMin + sSek;
            peli.pelinkesto = tslblAika.Text;
        }

        private void tmrEiParia_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox pb in kuvapaikat)
            {
                Kortti k = (Kortti)pb.Tag;
                pb.Enabled = true;
                pb.Image = k.kuvalista[1];
                k.kaannetty = false;
            }
            tmrEiParia.Enabled = false;
        }

        private void tslvblLuovuta_Click(object sender, EventArgs e)
        {
            luovutapainettu = true;
            tmrPelinAika.Enabled = false;
            if (DialogResult.Yes == MessageBox.Show("Luovutetaanko peli?", "Oletko varma?", MessageBoxButtons.YesNo))
            {
                if (peli.pelimuotoSolo == true)
                {
                    peli.Pelaaja1.haviot++;
                    peli.Pelaaja1.paritStreak = 0;
                    peli.Pelaaja1.paritYht = 0;
                    peli.Pelaaja1.voittoprosentti = peli.Pelaaja1.LaskeVoittopros(peli.Pelaaja1.voitot, peli.Pelaaja1.pelienmaara);
                    pelaajat[peli.Pelaaja1.indeksi].pelienmaara = peli.Pelaaja1.pelienmaara;
                    pelaajat[peli.Pelaaja1.indeksi].voitot = peli.Pelaaja1.voitot;
                    pelaajat[peli.Pelaaja1.indeksi].haviot = peli.Pelaaja1.haviot;
                    pelaajat[peli.Pelaaja1.indeksi].voittoprosentti = peli.Pelaaja1.voittoprosentti;
                    SerializeXMLPelaajat(pelaajat);

                    MessageBox.Show("Luovutit.", "Peli päättyi");
                }
                else
                {
                    peli.Pelaaja1.paritStreak = 0;
                    peli.Pelaaja1.paritYht = 0;
                    peli.Pelaaja2.paritStreak = 0;
                    peli.Pelaaja2.paritYht = 0;

                    if (tslblPelaaja.Text == peli.Pelaaja1.nimi)
                    {
                        peli.Pelaaja1.haviot++;
                        peli.Pelaaja1.voittoprosentti = peli.Pelaaja1.LaskeVoittopros(peli.Pelaaja1.voitot, peli.Pelaaja1.pelienmaara);
                        pelaajat[peli.Pelaaja1.indeksi].pelienmaara = peli.Pelaaja1.pelienmaara;
                        pelaajat[peli.Pelaaja1.indeksi].voitot = peli.Pelaaja1.voitot;
                        pelaajat[peli.Pelaaja1.indeksi].haviot = peli.Pelaaja1.haviot;
                        pelaajat[peli.Pelaaja1.indeksi].voittoprosentti = peli.Pelaaja1.voittoprosentti;
                        peli.Pelaaja2.voitot++;
                        peli.Pelaaja2.voittoprosentti = peli.Pelaaja2.LaskeVoittopros(peli.Pelaaja2.voitot, peli.Pelaaja2.pelienmaara);
                        pelaajat[peli.Pelaaja2.indeksi].pelienmaara = peli.Pelaaja2.pelienmaara;
                        pelaajat[peli.Pelaaja2.indeksi].voitot = peli.Pelaaja2.voitot;
                        pelaajat[peli.Pelaaja2.indeksi].haviot = peli.Pelaaja2.haviot;
                        pelaajat[peli.Pelaaja2.indeksi].voittoprosentti = peli.Pelaaja2.voittoprosentti;
                        SerializeXMLPelaajat(pelaajat);
                        voittaja = peli.Pelaaja2;
                        haviaja = peli.Pelaaja1;
                    }
                    else
                    {
                        peli.Pelaaja2.haviot++;
                        peli.Pelaaja2.voittoprosentti = peli.Pelaaja2.LaskeVoittopros(peli.Pelaaja2.voitot, peli.Pelaaja2.pelienmaara);
                        pelaajat[peli.Pelaaja2.indeksi].pelienmaara = peli.Pelaaja2.pelienmaara;
                        pelaajat[peli.Pelaaja2.indeksi].voitot = peli.Pelaaja2.voitot;
                        pelaajat[peli.Pelaaja2.indeksi].haviot = peli.Pelaaja2.haviot;
                        pelaajat[peli.Pelaaja2.indeksi].voittoprosentti = peli.Pelaaja2.voittoprosentti;
                        peli.Pelaaja1.voitot++;
                        peli.Pelaaja1.voittoprosentti = peli.Pelaaja1.LaskeVoittopros(peli.Pelaaja1.voitot, peli.Pelaaja1.pelienmaara);
                        pelaajat[peli.Pelaaja1.indeksi].pelienmaara = peli.Pelaaja1.pelienmaara;
                        pelaajat[peli.Pelaaja1.indeksi].voitot = peli.Pelaaja1.voitot;
                        pelaajat[peli.Pelaaja1.indeksi].haviot = peli.Pelaaja1.haviot;
                        pelaajat[peli.Pelaaja1.indeksi].voittoprosentti = peli.Pelaaja1.voittoprosentti;
                        SerializeXMLPelaajat(pelaajat);
                        voittaja = peli.Pelaaja1;
                        haviaja = peli.Pelaaja2;
                    }
                    MessageBox.Show("Voittaja: " + voittaja.nimi + " \nHäviäjä: " + haviaja.nimi, "Peli päättyi");
                }
                this.Hide();
                Form menu = Application.OpenForms["frmMenu"];
                menu.Show();

                if (File.Exists(tallennusnimi))
                    File.Delete(tallennusnimi);
            }
            else
                luovutapainettu = false;
                tmrPelinAika.Enabled = true;
        }
        public void SerializeXMLPelaajat(List<Pelaaja> input)
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
        public List<Pelaaja> DeserializeXMLPelaajat()
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

        private void tmrPoistaParit_Tick(object sender, EventArgs e)
        {
            PoistaParit();
        }
        public void PaataPeli()
        {
            tmrPelinAika.Enabled = false;
            if (peli.pelimuotoSolo == true)
            {
                peli.Pelaaja1.voitot++;
                peli.Pelaaja1.voittoprosentti = peli.Pelaaja1.LaskeVoittopros(peli.Pelaaja1.voitot, peli.Pelaaja1.pelienmaara);
                pelaajat[peli.Pelaaja1.indeksi].pelienmaara = peli.Pelaaja1.pelienmaara;
                pelaajat[peli.Pelaaja1.indeksi].voitot = peli.Pelaaja1.voitot;
                pelaajat[peli.Pelaaja1.indeksi].haviot = peli.Pelaaja1.haviot;
                pelaajat[peli.Pelaaja1.indeksi].voittoprosentti = peli.Pelaaja1.voittoprosentti;
                SerializeXMLPelaajat(pelaajat);
                MessageBox.Show("Voitit pelin!" + "\nPelin kesto: " + tslblAika.Text, "Peli päättyi");
                this.Hide();
                Form menu = Application.OpenForms["frmMenu"];
                menu.Show();
            }
            else
            {
                if (peli.Pelaaja1.paritYht != peli.Pelaaja2.paritYht)
                {
                    if (peli.Pelaaja1.paritYht > peli.Pelaaja2.paritYht)
                    {
                        voittaja = peli.Pelaaja1;
                        peli.Pelaaja1.voitot++;
                        peli.Pelaaja1.voittoprosentti = peli.Pelaaja1.LaskeVoittopros(peli.Pelaaja1.voitot, peli.Pelaaja1.pelienmaara);
                        pelaajat[peli.Pelaaja1.indeksi].pelienmaara = peli.Pelaaja1.pelienmaara;
                        pelaajat[peli.Pelaaja1.indeksi].voitot = peli.Pelaaja1.voitot;
                        pelaajat[peli.Pelaaja1.indeksi].haviot = peli.Pelaaja1.haviot;
                        pelaajat[peli.Pelaaja1.indeksi].voittoprosentti = peli.Pelaaja1.voittoprosentti;
                        haviaja = peli.Pelaaja2;
                        peli.Pelaaja2.haviot++;
                        peli.Pelaaja2.voittoprosentti = peli.Pelaaja2.LaskeVoittopros(peli.Pelaaja2.voitot, peli.Pelaaja2.pelienmaara);
                        pelaajat[peli.Pelaaja2.indeksi].pelienmaara = peli.Pelaaja2.pelienmaara;
                        pelaajat[peli.Pelaaja2.indeksi].voitot = peli.Pelaaja2.voitot;
                        pelaajat[peli.Pelaaja2.indeksi].haviot = peli.Pelaaja2.haviot;
                        pelaajat[peli.Pelaaja2.indeksi].voittoprosentti = peli.Pelaaja2.voittoprosentti;
                        SerializeXMLPelaajat(pelaajat);
                    }
                    else
                    {
                        voittaja = peli.Pelaaja2;
                        peli.Pelaaja2.voitot++;
                        peli.Pelaaja2.voittoprosentti = peli.Pelaaja2.LaskeVoittopros(peli.Pelaaja2.voitot, peli.Pelaaja2.pelienmaara);
                        pelaajat[peli.Pelaaja2.indeksi].pelienmaara = peli.Pelaaja2.pelienmaara;
                        pelaajat[peli.Pelaaja2.indeksi].voitot = peli.Pelaaja2.voitot;
                        pelaajat[peli.Pelaaja2.indeksi].haviot = peli.Pelaaja2.haviot;
                        pelaajat[peli.Pelaaja2.indeksi].voittoprosentti = peli.Pelaaja2.voittoprosentti;
                        haviaja = peli.Pelaaja1;
                        peli.Pelaaja1.haviot++;
                        peli.Pelaaja1.voittoprosentti = peli.Pelaaja1.LaskeVoittopros(peli.Pelaaja1.voitot, peli.Pelaaja1.pelienmaara);
                        pelaajat[peli.Pelaaja1.indeksi].pelienmaara = peli.Pelaaja1.pelienmaara;
                        pelaajat[peli.Pelaaja1.indeksi].voitot = peli.Pelaaja1.voitot;
                        pelaajat[peli.Pelaaja1.indeksi].haviot = peli.Pelaaja1.haviot;
                        pelaajat[peli.Pelaaja1.indeksi].voittoprosentti = peli.Pelaaja1.voittoprosentti;
                        SerializeXMLPelaajat(pelaajat);
                    }
                    MessageBox.Show("Voittaja: " + voittaja.nimi + " \nHäviäjä: " + haviaja.nimi + "\nPelin kesto: " + tslblAika.Text, "Peli päättyi");
                    this.Hide();
                    Form menu = Application.OpenForms["frmMenu"];
                    menu.Show();
                }
                else
                {
                    peli.Pelaaja1.voitot++;
                    peli.Pelaaja1.voittoprosentti = peli.Pelaaja1.LaskeVoittopros(peli.Pelaaja1.voitot, peli.Pelaaja1.pelienmaara);
                    pelaajat[peli.Pelaaja1.indeksi].pelienmaara = peli.Pelaaja1.pelienmaara;
                    pelaajat[peli.Pelaaja1.indeksi].voitot = peli.Pelaaja1.voitot;
                    pelaajat[peli.Pelaaja1.indeksi].haviot = peli.Pelaaja1.haviot;
                    pelaajat[peli.Pelaaja1.indeksi].voittoprosentti = peli.Pelaaja1.voittoprosentti;
                    peli.Pelaaja2.voitot++;
                    peli.Pelaaja2.voittoprosentti = peli.Pelaaja2.LaskeVoittopros(peli.Pelaaja2.voitot, peli.Pelaaja2.pelienmaara);
                    pelaajat[peli.Pelaaja2.indeksi].pelienmaara = peli.Pelaaja2.pelienmaara;
                    pelaajat[peli.Pelaaja2.indeksi].voitot = peli.Pelaaja2.voitot;
                    pelaajat[peli.Pelaaja2.indeksi].haviot = peli.Pelaaja2.haviot;
                    pelaajat[peli.Pelaaja2.indeksi].voittoprosentti = peli.Pelaaja2.voittoprosentti;
                    SerializeXMLPelaajat(pelaajat);
                    MessageBox.Show("Tasapeli" + "\nPelin kesto: " + tslblAika.Text, "Peli päättyi");
                    this.Hide();
                    Form menu = Application.OpenForms["frmMenu"];
                    menu.Show();
                }
            }
            PoistaVanhaTallennus();
        }

        private void tmrTallennettuFalse_Tick(object sender, EventArgs e)//Varmistaa, että peli on tallennettu ennen poistumista
        {
            tallennettu = false;
            tmrTallennettuFalse.Enabled = false;
        }
        public void SerializeXMLPeli(List<Peli> input)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(input.GetType());
                var sw = new StreamWriter(tallennusnimi + "\\peli.xml");
                serializer.Serialize(sw, input);
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public List<Peli> DeserializeXMLPeli()
        {
            if (File.Exists(tallennusnimi + "\\peli.xml"))
            {
                StreamReader sr = new StreamReader(tallennusnimi + "\\peli.xml");
                XmlSerializer ser = new XmlSerializer(typeof(List<Peli>));
                object obj = ser.Deserialize(sr);
                sr.Close();
                return (List<Peli>)obj;
            }
            else
                return null;
        }
        public void SerializeXMLKortit(List<Kuvaboksi> input)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(input.GetType());
                var sw = new StreamWriter(tallennusnimi + "\\kortit.xml");
                serializer.Serialize(sw, input);
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public List<Kuvaboksi> DeserializeXMLKortit()
        {
            if (File.Exists(tallennusnimi + "\\kortit.xml"))
            {
                StreamReader sr = new StreamReader(tallennusnimi + "\\kortit.xml");
                XmlSerializer ser = new XmlSerializer(typeof(List<Kuvaboksi>));
                object obj = ser.Deserialize(sr);
                sr.Close();
                return (List<Kuvaboksi>)obj;
            }
            else
                return null;
        }
        public void PoistaVanhaTallennus()
        {
            if (Directory.Exists(tallennusnimi))
            {
                if (File.Exists(tallennusnimi + "\\peli.xml"))
                    File.Delete(tallennusnimi + "\\peli.xml");
                if (File.Exists(tallennusnimi + "\\kortit.xml"))
                    File.Delete(tallennusnimi + "\\kortit.xml");
                Directory.Delete(tallennusnimi);
            }
        }

        private void frmMuistipeli_FormClosing(object sender, FormClosingEventArgs e)//Varmistaa tallennuksen, jos poistutaan vahingossa
        {
            Form menu = new Form();
            tmrPelinAika.Enabled = false;
            if (peli.paattynyt == false)
            {
                if (poistupainettu == false && luovutapainettu == false)//Tämä estää ponnahdusikkunan tulemasta kahdesti
                {
                    if (tallennettu == false)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Tallennetaanko peli?", "Peliä ei ole tallennettu", MessageBoxButtons.YesNo))
                        {
                            Tallenna();
                            this.Hide();
                            menu = Application.OpenForms["frmMenu"];
                            menu.Show();
                        }
                        else
                        {
                            this.Hide();
                            menu = Application.OpenForms["frmMenu"];
                            menu.Show();
                        }
                    }
                    this.Hide();
                    menu = Application.OpenForms["frmMenu"];
                    menu.Show();
                }
            }
        }
    }
}
