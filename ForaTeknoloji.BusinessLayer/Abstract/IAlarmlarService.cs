using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfAlarmlarDal;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAlarmlarService
    {
        List<Alarmlar> GetAllAlarmlar(Expression<Func<Alarmlar, bool>> filter = null);
        Alarmlar GetById(int AlarmNo);
        Alarmlar AddAlarmlar(Alarmlar alarmlar);
        void DeleteAlarmlar(Alarmlar alarmlar);
        Alarmlar UpdateAlarmlar(Alarmlar alarmlar);
        Alarmlar GetByAlarmAdi(string alarmAdi);
        List<ComplexAlarm> AlarmAndTip();
    }
}
