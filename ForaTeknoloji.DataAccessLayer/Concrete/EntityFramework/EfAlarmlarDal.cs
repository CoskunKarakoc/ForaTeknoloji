using ForaTeknoloji.Core.DataAccess.EntityFramework;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework
{
    public class EfAlarmlarDal : EfEntityRepositoryBase<Alarmlar, ForaContext>, IAlarmlarDal
    {

        public List<ComplexAlarm> AlarmAndAlarmTip()
        {
            using (var context = new ForaContext())
            {
                var entity = from a in context.Alarmlar
                             join at in context.AlarmTipleri
                             on a.Alarm_Tipi equals at.Alarm_Tipi
                             select new ComplexAlarm
                             {
                                 Alarm_No = a.Alarm_No,
                                 Adi = at.Adi,
                                 Alarm_Tipi = at.Alarm_Tipi,
                                 Alarm_Adi = a.Alarm_Adi
                             };

                return entity.ToList();
            }
        }
        public class ComplexAlarm
        {
            public int Alarm_No { get; set; }
            public string Alarm_Adi { get; set; }
            public int Alarm_Tipi { get; set; }
            public string Adi { get; set; }
        }

    }
}
