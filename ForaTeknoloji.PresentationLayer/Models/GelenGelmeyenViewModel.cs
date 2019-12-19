using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GelenGelmeyenViewModel
    {
        public List<GelenGelmeyenRaporList> GelenGelmeyen { get; set; }
        public IEnumerable<SelectListItem> Departmanlar { get; set; }
        public IEnumerable<SelectListItem> Sirketler { get; set; }
        public IEnumerable<SelectListItem> Groupsdetail { get; set; }
        public IEnumerable<SelectListItem> Global_Bolge_Adi { get; set; }
        public IEnumerable<SelectListItem> Visitors { get; internal set; }
    }
}