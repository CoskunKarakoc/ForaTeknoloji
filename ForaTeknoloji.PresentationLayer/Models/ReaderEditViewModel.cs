using System.Collections.Generic;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class ReaderEditViewModel
    {
        public List<PanelSettings> Paneller { get; set; }
        public List<ReaderSettingsNew> Okuyucular { get; set; }
        public int? Panel_ID { get; internal set; }
    }
}