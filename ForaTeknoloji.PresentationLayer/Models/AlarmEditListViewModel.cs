using ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework;
using ForaTeknoloji.Entities.ComplexType;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;

namespace ForaTeknoloji.PresentationLayer.Models
{
    public class AlarmEditListViewModel
    {
        public Alarmlar Alarm { get; set; }
        public Users SeciliKullanici { get; internal set; }
        public List<PersonelList> Kullanıcılar { get; internal set; }
    }
}