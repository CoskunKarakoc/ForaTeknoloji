using System.Collections.Generic;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class VisitorListViewModel
    {
        public List<Visitors> Visitor { get; set; }
        public int StatusControl { get; set; }
        public List<PanelSettings> PanelListesi { get; internal set; }
    }
}