using System.Collections.Generic;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class AccessGroupPanelListViewModel
    {
        public List<PanelSettings> Paneller { get; set; }
        public int Grup_No { get; set; }
    }
}