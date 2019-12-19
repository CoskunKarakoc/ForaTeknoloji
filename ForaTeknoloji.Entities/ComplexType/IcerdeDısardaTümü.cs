using System;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class IcerdeDısardaTümü
    {
        public int? Kayit_No { get; set; }
        public int? ID { get; set; }
        public string Kart_ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Ziyaretci_Adi { get; set; }
        public string Ziyaretci_Soyadi { get; set; }
        public string Sirket { get; set; }
        public string Departman { get; set; }
        public DateTime? Tarih { get; set; }
        public DateTime? Ziyaret_Tarihi { get; set; }
        public int? Gecis_Tipi { get; set; }
    }
}
