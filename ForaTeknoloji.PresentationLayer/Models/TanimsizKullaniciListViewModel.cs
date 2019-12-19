using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class TanimsizKullaniciListViewModel
    {
        public List<AccessDatasComplex> Liste { get; set; }
        public IEnumerable<SelectListItem> Panel { get; internal set; }
    }
}