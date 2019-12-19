using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class DigerGecisRaporListViewModel
    {
        public List<DigerGecisRaporList> DigerGecisListesi { get; set; }
        public IEnumerable<SelectListItem> Panel { get; set; }
    }
}