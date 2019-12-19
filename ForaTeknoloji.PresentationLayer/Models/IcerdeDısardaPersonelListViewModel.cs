using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class IcerdeDısardaPersonelListViewModel
    {
        public List<IcerdeDisardaPersonel> IcerdeDısardaPersonel { get; set; }
        public IEnumerable<SelectListItem> Panel { get; set; }
        public IEnumerable<SelectListItem> Global_Kapi_Bolgesi { get; set; }
    }
}