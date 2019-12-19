using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class PersonelListReportParameters
    {
        public int? Sirket { get; set; }

        public int? Departman { get; set; }

        public int? Daire { get; set; }

        public int? Blok { get; set; }

        public int? Gecis_Grubu { get; set; }

        public int? Global_Kapi_Bolgesi { get; set; }

        public string Plaka { get; set; }
    }
}