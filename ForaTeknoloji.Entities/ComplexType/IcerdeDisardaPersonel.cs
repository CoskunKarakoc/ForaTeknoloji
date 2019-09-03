using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class IcerdeDisardaPersonel
    {

        public int? Kayit_No { get; set; }
        public int? ID { get; set; }
        public string Kart_ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Sirket { get; set; }
        public string Departman { get; set; }
        public DateTime? Tarih { get; set; }
        public int? Gecis_Tipi { get; set; }
    }
}
