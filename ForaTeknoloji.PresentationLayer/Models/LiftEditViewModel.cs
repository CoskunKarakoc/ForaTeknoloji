using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class LiftEditViewModel
    {
        public LiftGroups LiftGroup { get; set; }
        public List<FloorNames> FloorName { get; set; }
    }
}