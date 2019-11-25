using System.Collections.Generic;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class ProgRelay2EditViewModel
    {
        public ProgRelay2 ProgRelay { get; set; }
        public List<ReaderSettingsNew> DoorNames { get; set; }
    }
}