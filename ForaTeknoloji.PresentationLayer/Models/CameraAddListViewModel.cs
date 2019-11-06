using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class CameraAddListViewModel
    {
        public int Kamera_No { get; set; }
        public IEnumerable<SelectListItem> Kamera_Tipi { get; set; }
        public IEnumerable<SelectListItem> Panel_ID { get; internal set; }
        public List<int> Kapi_ID { get; internal set; }
    }
}