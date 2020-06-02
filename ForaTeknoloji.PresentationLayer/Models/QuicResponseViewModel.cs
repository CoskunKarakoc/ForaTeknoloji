using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class QuicResponseViewModel
    {
        public string QRCode { get; set; }
        public IEnumerable<SelectListItem> Grup_No { get; internal set; }
    }
}