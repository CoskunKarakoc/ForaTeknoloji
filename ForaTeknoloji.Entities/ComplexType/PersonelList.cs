using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Entities.ComplexType
{
    public class PersonelList
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public string Kart_ID { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string TCKimlik { get; set; }

        public string SirketAdi { get; set; }

        public string DepartmanAdi { get; set; }

        public string Plaka { get; set; }

        public string BlokAdi { get; set; }

        public int? Daire { get; set; }

        public int? Grup_No { get; set; }

        public string Grup_Adi { get; set; }

        public string Tmp { get; set; }
        public bool Kapi1 { get; set; }
        public bool Kapi2 { get; set; }
        public bool Kapi3 { get; set; }
        public bool Kapi4 { get; set; }
        public bool Kapi5 { get; set; }
        public bool Kapi6 { get; set; }
        public bool Kapi7 { get; set; }
        public bool Kapi8 { get; set; }
        public bool Kapi9 { get; set; }
        public bool Kapi10 { get; set; }
        public bool Kapi11 { get; set; }
        public bool Kapi12 { get; set; }
        public bool Kapi13 { get; set; }
        public bool Kapi14 { get; set; }
        public bool Kapi15 { get; set; }
        public bool Kapi16{ get; set; }
        public int? Kapi1_Global_Bolge_No { get; set; }
        public int? Kapi2_Global_Bolge_No { get; set; }
        public int? Kapi3_Global_Bolge_No { get; set; }
        public int? Kapi4_Global_Bolge_No { get; set; }
        public int? Kapi5_Global_Bolge_No { get; set; }
        public int? Kapi6_Global_Bolge_No { get; set; }
        public int? Kapi7_Global_Bolge_No { get; set; }
        public int? Kapi8_Global_Bolge_No { get; set; }
        public int? Kapi9_Global_Bolge_No { get; set; }
        public int? Kapi10_Global_Bolge_No { get; set; }
        public int? Kapi11_Global_Bolge_No { get; set; }
        public int? Kapi12_Global_Bolge_No { get; set; }
        public int? Kapi13_Global_Bolge_No { get; set; }
        public int? Kapi14_Global_Bolge_No { get; set; }
        public int? Kapi15_Global_Bolge_No { get; set; }
        public int? Kapi16_Global_Bolge_No { get; set; }

    }
}
