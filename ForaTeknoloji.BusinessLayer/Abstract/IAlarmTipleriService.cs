using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAlarmTipleriService
    {
        List<AlarmTipleri> GetAllAlarmlar(Expression<Func<AlarmTipleri, bool>> filter = null);
        AlarmTipleri GetByAlarmTipi(int AlarmTipi);
        AlarmTipleri AddAlarmTipleri(AlarmTipleri alarmTipleri);
        void DeleteAlarmTipleri(AlarmTipleri alarmTipleri);
        AlarmTipleri UpdateAlarmTipleri(AlarmTipleri alarmTipleri);
        AlarmTipleri GetByAlarmAdi(string alarmAdi);
    }
}
