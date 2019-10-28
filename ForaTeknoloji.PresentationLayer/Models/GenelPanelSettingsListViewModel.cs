using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class GenelPanelSettingsListViewModel
    {
        public PanelSettings GenelAyar { get; set; }
        public PanelSettings Panel { get; internal set; }
    }
}