using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class DigerGecisRaporAlarmListViewModel
    {
        public List<DigerGecisRaporListKullaniciAlarm> DigerGecisListesiAlarm { get;  set; }
        public IEnumerable<SelectListItem> Paneller { get;  set; }
    }
}