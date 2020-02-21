using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class CreateReaderModel
    {
        public List<SelectList> Kapi_Asansor_Bolge_No { get; internal set; }
        public List<SelectList> Kapi_Zaman_Grup_No { get; internal set; }
        public List<ComplexGroupsDetailNew> Groups { get; internal set; }
        public int? Panel_ID { get; internal set; }
        public List<PanelSettings> PanelList { get; internal set; }
        public int? PanelModel { get; internal set; }
    }
}