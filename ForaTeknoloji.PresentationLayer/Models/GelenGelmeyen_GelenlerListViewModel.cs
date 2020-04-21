using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GelenGelmeyen_GelenlerListViewModel
    {
        public IEnumerable<SelectListItem> Departman { get; set; }
        public IEnumerable<SelectListItem> Sirket { get; set; }
        public IEnumerable<SelectListItem> Gecis_Grubu { get; set; }
        public IEnumerable<SelectListItem> Global_Kapi_Bolgesi { get; set; }
        public List<GelenGelmeyen_Gelenler> Gelenler { get; internal set; }
        public IEnumerable<SelectListItem> AltDepartman { get; internal set; }
        public IEnumerable<SelectListItem> Unvan { get; internal set; }
        public IEnumerable<SelectListItem> Bolum { get; internal set; }
        public IEnumerable<SelectListItem> Birim_No { get; internal set; }
    }
}