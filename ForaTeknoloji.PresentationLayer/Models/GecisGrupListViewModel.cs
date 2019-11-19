using System.Collections.Generic;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GecisGrupListViewModel
    {
        public List<GroupsMaster> Gruplar { get; set; }
        public List<PanelSettings> PanelListesi { get; set; }
    }
}