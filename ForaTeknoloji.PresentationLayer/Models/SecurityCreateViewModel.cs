using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class SecurityCreateViewModel
    {
        public IEnumerable<SelectListItem> Roller { get; set; }
        public List<Sirketler> Sirketler { get; set; }
        public List<PanelSettings> Paneller { get; set; }
    }
}