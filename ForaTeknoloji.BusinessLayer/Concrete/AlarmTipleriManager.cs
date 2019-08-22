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
    public class AlarmTipleriManager : IAlarmTipleriService
    {
        private IAlarmTipleriDal _alarmTipleriDal;
        public AlarmTipleriManager(IAlarmTipleriDal alarmTipleriDal)
        {
            _alarmTipleriDal = alarmTipleriDal;
        }
        public AlarmTipleri AddAlarmTipleri(AlarmTipleri alarmTipleri)
        {
            return _alarmTipleriDal.Add(alarmTipleri);
        }

        public void DeleteAlarmTipleri(AlarmTipleri alarmTipleri)
        {
            _alarmTipleriDal.Delete(alarmTipleri);
        }

        public List<AlarmTipleri> GetAllAlarmTipleri()
        {
            return _alarmTipleriDal.GetList();
        }

        public AlarmTipleri GetById(int id)
        {
            return _alarmTipleriDal.Get(x => x.Alarm_Tipi == id);
        }

        public AlarmTipleri UpdateAlarmTipleri(AlarmTipleri alarmTipleri)
        {
            return _alarmTipleriDal.Update(alarmTipleri);
        }
    }
}
