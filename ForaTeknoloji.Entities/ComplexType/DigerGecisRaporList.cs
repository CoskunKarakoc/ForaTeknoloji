using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class DigerGecisRaporList
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? Kayit_No { get; set; }
        public int? Panel_ID { get; set; }
        public string Kapi { get; set; }
        public int? Gecis_Tipi { get; set; }
        public string Operasyon { get; set; }
        public DateTime? Tarih { get; set; }

    }
}
