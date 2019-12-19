using ForaTeknoloji.Entities.ComplexType;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class DigerGecisRaporAlarmListViewModel
    {
        public List<DigerGecisRaporListKullaniciAlarm> DigerGecisListesiAlarm { get;  set; }
        public IEnumerable<SelectListItem> Panel { get;  set; }
    }
}