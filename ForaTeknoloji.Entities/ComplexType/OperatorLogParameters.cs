using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class OperatorLogParameters
    {

        public OperatorLogParameters()
        {
            Baslangic_Tarihi = DateTime.Now.Date;
        }


        public string Kullanici_Adi { get; set; }

        public int? Code_Operation { get; set; }

        public DateTime? Baslangic_Tarihi { get; set; }

        public DateTime? Bitis_Tarihi { get; set; }

        public DateTime? Baslangic_Saati { get; set; }

        public DateTime? Bitis_Saati { get; set; }

        public bool? Tum_Tarih { get; set; }


    }
}
