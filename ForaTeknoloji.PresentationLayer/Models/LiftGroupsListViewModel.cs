using System.Collections.Generic;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class LiftGroupsListViewModel
    {
        public List<LiftGroups> LiftGroup { get; set; }
        public List<PanelSettings> PanelListesi { get; internal set; }
    }
}