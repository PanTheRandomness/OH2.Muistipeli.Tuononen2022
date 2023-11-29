using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OH2.Muistipeli.Tuononen
{
    public class Kuvaboksi
    {
        public string Name { get; set; }
        public Size Size { get; set; }
        public int TabIndex { get; set; }
        public int tunniste { get; set; }
        public bool Enabled { get; set; }
        public int KorttiArvo { get; set; }
        public string KorttiMaa { get; set; }
        public bool KorttiKaannetty { get; set; }
        public bool KorttiPoistettu { get; set; }
        public Point Location { get; set; }
    }
}
