using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class GelenGelmeyen_IlkGirisSonCikis
    {
        public int ID { get; set; }
        public string Kart_ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string SirketAdi { get; set; }
        public string DepartmanAdi { get; set; }
        public string Grup_Adi { get; set; }
        public DateTime? Tarih_Degeri { get; set; }
        public DateTime? Ilk_Kayit { get; set; }
        public DateTime? Son_Kayit { get; set; }
        public DateTime? Fark { get; set; }

    }
}
