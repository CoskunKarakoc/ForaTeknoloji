using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class ComplexBirim
    {
        public int Birim_No { get; set; }

        public string Adi { get; set; }

        public int Departman_No { get; set; }

        public string Departman_Adi { get; set; }

        public int Alt_Departman_No { get; set; }

        public string Alt_Departman_Adi { get; set; }

        public int Bolum_No { get; set; }

        public string Bolum_Adi { get; set; }


    }
}
