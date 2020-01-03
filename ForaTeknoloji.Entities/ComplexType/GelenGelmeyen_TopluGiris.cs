using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class GelenGelmeyen_TopluGiris
    {
        public int? ID { get; set; }

        public string Kart_ID { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string Unvan_Adi { get; set; }

        public string Grup_Adi { get; set; }

        public string Sirket_Adi { get; set; }

        public string Departman_Adi { get; set; }

        public string Alt_Departman_Adi { get; set; }

        public string Bolum_Adi { get; set; }

        public int? Giris_Sayisi { get; set; }
    }
}
