using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class GroupReadersParameters
    {
        public GroupReadersParameters()
        {
            Kapi_Zaman_Grup_No = new List<int>();

            Kapi_Asansor_Bolge_No = new List<int>();
        }


        public bool? Kapi_1 { get; set; }

        public bool? Kapi_2 { get; set; }

        public bool? Kapi_3 { get; set; }

        public bool? Kapi_4 { get; set; }

        public bool? Kapi_5 { get; set; }

        public bool? Kapi_6 { get; set; }

        public bool? Kapi_7 { get; set; }

        public bool? Kapi_8 { get; set; }

        public bool? Kapi_9 { get; set; }

        public bool? Kapi_10 { get; set; }

        public bool? Kapi_11 { get; set; }

        public bool? Kapi_12 { get; set; }

        public bool? Kapi_13 { get; set; }

        public bool? Kapi_14 { get; set; }

        public bool? Kapi_15 { get; set; }

        public bool? Kapi_16 { get; set; }

        public IList<int> Kapi_Zaman_Grup_No { get; set; }

        public IList<int> Kapi_Asansor_Bolge_No { get; set; }

        public int Grup_No { get; set; }

        public string Grup_Adi { get; set; }

        public int Panel_ID { get; set; }
    }
}
