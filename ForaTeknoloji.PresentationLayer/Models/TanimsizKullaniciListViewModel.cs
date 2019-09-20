using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class TanimsizKullaniciListViewModel
    {
        public List<AccessDatasComplex> Liste { get; set; }
        public IEnumerable<SelectListItem> Panel { get; internal set; }
    }
}