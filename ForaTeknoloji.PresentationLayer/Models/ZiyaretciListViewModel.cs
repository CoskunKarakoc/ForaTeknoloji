using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class ZiyaretciListViewModel
    {
        public IEnumerable<SelectListItem> Paneller { get; set; }
        public IEnumerable<SelectListItem> Global_Bolge_Adi { get; set; }
        public List<IcerdeDisardaPersonel> IcerdeDısardaPersonel { get; internal set; }
    }
}