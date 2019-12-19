using System;
using System.Collections.Generic;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class OutherReportParameters
    {
        public OutherReportParameters()
        {
            Kapi = new List<int>();

            Baslangic_Tarihi = DateTime.Now.Date;

            Kod = 100;

        }


        public List<int> Kapi { get; set; }

        public int? Panel { get; set; }

        public DateTime? Baslangic_Tarihi { get; set; }

        public DateTime? Bitis_Tarihi { get; set; }

        public DateTime? Baslangic_Saati { get; set; }

        public DateTime? Bitis_Saati { get; set; }

        public int? Kapi_Yon { get; set; }

        public int? Kod { get; set; }

        public bool? Tum_Kapi { get; set; }
    }
}
