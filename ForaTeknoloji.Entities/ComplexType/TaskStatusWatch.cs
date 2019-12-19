using System;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class TaskStatusWatch
    {
        public int Gorev_Kodu { get; set; }

        public string Gorev_Adi { get; set; }

        public string Panel_Adi { get; set; }

        public int Panel_ID { get; set; }

        public string Durum_Adi { get; set; }

        public int Durum_Kodu { get; set; }

        public DateTime? Tarih { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string Kullanici_Adi { get; set; }
    }
}
