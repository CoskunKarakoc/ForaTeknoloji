using System;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class ComplexTaskList
    {
        public int Kayit_No { get; set; }

        public int Gorev_Kodu { get; set; }

        public string Gorev_Adi { get; set; }

        public int? Panel_No { get; set; }

        public int Durum_Kodu { get; set; }

        public string Durum_Adi { get; set; }

        public string Panel_Adi { get; set; }

        public DateTime Tarih { get; set; }

        public string Kullanici_Adi { get; set; }

    }
}
