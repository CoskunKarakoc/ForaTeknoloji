using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class MonitorWatchViewModel
    {
        public IEnumerable<SelectListItem> Panel_ID { get; set; }
        public List<WatchEntityComplex> MonitorListesi { get; set; }
        public IEnumerable<SelectListItem> Kapi_ID { get; internal set; }
    }
}