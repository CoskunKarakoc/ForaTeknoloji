using System.Collections.Generic;
using System.Web.Mvc;
using ForaTeknoloji.Entities.Entities;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfAlarmlarDal;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class AlarmListViewModel
    {
        public List<ComplexAlarm> Alarmlar { get; set; }
        public List<Users> Users { get; set; }
        public IEnumerable<SelectListItem> AlarmTipleri { get; internal set; }
        public IEnumerable<SelectListItem> Panels { get; internal set; }
        public int MaxID { get; internal set; }
        public List<PanelSettings> PanelListesi { get; internal set; }
        
    }
}