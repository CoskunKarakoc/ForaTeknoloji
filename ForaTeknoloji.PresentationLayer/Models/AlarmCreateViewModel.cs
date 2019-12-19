using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class AlarmCreateViewModel
    {
        public IEnumerable<SelectListItem> Paneller { get; set; }
        public IEnumerable<SelectListItem> AlarmTipleri { get; set; }
        public List<int> Kapilar { get; set; }
        public List<int> AlarmRolesi { get; set; }
        public int Alarm_No { get; internal set; }
        public List<EfUserDal.ComplexUser> Kullanıcılar { get; internal set; }
    }
}