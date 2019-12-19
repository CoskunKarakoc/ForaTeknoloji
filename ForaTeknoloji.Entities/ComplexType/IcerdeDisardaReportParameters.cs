using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class IcerdeDisardaReportParameters
    {
        public IcerdeDisardaReportParameters()
        {
            Bolge = "Lokal";

            Gecis = 0;
        }


        public int? Global_Kapi_Bolgesi { get; set; }

        public int? Panel { get; set; }

        public string Kapi { get; set; }

        public string Bolge { get; set; }

        public int? Gecis { get; set; }
    }
}
