using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class ProgRelay2EditViewModel
    {
        public ProgRelay2 ProgRelay { get; set; }
        public List<ReaderSettingsNew> DoorNames { get; set; }
        public int? PanelModel { get; internal set; }
    }
}