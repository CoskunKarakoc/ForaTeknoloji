using System.Collections.Generic;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class LiftEditViewModel
    {
        public LiftGroups LiftGroup { get; set; }
        public List<FloorNames> FloorName { get; set; }
    }
}