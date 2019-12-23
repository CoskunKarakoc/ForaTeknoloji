using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class AltDepartmanListViewModel
    {
        public AltDepartmanListViewModel()
        {
        }


        public IEnumerable<SelectListItem> Departman_No { get; set; }
        public List<ComplexAltDepartman> AltDepartmanListesi { get; internal set; }
    }
}