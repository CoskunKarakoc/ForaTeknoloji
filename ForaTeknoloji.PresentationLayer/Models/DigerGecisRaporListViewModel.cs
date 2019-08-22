using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class DigerGecisRaporListViewModel
    {
        public List<DigerGecisRaporList> DigerGecisListesi { get; set; }
        public IEnumerable<SelectListItem> Paneller { get; set; }
    }
}