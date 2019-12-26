using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class DoorGroupReaderCreateViewModel
    {
        public IEnumerable<SelectListItem> Panel_ID { get; set; }
        public int? Grup_No { get; internal set; }
        public string Kapi_Grup_Adi { get; internal set; }
    }
}