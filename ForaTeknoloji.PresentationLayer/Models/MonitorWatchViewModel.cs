using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class MonitorWatchViewModel
    {
        public List<WatchEntityComplex> MonitorListesi { get; set; }
    }
}