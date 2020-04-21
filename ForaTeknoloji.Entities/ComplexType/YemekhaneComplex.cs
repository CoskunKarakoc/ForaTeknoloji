using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class YemekhaneComplex
    {
        public int? Gecis_Sayisi { get; set; }

        public int? ID { get; set; }

        public string Kart_ID { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string TC_Kimlik { get; set; }

        public int? Panel_ID { get; set; }

        public string Panel_Name { get; set; }

        public int? Kapi_ID { get; set; }

        public string Grup_Adi { get; set; }

        public string Departman_Adi { get; set; }

        public string SirketAdi { get; set; }

        public string AltDepartmanAdi { get; set; }

        public string BolumAdi { get; set; }

        public string BirimAdi { get; set; }

    }
}
