using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GelenGelmeyen_GelmeyenlerListViewModel
    {
        public IEnumerable<SelectListItem> Departmanlar { get; set; }
        public IEnumerable<SelectListItem> Sirketler { get; set; }
        public IEnumerable<SelectListItem> Groupsdetail { get; set; }
        public IEnumerable<SelectListItem> Global_Bolge_Adi { get; set; }
        public List<GelenGelmeyen_Gelmeyen> Gelmeyenler { get; internal set; }
    }
}