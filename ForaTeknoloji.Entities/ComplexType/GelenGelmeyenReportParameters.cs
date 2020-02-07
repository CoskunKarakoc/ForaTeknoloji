using System;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class GelenGelmeyenReportParameters
    {
        public GelenGelmeyenReportParameters()
        {
            Baslangic_Tarihi = DateTime.Now.Date;
            Bitis_Tarihi = DateTime.Now.Date;
            Fark = 45;
        }
        public int? Sirket { get; set; }

        public int? Departman { get; set; }

        public int? Global_Kapi_Bolgesi { get; set; }

        public int? Gecis_Grubu { get; set; }

        public DateTime? Baslangic_Tarihi { get; set; }

        public DateTime? Bitis_Tarihi { get; set; }

        public double? Fark { get; set; }

        public int? User { get; set; }

        public bool? Tum_Tarih { get; set; }

        public int? AltDepartman { get; set; }

        public int? Unvan { get; set; }

        public int? Bolum { get; set; }
    }
}
