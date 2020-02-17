using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GecisGrupListViewModel
    {
        public List<GroupsMaster> Gruplar { get; set; }
        public List<PanelSettings> PanelListesi { get; set; }
        public IDictionary<int, int> GroupUserCount { get; internal set; }
    }
}