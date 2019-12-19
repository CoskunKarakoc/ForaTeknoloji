using ForaTeknoloji.Core.DataAccess;
using ForaTeknoloji.Entities.Entities;
using System.Collections.Generic;
using static ForaTeknoloji.DataAccessLayer.Concrete.EntityFramework.EfAlarmlarDal;

namespace ForaTeknoloji.DataAccessLayer.Abstract
{
    public interface IAlarmlarDal : IEntityRepository<Alarmlar>
    {
        List<ComplexAlarm> AlarmAndAlarmTip();
    }
}
