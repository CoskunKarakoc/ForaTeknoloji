using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class HolidayListViewModel
    {
        public IEnumerable<SelectListItem> Ozel_Gun_No { get; internal set; }
        public List<TatilGunu> HolidayList { get; internal set; }
        public IEnumerable<SelectListItem> Panel_No { get; internal set; }
    }
}