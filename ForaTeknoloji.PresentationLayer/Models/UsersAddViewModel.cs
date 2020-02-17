using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class UsersAddViewModel
    {
        public IEnumerable<SelectListItem> Visitor_Grup_No { get; internal set; }
        public IEnumerable<SelectListItem> Grup_No_3 { get; internal set; }
        public IEnumerable<SelectListItem> Grup_No_2 { get; internal set; }
        public IEnumerable<SelectListItem> Kullanici_Tipi { get; internal set; }
        public IEnumerable<SelectListItem> Gecis_Modu { get; internal set; }
        public IEnumerable<SelectListItem> Blok_No { get; internal set; }
        public IEnumerable<SelectListItem> Departman_No { get; internal set; }
        public IEnumerable<SelectListItem> Sirket_No { get; internal set; }
        public IEnumerable<SelectListItem> Grup_Takvimi_No { get; internal set; }
        public int ID { get; internal set; }
        public string Kart_ID { get; internal set; }
        public IEnumerable<SelectListItem> Gorev_No { get; internal set; }
        public IEnumerable<SelectListItem> Alt_Departman_No { get; internal set; }
        public IEnumerable<SelectListItem> Bolum_No { get; internal set; }
        public IEnumerable<SelectListItem> Unvan_No { get; internal set; }


        public string Dogrulama_PIN { get; set; }

        public int? Kimlik_PIN { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public int? Sifre { get; set; }

        public int? Grup_No { get; set; }

        public string Resim { get; set; }

        public string Plaka { get; set; }

        public string TCKimlik { get; set; }

        public int? Daire { get; set; }

        public string Adres { get; set; }

        public int? Gorev { get; set; }

        public string Aciklama { get; set; }

        public bool? Iptal { get; set; }

        public bool? Grup_Takvimi_Aktif { get; set; }

        public DateTime? Saat_1 { get; set; }

        public int? Grup_No_1 { get; set; }

        public DateTime? Saat_2 { get; set; }

        public DateTime? Saat_3 { get; set; }

        public string Tmp { get; set; }

        public bool? Sureli_Kullanici { get; set; }

        public DateTime? Bitis_Tarihi { get; set; }

        public DateTime? Bitis_Saati { get; set; }

        public string Telefon { get; set; }

        public bool? C3_Grup { get; set; }

    }
}