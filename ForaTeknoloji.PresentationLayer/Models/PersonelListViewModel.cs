using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;

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
    }
}