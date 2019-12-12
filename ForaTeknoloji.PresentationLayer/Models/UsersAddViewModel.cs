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
        public IEnumerable<SelectListItem> Bolum_No { get; internal set; }
    }
}