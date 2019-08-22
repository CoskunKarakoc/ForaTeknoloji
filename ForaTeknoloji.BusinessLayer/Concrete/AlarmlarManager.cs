using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Concrete
{
    public class AlarmlarManager : IAlarmlarService
    {
        private IAlarmlarDal _alarmlarDal;
        public AlarmlarManager(IAlarmlarDal alarmlarDal)
        {
            _alarmlarDal = alarmlarDal;
        }
        public Alarmlar AddAlarm(Alarmlar alarmlar)
        {
            return _alarmlarDal.Add(alarmlar);
        }

        public void DeleteAlarm(Alarmlar alarmlar)
        {
            _alarmlarDal.Delete(alarmlar);
        }

        public List<Alarmlar> GetAllAlarmlar()
        {
            return _alarmlarDal.GetList();
        }

        public Alarmlar GetById(int id)
        {
            return _alarmlarDal.Get(x => x.Alarm_No == id);
        }

        public Alarmlar UpdateAlarm(Alarmlar alarmlar)
        {
            return _alarmlarDal.Update(alarmlar);
        }
    }
}
