using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class ZiyaretciRaporList
    {
        public int? ID { get; set; }
        public int? Kod { get; set; }
        public int Kayit_No { get; set; }
        public string Kart_ID { get; set; }
        public string Ziyaretci_Adi { get; set; }
        public string Ziyaretci_Soyadi { get; set; }
        public string Ziyaretci_TCKimlik { get; set; }
        public string Ziyaretci_Telefon { get; set; }
        public string Ziyaretci_Plaka { get; set; }
        public string Ziyaret_Sebebi { get; set; }
        public string Grup_Adi { get; set; }
        public int? Panel_ID { get; set; }
        public string Kapi { get; set; }
        public int? Gecis_Tipi { get; set; }
        public DateTime? Tarih { get; set; }
        public string Personel_Adi { get; set; }
        public string Personel_Soyadi { get; set; }
        public string Ziyaretci_Resim { get; set; }
    }
}
