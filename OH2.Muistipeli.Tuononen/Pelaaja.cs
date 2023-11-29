using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace OH2.Muistipeli.Tuononen
{
    public class Pelaaja
    {
        public string nimi { get; set; } 
        public double pelienmaara { get; set; }
        public double voitot { get; set; }
        public double haviot { get; set; }
        public string voittoprosentti { get; set; }
        public int indeksi { get; set; }

        public string LaskeVoittopros(double voitot, double pelienmaara)//lasketaan voittoprosentti
        {
            double voittopros = ((voitot/pelienmaara) * 100);
            voittoprosentti = voittopros.ToString("F") + " %";
            return voittoprosentti;
        }
        public int paritYht { get; set; }
        public int paritStreak { get; set; }
    }
}
