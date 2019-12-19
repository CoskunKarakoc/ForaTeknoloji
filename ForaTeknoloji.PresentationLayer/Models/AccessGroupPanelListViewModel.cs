using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class AccessGroupPanelListViewModel
    {
        public List<PanelSettings> Paneller { get; set; }
        public int Grup_No { get; set; }
    }
}