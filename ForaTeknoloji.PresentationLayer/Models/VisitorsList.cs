using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class VisitorsList
    {
        public List<ZiyaretciRaporList> ComplexVisitorsListesi { get; set; }
        public IEnumerable<SelectListItem> Panel { get; set; }
        public List<Visitors> Visitors { get; set; }
        public IEnumerable<SelectListItem> Gecis_Grubu { get; set; }
        public IEnumerable<SelectListItem> Global_Kapi_Bolgesi { get; set; }
    }
}