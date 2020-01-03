using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class OperatorLogComplex
    {

        public int? Kayit_No { get; set; }

        public int? Panel_ID { get; set; }

        public string Kapi_Adi { get; set; }

        public int? Gecis_Tipi { get; set; }

        public string Operasyon { get; set; }

        public DateTime? Tarih { get; set; }

        public string Kullanici_Adi { get; set; }

        public int? Islem_Verisi_1 { get; set; }

        public int? Islem_Verisi_2 { get; set; }


    }
}
