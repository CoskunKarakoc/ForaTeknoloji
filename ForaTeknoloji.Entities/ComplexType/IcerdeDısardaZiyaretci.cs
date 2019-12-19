using System;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class IcerdeDısardaZiyaretci
    {
        public int? Kayit_No { get; set; }
        public string Kart_ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Ziyaret_Sebebi { get; set; }
        public DateTime? Tarih { get; set; }
        public int? Gecis_Tipi { get; set; }
    }
}
