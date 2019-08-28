using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class DigerGecisRaporListKullaniciAlarm
    {
        public int Kayit_No { get; set; }
        public int? ID { get; set; }
        public string Kart_ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string SirketAdi { get; set; }
        public int? PanelID { get; set; }
        public int? Kapi_ID { get; set; }
        public int? Gecis_Tipi { get; set; }
        public string Operasyon { get; set; }
        public DateTime? Tarih { get; set; }
    }
}
