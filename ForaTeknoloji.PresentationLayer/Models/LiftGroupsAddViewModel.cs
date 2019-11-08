using System.Collections.Generic;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class LiftGroupsAddViewModel
    {
        public int Asansor_Grup_No { get; set; }
        public List<FloorNames> FloorName { get; set; }
    }
}