using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GelenGelmeyen_PasifListViewModel
    {
        public List<GelenGelmeyen_PasifKullanici> Pasif { get; set; }
        public IEnumerable<SelectListItem> Departman { get; set; }
        public IEnumerable<SelectListItem> Sirket { get; set; }
        public IEnumerable<SelectListItem> Gecis_Grubu { get; set; }
        public IEnumerable<SelectListItem> Global_Kapi_Bolgesi { get; set; }
    }
}