using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class LiftGroupsListViewModel
    {
        public List<LiftGroups> LiftGroup { get; set; }
        public List<PanelSettings> PanelListesi { get; internal set; }
    }
}