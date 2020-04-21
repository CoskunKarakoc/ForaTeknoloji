using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class PersonelListViewModel
    {
        public List<PersonelList> PersonelListesi { get; set; }
        public string ListCount { get; internal set; }
        public IEnumerable<SelectListItem> Gecis_Grubu { get; internal set; }
        public IEnumerable<SelectListItem> Global_Kapi_Bolgesi { get; internal set; }
        public IEnumerable<SelectListItem> Sirket { get; internal set; }
        public IEnumerable<SelectListItem> Blok { get; internal set; }
        public IEnumerable<SelectListItem> Departman { get; internal set; }
        public IEnumerable<SelectListItem> Alt_Departman_No { get; internal set; }
        public IEnumerable<SelectListItem> Unvan_No { get; internal set; }
        public IEnumerable<SelectListItem> Bolum_No { get; internal set; }
        public IEnumerable<SelectListItem> Birim_No { get; internal set; }
    }
}