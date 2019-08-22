using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.BusinessLayer.Abstract
{
    public interface IAlarmlarService
    {
        List<Alarmlar> GetAllAlarmlar();
        Alarmlar GetById(int id);
        Alarmlar AddAlarm(Alarmlar alarmlar);
        void DeleteAlarm(Alarmlar alarmlar);
        Alarmlar UpdateAlarm(Alarmlar alarmlar);
    }
}
