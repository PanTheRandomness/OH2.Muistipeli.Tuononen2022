using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OH2.Muistipeli.Tuononen
{
    public class Peli
    {
        public Pelaaja Pelaaja1 { get; set; }
        public Pelaaja Pelaaja2 { get; set; }
        public bool pelimuotoSolo { get; set; }
        public Pelaaja kenenVuoro { get; set; }
        public string pelinkesto { get; set; }
        public int korttienmaara { get; set; }
        public int sek { get; set; }
        public int min { get; set; }
        public int tun { get; set; }
        public Size ikkunanKoko { get; set; }
        public float riviPros { get; set; }
        public float sarakePros { get; set; }
        public bool paattynyt { get; set; }
    }
}
