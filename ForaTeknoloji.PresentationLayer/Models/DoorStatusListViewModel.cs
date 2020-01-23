using System.Collections.Generic;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class DoorStatusListViewModel
    {
        public List<ComplexDoorStatus> DoorStatusList { get; set; }
        public List<ReaderSettingsNew> ReaderList { get; set; }
    }
}