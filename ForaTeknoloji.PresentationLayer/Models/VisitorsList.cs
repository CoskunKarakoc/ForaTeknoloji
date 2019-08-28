using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class VisitorsList
    {
        public List<ZiyaretciRaporList> ComplexVisitorsListesi { get; set; }
        public IEnumerable<SelectListItem> Paneller { get; set; }
        public List<Visitors> Visitors { get; set; }
        public IEnumerable<SelectListItem> Groupsdetail { get; set; }
        public IEnumerable<SelectListItem> Global_Bolge_Adi { get; set; }
    }
}