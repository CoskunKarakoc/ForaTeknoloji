using System;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class ReportPersonelList
    {
        public int Kayit_No { get; set; }

        public int? ID { get; set; }

        public string Kart_ID { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string TCKimlik { get; set; }

        public string UnvanAdi { get; set; }

        public string Telefon { get; set; }

        public string SirketAdi { get; set; }

        public string DepartmanAdi { get; set; }

        public string AltDepartmanAdi { get; set; }

        public string BolumAdi { get; set; }

        public string Plaka { get; set; }

        public string BlokAdi { get; set; }

        public int? Daire { get; set; }

        public string Grup_Adi { get; set; }

        public int? Panel_ID { get; set; }

        public string Kapi { get; set; }

        public int? Gecis_Tipi { get; set; }

        public DateTime? Tarih { get; set; }

        public string Resim { get; set; }

        public string Canli_Resim { get; set; }

        public int? User_Kayit_No { get; set; }
    }
}
