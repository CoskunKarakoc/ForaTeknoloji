using System.Collections.Generic;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class OfflineAccessReceiveListViewModel
    {
        public ProgInit ProgEntity { get; set; }
        public List<PanelSettings> PanelListesi { get; set; }
    }
}