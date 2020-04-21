using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfAlarmlarDal;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class AlarmlarManager : IAlarmlarService
    {
        private IAlarmlarDal _alarmlarDal;
        public AlarmlarManager(IAlarmlarDal alarmlarDal)
        {
            _alarmlarDal = alarmlarDal;
        }

        public Alarmlar AddAlarmlar(Alarmlar alarmlar)
        {
            return _alarmlarDal.Add(alarmlar);
        }

        public List<ComplexAlarm> AlarmAndTip(Expression<Func<ComplexAlarm, bool>> filter = null)
        {
            return filter == null ? _alarmlarDal.AlarmAndAlarmTip() : _alarmlarDal.AlarmAndAlarmTip(filter);
        }

        public void DeleteAlarmlar(Alarmlar alarmlar)
        {
            _alarmlarDal.Delete(alarmlar);
        }

        public List<Alarmlar> GetAllAlarmlar(Expression<Func<Alarmlar, bool>> filter = null)
        {
            return filter == null ? _alarmlarDal.GetList() : _alarmlarDal.GetList(filter);
        }

        public Alarmlar GetByAlarmAdi(string alarmAdi)
        {
            return _alarmlarDal.Get(x => x.Alarm_Adi == alarmAdi);
        }

        public Alarmlar GetById(int AlarmNo)
        {
            return _alarmlarDal.Get(x => x.Alarm_No == AlarmNo);
        }

        public Alarmlar UpdateAlarmlar(Alarmlar alarmlar)
        {
            return _alarmlarDal.Update(alarmlar);
        }
    }
}
