using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class ProgRelayListViewModel
    {
        public IEnumerable<SelectListItem> Panel_No { get; internal set; }
        public IEnumerable<SelectListItem> Haftanin_Gunu { get; internal set; }
        public List<ProgRelay2> Liste { get; internal set; }
        public List<ReaderSettingsNew> Kapilar { get; internal set; }
    }
}