using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class VisitorReportParameters
    {
        public VisitorReportParameters()
        {
            Kapi = new List<int>();
            Baslangic_Tarihi = DateTime.Now.Date;
        }

        public List<int> Kapi { get; set; }

        public int? Visitor { get; set; }

        public int? Global_Kapi_Bolgesi { get; set; }

        public int? Gecis_Grubu { get; set; }

        public int? Gecis_Tipi { get; set; }

        public int? Kapi_Yon { get; set; }

        public int? Panel { get; set; }

        public DateTime? Baslangic_Tarihi { get; set; }

        public DateTime? Bitis_Tarihi { get; set; }

        public DateTime? Baslangic_Saati { get; set; }

        public DateTime? Bitis_Saati { get; set; }

        public bool? Tum_Tarih { get; set; }

        public string Search { get; set; }

        public bool? All_Visitor { get; set; }

    }
}
