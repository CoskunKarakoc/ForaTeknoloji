using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class TanimsizReportParameters
    {
        public TanimsizReportParameters()
        {
            Kapi = new List<string>();
            Baslangic_Tarihi = DateTime.Now.Date;
        }

        public List<string> Kapi { get; set; }

        public int? Panel { get; set; }

        public DateTime? Baslangic_Tarihi { get; set; }

        public DateTime? Bitis_Tarihi { get; set; }

        public DateTime? Baslangic_Saati { get; set; }

        public DateTime? Bitis_Saati { get; set; }

        public int? Kapi_Yon { get; set; }

        public bool? Tum_Tarih { get; set; }
    }
}
