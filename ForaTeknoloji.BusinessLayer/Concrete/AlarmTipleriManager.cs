using ForaTeknoloji.BusinessLayer.Abstract;
using ForaTeknoloji.DataAccessLayer.Abstract;
using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<AlarmTipleri> GetAllAlarmlar(Expression<Func<AlarmTipleri, bool>> filter = null)
        {
            return filter == null ? _alarmTipleriDal.GetList() : _alarmTipleriDal.GetList(filter);
        }

        public AlarmTipleri GetByAlarmAdi(string alarmAdi)
        {
            return _alarmTipleriDal.Get(x => x.Adi == alarmAdi);
        }

        public AlarmTipleri GetByAlarmTipi(int AlarmTipi)
        {
            return _alarmTipleriDal.Get(x => x.Alarm_Tipi == AlarmTipi);
        }

        public AlarmTipleri UpdateAlarmTipleri(AlarmTipleri alarmTipleri)
        {
            return _alarmTipleriDal.Update(alarmTipleri);
        }
    }
}
