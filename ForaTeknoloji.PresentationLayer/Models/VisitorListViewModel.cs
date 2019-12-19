using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class VisitorListViewModel
    {
        public List<Visitors> Visitor { get; set; }
        public List<PanelSettings> PanelListesi { get; internal set; }
    }
}