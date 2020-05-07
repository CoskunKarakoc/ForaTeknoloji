using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class SecurityCreateViewModel
    {
        public IEnumerable<SelectListItem> Roller { get; set; }
        public List<Sirketler> Sirketler { get; set; }
        public List<PanelSettings> Paneller { get; set; }
        public List<Departmanlar> Departmanlar { get; internal set; }
        public List<Bolum> Bolumler { get; internal set; }
    }
}