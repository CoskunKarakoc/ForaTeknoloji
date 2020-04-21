using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class BirimListViewModel
    {
        public IEnumerable<SelectListItem> Alt_Departman_No { get; set; }
        public IEnumerable<SelectListItem> Departman_No { get; set; }
        public IEnumerable<SelectListItem> Bolum_No { get; set; }
        public List<ComplexBirim> BirimListesi { get; set; }
    }
}