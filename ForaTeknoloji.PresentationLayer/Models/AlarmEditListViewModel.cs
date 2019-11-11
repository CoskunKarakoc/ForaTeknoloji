using System.Collections.Generic;
using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.Entities;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class AlarmEditListViewModel
    {
        public Alarmlar Alarm { get; set; }
        public Users SeciliKullanici { get; internal set; }
        public List<EfUserDal.ComplexUser> Kullanıcılar { get; internal set; }
    }
}