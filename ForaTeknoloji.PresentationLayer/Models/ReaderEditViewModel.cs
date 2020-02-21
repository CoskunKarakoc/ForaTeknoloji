using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class ReaderEditViewModel
    {
        public List<PanelSettings> Paneller { get; set; }
        public List<ReaderSettingsNew> Okuyucular { get; set; }
        public int? Panel_ID { get; internal set; }
        public int? PanelModel { get; internal set; }
    }
}