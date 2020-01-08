using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class FastGroupListViewModel
    {
        public IEnumerable<SelectListItem> Grup_No { get; set; }
        public IEnumerable<SelectListItem> Unvan_No { get; set; }
        public int? Durum { get; internal set; }
    }
}