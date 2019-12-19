using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class LiftGroupsAddViewModel
    {
        public int Asansor_Grup_No { get; set; }
        public List<FloorNames> FloorName { get; set; }
    }
}