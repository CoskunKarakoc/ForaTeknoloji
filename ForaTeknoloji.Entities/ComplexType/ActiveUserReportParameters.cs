using System;
using System.Collections.Generic;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class ActiveUserReportParameters
    {
        public ActiveUserReportParameters()
        {
            Kapilar = new List<int>();
            Baslangic_Tarihi = DateTime.Now.Date;
        }


        public int? Departman { get; set; }

        public int? Sirket { get; set; }

        public int? Global_Kapi_Bolgesi { get; set; }

        public int? Blok { get; set; }

        public int? Panel { get; set; }

        public DateTime? Baslangic_Tarihi { get; set; }

        public DateTime? Bitis_Tarihi { get; set; }

        public DateTime? Baslangic_Saati { get; set; }

        public DateTime? Bitis_Saati { get; set; }

        public List<int> Kapilar { get; set; }

        public int? Daire { get; set; }

        public int? Gecis_Grubu { get; set; }

        public int? User { get; set; }

        public string Plaka { get; set; }

        public int? Kapi_Yon { get; set; }

        public int? Gecis_Tipi { get; set; }

        public bool? Gunluk_Saat_Dilimi { get; set; }

        public bool? Tum_Tarih { get; set; }

        public bool? Tum_Kullanici { get; set; }

        public int? AltDepartman { get; set; }

        public int? Unvan { get; set; }

        public int? Bolum { get; set; }

        public int? Birim_No { get; set; }

        public int? User_Kayit_No { get; set; }
    }
}
