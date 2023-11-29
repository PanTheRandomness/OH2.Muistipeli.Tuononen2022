using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH2.Muistipeli.Tuononen
{
    public class Kortti
    {
        public int arvo { get; set; }
        public List<Image> kuvalista { get; set; }
        public bool kaannetty { get; set; }
        public string maa { get; set; }
        public bool poistettu { get; set; }
        public int tunniste { get; set; }
    }
}
